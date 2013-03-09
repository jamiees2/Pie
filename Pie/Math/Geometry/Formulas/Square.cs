using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Math.Geometry.Formulas
{
    public class Square
    {
        public static double Area(int w, int h)
        {
            return w * h;
        }

        public double Perimeter(int w, int h)
        {
            return System.Math.Pow((w + h), 2);
        }
    }
}
