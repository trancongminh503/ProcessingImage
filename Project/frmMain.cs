using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Project
{
	public partial class frmMain : Form
	{
		#region Variable

		Bitmap imageSrc;
		Bitmap imageGrayScale;
		Bitmap imageDest;
		Transformation transfrom = new Transformation();
		SpatialFilter1 filter1 = new SpatialFilter1();
		SpatialFilter2 filter2 = new SpatialFilter2();
		Segmentaion segmentaion = new Segmentaion();
		Morphology morphology = new Morphology();

		#endregion

		public frmMain()
		{
			InitializeComponent();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pbSource_DoubleClick(sender, e);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageDest == null)
				return;

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "(*.bmp)|*.bmp";
			saveFileDialog.FileName = "Image";
			saveFileDialog.ShowDialog();
			bool isValid = saveFileDialog.CheckPathExists;
			if (isValid)
				imageDest.Save(saveFileDialog.FileName);
		}

		private void pbSource_DoubleClick(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				imageSrc = new Bitmap(dialog.FileName);
				imageGrayScale = (Bitmap)imageSrc.Clone();
				imageGrayScale.RGB2GrayScale();
				pbSource.Image = imageGrayScale;
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			imageGrayScale = (Bitmap)imageDest.Clone();
			pbSource.Image = imageGrayScale;

			imageDest = null;
			pbDest.Image = null;
		}

		#region Histogram event

		private void mntsHistogramDrawLeft_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			var histogram = new FormHistogram(imageGrayScale, "Histogram Source");
			histogram.Show();
		}

		private void mntsHistogramDrawRight_Click(object sender, EventArgs e)
		{
			if (imageDest == null)
				return;

			var histogram = new FormHistogram(imageDest, "Histogram Destination");
			histogram.Show();
		}

		private void mntsHistogramEqua_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			imageDest.Equalization();
			pbDest.Image = imageDest;
		}

		#endregion

		#region Transformation events

		private void mntsTransformationsNegative_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			imageDest = transfrom.Negative(imageDest);
			pbDest.Image = imageDest;
		}

		private void mntsTransformationsLogarithmic_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			var listBitmap = new List<Bitmap>();
			var notes = new List<string>(); // take note c = value into image
			for (int i = 0; i < 3; i++) // clone 3 image
			{
				Bitmap bitmap = (Bitmap)imageGrayScale.Clone();
				listBitmap.Add(bitmap);
			}

			var input = new FormInputLogarithmic();
			input.ShowDialog();
			if (input.DialogResult != DialogResult.OK)
				return;

			var c1 = double.Parse(input.txtValue1.Text);
			var c2 = double.Parse(input.txtValue2.Text);
			var c3 = double.Parse(input.txtValue3.Text);
			string s1 = "c = " + c1.ToString();
			string s2 = "c = " + c2.ToString();
			string s3 = "c = " + c3.ToString();
			notes.AddRange(new List<string>() { s1, s2, s3 });
			transfrom.Logarithmic(listBitmap[0], c1);
			transfrom.Logarithmic(listBitmap[1], c2);
			transfrom.Logarithmic(listBitmap[2], c3);

			var outPut = new FormTransformation(listBitmap, notes);
			outPut.Show();

			imageDest = HistogramExtensions.GetBestImageUseHistogram(listBitmap);
			pbDest.Image = imageDest;
		}

		private void mntsTransformationsPower_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			var notes = new List<string>();
			var listBitmap = new List<Bitmap>();
			for (int i = 0; i < 3; i++)
			{
				Bitmap bitmap = (Bitmap)imageGrayScale.Clone();
				listBitmap.Add(bitmap);
			}

			var input = new FormInputPower();
			input.ShowDialog();
			if (input.DialogResult != DialogResult.OK)
				return;

			var c1 = double.Parse(input.txtC1.Text);
			var c2 = double.Parse(input.txtC2.Text);
			var c3 = double.Parse(input.txtC3.Text);
			var lamda1 = double.Parse(input.txtLamda1.Text);
			var lamda2 = double.Parse(input.txtLamda2.Text);
			var lamda3 = double.Parse(input.txtLamda3.Text);
			string s1 = "c = " + c1.ToString() + " / lamda = " + lamda1.ToString();
			string s2 = "c = " + c2.ToString() + " / lamda = " + lamda2.ToString();
			string s3 = "c = " + c3.ToString() + " / lamda = " + lamda3.ToString();
			notes.AddRange(new List<string>() { s1, s2, s3 });
			transfrom.PowerLaw(listBitmap[0], lamda1, c1);
			transfrom.PowerLaw(listBitmap[1], lamda2, c2);
			transfrom.PowerLaw(listBitmap[2], lamda3, c3);

			var outPut = new FormTransformation(listBitmap, notes);
			outPut.Show();

			imageDest = HistogramExtensions.GetBestImageUseHistogram(listBitmap);
			pbDest.Image = imageDest;
		}

		private void mntsTransformationsBitPlane_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			var listBitmap = new List<Bitmap>();
			var notes = new List<string>(); // take note c = value into image
			for (int i = 0; i < 3; i++) // clone 3 image
			{
				Bitmap bitmap = (Bitmap)imageGrayScale.Clone();
				listBitmap.Add(bitmap);
			}

			var input = new FormInputBitPlane();
			input.ShowDialog();
			if (input.DialogResult != DialogResult.OK)
				return;

			var lv1 = int.Parse(input.txtValue1.Text);
			var lv2 = int.Parse(input.txtValue2.Text);
			var lv3 = int.Parse(input.txtValue3.Text);
			string s1 = "Level = " + lv1.ToString();
			string s2 = "Level = " + lv2.ToString();
			string s3 = "Level = " + lv3.ToString();
			notes.AddRange(new List<string>() { s1, s2, s3 });
			transfrom.BitPlaneSlicing(listBitmap[0], lv1);
			transfrom.BitPlaneSlicing(listBitmap[1], lv2);
			transfrom.BitPlaneSlicing(listBitmap[2], lv3);

			var outPut = new FormTransformation(listBitmap, notes);
			outPut.Show();

			imageDest = HistogramExtensions.GetBestImageUseHistogram(listBitmap);
			pbDest.Image = imageDest;
		}

		private void mntsTransformationsGrayLevel_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			var notes = new List<string>();
			var listBitmap = new List<Bitmap>();
			for (int i = 0; i < 3; i++)
			{
				Bitmap bitmap = (Bitmap)imageGrayScale.Clone();
				listBitmap.Add(bitmap);
			}

			var input = new FormInputGrayLevel();
			input.ShowDialog();
			if (input.DialogResult != DialogResult.OK)
				return;

			var t11 = int.Parse(input.txtT11.Text);
			var t12 = int.Parse(input.txtT12.Text);
			var t13 = int.Parse(input.txtT13.Text);
			var t21 = int.Parse(input.txtT21.Text);
			var t22 = int.Parse(input.txtT22.Text);
			var t23 = int.Parse(input.txtT23.Text);
			string s1 = "t1 = " + t11.ToString() + " / t2 = " + t21.ToString();
			string s2 = "t1 = " + t12.ToString() + " / t2 = " + t22.ToString();
			string s3 = "t1 = " + t13.ToString() + " / t2 = " + t23.ToString();
			notes.AddRange(new List<string>() { s1, s2, s3 });
			transfrom.GrayLevelSlicing(listBitmap[0], t11, t21);
			transfrom.GrayLevelSlicing(listBitmap[1], t12, t22);
			transfrom.GrayLevelSlicing(listBitmap[2], t13, t23);

			var outPut = new FormTransformation(listBitmap, notes);
			outPut.Show();

			imageDest = HistogramExtensions.GetBestImageUseHistogram(listBitmap);
			pbDest.Image = imageDest;
		}

		#endregion

		#region Filter 1 event

		public delegate Bitmap FilterWrapAroundHandler(Bitmap srcImage, Bitmap desImage, int level, int color);

		public delegate Bitmap FilterReplicateHandler(Bitmap srcImage, Bitmap desImage, int level);

		private void mntsFilterWrapAround(FilterWrapAroundHandler filterWrapAround)
		{
			if (imageGrayScale == null)
				return;

			int level = 3, color = 0;
			var input = new FormInputFilter();
			input.label1.Text = "Matrix size";
			if (filterWrapAround == filter1.FilterWeightAverageWrapAround)
			{
				input.textBox1.Text = "3";
				input.textBox1.Enabled = false;
			}
			input.textBox1.Text = level.ToString();
			input.label2.Text = "Boder Color";
			input.textBox2.Text = color.ToString();
			input.ShowDialog();
			if (input.DialogResult != DialogResult.OK)
				return;

			int.TryParse(input.textBox1.Text, out level);
			int.TryParse(input.textBox2.Text, out color);

			imageDest = (Bitmap)imageGrayScale.Clone();
			Bitmap temp = (Bitmap)imageGrayScale.Clone();
			imageDest = filterWrapAround(temp, imageDest, level, color);
			pbDest.Image = imageDest;
		}

		private void mntsFilterReplicate(FilterReplicateHandler filterReplicate)
		{
			if (imageGrayScale == null)
				return;

			int level = 3;
			FormInputFilter input = new FormInputFilter();
			input.label1.Text = "Matrix size";
			if (filterReplicate == filter1.FilterWeightedAverageReplicate || filterReplicate == filter2.FilteringLaplacianReplicate
				|| filterReplicate == filter2.FilteringSobelReplicate)
			{
				input.textBox1.Text = "3";
				input.textBox1.Enabled = false;
			}
			input.label2.Hide();
			input.textBox2.Hide();
			input.textBox1.Text = level.ToString();
			input.ShowDialog();
			if (input.DialogResult != DialogResult.OK)
				return;

			int.TryParse(input.textBox1.Text, out level);

			Bitmap temp = (Bitmap)imageGrayScale.Clone();
			imageDest = (Bitmap)imageGrayScale.Clone();
			imageDest = filterReplicate(temp, imageDest, level);
			pbDest.Image = imageDest;
		}

		private void mntsFilterMaxWrap_Click(object sender, EventArgs e)
		{
			mntsFilterWrapAround(filter1.FilterMaxWrapAround);
		}

		private void mntsFilterMaxReplicate_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter1.FilterMaxReplicate);
		}

		private void mntsFilterMinWrap_Click(object sender, EventArgs e)
		{
			mntsFilterWrapAround(filter1.FilterMinWrapAround);
		}

		private void mntsFilterMinReplicate_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter1.FilterMinReplicate);
		}

		private void mntsFilterMedianWrap_Click(object sender, EventArgs e)
		{
			mntsFilterWrapAround(filter1.FilterMedianWrapAround);
		}

		private void mntsFilterMedianReplicate_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter1.FilterMedianReplicate);
		}

		private void mntsFilterAverageWrap_Click(object sender, EventArgs e)
		{
			mntsFilterWrapAround(filter1.FilterAverageWrapAround);
		}

		private void mntsFilterAverageReplicate_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter1.FilterAverageReplicate);
		}

		private void mntsFilterWeightedWrap_Click(object sender, EventArgs e)
		{
			mntsFilterWrapAround(filter1.FilterWeightAverageWrapAround);
		}

		private void mntsFilterWeightReplicate_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter1.FilterWeightedAverageReplicate);
		}

		#endregion

		#region Filter 2 event

		private void mntsFilterLaplacian_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter2.FilteringLaplacianReplicate);
		}

		private void mntsFilterSobel_Click(object sender, EventArgs e)
		{
			mntsFilterReplicate(filter2.FilteringSobelReplicate);
		}

		#endregion

		#region Segmentation event

		private void mntsSegmentationPoint_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingPointDetection(imageGrayScale, imageDest);
			pbDest.Image = imageDest;
		}

		private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingLineDetection(imageGrayScale, imageDest, 1);
			pbDest.Image = imageDest;
		}

		private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingLineDetection(imageGrayScale, imageDest, 2);
			pbDest.Image = imageDest;
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingLineDetection(imageGrayScale, imageDest, 3);
			pbDest.Image = imageDest;
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingLineDetection(imageGrayScale, imageDest, 4);
			pbDest.Image = imageDest;
		}

		private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingEdgeDetection(imageGrayScale, imageDest, 1);
			pbDest.Image = imageDest;
		}

		private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			imageDest = (Bitmap)imageGrayScale.Clone();
			segmentaion.ThresholdingEdgeDetection(imageGrayScale, imageDest, 2);
			pbDest.Image = imageDest;
		}

		#endregion

		#region Morphology event
		FormMorphology input = new FormMorphology();
		private delegate Bitmap MorphologyHandler(Bitmap srcImage, int objectColor);
		private void Morphology(MorphologyHandler morphology, Bitmap srcImage)
		{
			if (imageGrayScale == null)
				return;

			int repeat = 1;

			int objectColor = 0;
			input = new FormMorphology();
			input.ShowDialog();
			if (input.DialogResult == DialogResult.OK)
			{
				repeat = int.Parse(input.txtMatrixSize.Text);
				objectColor = int.Parse(input.txtObjectColor.Text);
			}

			Bitmap temp = (Bitmap)srcImage.Clone();
			for (int i = 0; i < repeat; i++)
			{
				imageDest = morphology(temp, objectColor);
				temp = (Bitmap)imageDest.Clone();
			}
		}
		private void mntsMorphologyErosion_Click(object sender, EventArgs e)
		{
			Morphology(morphology.MorphologyErosion, imageGrayScale);
			pbDest.Image = imageDest;
		}
		private void mntsMorphologyDilation_Click(object sender, EventArgs e)
		{
			Morphology(morphology.MorphologyDilation, imageGrayScale);
			pbDest.Image = imageDest;
		}
		private void openingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			int repeat = 1;

			int objectColor = 0;
			input = new FormMorphology();
			input.ShowDialog();
			if (input.DialogResult == DialogResult.OK)
			{
				repeat = int.Parse(input.txtMatrixSize.Text);
				objectColor = int.Parse(input.txtObjectColor.Text);
			}


			Bitmap temp = (Bitmap)imageGrayScale.Clone();
			for (int i = 0; i < repeat; i++)
			{
				imageDest = morphology.MorphologyErosion(temp, objectColor);
				temp = (Bitmap)imageDest.Clone();
			}
			for (int i = 0; i < repeat; i++)
			{
				imageDest = morphology.MorphologyDilation(temp, objectColor);
				temp = (Bitmap)imageDest.Clone();
			}
			pbDest.Image = imageDest;
		}
		private void closingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (imageGrayScale == null)
				return;

			int repeat = 1;

			int objectColor = 0;
			input = new FormMorphology();
			input.ShowDialog();
			if (input.DialogResult == DialogResult.OK)
			{
				repeat = int.Parse(input.txtMatrixSize.Text);
				objectColor = int.Parse(input.txtObjectColor.Text);
			}


			Bitmap temp = (Bitmap)imageGrayScale.Clone();
			for (int i = 0; i < repeat; i++)
			{
				imageDest = morphology.MorphologyDilation(temp, objectColor);
				temp = (Bitmap)imageDest.Clone();
			}
			for (int i = 0; i < repeat; i++)
			{
				imageDest = morphology.MorphologyErosion(temp, objectColor);
				temp = (Bitmap)imageDest.Clone();
			}
			pbDest.Image = imageDest;
		}
		private void boundaryExtractionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Morphology(morphology.MorphologyErosion, imageGrayScale);
			//imageDest = (Bitmap)imageGrayScale.Clone();
			Bitmap image = morphology.MorphologyBoundaryExtraction(imageGrayScale, imageDest, int.Parse(input.txtObjectColor.Text));
			pbDest.Image = image;
		}
		private void regionFillingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			while (true)
			{

			}
		}
		#endregion
	}
}