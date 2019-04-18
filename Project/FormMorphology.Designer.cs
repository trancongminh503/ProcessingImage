namespace Project
{
	partial class FormMorphology
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtMatrixSize = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtObjectColor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(151, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Repeat number:";
			// 
			// txtMatrixSize
			// 
			this.txtMatrixSize.Location = new System.Drawing.Point(209, 88);
			this.txtMatrixSize.Name = "txtMatrixSize";
			this.txtMatrixSize.Size = new System.Drawing.Size(136, 30);
			this.txtMatrixSize.TabIndex = 1;
			this.txtMatrixSize.Enter += new System.EventHandler(this.txtMatrixSize_Enter);
			this.txtMatrixSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatrixSize_KeyDown);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(160, 207);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(103, 47);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtObjectColor
			// 
			this.txtObjectColor.Location = new System.Drawing.Point(209, 125);
			this.txtObjectColor.Name = "txtObjectColor";
			this.txtObjectColor.Size = new System.Drawing.Size(136, 30);
			this.txtObjectColor.TabIndex = 3;
			this.txtObjectColor.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 25);
			this.label2.TabIndex = 4;
			this.label2.Text = "Object color:";
			// 
			// FormMorphology
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(391, 279);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtObjectColor);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtMatrixSize);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "FormMorphology";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MorphologyForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.TextBox txtMatrixSize;
		public System.Windows.Forms.TextBox txtObjectColor;
		private System.Windows.Forms.Label label2;
	}
}