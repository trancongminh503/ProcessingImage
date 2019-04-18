using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Project
{
    public class Segmentaion : SpatialFilter2
    {
        private int[,] PointDetectionMatrix = {
                                                {-1, -1, -1 },
                                                {-1,  8, -1 },
                                                {-1, -1, -1 }
                                                };
		private int[,] LineDetectionVerticalMatrix =
		{
			{ -1, 2, -1},
			{ -1, 2, -1},
			{ -1, 2, -1}
		};
		private int[,] LineDetectionHorizontalMatrix =
		{
			{ -1, -1, -1},
			{  2,  2,  2},
			{ -1, -1, -1}
		};
		private int[,] LineDetection45DegreeMatrix =
		{
			{-1, -1, 2 },
			{-1, 2, -1 },
			{2, -1, -1 }
		};
		private int[,] LineDetectionNegative45DegreeMatrix =
		{
			{2, -1, -1 },
			{-1, 2, -1 },
			{-1, -1, 2 }
		};
		private int[,] EdgeDetectionPrewittHorizontalMatrix = { 
														{ -1, -1, -1}, 
														{ 0, 0, 0}, 
														{ 1, 1, 1} };
		private int[,] EdgeDetectionPrewittVerticalMatrix = {
														{ -1, 0, 1},
														{ -1, 0, 1},
														{ -1, 0, 1} };

		private int GetPointDetectionMatrix(int[,] matrix)
		{
			double sum = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					sum += matrix[i, j] * PointDetectionMatrix[i, j];
			return (int)sum;
		}
		private int GetLineDetectionVerticalMatrix(int[,] matrix)
		{
			double sum = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					sum += matrix[i, j] * LineDetectionVerticalMatrix[i, j];
			return (int)sum;
		}
		private int GetLineDetectionHorizontalMatrix(int[,] matrix)
		{
			double sum = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					sum += matrix[i, j] * LineDetectionHorizontalMatrix[i, j];
			return (int)sum;
		}
		private int GetLineDetection45DegreeMatrix(int[,] matrix)
		{
			double sum = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					sum += matrix[i, j] * LineDetection45DegreeMatrix[i, j];
			return (int)sum;
		}
		private int GetLineDetectionNegative45DegreeMatrix(int[,] matrix)
		{
			double sum = 0;
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					sum += matrix[i, j] * LineDetectionNegative45DegreeMatrix[i, j];
			return (int)sum;
		}
		public int GetPrewittInMatrix(int[,] matrix)
		{
			double sum1 = 0;
			double sum2 = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					sum1 += matrix[i, j] * EdgeDetectionPrewittHorizontalMatrix[i, j];
					sum2 += matrix[i, j] * EdgeDetectionPrewittVerticalMatrix[i, j];
				}
			}
			return (int)Math.Sqrt(Math.Pow(sum1, 2) + Math.Pow(sum2, 2));
		}

		private Bitmap ThresholdingHandler(Bitmap srcImage, Bitmap desImage, GetInMatrixHandler getInMatrixHandler)
		{
			desImage = FilteringReplicate(srcImage, desImage, 3, getInMatrixHandler);
			Thresholding(desImage);
			return desImage;
		}
		public Bitmap ThresholdingPointDetection(Bitmap srcImage, Bitmap desImage)
		{
			return ThresholdingHandler(srcImage, desImage, GetPointDetectionMatrix);
		}
		public Bitmap ThresholdingLineDetection(Bitmap srcImage, Bitmap desImage, int select)
		{
			switch(select)
			{
				case 1:
					return ThresholdingHandler(srcImage, desImage, GetLineDetectionVerticalMatrix);
				case 2:
					return ThresholdingHandler(srcImage, desImage, GetLineDetectionHorizontalMatrix);
				case 3:
					return ThresholdingHandler(srcImage, desImage, GetLineDetection45DegreeMatrix);
				case 4:
					return ThresholdingHandler(srcImage, desImage, GetLineDetectionNegative45DegreeMatrix);
			}
			return null;
		}
		public Bitmap ThresholdingEdgeDetection(Bitmap srcImage, Bitmap desImage, int select)
		{
			switch (select)
			{
				case 1:
					return ThresholdingHandler(srcImage, desImage, GetSobelInMatrix);
				case 2:
					return ThresholdingHandler(srcImage, desImage, GetPrewittInMatrix);
			}
			return null;
		}

		unsafe
        public void Thresholding(Bitmap image)
        {
            int T = CalculateThresholding(image);

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    int newValue;
                    if (p[0] >= T && p[0] <= 255)
                        newValue = 255;
                    else
                        newValue = 0;
                    p[0] = (byte)newValue;
                    p[1] = (byte)newValue;
                    p[2] = (byte)newValue;
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }

        private int CalculateThresholding(Bitmap image)
        {
			// Select an initial estimate for T (typically the average grey level in the image)
			int T2;
            int T1 = image.CalcAverageGrayLevel();
			while (true)
			{
				var G = GenerateGroupPiexel(image, T1);
				List<int> G1 = G[0];
				List<int> G2 = G[1];
				int μ1 = (int)G1.Average();
				int μ2 = (int)G2.Average();
				double temp = (μ1 + μ2) / 2;
				T2 = (int)Math.Round(temp);

				if (T1 == T2)
					break;
				T1 = T2;
			}
			return T1;
        }

        unsafe
        private List<int>[] GenerateGroupPiexel(Bitmap image, int T)
        {
            List<int> G1 = new List<int>();
            List<int> G2 = new List<int>();

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
				for (int j = 0; j < image.Width; j++)
				{
					// G1 consisting of pixels with grey levels > T
					if (p[0] > T)
                        G1.Add(p[0]);
                    // G2 consisting pixels with grey levels ≤ T
                    else if(p[0] <= T)
                        G2.Add(p[0]);
                    p += 3;
                }
                p += padding;
            }

            image.UnlockBits(bitmapData);

            return new List<int>[2] { G1, G2 };
        }
    }
}
