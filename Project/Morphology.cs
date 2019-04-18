using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	public class Morphology : SpatialFilter1 //getmatrixaroundpixel
	{
		Segmentaion segmentaion = new Segmentaion();

		public delegate bool CheckFitHitHandler(int[,] matrix, int objectColor);
		private bool IsFit(int[,] matrix, int objectColor)
		{
			int backgroundColor = 255 - objectColor;
			// Khác màu vật => trả về màu nền
			if (matrix[0, 0] != objectColor) return false;
			if (matrix[0, 1] != objectColor) return false;
			if (matrix[0, 2] != objectColor) return false;
			if (matrix[1, 0] != objectColor) return false;
			if (matrix[1, 1] != objectColor) return false;
			if (matrix[1, 2] != objectColor) return false;
			if (matrix[2, 0] != objectColor) return false;
			if (matrix[2, 1] != objectColor) return false;
			if (matrix[2, 2] != objectColor) return false;

			return true;
		}
		private bool IsHit(int[,] matrix, int objectColor)
		{
			int backgroundColor = 255 - objectColor;
			if (matrix[0, 0] != objectColor &&
				matrix[0, 1] != objectColor &&
				matrix[0, 2] != objectColor &&
				matrix[1, 0] != objectColor &&
				matrix[1, 1] != objectColor &&
				matrix[1, 2] != objectColor &&
				matrix[2, 0] != objectColor &&
				matrix[2, 1] != objectColor &&
				matrix[2, 2] != objectColor)
				return false;
			return true;
		}

		unsafe
		protected Bitmap MorphologyReplicate(Bitmap srcImage, int level, CheckFitHitHandler checkFitHit, int objectColor)
		{
			int temp = level / 2;
			// Tô viền
			Bitmap desImage = (Bitmap)srcImage.Clone();
			desImage = ReplicateBorder(desImage, temp);
			BitmapData srcBitmapData = srcImage.LockBits(new Rectangle(0, 0, srcImage.Width, srcImage.Height),
														ImageLockMode.ReadOnly,
														PixelFormat.Format24bppRgb);
			BitmapData desBitmapData = desImage.LockBits(new Rectangle(0, 0, desImage.Width, desImage.Height),
														ImageLockMode.WriteOnly,
														PixelFormat.Format24bppRgb);
			int padding = srcBitmapData.Stride - srcBitmapData.Width * 3;
			byte* pSrc = (byte*)srcBitmapData.Scan0;
			byte* pDes = (byte*)desBitmapData.Scan0;
			// Di chuyển con trỏ tới (1, 1)
			pSrc = pSrc + (srcBitmapData.Stride + 3) * temp;
			pDes = pDes + (desBitmapData.Stride + 3) * temp;
			for (int i = temp; i < srcBitmapData.Height - temp; i++)
			{
				for (int j = temp; j < srcBitmapData.Width - temp; j++)
				{
					int[,] matrix = GetMatrixAroundPixel(srcBitmapData, j, i, level);
					int newValue = objectColor;
					if (!checkFitHit(matrix, objectColor))
						newValue = 255 - objectColor;

					pDes[0] = (byte)newValue;
					pDes[1] = (byte)newValue;
					pDes[2] = (byte)newValue;
					pDes += 3;
					pSrc += 3;
				}
				pDes += 3 * (level - 1);
				pDes += padding;
				pSrc += 3 * (level - 1);
				pSrc += padding;
			}
			srcImage.UnlockBits(srcBitmapData);
			desImage.UnlockBits(desBitmapData);
			return desImage;
		}
		public Bitmap MorphologyErosion(Bitmap srcImage, int objectColor)
		{
			segmentaion.Thresholding(srcImage);
			//int objectColor = CalculateObjectColor(srcImage);
			return MorphologyReplicate(srcImage, 3, IsFit, objectColor);
		}
		public Bitmap MorphologyDilation(Bitmap srcImage, int objectColor)
		{
			segmentaion.Thresholding(srcImage);
			//int objectColor = CalculateObjectColor(srcImage);
			return MorphologyReplicate(srcImage, 3, IsHit, objectColor);
		}
		public Bitmap MorphologyOpening(Bitmap srcImage, int objectColor)
		{
			segmentaion.Thresholding(srcImage);
			//int objectColor = CalculateObjectColor(srcImage);
			Bitmap afterErosion = MorphologyErosion(srcImage, objectColor);
			Bitmap afterOpening = MorphologyDilation(afterErosion, objectColor);
			return afterOpening;
		}

		unsafe
		public Bitmap MorphologyBoundaryExtraction(Bitmap image11, Bitmap image22, int objectColor)
		{
			Bitmap image1 = (Bitmap)image11.Clone();
			Bitmap image2 = (Bitmap)image22.Clone();
			segmentaion.Thresholding(image1);
			segmentaion.Thresholding(image2);
			Bitmap result = (Bitmap)image1.Clone();
			int level = 3;
			int temp = level / 2;
			// Tô viền
			BitmapData srcBitmapData = image1.LockBits(new Rectangle(0, 0, image1.Width, image1.Height),
														ImageLockMode.ReadOnly,
														PixelFormat.Format24bppRgb);
			BitmapData desBitmapData = image2.LockBits(new Rectangle(0, 0, image2.Width, image2.Height),
														ImageLockMode.WriteOnly,
														PixelFormat.Format24bppRgb);
			BitmapData resultBitmapData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
														ImageLockMode.WriteOnly,
														PixelFormat.Format24bppRgb);
			int padding1 = srcBitmapData.Stride - srcBitmapData.Width * 3;
			int padding2 = desBitmapData.Stride - desBitmapData.Width * 3;
			int padding3 = resultBitmapData.Stride - resultBitmapData.Width * 3;
			byte* pSrc = (byte*)srcBitmapData.Scan0;
			byte* pDes = (byte*)desBitmapData.Scan0;
			byte* pResult = (byte*)resultBitmapData.Scan0;
			for (int i = 0; i < srcBitmapData.Height; i++)
			{
				for (int j = 0; j < srcBitmapData.Width; j++)
				{
					int	newValue = pSrc[0] - pDes[0];
					if(objectColor == 0)
					{
						if (newValue == 0) newValue = 255;
					}

					if (newValue > 255) newValue = 255;
					if (newValue < 0) newValue = 0;

					pResult[0] = (byte)newValue;
					pResult[1] = (byte)newValue;
					pResult[2] = (byte)newValue;
					pDes += 3;
					pSrc += 3;
					pResult += 3;
				}
				pDes += padding1;
				pSrc += padding2;
				pResult += padding3;
			}
			image1.UnlockBits(srcBitmapData);
			image2.UnlockBits(desBitmapData);
			result.UnlockBits(resultBitmapData);

			return result;
		}

		private int CalculateObjectColor(Bitmap bitmap)
		{
			int objectColor = 0;

			// nếu giá trị mức xám trung bình < 128 => màu đen nhiều hơn => khả năng cao nền màu đen
			int temp = bitmap.CalcAverageGrayLevel();
			if (temp < 128) objectColor = 255;

			return objectColor;
		}
	}
}
