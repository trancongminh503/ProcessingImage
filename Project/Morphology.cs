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

		unsafe
		public Bitmap GenerateX0(Bitmap image)
		{
			segmentaion.Thresholding(image);
			Bitmap bitmap = (Bitmap)image.Clone();

			BitmapData srcBitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
														ImageLockMode.ReadWrite,
														PixelFormat.Format24bppRgb);
			BitmapData desBitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
														ImageLockMode.ReadWrite,
														PixelFormat.Format24bppRgb);
			int padding = srcBitmapData.Stride - srcBitmapData.Width * 3;
			byte* pSrc = (byte*)srcBitmapData.Scan0;
			byte* pDes = (byte*)desBitmapData.Scan0;

			for (int i = 1; i < srcBitmapData.Height - 1; i++)
			{
				for (int j = 1; j < srcBitmapData.Width - 1; j++)
				{
					int[,] matrix = GetMatrixAroundPixel(srcBitmapData, j, i, 3);
					int newValue = 0;
					if (matrix[0, 1] == 255 && 
						matrix[1, 0] == 255 && 
						matrix[1, 1] == 0 && 
						matrix[1, 2] == 0 && 
						matrix[2,1]==0)
						newValue = 255;

					pDes[0] = (byte)newValue;
					pDes[1] = (byte)newValue;
					pDes[2] = (byte)newValue;
					pDes += 3;
					pSrc += 3;
				}
				pDes += 3 * (3 - 1);
				pDes += padding;
				pSrc += 3 * (3 - 1);
				pSrc += padding;
			}
			image.UnlockBits(srcBitmapData);
			bitmap.UnlockBits(desBitmapData);

			return bitmap;
		}

		unsafe
		public Bitmap Giao(Bitmap bitmap1, Bitmap bitmap2)
		{
			int temp = 3 / 2;
			Bitmap des = (Bitmap)bitmap1.Clone();

			BitmapData srcBitmapData1 = bitmap1.LockBits(new Rectangle(0, 0, bitmap1.Width, bitmap1.Height),
														ImageLockMode.ReadOnly,
														PixelFormat.Format24bppRgb);
			BitmapData srcBitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height),
														ImageLockMode.ReadOnly,
														PixelFormat.Format24bppRgb);
			BitmapData desBitmapData = des.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height),
														ImageLockMode.WriteOnly,
														PixelFormat.Format24bppRgb);
			int padding = srcBitmapData1.Stride - srcBitmapData1.Width * 3;
			byte* pSrc1 = (byte*)srcBitmapData1.Scan0;
			byte* pSrc2 = (byte*)srcBitmapData2.Scan0;
			byte* pDes = (byte*)desBitmapData.Scan0;
			// Di chuyển con trỏ tới (1, 1)
			pSrc1 = pSrc1 + (srcBitmapData1.Stride + 3) * temp;
			pSrc2 = pSrc2 + (desBitmapData.Stride + 3) * temp;
			pDes = pDes + (desBitmapData.Stride + 3) * temp;
			for (int i = temp; i < srcBitmapData1.Height - temp; i++)
			{
				for (int j = temp; j < srcBitmapData1.Width - temp; j++)
				{
					int newValue = pSrc1[0] + pSrc2[0];

					if (newValue > 255) newValue = 255;
					if (newValue < 0) newValue = 0;

					pDes[0] = (byte)newValue;
					pDes[1] = (byte)newValue;
					pDes[2] = (byte)newValue;
					pDes += 3;
					pSrc2 += 3;
					pSrc1 += 3;
				}
				pDes += 3 * (3 - 1);
				pDes += padding;
				pSrc1 += 3 * (3 - 1);
				pSrc2 += padding;
			}
			bitmap1.UnlockBits(srcBitmapData1);
			bitmap2.UnlockBits(srcBitmapData2);
			des.UnlockBits(desBitmapData);
			return des;
		}
	}
}
