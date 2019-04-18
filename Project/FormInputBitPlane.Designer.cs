namespace Project
{
    partial class FormInputBitPlane
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
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtValue3
            // 
            this.txtValue3.Location = new System.Drawing.Point(180, 226);
            this.txtValue3.Margin = new System.Windows.Forms.Padding(11);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Size = new System.Drawing.Size(171, 30);
            this.txtValue3.TabIndex = 12;
            this.txtValue3.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 229);
            this.label3.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Input level 3:";
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(180, 151);
            this.txtValue2.Margin = new System.Windows.Forms.Padding(11);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(171, 30);
            this.txtValue2.TabIndex = 10;
            this.txtValue2.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Input level 2:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(140, 281);
            this.btnOK.Margin = new System.Windows.Forms.Padding(11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(119, 46);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtValue1
            // 
            this.txtValue1.Location = new System.Drawing.Point(180, 76);
            this.txtValue1.Margin = new System.Windows.Forms.Padding(11);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(171, 30);
            this.txtValue1.TabIndex = 8;
            this.txtValue1.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Input level 1:";
            // 
            // InputBitPlaneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 403);
            this.Controls.Add(this.txtValue3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "InputBitPlaneForm";
            this.Text = "Input Bit Plane Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtValue3;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtValue2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtValue1;
        public System.Windows.Forms.Label label1;
    }
}