
namespace CrossPoints
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dataGridSegment = new System.Windows.Forms.DataGridView();
			this.dataGridCross = new System.Windows.Forms.DataGridView();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.buttonCrossColor = new System.Windows.Forms.Button();
			this.buttonSegColor = new System.Windows.Forms.Button();
			this.buttonReload = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSegment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCross)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridSegment
			// 
			this.dataGridSegment.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridSegment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridSegment.Location = new System.Drawing.Point(53, 9);
			this.dataGridSegment.Name = "dataGridSegment";
			this.dataGridSegment.RowTemplate.Height = 23;
			this.dataGridSegment.Size = new System.Drawing.Size(282, 241);
			this.dataGridSegment.TabIndex = 2;
			// 
			// dataGridCross
			// 
			this.dataGridCross.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridCross.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridCross.Location = new System.Drawing.Point(53, 256);
			this.dataGridCross.Name = "dataGridCross";
			this.dataGridCross.RowTemplate.Height = 23;
			this.dataGridCross.Size = new System.Drawing.Size(282, 246);
			this.dataGridCross.TabIndex = 3;
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.Location = new System.Drawing.Point(341, 8);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(461, 494);
			this.pictureBox.TabIndex = 10;
			this.pictureBox.TabStop = false;
			this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerate.Image")));
			this.buttonGenerate.Location = new System.Drawing.Point(9, 97);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(38, 38);
			this.buttonGenerate.TabIndex = 32;
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
			// 
			// buttonCrossColor
			// 
			this.buttonCrossColor.BackColor = System.Drawing.Color.Red;
			this.buttonCrossColor.Location = new System.Drawing.Point(9, 185);
			this.buttonCrossColor.Name = "buttonCrossColor";
			this.buttonCrossColor.Size = new System.Drawing.Size(38, 38);
			this.buttonCrossColor.TabIndex = 33;
			this.buttonCrossColor.UseVisualStyleBackColor = false;
			this.buttonCrossColor.Click += new System.EventHandler(this.ButtonCrossColor_Click);
			// 
			// buttonSegColor
			// 
			this.buttonSegColor.BackColor = System.Drawing.Color.Blue;
			this.buttonSegColor.Location = new System.Drawing.Point(9, 141);
			this.buttonSegColor.Name = "buttonSegColor";
			this.buttonSegColor.Size = new System.Drawing.Size(38, 38);
			this.buttonSegColor.TabIndex = 35;
			this.buttonSegColor.UseVisualStyleBackColor = false;
			this.buttonSegColor.Click += new System.EventHandler(this.ButtonSegColor_Click);
			// 
			// buttonReload
			// 
			this.buttonReload.Image = ((System.Drawing.Image)(resources.GetObject("buttonReload.Image")));
			this.buttonReload.Location = new System.Drawing.Point(9, 9);
			this.buttonReload.Name = "buttonReload";
			this.buttonReload.Size = new System.Drawing.Size(38, 38);
			this.buttonReload.TabIndex = 36;
			this.buttonReload.UseVisualStyleBackColor = true;
			// 
			// buttonSave
			// 
			this.buttonSave.AutoSize = true;
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.Location = new System.Drawing.Point(9, 53);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(38, 38);
			this.buttonSave.TabIndex = 37;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 553);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonReload);
			this.Controls.Add(this.buttonSegColor);
			this.Controls.Add(this.buttonCrossColor);
			this.Controls.Add(this.buttonGenerate);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.dataGridCross);
			this.Controls.Add(this.dataGridSegment);
			this.Name = "MainForm";
			this.Text = "Пересечения отрезков";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridSegment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCross)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.DataGridView dataGridSegment;
		private System.Windows.Forms.DataGridView dataGridCross;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.Button buttonCrossColor;
		private System.Windows.Forms.Button buttonSegColor;
		private System.Windows.Forms.Button buttonReload;
		private System.Windows.Forms.Button buttonSave;
	}
}

