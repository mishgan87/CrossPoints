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
        public MainForm()
		{
			InitializeComponent();
		}
        /// <summary>
        /// Заполнение DataGrid координатами отрезков
        /// </summary>
        /// <param name="dg">ссылка на DataGrid</param>
        /// <param name="seg">ссылка на массив отрезков</param>
        private void FillSegmentDataGridView(ref DataGridView dg, ref Segment[] seg)
		{
            var dTable = new DataTable();
            dTable.Columns.Add("Id", typeof(int));
            dTable.Columns.Add("Отрезок", typeof(string));
            for (int i = 0; i < seg.Length; i++)
			{
                dTable.Rows.Add(i + 1, "( " + seg[i].x1.ToString() + ", " + seg[i].y1.ToString() + " , " + 
                    seg[i].x1.ToString() + ", " + seg[i].y1.ToString() + " )");
            }
            dg.DataSource = dTable;
            dg.Update();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Генерировать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void buttonGenerate_Click(object sender, EventArgs e)
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
            if (segmentCount.Text.Length == 0)
			{
                return;
			}
            // проверка является ли числом содержимое текстбокса
            bool isNumber = true;
            for (int i = 0; i < segmentCount.Text.Length; i++)
			{
                bool isDigit = false;
                for (int j = 0; j < 9; j++)
				{
                    if (segmentCount.Text.Substring(i, 1) == j.ToString())
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
            Random rnd = new Random();
            int xmax = pictureBox.Width;
            int ymax = pictureBox.Height;
            int count = Convert.ToInt32(segmentCount.Text);
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
            FillSegmentDataGridView(ref dataGridSegment, ref seg);
            FindSegmentsArrayIntersections(ref seg);
        }
        /// <summary>
        /// Визуализация массива отрезков и их пересечений на pictureBox
        /// </summary>
        /// <param name="segArray">Ссылка на массив отрезков</param>
        private void FindSegmentsArrayIntersections(ref Segment[] segArray)
		{
            List<Segment> inter = new List<Segment>();
            List<Point> cPoints = new List<Point>();
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
                                    inter.Add(new Segment(segArray[i].x1, segArray[i].y1, 
                                        cPoint.X - (int)(2 * Math.Cos(anglei)), cPoint.Y - (int)(2 * Math.Sin(anglei))));

                                    inter.Add(new Segment(segArray[i].x1, segArray[i].y1,
                                        cPoint.X + (int)(2 * Math.Cos(anglei)), cPoint.Y + (int)(2 * Math.Sin(anglei))));

                                    // SegmentsForDelete.Add(Segments[i]);
                                }
                                else
                                {
                                    inter.Add(new Segment(segArray[j].x1, segArray[j].y1,
                                        cPoint.X - (int)(2 * Math.Cos(anglej)), cPoint.Y - (int)(2 * Math.Sin(anglej))));

                                    inter.Add(new Segment(segArray[j].x1, segArray[j].y1,
                                        cPoint.X + (int)(2 * Math.Cos(anglej)), cPoint.Y + (int)(2 * Math.Sin(anglej))));

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
            FillSegmentDataGridView(ref dataGridCross, ref cross);
        }
		private void buttonApply_Click(object sender, EventArgs e)
		{
            
        }

		private void segmentColor_Click(object sender, EventArgs e)
		{
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = segmentColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
                segmentColor.BackColor = cd.Color;
        }

		private void intersectionColor_Click(object sender, EventArgs e)
		{
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = false;
            cd.ShowHelp = true;
            cd.Color = intersectionColor.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
                intersectionColor.BackColor = cd.Color;
        }
	}
}
