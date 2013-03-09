using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Math.Geometry.Formulas
{
    public class Circle
    {
        public static double Area(int r)
        {
            return System.Math.PI * System.Math.Pow(r, 2);
        }

        public static double Perimeter(int r)
        {
            return (System.Math.PI + System.Math.PI) * r;
        }
    }
}
