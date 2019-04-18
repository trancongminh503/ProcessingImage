using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class HistogramExtensions
    {
        unsafe
        public static void RGB2GrayScale(this Bitmap image)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            //(RGB)(RGB)(RGB)(RGB)...
            int padding = bitmapData.Stride - image.Width * 3;
            //Đưa con trỏ về pixel đầu tiên
            byte* p = (byte*)bitmapData.Scan0;
            // Duyệt pixel chuyển RGB->Grayscale
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    // Công thức RGB->Grayscale
                    //double t = p[0] * 0.299 + p[1] * 0.587 + p[2] * 0.114;
                    double t = (p[0] + p[1] + p[2]) / 3;
                    // Gán cho 3 màu RGB
                    p[0] = (byte)t;
                    p[1] = (byte)t;
                    p[2] = (byte)t;
                    // Nhảy
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }

        unsafe
        public static void Equalization(this Bitmap image)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            #region values
            int rows = bitmapData.Width;
            int cols = bitmapData.Height;
            int area = rows * cols;
            int dm = 256;
            int k;
            int[] hist = new int[256];
            int[] sum_of_hist = new int[256];
            int sum = 0;
            for (int i = 0; i < dm; i++)
            {
                hist[i] = sum_of_hist[i] = 0;
            }
            #endregion

            //...
            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    hist[p[0]]++;
                    p += 3;
                }
                p += padding;
            }

            for (int i = 0; i < dm; i++)
            {
                sum += hist[i];
                sum_of_hist[i] = sum;
            }

            p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    k = p[0];
                    double temp = ((dm * 1.0 / area) * sum_of_hist[k]) - 1.0;
                    p[0] = (byte)temp;
                    p[1] = (byte)temp;
                    p[2] = (byte)temp;
                    p += 3;
                }
                p += padding;
            }

            image.UnlockBits(bitmapData);
        }

        public static Bitmap GetBestImageUseHistogram(List<Bitmap> list)
        {
            int max = int.MinValue;
            int pos = -1;
            for (int i = 0; i < list.Count; i++)
            {
                Bitmap temp = (Bitmap)list[i].Clone();
                int count = CountNotEqua0(temp);
                if (max < count)
                {
                    max = count;
                    pos = i;
                }
            }
            return list[pos];
        }

        unsafe
        private static int CountNotEqua0(Bitmap image)
        {
            int count = 0;
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            int[] hist = new int[256];

            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    hist[p[0]]++;
                    p += 3;
                }
                p += padding;
            }

            for (int i = 0; i < 256; i++)
                count = hist[i] != 0 ? (count + 1) : count;

            image.UnlockBits(bitmapData);
            return count;
        }

        unsafe
        public static int[] GenerateHistogramMatrix(this Bitmap image)
        {
            int[] hist = new int[256];

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    hist[p[0]]++;
                    p += 3;
                }
                p += padding;
            }

            return hist;
        }

        unsafe
        public static int CalcAverageGrayLevel(this Bitmap image)
        {
            int sum = 0;

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);

            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    sum += p[0];
                    p += 3;
                }
                p += padding;
            }

            image.UnlockBits(bitmapData);
            return sum / (image.Width * image.Height);
        }
    }
}
