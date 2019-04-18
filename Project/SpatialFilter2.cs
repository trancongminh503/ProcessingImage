using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Project
{
    public class SpatialFilter2
    {
       private int[,] LaplacianEnhanceMatrix = {
                                        { 0, -1, 0 },
                                        { -1,  5, -1 },
                                        { 0, -1, 0 }
                                     };

		private int[,] SobelHorizontalMatrix = {
                                        { -1, -2, -1 },
                                        { 0, 0, 0 },
                                        { 1, 2, 1 }
                                     };

        private int[,] SobelVerticalMatrix = {
                                        { -1, 0, 1 },
                                        { -2, 0, 2 },
                                        { -1, 0, 1 }
                                     };

        unsafe
        private Bitmap ReplicateBorder(Bitmap image, int numPad)
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
        private int[,] GetMatrixAroundPixel(BitmapData bitmapData, int x, int y, int level)
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

        public delegate int GetInMatrixHandler(int[,] matrix);

        private int GetLaplacianInMatrix(int[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    sum += matrix[i, j] * LaplacianEnhanceMatrix[i, j];
            return (int)sum;
        }

        public int GetSobelInMatrix(int[,] matrix)
        {
            double sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum1 += matrix[i, j] * SobelHorizontalMatrix[i, j];
                    sum2 += matrix[i, j] * SobelVerticalMatrix[i, j];
                }
            }
            return (int)Math.Sqrt(Math.Pow(sum1, 2) + Math.Pow(sum2, 2));
        }

        unsafe
        protected Bitmap FilteringReplicate(Bitmap srcImage, Bitmap desImage, int level, GetInMatrixHandler getInMatrixHandler)
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
                    int[,] matrix = GetMatrixAroundPixel(srcBitmapData, j, i, 3);
                    int newValue = getInMatrixHandler(matrix);

                    if (newValue > 255) newValue = 255;
                    if (newValue < 0) newValue = 0;

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

        public Bitmap FilteringLaplacianReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetLaplacianInMatrix);
        }

        public Bitmap FilteringSobelReplicate(Bitmap srcImage, Bitmap desImage, int level)
        {
            return FilteringReplicate(srcImage, desImage, level, GetSobelInMatrix);
        }
    }
}
