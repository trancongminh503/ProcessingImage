using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Project
{
    public class Transformation
    {
        unsafe
        public void Negative(Bitmap image)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            double newValue, oldValue;
            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    // s = c * log(1 + r)   r: [0, 1]
                    oldValue = p[0] / 255.0;
                    newValue = (1.0 - oldValue) * 255;
                    p[0] = (byte)newValue;
                    p[1] = (byte)newValue;
                    p[2] = (byte)newValue;
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }

        unsafe
        public void Logarithmic(Bitmap image, double c)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            double s, r;
            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    // s = c * log(1 + r)   r: [0, 1]
                    //p[0] = p[0] > 255 ? (byte)255 : p[0];
                    r = p[0] / 255.0;
                    s = Math.Log10(1 + r) * c * 255;
                    //int temp = (int)s;

                    s = s > 255 ? 255 : s;

                    p[0] = (byte)s;
                    p[1] = (byte)s;
                    p[2] = (byte)s;
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }

        unsafe
        public void PowerLaw(Bitmap image, double lamda, double c)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            double s, r;
            int padding = bitmapData.Stride - image.Width * 3;
            byte* p = (byte*)bitmapData.Scan0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    // s = c * r^lamda   r: [0, 1]
                    r = p[0] / 255.0;
                    s = c * Math.Pow(r, lamda) * 255.0;
                    p[0] = (byte)s;
                    p[1] = (byte)s;
                    p[2] = (byte)s;
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }

        unsafe
        public void BitPlaneSlicing(Bitmap image, int bitPlane)
        {
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
                    double bitValue = Math.Pow(2.0, (double)bitPlane);
                    newValue = ((p[0] & (int)bitValue) == bitValue) ? 255 : 0;
                    p[0] = (byte)newValue;
                    p[1] = (byte)newValue;
                    p[2] = (byte)newValue;
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }

        unsafe
        public void GrayLevelSlicing(Bitmap image, int startPoint, int endPoint)
        {
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
                    if (p[0] >= startPoint && p[0] <= endPoint)
                        newValue = 255;
                    else
                        newValue = p[0];
                    p[0] = (byte)newValue;
                    p[1] = (byte)newValue;
                    p[2] = (byte)newValue;
                    p += 3;
                }
                p += padding;
            }
            image.UnlockBits(bitmapData);
        }
    }
}
