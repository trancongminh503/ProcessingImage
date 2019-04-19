namespace Project
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.drawHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsHistogramDrawLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsHistogramDrawRight = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsHistogramEqua = new System.Windows.Forms.ToolStripMenuItem();
			this.tranformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsTransformationsNegative = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsTransformationsLogarithmic = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsTransformationsPower = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsTransformationsBitPlane = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsTransformationsGrayLevel = new System.Windows.Forms.ToolStripMenuItem();
			this.filteringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.maxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterMaxReplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterMaxWrap = new System.Windows.Forms.ToolStripMenuItem();
			this.minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterMinReplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterMinWrap = new System.Windows.Forms.ToolStripMenuItem();
			this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterMedianReplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterMedianWrap = new System.Windows.Forms.ToolStripMenuItem();
			this.averageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterAverageReplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterAverageWrap = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterWeightedReplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterWeightReplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterWeightedWrap = new System.Windows.Forms.ToolStripMenuItem();
			this.filteringInTheFeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterLaplacian = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsFilterSobel = new System.Windows.Forms.ToolStripMenuItem();
			this.segmentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsSegmentationPoint = new System.Windows.Forms.ToolStripMenuItem();
			this.lineDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.edgeDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.morphologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsMorphologyErosion = new System.Windows.Forms.ToolStripMenuItem();
			this.mntsMorphologyDilation = new System.Windows.Forms.ToolStripMenuItem();
			this.openingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.boundaryExtractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainerImage = new System.Windows.Forms.SplitContainer();
			this.pbSource = new System.Windows.Forms.PictureBox();
			this.pbDest = new System.Windows.Forms.PictureBox();
			this.regionFillingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerImage)).BeginInit();
			this.splitContainerImage.Panel1.SuspendLayout();
			this.splitContainerImage.Panel2.SuspendLayout();
			this.splitContainerImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDest)).BeginInit();
			this.SuspendLayout();
			// 
			// MenuBar
			// 
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.tranformationsToolStripMenuItem,
            this.filteringToolStripMenuItem,
            this.filteringInTheFeToolStripMenuItem,
            this.segmentationToolStripMenuItem,
            this.morphologyToolStripMenuItem,
            this.moreToolStripMenuItem});
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.Size = new System.Drawing.Size(800, 24);
			this.MenuBar.TabIndex = 0;
			this.MenuBar.Text = "MenuBar";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// histogramToolStripMenuItem
			// 
			this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawHistogramToolStripMenuItem,
            this.mntsHistogramEqua});
			this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
			this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.histogramToolStripMenuItem.Text = "Histogram";
			// 
			// drawHistogramToolStripMenuItem
			// 
			this.drawHistogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsHistogramDrawLeft,
            this.mntsHistogramDrawRight});
			this.drawHistogramToolStripMenuItem.Name = "drawHistogramToolStripMenuItem";
			this.drawHistogramToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.drawHistogramToolStripMenuItem.Text = "Draw Histogram";
			// 
			// mntsHistogramDrawLeft
			// 
			this.mntsHistogramDrawLeft.Name = "mntsHistogramDrawLeft";
			this.mntsHistogramDrawLeft.Size = new System.Drawing.Size(138, 22);
			this.mntsHistogramDrawLeft.Text = "Left Image";
			this.mntsHistogramDrawLeft.Click += new System.EventHandler(this.mntsHistogramDrawLeft_Click);
			// 
			// mntsHistogramDrawRight
			// 
			this.mntsHistogramDrawRight.Name = "mntsHistogramDrawRight";
			this.mntsHistogramDrawRight.Size = new System.Drawing.Size(138, 22);
			this.mntsHistogramDrawRight.Text = "Right Image";
			this.mntsHistogramDrawRight.Click += new System.EventHandler(this.mntsHistogramDrawRight_Click);
			// 
			// mntsHistogramEqua
			// 
			this.mntsHistogramEqua.Name = "mntsHistogramEqua";
			this.mntsHistogramEqua.Size = new System.Drawing.Size(160, 22);
			this.mntsHistogramEqua.Text = "Equalization";
			this.mntsHistogramEqua.Click += new System.EventHandler(this.mntsHistogramEqua_Click);
			// 
			// tranformationsToolStripMenuItem
			// 
			this.tranformationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsTransformationsNegative,
            this.mntsTransformationsLogarithmic,
            this.mntsTransformationsPower,
            this.mntsTransformationsBitPlane,
            this.mntsTransformationsGrayLevel});
			this.tranformationsToolStripMenuItem.Name = "tranformationsToolStripMenuItem";
			this.tranformationsToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
			this.tranformationsToolStripMenuItem.Text = "Tranformations";
			// 
			// mntsTransformationsNegative
			// 
			this.mntsTransformationsNegative.Name = "mntsTransformationsNegative";
			this.mntsTransformationsNegative.Size = new System.Drawing.Size(166, 22);
			this.mntsTransformationsNegative.Text = "Negative";
			this.mntsTransformationsNegative.Click += new System.EventHandler(this.mntsTransformationsNegative_Click);
			// 
			// mntsTransformationsLogarithmic
			// 
			this.mntsTransformationsLogarithmic.Name = "mntsTransformationsLogarithmic";
			this.mntsTransformationsLogarithmic.Size = new System.Drawing.Size(166, 22);
			this.mntsTransformationsLogarithmic.Text = "Logarithmic";
			this.mntsTransformationsLogarithmic.Click += new System.EventHandler(this.mntsTransformationsLogarithmic_Click);
			// 
			// mntsTransformationsPower
			// 
			this.mntsTransformationsPower.Name = "mntsTransformationsPower";
			this.mntsTransformationsPower.Size = new System.Drawing.Size(166, 22);
			this.mntsTransformationsPower.Text = "Power";
			this.mntsTransformationsPower.Click += new System.EventHandler(this.mntsTransformationsPower_Click);
			// 
			// mntsTransformationsBitPlane
			// 
			this.mntsTransformationsBitPlane.Name = "mntsTransformationsBitPlane";
			this.mntsTransformationsBitPlane.Size = new System.Drawing.Size(166, 22);
			this.mntsTransformationsBitPlane.Text = "Bit Plane Slicing";
			this.mntsTransformationsBitPlane.Click += new System.EventHandler(this.mntsTransformationsBitPlane_Click);
			// 
			// mntsTransformationsGrayLevel
			// 
			this.mntsTransformationsGrayLevel.Name = "mntsTransformationsGrayLevel";
			this.mntsTransformationsGrayLevel.Size = new System.Drawing.Size(166, 22);
			this.mntsTransformationsGrayLevel.Text = "Gray Level Slicing";
			this.mntsTransformationsGrayLevel.Click += new System.EventHandler(this.mntsTransformationsGrayLevel_Click);
			// 
			// filteringToolStripMenuItem
			// 
			this.filteringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxToolStripMenuItem,
            this.minToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.averageToolStripMenuItem,
            this.mntsFilterWeightedReplicate});
			this.filteringToolStripMenuItem.Name = "filteringToolStripMenuItem";
			this.filteringToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
			this.filteringToolStripMenuItem.Text = "Spatial Filtering 1";
			// 
			// maxToolStripMenuItem
			// 
			this.maxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsFilterMaxReplicate,
            this.mntsFilterMaxWrap});
			this.maxToolStripMenuItem.Name = "maxToolStripMenuItem";
			this.maxToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.maxToolStripMenuItem.Text = "Max";
			// 
			// mntsFilterMaxReplicate
			// 
			this.mntsFilterMaxReplicate.Name = "mntsFilterMaxReplicate";
			this.mntsFilterMaxReplicate.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterMaxReplicate.Text = "Replicate Border";
			this.mntsFilterMaxReplicate.Click += new System.EventHandler(this.mntsFilterMaxReplicate_Click);
			// 
			// mntsFilterMaxWrap
			// 
			this.mntsFilterMaxWrap.Name = "mntsFilterMaxWrap";
			this.mntsFilterMaxWrap.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterMaxWrap.Text = "Wrap Color";
			this.mntsFilterMaxWrap.Click += new System.EventHandler(this.mntsFilterMaxWrap_Click);
			// 
			// minToolStripMenuItem
			// 
			this.minToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsFilterMinReplicate,
            this.mntsFilterMinWrap});
			this.minToolStripMenuItem.Name = "minToolStripMenuItem";
			this.minToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.minToolStripMenuItem.Text = "Min";
			// 
			// mntsFilterMinReplicate
			// 
			this.mntsFilterMinReplicate.Name = "mntsFilterMinReplicate";
			this.mntsFilterMinReplicate.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterMinReplicate.Text = "Replicate Border";
			this.mntsFilterMinReplicate.Click += new System.EventHandler(this.mntsFilterMinReplicate_Click);
			// 
			// mntsFilterMinWrap
			// 
			this.mntsFilterMinWrap.Name = "mntsFilterMinWrap";
			this.mntsFilterMinWrap.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterMinWrap.Text = "Wrap Color";
			this.mntsFilterMinWrap.Click += new System.EventHandler(this.mntsFilterMinWrap_Click);
			// 
			// medianToolStripMenuItem
			// 
			this.medianToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsFilterMedianReplicate,
            this.mntsFilterMedianWrap});
			this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
			this.medianToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.medianToolStripMenuItem.Text = "Median";
			// 
			// mntsFilterMedianReplicate
			// 
			this.mntsFilterMedianReplicate.Name = "mntsFilterMedianReplicate";
			this.mntsFilterMedianReplicate.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterMedianReplicate.Text = "Replicate Border";
			this.mntsFilterMedianReplicate.Click += new System.EventHandler(this.mntsFilterMedianReplicate_Click);
			// 
			// mntsFilterMedianWrap
			// 
			this.mntsFilterMedianWrap.Name = "mntsFilterMedianWrap";
			this.mntsFilterMedianWrap.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterMedianWrap.Text = "Wrap Color";
			this.mntsFilterMedianWrap.Click += new System.EventHandler(this.mntsFilterMedianWrap_Click);
			// 
			// averageToolStripMenuItem
			// 
			this.averageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsFilterAverageReplicate,
            this.mntsFilterAverageWrap});
			this.averageToolStripMenuItem.Name = "averageToolStripMenuItem";
			this.averageToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.averageToolStripMenuItem.Text = "Average";
			// 
			// mntsFilterAverageReplicate
			// 
			this.mntsFilterAverageReplicate.Name = "mntsFilterAverageReplicate";
			this.mntsFilterAverageReplicate.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterAverageReplicate.Text = "Replicate Border";
			this.mntsFilterAverageReplicate.Click += new System.EventHandler(this.mntsFilterAverageReplicate_Click);
			// 
			// mntsFilterAverageWrap
			// 
			this.mntsFilterAverageWrap.Name = "mntsFilterAverageWrap";
			this.mntsFilterAverageWrap.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterAverageWrap.Text = "Wrap Color";
			this.mntsFilterAverageWrap.Click += new System.EventHandler(this.mntsFilterAverageWrap_Click);
			// 
			// mntsFilterWeightedReplicate
			// 
			this.mntsFilterWeightedReplicate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsFilterWeightReplicate,
            this.mntsFilterWeightedWrap});
			this.mntsFilterWeightedReplicate.Name = "mntsFilterWeightedReplicate";
			this.mntsFilterWeightedReplicate.Size = new System.Drawing.Size(171, 22);
			this.mntsFilterWeightedReplicate.Text = "Weighted Average";
			// 
			// mntsFilterWeightReplicate
			// 
			this.mntsFilterWeightReplicate.Name = "mntsFilterWeightReplicate";
			this.mntsFilterWeightReplicate.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterWeightReplicate.Text = "Replicate Border";
			this.mntsFilterWeightReplicate.Click += new System.EventHandler(this.mntsFilterWeightReplicate_Click);
			// 
			// mntsFilterWeightedWrap
			// 
			this.mntsFilterWeightedWrap.Name = "mntsFilterWeightedWrap";
			this.mntsFilterWeightedWrap.Size = new System.Drawing.Size(160, 22);
			this.mntsFilterWeightedWrap.Text = "Wrap Color";
			this.mntsFilterWeightedWrap.Click += new System.EventHandler(this.mntsFilterWeightedWrap_Click);
			// 
			// filteringInTheFeToolStripMenuItem
			// 
			this.filteringInTheFeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsFilterLaplacian,
            this.mntsFilterSobel});
			this.filteringInTheFeToolStripMenuItem.Name = "filteringInTheFeToolStripMenuItem";
			this.filteringInTheFeToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
			this.filteringInTheFeToolStripMenuItem.Text = "Spatial Filtering 2";
			// 
			// mntsFilterLaplacian
			// 
			this.mntsFilterLaplacian.Name = "mntsFilterLaplacian";
			this.mntsFilterLaplacian.Size = new System.Drawing.Size(124, 22);
			this.mntsFilterLaplacian.Text = "Laplacian";
			this.mntsFilterLaplacian.Click += new System.EventHandler(this.mntsFilterLaplacian_Click);
			// 
			// mntsFilterSobel
			// 
			this.mntsFilterSobel.Name = "mntsFilterSobel";
			this.mntsFilterSobel.Size = new System.Drawing.Size(124, 22);
			this.mntsFilterSobel.Text = "Sobel";
			this.mntsFilterSobel.Click += new System.EventHandler(this.mntsFilterSobel_Click);
			// 
			// segmentationToolStripMenuItem
			// 
			this.segmentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsSegmentationPoint,
            this.lineDetectionToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem});
			this.segmentationToolStripMenuItem.Name = "segmentationToolStripMenuItem";
			this.segmentationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
			this.segmentationToolStripMenuItem.Text = "Segmentation";
			// 
			// mntsSegmentationPoint
			// 
			this.mntsSegmentationPoint.Name = "mntsSegmentationPoint";
			this.mntsSegmentationPoint.Size = new System.Drawing.Size(156, 22);
			this.mntsSegmentationPoint.Text = "Point Detection";
			this.mntsSegmentationPoint.Click += new System.EventHandler(this.mntsSegmentationPoint_Click);
			// 
			// lineDetectionToolStripMenuItem
			// 
			this.lineDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
			this.lineDetectionToolStripMenuItem.Name = "lineDetectionToolStripMenuItem";
			this.lineDetectionToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.lineDetectionToolStripMenuItem.Text = "Line Detection";
			// 
			// horizontalToolStripMenuItem
			// 
			this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
			this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.horizontalToolStripMenuItem.Text = "Horizontal";
			this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
			// 
			// verticalToolStripMenuItem
			// 
			this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
			this.verticalToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.verticalToolStripMenuItem.Text = "Vertical";
			this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(129, 22);
			this.toolStripMenuItem3.Text = "+45";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(129, 22);
			this.toolStripMenuItem4.Text = "-45";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// edgeDetectionToolStripMenuItem
			// 
			this.edgeDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prewittToolStripMenuItem,
            this.sobelToolStripMenuItem});
			this.edgeDetectionToolStripMenuItem.Name = "edgeDetectionToolStripMenuItem";
			this.edgeDetectionToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.edgeDetectionToolStripMenuItem.Text = "Edge Detection";
			// 
			// prewittToolStripMenuItem
			// 
			this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
			this.prewittToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.prewittToolStripMenuItem.Text = "Prewitt";
			this.prewittToolStripMenuItem.Click += new System.EventHandler(this.prewittToolStripMenuItem_Click);
			// 
			// sobelToolStripMenuItem
			// 
			this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
			this.sobelToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.sobelToolStripMenuItem.Text = "Sobel";
			this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
			// 
			// morphologyToolStripMenuItem
			// 
			this.morphologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntsMorphologyErosion,
            this.mntsMorphologyDilation,
            this.openingToolStripMenuItem,
            this.closingToolStripMenuItem,
            this.boundaryExtractionToolStripMenuItem,
            this.regionFillingToolStripMenuItem});
			this.morphologyToolStripMenuItem.Name = "morphologyToolStripMenuItem";
			this.morphologyToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
			this.morphologyToolStripMenuItem.Text = "Morphology";
			// 
			// mntsMorphologyErosion
			// 
			this.mntsMorphologyErosion.Name = "mntsMorphologyErosion";
			this.mntsMorphologyErosion.Size = new System.Drawing.Size(180, 22);
			this.mntsMorphologyErosion.Text = "Erosion";
			this.mntsMorphologyErosion.Click += new System.EventHandler(this.mntsMorphologyErosion_Click);
			// 
			// mntsMorphologyDilation
			// 
			this.mntsMorphologyDilation.Name = "mntsMorphologyDilation";
			this.mntsMorphologyDilation.Size = new System.Drawing.Size(180, 22);
			this.mntsMorphologyDilation.Text = "Dilation";
			this.mntsMorphologyDilation.Click += new System.EventHandler(this.mntsMorphologyDilation_Click);
			// 
			// openingToolStripMenuItem
			// 
			this.openingToolStripMenuItem.Name = "openingToolStripMenuItem";
			this.openingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openingToolStripMenuItem.Text = "Opening";
			this.openingToolStripMenuItem.Click += new System.EventHandler(this.openingToolStripMenuItem_Click);
			// 
			// closingToolStripMenuItem
			// 
			this.closingToolStripMenuItem.Name = "closingToolStripMenuItem";
			this.closingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.closingToolStripMenuItem.Text = "Closing";
			this.closingToolStripMenuItem.Click += new System.EventHandler(this.closingToolStripMenuItem_Click);
			// 
			// boundaryExtractionToolStripMenuItem
			// 
			this.boundaryExtractionToolStripMenuItem.Name = "boundaryExtractionToolStripMenuItem";
			this.boundaryExtractionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.boundaryExtractionToolStripMenuItem.Text = "Boundary Extraction";
			this.boundaryExtractionToolStripMenuItem.Click += new System.EventHandler(this.boundaryExtractionToolStripMenuItem_Click);
			// 
			// moreToolStripMenuItem
			// 
			this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
			this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
			this.moreToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.moreToolStripMenuItem.Text = "More";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
			this.toolStripMenuItem2.Text = "<------------------------";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// splitContainerImage
			// 
			this.splitContainerImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerImage.Location = new System.Drawing.Point(0, 24);
			this.splitContainerImage.Name = "splitContainerImage";
			// 
			// splitContainerImage.Panel1
			// 
			this.splitContainerImage.Panel1.Controls.Add(this.pbSource);
			// 
			// splitContainerImage.Panel2
			// 
			this.splitContainerImage.Panel2.Controls.Add(this.pbDest);
			this.splitContainerImage.Size = new System.Drawing.Size(800, 426);
			this.splitContainerImage.SplitterDistance = 396;
			this.splitContainerImage.TabIndex = 1;
			// 
			// pbSource
			// 
			this.pbSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbSource.Location = new System.Drawing.Point(0, 0);
			this.pbSource.Name = "pbSource";
			this.pbSource.Size = new System.Drawing.Size(396, 426);
			this.pbSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbSource.TabIndex = 0;
			this.pbSource.TabStop = false;
			this.pbSource.DoubleClick += new System.EventHandler(this.pbSource_DoubleClick);
			// 
			// pbDest
			// 
			this.pbDest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbDest.Location = new System.Drawing.Point(0, 0);
			this.pbDest.Name = "pbDest";
			this.pbDest.Size = new System.Drawing.Size(400, 426);
			this.pbDest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbDest.TabIndex = 0;
			this.pbDest.TabStop = false;
			// 
			// regionFillingToolStripMenuItem
			// 
			this.regionFillingToolStripMenuItem.Name = "regionFillingToolStripMenuItem";
			this.regionFillingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.regionFillingToolStripMenuItem.Text = "Region Filling";
			this.regionFillingToolStripMenuItem.Click += new System.EventHandler(this.regionFillingToolStripMenuItem_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.splitContainerImage);
			this.Controls.Add(this.MenuBar);
			this.MainMenuStrip = this.MenuBar;
			this.Name = "frmMain";
			this.Text = "Processing Image";
			this.MenuBar.ResumeLayout(false);
			this.MenuBar.PerformLayout();
			this.splitContainerImage.Panel1.ResumeLayout(false);
			this.splitContainerImage.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerImage)).EndInit();
			this.splitContainerImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDest)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsHistogramDrawLeft;
        private System.Windows.Forms.ToolStripMenuItem mntsHistogramDrawRight;
        private System.Windows.Forms.ToolStripMenuItem mntsHistogramEqua;
        private System.Windows.Forms.ToolStripMenuItem tranformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsTransformationsNegative;
        private System.Windows.Forms.ToolStripMenuItem mntsTransformationsLogarithmic;
        private System.Windows.Forms.ToolStripMenuItem mntsTransformationsPower;
        private System.Windows.Forms.ToolStripMenuItem mntsTransformationsBitPlane;
        private System.Windows.Forms.ToolStripMenuItem mntsTransformationsGrayLevel;
        private System.Windows.Forms.ToolStripMenuItem filteringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterMaxReplicate;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterMaxWrap;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterMinReplicate;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterMinWrap;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterMedianReplicate;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterMedianWrap;
        private System.Windows.Forms.ToolStripMenuItem averageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterAverageReplicate;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterAverageWrap;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterWeightedReplicate;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterWeightReplicate;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterWeightedWrap;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainerImage;
        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbDest;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filteringInTheFeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterLaplacian;
        private System.Windows.Forms.ToolStripMenuItem mntsFilterSobel;
        private System.Windows.Forms.ToolStripMenuItem segmentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntsSegmentationPoint;
		private System.Windows.Forms.ToolStripMenuItem lineDetectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem morphologyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mntsMorphologyErosion;
		private System.Windows.Forms.ToolStripMenuItem mntsMorphologyDilation;
		private System.Windows.Forms.ToolStripMenuItem openingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem boundaryExtractionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem regionFillingToolStripMenuItem;
	}
}

