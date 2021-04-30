using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CrossPoints
{
    /// <summary>
    /// Класс, описывающий отрезок на плоскости XY
    /// </summary>
    class Segment
    {
        // координаты вершин отрезка
        public int x1, x2, y1, y2;
        // конструктор класса
        public Segment()
        {
            x1 = x2 = y1 = y2 = -1;
        }
        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="xf">Координата по оси OX первой точки</param>
        /// <param name="yf">Координата по оси OY первой точки</param>
        /// <param name="xs">Координата по оси OX второй точки</param>
        /// <param name="ys">Координата по оси OY второй точки</param>
        public Segment(int xf, int yf, int xs, int ys)
        {
            x1 = xf;
            x2 = xs;
            y1 = yf;
            y2 = ys;
        }
        /// <summary>
        /// Перегрузка оператора ==
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Segment s1, Segment s2)
        {
            if  ( (s1.x1 == s2.x1) && (s1.x2 == s2.x2) && (s1.y1 == s2.y1) && (s1.y2 == s2.y2) )
			{
                return true;
			}
            return false;
        }
        /// <summary>
        /// Перегрузка оператора !=
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Segment s1, Segment s2)
        {
            if ((s1.x1 != s2.x1) || (s1.x2 != s2.x2) || (s1.y1 != s2.y1) || (s1.y2 != s2.y2))
            {
                return true;
            }
            return false;
        }
        public void SetPoint(int xf, int yf, int xs, int ys)
		{
            x1 = xf;
            x2 = xs;
            y1 = yf;
            y2 = ys;
        }
        /// <summary>
        /// векторное произведение
        /// </summary>
        /// <param name="ax"></param>
        /// <param name="ay"></param>
        /// <param name="bx"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        static int VectorMult(int ax, int ay, int bx, int by)
        {
            return ax * by - bx * ay;
        }
        public static bool SegmentsAreCrossing(ref Segment seg1, ref Segment seg2)
        {
            int v1 = VectorMult(seg2.x2 - seg2.x1, seg2.y2 - seg2.y1, seg1.x1 - seg2.x1, seg1.y1 - seg2.y1);
            int v2 = VectorMult(seg2.x2 - seg2.x1, seg2.y2 - seg2.y1, seg1.x2 - seg2.x1, seg1.y2 - seg2.y1);
            int v3 = VectorMult(seg1.x2 - seg1.x1, seg1.y2 - seg1.y1, seg2.x1 - seg1.x1, seg2.y1 - seg1.y1);
            int v4 = VectorMult(seg1.x2 - seg1.x1, seg1.y2 - seg1.y1, seg2.x2 - seg1.x1, seg2.y2 - seg1.y1);
            if ((v1 * v2) < 0 && (v3 * v4) < 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Возвращает точку пересечения отрезков
        /// </summary>
        /// <param name="seg1">Отрезок 1</param>
        /// <param name="seg2">Отрезок 2</param>
        /// <returns></returns>
        public static Point CrossingPoint(ref Segment seg1, ref Segment seg2)
        {
            int a1 = seg1.y2 - seg1.y1;
            int b1 = seg1.x1 - seg1.x2;
            int c1 = -seg1.x1 * (seg1.y2 - seg1.y1) + seg1.y1 * (seg1.x2 - seg1.x1);
            int a2 = seg2.y2 - seg2.y1;
            int b2 = seg2.x1 - seg2.x2;
            int c2 = -seg2.x1 * (seg2.y2 - seg2.y1) + seg2.y1 * (seg2.x2 - seg2.x1);
            double d = (double)(a1 * b2 - b1 * a2);
            double dx = (double)(-c1 * b2 + b1 * c2);
            double dy = (double)(-a1 * c2 + c1 * a2);
            int x = (int)(dx / d);
            int y = (int)(dy / d);
            return new Point(x, y);
        }
        /// <summary>
        /// Угол наклона отрезка к оси OX
        /// </summary>
        /// <param name="seg">Отрезок</param>
        /// <returns>Возвращает угол в градусах</returns>
        public static double AngleToOX(Segment seg)
        {
            double angle = Math.Atan2((double)seg.y2 - (double)seg.y1, (double)seg.x2 - (double)seg.x1);
            angle = Math.Abs((angle * 180) / Math.PI);
            return angle;
        }
    }
}
