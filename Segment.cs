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
        // Вершины отрезка
        public Point p1, p2;
        // конструктор класса
        public Segment()
        {
            p1 = new Point(-1, -1);
            p2 = new Point(-1, -1);
        }
        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="firstPoint">Первая точка</param>
        /// <param name="secondPoint">Вторая точка</param>
        public Segment(Point firstPoint, Point secondPoint)
		{
            p1 = firstPoint;
            p2 = secondPoint;
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
            p1 = new Point(xf, yf);
            p2 = new Point(xs, ys);
        }
        /// <summary>
        /// Перегрузка оператора ==
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Segment s1, Segment s2)
        {
            if  ( (s1.p1 == s2.p1) && (s1.p2 == s2.p2) )
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
            if ( (s1.p1 != s2.p1) || (s1.p2 != s2.p2) )
            {
                return true;
            }
            return false;
        }
        public void SetPoint(int xf, int yf, int xs, int ys)
		{
            p1.X = xf;
            p1.Y = yf;
            p2.X = xs;
            p2.Y = ys;
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
            int v1 = VectorMult(seg2.p2.X - seg2.p1.X, seg2.p2.Y - seg2.p1.Y, seg1.p1.X - seg2.p1.X, seg1.p1.Y - seg2.p1.Y);
            int v2 = VectorMult(seg2.p2.X - seg2.p1.X, seg2.p2.Y - seg2.p1.Y, seg1.p2.X - seg2.p1.X, seg1.p2.Y - seg2.p1.Y);
            int v3 = VectorMult(seg1.p2.X - seg1.p1.X, seg1.p2.Y - seg1.p1.Y, seg2.p1.X - seg1.p1.X, seg2.p1.Y - seg1.p1.Y);
            int v4 = VectorMult(seg1.p2.X - seg1.p1.X, seg1.p2.Y - seg1.p1.Y, seg2.p2.X - seg1.p1.X, seg2.p2.Y - seg1.p1.Y);
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
            int a1 = seg1.p2.Y - seg1.p1.Y;
            int b1 = seg1.p1.X - seg1.p2.X;
            int c1 = -seg1.p1.X * (seg1.p2.Y - seg1.p1.Y) + seg1.p1.Y * (seg1.p2.X - seg1.p1.X);
            int a2 = seg2.p2.Y - seg2.p1.Y;
            int b2 = seg2.p1.X - seg2.p2.X;
            int c2 = -seg2.p1.X * (seg2.p2.Y - seg2.p1.Y) + seg2.p1.Y * (seg2.p2.X - seg2.p1.X);
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
            double angle = Math.Atan2((double)seg.p2.Y - (double)seg.p1.Y, (double)seg.p2.X - (double)seg.p1.X);
            angle = Math.Abs((angle * 180) / Math.PI);
            return angle;
        }
    }
}
