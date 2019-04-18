using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Project
{
    public class SpatialFilter1
    {
        public int[,] GaussianBlurMatrix = {
                                        { 1, 2, 1 },
                                        { 2, 4, 2 },
                                        { 1, 2, 1 }
                                     };

        unsafe
		public Bitmap WrapAroundBorder(Bitmap image, int numPad, Color color)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            int padding = bitmapData.Stride - bitmapData.Width * 3;
            byte* top = (byte*)bitmapData.Scan0;
            byte* bottom = (byte*)bitmapData.Scan0 + bitmapData.Stride * (bitmapData.Height - 1);

            for (int j = 0; j < numPad; j++)
            {
                for (int i = 0; i < bitmapData.Width * 3; i++)
                {
                    top[i] = color.R;
                    bottom[i] = color.R;
                }
                top += bitmapData.Stride;
                bottom -= bitmapData.Stride;
            }

            for (int j = 0; j < numPad; j++)
            {
                top = (byte*)bitmapData.Scan0 + 3 * j;
                bottom = (byte*)bitmapData.Scan0 + (bitmapData.Width - 1) * 3 - 3 * j;
                for (int i = 0; i < bitmapData.Height; i++)
                {
                    top[0] = color.R;
                    top[1] = color.R;
                    top[2] = color.R;
                    bottom[0] = color.R;
                    bottom[1] = color.R;
                    bottom[2] = color.R;
                    top += bitmapData.Stride;
                    bottom += bitmapData.Stride;
                }
            }

            image.UnlockBits(bitmapData);
            return image;
        }

        unsafe
		public Bitmap ReplicateBorder(Bitmap image, int numPad)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            int padding = bitmapData.Stride - bitmapData.Width * 3;
            byte* top = (byte*)bitmapData.Scan0 + (3 * numPad) + ((numPad - 1) * bitmapData.Stride);
            byte* bottom = (byte*)bitmapData.Scan0 + (bitmapData.Stride * (bitmapData.Height - numPad - 1)) + (3 * numPad);

            for (int j = numPad - 1; j >= 0; j--)
            {
                for (int i = 0; i < (bitmapData.Width - numPad * 2) * 3; i++)
                {
                    top[i] = top[i + bitmapData.Stride];
                    bottom[i + bitmapData.Stride] = bottom[i];
                }
                top -= bitmapData.Stride;
                bottom += bitmapData.Stride;
            }

            for (int i = 0; i < bitmapData.Height; i++)
            {
                top = (byte*)bitmapData.Scan0 + i * bitmapData.Stride;
                bottom = (byte*)bitmapData.Scan0 + ((bitmapData.Width - numPad) * 3) - 3 + i * bitmapData.Stride;
                for (int j = 0; j < numPad * 3; j++)
                {
                    top[j] = top[3 * numPad];

                    bottom[j + 3] = bottom[0];
                }
            }

            image.UnlockBits(bitmapData);
            return image;
        }

        unsafe
		public int[,] GetMatrixAroundPixel(BitmapData bitmapData, int x, int y, int level)
        {
            int[,] matrix = new int[level, level];
            byte* p = (byte*)bitmapData.Scan0;
            int padding = (level / 2);
            p = p + bitmapData.Stride * (y - padding) + 3 * (x - padding);

            for (int i = 0; i < level; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    matrix[i, j] = p[0];
                    p += 3;
                }
                p -= level * 3;
                p += bitmapData.Stride;
            }
            return matrix;
        }

        public delegate int GetInMatrixHandler(int[,] matrix, int level);

		public int GetMaxInMatrix(int[,] matrix, int level)
        {
            int max = 0;
            foreach (var item in matrix)
                max = item > max ? item : max;
            return max;
        }

		public int GetMinInMatrix(int[,] matrix, int level)
        {
            int min = 255;
            foreach (var item in matrix)
                min = item < min ? item : min;
            return min;
        }

		public int GetMedianInMatrix(int[,] matrix, int level)
        {
            int i = 0;
            int[] median = new int[level * level];
            foreach (var item in matrix)
            {
                median[i++] = item;
            }
            Array.Sort<int>(median);
            return median[median.Length / 2];
        }

		public int GetAverageInMatrix(int[,] matrix, int level)
        {
            int sum = 0;
            foreach (var value in matrix)
                sum += value;
            return (int)((sum * 1.0) / (level * level));
        }

		public int GetWeightAverageInMatrix(int[,] matrix, int level)
        {
            double sum = 0;
            for (int i = 0; i < level; i++)
                for (int j = 0; j < level; j++)
                    sum += matrix[i, j] * GaussianBlurMatrix[i, j];
            return (int)sum / 16;
        }

        // Filtering + kiểu filter + phương thức xử lý viền
        unsafe
		public Bitmap FilteringWrapAround(Bitmap srcImage, Bitmap desImage, int level, int color, GetInMatrixHandler getInMatrixHandler)
        {
            int temp = level / 2;

            // Tô viền
            desImage = WrapAroundBorder(desImage, temp, Color.FromArgb(color, color, color));

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
                    int newValue = getInMatrixHandler(matrix, level);

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

        public Bitmap FilterMaxWrapAround(Bitmap srcImage, Bitmap desImage, int level, int color)
        {
            return FilteringWrapAround(srcImage, desImage, level, color, GetMaxInMatrix);
        }

        public Bitmap FilterMinWrapAround(Bitmap srcImage, Bitmap desImage, int level, int color)
        {
            return FilteringWrapAround(srcImage, desImage, level, color, GetMinInMatrix);
        }

        public Bitmap FilterMedianWrapAround(Bitmap srcImage, Bitmap desImage, int level, int color)
        {
            return FilteringWrapAround(srcImage, desImage, level, color, GetMedianInMatrix);
        }

        public Bitmap FilterAverageWrapAround(Bitmap srcImage, Bitmap desImage, int level, int color)
        {
            return FilteringWrapAround(srcImage, desImage, level, color, GetAverageInMatrix);
        }

        public Bitmap FilterWeightAverageWrapAround(Bitmap srcImage, Bitmap desImage, int level, int color)
        {
            return FilteringWrapAround(srcImage, desImage, level, color, GetWeightAverageInMatrix);
        }

        unsafe
		public Bitmap FilteringReplicate(Bitmap srcImage, Bitmap desImage, int level, GetInMatrixHandler getInMatrixHandler)
        {
            int temp = level / 2;

            // Tô viền
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
                    int newValue = getInMatrixHandler(matrix, level);

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

        public Bitmap FilterMaxReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetMaxInMatrix);
        }

        public Bitmap FilterMinReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetMinInMatrix);
        }

        public Bitmap FilterMedianReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetMedianInMatrix);
        }

        public Bitmap FilterAverageReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetAverageInMatrix);
        }

        public Bitmap FilterWeightedAverageReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetWeightAverageInMatrix);
        }
    }
}
