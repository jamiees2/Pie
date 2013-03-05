using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysMath = System.Math;

namespace Pie.Math.Geometry
{
    /// <summary>
    /// Contains geometry formulas for most of the concievable 2D shapes
    /// </summary>
    public class Geometry2D
    {
        #region Triangles
        /// <summary>
        /// Calculates the area of the triangle, given the width and height of the triangle
        /// </summary>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <returns>The area of a triangle with width b, and height h</returns>
        public static double TriangleArea(double b, double h)
        {
            return 0.5 * b * h;
        }

        /// <summary>
        /// The Area of a triangle, given all the sides of the triangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>The area of a triangle given the sides a, b and c</returns>
        public static double TriangleArea(double a, double b, double c)
        {
            double s = TrianglePerimeter(a, b, c) / 2;
            return SysMath.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        /// <summary>
        /// The area of an equilateral triangle, given the length of one side
        /// </summary>
        /// <param name="a"></param>
        /// <returns>The area of an equilateral triangle given the sides a</returns>
        public static double TriangleArea(double a)
        {
            return (SysMath.Sqrt(3) / 4) * SysMath.Pow(a, 2);
        }

        /// <summary>
        /// The perimeter of a triangle given the sides a, b and c
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>The perimeter of the given triangle</returns>
        public static double TrianglePerimeter(double a, double b, double c)
        {
            return a + b + c;
        }
        #endregion

        #region Rectangles
        /// <summary>
        /// Calculates the area of a square, given the length of one side
        /// </summary>
        /// <param name="a">The area of a square with sides a</param>
        /// <returns>The area of the given square</returns>
        public static double SquareArea(double a)
        {
            return a * a;
        }

        /// <summary>
        /// Calculates the area of a rectangle, given the sides a and b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The area of the given rectangle</returns>
        public static double RectangleArea(double a, double b)
        { 
            return a * b;
        }

        /// <summary>
        /// Returns the area of the given paralellogram
        /// </summary>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <returns>The area of the given paralellogram</returns>
        public static double ParalellogramArea(double b, double h)
        {
            return b * h;
        }

        /// <summary>
        /// Calculates the area of a trapezoid, given the height and the sides
        /// </summary>
        /// <param name="h"></param>
        /// <param name="b"></param>
        /// <param name="b1"></param>
        /// <returns>The area of the given trapezoid</returns>
        public static double TrapezoidArea(double h, double b, double b1)
        {
            return (h / 2) * b * b1;
        }

        /// <summary>
        /// Calculates the perimeter of the given square
        /// </summary>
        /// <param name="a"></param>
        /// <returns>The perimeter of the given square</returns>
        public static double SquarePerimeter(double a)
        {
            return a * 4;
        }

        /// <summary>
        /// Calculates the perimeter of the given rectangle
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The perimeter of the given rectangle</returns>
        public static double RectanglePerimeter(double a, double b)
        {
            return a * 2 + b * 2;
        }

        /// <summary>
        /// Calculates the perimeter of the given paralellogram
        /// </summary>
        /// <param name="b"></param>
        /// <param name="h"></param>
        /// <returns>The perimeter of the given paralellogram</returns>
        public static double ParalellogramPerimeter(double b, double h)
        {
            return 2 * (b + h);
        }

        /// <summary>
        /// Calculates the perimeter of a rectangle, given all the sides of the 4-sided polygon
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns>The perimeter of the given 4-sided polygon</returns>
        public static double RectanglePerimeter(double a, double b, double c, double d)
        {
            return a + b + c + d;
        }
        #endregion

        #region Circles
        /// <summary>
        /// Calculates the area of the circle, given the radius
        /// </summary>
        /// <param name="r"></param>
        /// <returns>The area of the given circle</returns>
        public static double CircleArea(double r)
        {
            return r * r * SysMath.PI;
        }

        /// <summary>
        /// Calculates the area of the given ellipse
        /// </summary>
        /// <param name="r"></param>
        /// <param name="r1"></param>
        /// <returns></returns>
        public static double EllipseArea(double r, double r1)
        {
            return r * r1 * SysMath.PI;
        }

        /// <summary>
        /// Calculates the perimeter of the given circle
        /// </summary>
        /// <param name="r"></param>
        /// <returns>The perimeter of the circle</returns>
        public static double CirclePerimeter(double r)
        {
            return r * Constants.TwoPi;
        }

        /// <summary>
        /// Calculates an estimation of the perimeter of the given ellipse
        /// </summary>
        /// <param name="r"></param>
        /// <param name="r1"></param>
        /// <returns></returns>
        public static double EllipsePerimeter(double r, double r1)
        {
            return Constants.TwoPi * SysMath.Sqrt(((r * r) + (r1 * r1)) / 2);
        }
        #endregion

        /// <summary>
        /// Calculates the area of a regular polygon
        /// </summary>
        /// <param name="n">The number of sides in the polygon</param>
        /// <param name="b">The length of any side in the polygon</param>
        /// <returns>The area of the given polygon</returns>
        public static double RegularPolygonArea(double n, double b)
        {
            return (n * b * b * (1 / SysMath.Tan(180 / n)))/ 4;
        }

        /// <summary>
        /// Calculates the perimeter of the given polygon, given all the sides of them
        /// </summary>
        /// <param name="sides"></param>
        /// <returns>The perimeter of the given polygon</returns>
        public static double PolygonPerimeter(params double[] sides)
        {
            return sides.Sum();
        }
    }
}
