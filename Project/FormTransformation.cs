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
    public partial class FormTransformation : Form
    {
        public FormTransformation(List<Bitmap> images, List<string> note)
        {
            InitializeComponent();
            DrawHistogram(images[0], chart1);
            DrawHistogram(images[1], chart2);
            DrawHistogram(images[2], chart3);
            label1.Text = note[0];
            label2.Text = note[1];
            label3.Text = note[2];
            pictureBox1.Image = images[0];
            pictureBox2.Image = images[1];
            pictureBox3.Image = images[2];
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
