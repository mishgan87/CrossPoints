using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossPoints
{
	public partial class MainForm : Form
	{
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlCommandBuilder sqlBuilderCross = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlDataAdapter sqlDataAdapterCross = null;
        private DataSet dataSet = null;
        private DataSet dataSetCross = null;
        public MainForm()
		{
			InitializeComponent();
            ToolTip toolTipCustom = new ToolTip();
            toolTipCustom.AutoPopDelay = 5000;
            toolTipCustom.InitialDelay = 1000;
            toolTipCustom.ReshowDelay = 500;
            toolTipCustom.ShowAlways = true;
            toolTipCustom.SetToolTip(this.buttonSegColor, @"Цвет отрезков");
            toolTipCustom.SetToolTip(this.buttonCrossColor, @"Цвет пересечений");
            toolTipCustom.SetToolTip(this.buttonGenerate, @"Генерировать");
            toolTipCustom.SetToolTip(this.buttonReload, @"Обновить");
            toolTipCustom.SetToolTip(this.buttonSave, @"Сохранить");
        }
        /// <summary>
        /// Обновление pictureBox и отрисовка отрезков из dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
			Pen penSeg = new(buttonSegColor.BackColor, 2)
			{
				StartCap = LineCap.Flat,
				EndCap = LineCap.Flat
			};

			Pen penInter = new(buttonCrossColor.BackColor, 2)
			{
				StartCap = LineCap.Flat,
				EndCap = LineCap.Flat
			};

			for (int i = 0; i < dataGridSegment.Rows.Count - 1; i++)
            {
                string str = dataGridSegment[1, i].Value.ToString();
                string[] subs = str.Split(' ');
                Point p1 = new(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]));
                Point p2 = new(Convert.ToInt32(subs[2]), Convert.ToInt32(subs[3]));
                e.Graphics.DrawLine(penSeg, p1.X, p1.Y, p2.X, p2.Y);
            }

            for (int i = 0; i < dataGridCross.Rows.Count - 1; i++)
            {
                string str = dataGridCross[1, i].Value.ToString();
                string[] subs = str.Split(' ');
				Point p1 = new(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1]));
                Point p2 = new(Convert.ToInt32(subs[2]), Convert.ToInt32(subs[3]));
                e.Graphics.DrawLine(penInter, p1.X, p1.Y, p2.X, p2.Y);
            }
        }
        /// <summary>
        /// Заполнение DataGrid координатами отрезков
        /// </summary>
        /// <param name="dg">ссылка на DataGrid</param>
        /// <param name="seg">ссылка на массив отрезков</param>
        private void FillSegmentDataGridView(ref DataGridView dg, ref Segment[] seg, string title)
		{
            var dTable = new DataTable();
            dTable.Columns.Add("Id", typeof(int));
            dTable.Columns.Add(title, typeof(string));
            for (int i = 0; i < seg.Length; i++)
			{
                dTable.Rows.Add(i + 1, seg[i].p1.X.ToString() + " " + seg[i].p1.Y.ToString() + " " + 
                    seg[i].p2.X.ToString() + " " + seg[i].p2.Y.ToString());
            }
            dg.DataSource = dTable;
            dg.Update();
        }
        /// <summary>
        /// Визуализация массива отрезков и их пересечений на pictureBox
        /// </summary>
        /// <param name="segArray">Ссылка на массив отрезков</param>
        private void FindSegmentsArrayIntersections(ref Segment[] segArray)
		{
            List<Segment> inter = new();
            List<Point> cPoints = new();
            for (int i = 0; i < segArray.Length; i++)
            {
                for (int j = 0; j < segArray.Length; j++)
                {
                    if (i != j)
                    {
                        if (CrossPoints.Segment.SegmentsAreCrossing(ref segArray[i], ref segArray[j]))
                        {
                            Point cPoint = CrossPoints.Segment.CrossingPoint(ref segArray[i], ref segArray[j]);

                            if (!cPoints.Contains(cPoint))
                            {
                                cPoints.Add(cPoint);
                                double anglei = CrossPoints.Segment.AngleToOX(segArray[i]);
                                double anglej = CrossPoints.Segment.AngleToOX(segArray[j]);
                                if (anglei >= anglej)
                                {
                                    Point newPoint = new();
                                    newPoint.X = cPoint.X - (int)(40 * Math.Cos(anglei));
                                    newPoint.Y = cPoint.Y - (int)(40 * Math.Sin(anglei));
                                    if (newPoint.X < 0)
                                        newPoint.X = 0;
                                    if (newPoint.X > pictureBox.Width)
                                        newPoint.X = pictureBox.Width;
                                    if (newPoint.Y < 0)
                                        newPoint.Y = 0;
                                    if (newPoint.Y > pictureBox.Height)
                                        newPoint.Y = pictureBox.Height;
                                    inter.Add(new Segment(segArray[i].p1.X, segArray[i].p1.Y, newPoint.X, newPoint.Y));
                                    newPoint.X = cPoint.X + (int)(40 * Math.Cos(anglei));
                                    newPoint.Y = cPoint.Y + (int)(40 * Math.Sin(anglei));
                                    if (newPoint.X < 0)
                                        newPoint.X = 0;
                                    if (newPoint.X > pictureBox.Width)
                                        newPoint.X = pictureBox.Width;
                                    if (newPoint.Y < 0)
                                        newPoint.Y = 0;
                                    if (newPoint.Y > pictureBox.Height)
                                        newPoint.Y = pictureBox.Height;
                                    inter.Add(new Segment(newPoint.X, newPoint.Y, segArray[i].p2.X, segArray[i].p2.Y));

                                    // SegmentsForDelete.Add(Segments[i]);
                                }
                                else
                                {
                                    Point newPoint = new();
                                    newPoint.X = cPoint.X - (int)(40 * Math.Cos(anglej));
                                    newPoint.Y = cPoint.Y - (int)(40 * Math.Sin(anglej));
                                    if (newPoint.X < 0)
                                        newPoint.X = 0;
                                    if (newPoint.X > pictureBox.Width)
                                        newPoint.X = pictureBox.Width;
                                    if (newPoint.Y < 0)
                                        newPoint.Y = 0;
                                    if (newPoint.Y > pictureBox.Height)
                                        newPoint.Y = pictureBox.Height;
                                    inter.Add(new Segment(segArray[j].p1.X, segArray[j].p1.Y, newPoint.X, newPoint.Y));
                                    newPoint.X = cPoint.X + (int)(40 * Math.Cos(anglej));
                                    newPoint.Y = cPoint.Y + (int)(40 * Math.Sin(anglej));
                                    if (newPoint.X < 0)
                                        newPoint.X = 0;
                                    if (newPoint.X > pictureBox.Width)
                                        newPoint.X = pictureBox.Width;
                                    if (newPoint.Y < 0)
                                        newPoint.Y = 0;
                                    if (newPoint.Y > pictureBox.Height)
                                        newPoint.Y = pictureBox.Height;
                                    inter.Add(new Segment(newPoint.X, newPoint.Y, segArray[j].p2.X, segArray[j].p2.Y));

                                    // SegmentsForDelete.Add(Segments[j]);
                                }
                            }
                        }
                    }
                }
            }
            /*
            for (int i = 0; i < Segments.Count; i++)
            {
                if (SegmentsForDelete.Contains(Segments[i]))
                {
                    Segments.RemoveAt(i);
                }
            }
            */
            // Segment[] cross = inter.Distinct().ToList().ToArray();
            Segment[] cross = inter.ToArray();
            FillSegmentDataGridView(ref dataGridCross, ref cross, @"Пересечения");

            pictureBox.Refresh();
        }
        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            // pictureBox.Height = this.Height - 20;
            // pictureBox.Width = this.Width - buttonGenerate.Width - 20;
        }
        private void ReloadDataFromDB()
        {
            try
            {
                dataSet.Tables["Отрезки"].Clear();
                sqlDataAdapter.Fill(dataSet, "Отрезки");
                dataGridSegment.DataSource = dataSet.Tables["Отрезки"];
                dataSetCross.Tables["Пересечения"].Clear();
                sqlDataAdapterCross.Fill(dataSetCross, "Пересечения");
                dataGridCross.DataSource = dataSetCross.Tables["Пересечения"];
                int count = dataGridSegment.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataFromDB()
		{
			try
			{
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Отрезки", sqlConnection);
                
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Отрезки");

                dataGridSegment.DataSource = dataSet.Tables["Отрезки"];

                sqlDataAdapterCross = new SqlDataAdapter("SELECT * FROM Пересечения", sqlConnection);

                sqlBuilderCross = new SqlCommandBuilder(sqlDataAdapterCross);
                sqlBuilderCross.GetInsertCommand();
                sqlBuilderCross.GetUpdateCommand();
                sqlBuilderCross.GetDeleteCommand();

                dataSetCross = new DataSet();
                sqlDataAdapterCross.Fill(dataSetCross, "Пересечения");

                dataGridCross.DataSource = dataSetCross.Tables["Пересечения"];

                int count = dataGridSegment.Rows.Count - 1;
            }
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        // private async void MainForm_Load(object sender, EventArgs e)
        private void MainForm_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\Users\Rachkov\Source\Repos\CrossPoints\SegDB.mdf; Integrated Security = True";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            LoadDataFromDB();
        }
		private void ButtonSegColor_Click(object sender, EventArgs e)
		{
            ColorDialog cd = new();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = buttonSegColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonSegColor.BackColor = cd.Color;
                pictureBox.Refresh();
            }
        }

		private void ButtonCrossColor_Click(object sender, EventArgs e)
		{
            ColorDialog cd = new();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = buttonCrossColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                buttonCrossColor.BackColor = cd.Color;
                pictureBox.Refresh();
            }
        }

		private void ButtonGenerate_Click(object sender, EventArgs e)
		{
            /*
                        using (StreamWriter sw = new StreamWriter(@".\settings.txt"))
                        {
                            sw.WriteLine(pictureBox.Width.ToString() + " " + pictureBox.Height.ToString() + " " + segmentCount.Text);
                            sw.WriteLine(segmentColor.BackColor.ToString());
                            sw.WriteLine(intersectionColor.BackColor.ToString());
                            sw.Flush();
                        };
                        */
            var countStr = Microsoft.VisualBasic.Interaction.InputBox("Введите количество отрезков", "Количество отрезков", "1");
            if (countStr.Length == 0)
            {
                return;
            }
            // проверка является ли числом содержимое текстбокса
            bool isNumber = true;
            for (int i = 0; i < countStr.Length; i++)
            {
                bool isDigit = false;
                for (int j = 0; j < 9; j++)
                {
                    if (countStr.Substring(i, 1) == j.ToString())
                    {
                        isDigit = true;
                        break;
                    }
                }
                if (!isDigit)
                {
                    isNumber = false;
                    break;
                }
            }
            if (!isNumber)
            {
                return;
            }
            // генерируем список отрезков в дипазоне границ pictureBox
            Random rnd = new();
            int xmax = pictureBox.Width;
            int ymax = pictureBox.Height;
            int count = Convert.ToInt32(countStr);
            // массив отрезков
            Segment[] seg = new Segment[count];
            for (int i = 0; i < count; i++)
            {
                // получаем случайные точки в дипазоне границ pictureBox
                int x1 = rnd.Next(0, xmax);
                int x2 = rnd.Next(0, xmax);
                int y1 = rnd.Next(0, ymax);
                int y2 = rnd.Next(0, ymax);
                // расставим точки по порядку x1 <= x2
                if (x2 < x1)
                {
                    int x = x1;
                    x1 = x2;
                    x2 = x;
                    int y = y1;
                    y1 = y2;
                    y2 = y;
                }
                seg[i] = new Segment(x1, y1, x2, y2);
            }
            FillSegmentDataGridView(ref dataGridSegment, ref seg, @"Отрезки");
            FindSegmentsArrayIntersections(ref seg);
        }

		private void ButtonSave_Click(object sender, EventArgs e)
		{

            dataSet.Tables["Отрезки"].Clear();
            dataSetCross.Tables["Пересечения"].Clear();

            // dataSet.Tables["Отрезки"].Rows.Clear();
            // dataSetCross.Tables["Пересечения"].Rows.Clear();

            for (int i = 0; i < dataGridSegment.Rows.Count - 1; i++)
            {
                dataSet.Tables["Отрезки"].Rows.Add(i + 1, dataGridSegment.Rows[i].Cells["Отрезки"].Value);
            }

            for (int i = 0; i < dataGridCross.Rows.Count - 1; i++)
            {
                dataSetCross.Tables["Пересечения"].Rows.Add(i + 1, dataGridCross.Rows[i].Cells["Пересечения"].Value);
            }

            sqlDataAdapter.Update(dataSet, "Отрезки");
            sqlDataAdapterCross.Update(dataSetCross, "Пересечения");
        }
	}
}
