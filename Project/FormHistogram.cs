using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class FormHistogram : Form
    {
        public FormHistogram(Bitmap image, string title)
        {
            InitializeComponent();
            this.Text = title;
            DrawHistogram(image, chartHistogram);
        }

        unsafe
        private void DrawHistogram(Bitmap image, Chart chart)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                        ImageLockMode.ReadWrite,
                                                        PixelFormat.Format24bppRgb);
            int[] hist = new int[256];
            for (int i = 0; i < 256; i++)
            {
                hist[i] = 0;
            }

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
            {
                chart.Series[0].Points.AddXY("", hist[i]);
            }

            image.UnlockBits(bitmapData);
        }
    }
}
