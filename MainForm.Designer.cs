
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
			this.buttonGenerate = new System.Windows.Forms.Button();
			this.dataGridSegment = new System.Windows.Forms.DataGridView();
			this.dataGridCross = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.segmentCount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.intersectionColor = new System.Windows.Forms.Button();
			this.segmentColor = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridSegment)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCross)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonGenerate
			// 
			this.buttonGenerate.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.buttonGenerate.Location = new System.Drawing.Point(7, 120);
			this.buttonGenerate.Name = "buttonGenerate";
			this.buttonGenerate.Size = new System.Drawing.Size(289, 37);
			this.buttonGenerate.TabIndex = 0;
			this.buttonGenerate.Text = "Генерировать";
			this.buttonGenerate.UseVisualStyleBackColor = true;
			this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
			// 
			// dataGridSegment
			// 
			this.dataGridSegment.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridSegment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridSegment.Location = new System.Drawing.Point(7, 186);
			this.dataGridSegment.Name = "dataGridSegment";
			this.dataGridSegment.RowTemplate.Height = 23;
			this.dataGridSegment.Size = new System.Drawing.Size(289, 246);
			this.dataGridSegment.TabIndex = 2;
			// 
			// dataGridCross
			// 
			this.dataGridCross.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGridCross.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridCross.Location = new System.Drawing.Point(7, 461);
			this.dataGridCross.Name = "dataGridCross";
			this.dataGridCross.RowTemplate.Height = 23;
			this.dataGridCross.Size = new System.Drawing.Size(289, 197);
			this.dataGridCross.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(7, 160);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Отрезки";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(7, 435);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Пересечения";
			// 
			// segmentCount
			// 
			this.segmentCount.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.segmentCount.Location = new System.Drawing.Point(217, 12);
			this.segmentCount.Name = "segmentCount";
			this.segmentCount.Size = new System.Drawing.Size(79, 30);
			this.segmentCount.TabIndex = 26;
			this.segmentCount.Text = "5";
			this.segmentCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(48, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(163, 23);
			this.label4.TabIndex = 24;
			this.label4.Text = "Цвет пересечений";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(79, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 23);
			this.label1.TabIndex = 23;
			this.label1.Text = "Цвет отрезков";
			// 
			// intersectionColor
			// 
			this.intersectionColor.BackColor = System.Drawing.Color.Red;
			this.intersectionColor.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.intersectionColor.Location = new System.Drawing.Point(217, 48);
			this.intersectionColor.Name = "intersectionColor";
			this.intersectionColor.Size = new System.Drawing.Size(79, 30);
			this.intersectionColor.TabIndex = 22;
			this.intersectionColor.UseVisualStyleBackColor = false;
			this.intersectionColor.Click += new System.EventHandler(this.intersectionColor_Click);
			// 
			// segmentColor
			// 
			this.segmentColor.BackColor = System.Drawing.Color.Blue;
			this.segmentColor.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.segmentColor.Location = new System.Drawing.Point(217, 84);
			this.segmentColor.Name = "segmentColor";
			this.segmentColor.Size = new System.Drawing.Size(79, 30);
			this.segmentColor.TabIndex = 21;
			this.segmentColor.UseVisualStyleBackColor = false;
			this.segmentColor.Click += new System.EventHandler(this.segmentColor_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label7.Location = new System.Drawing.Point(23, 12);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(188, 23);
			this.label7.TabIndex = 17;
			this.label7.Text = "Количество отрезков";
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.Location = new System.Drawing.Point(303, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(504, 646);
			this.pictureBox.TabIndex = 10;
			this.pictureBox.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 666);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.segmentCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.intersectionColor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.segmentColor);
			this.Controls.Add(this.dataGridCross);
			this.Controls.Add(this.buttonGenerate);
			this.Controls.Add(this.dataGridSegment);
			this.Name = "MainForm";
			this.Text = "Пересечения отрезков";
			((System.ComponentModel.ISupportInitialize)(this.dataGridSegment)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridCross)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonGenerate;
		private System.Windows.Forms.DataGridView dataGridSegment;
		private System.Windows.Forms.DataGridView dataGridCross;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox segmentCount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button intersectionColor;
		private System.Windows.Forms.Button segmentColor;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}

