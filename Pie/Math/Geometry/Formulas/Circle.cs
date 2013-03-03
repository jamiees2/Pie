using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Math.Geometry.Formulas
{
    public class Circle
    {
        public double Area(int r)
        {
            return System.Math.PI * System.Math.Pow(r, 2);
        }

        public double Perimeter(int r)
        {
            return (System.Math.PI + System.Math.PI) * r;
        }
    }
}
