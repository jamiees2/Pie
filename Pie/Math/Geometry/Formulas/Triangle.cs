﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Math.Geometry.Formulas
{
    public class Triangle
    {
        public double Area(int b, int h)
        {
            return (1 / 2) * (b * h);
        }

        public double Perimeter(int a, int b, int c)
        {
            return a + b + c;
        }

        public double Pythagoras(int a, int b)
        {
            return System.Math.Sqrt(System.Math.Pow(a, 2) + System.Math.Pow(b, 2));
        }
    }
}
