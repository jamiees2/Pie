using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Centimeter : Length
    {
        public override string Unit
        {
            get
            {
                return "cm";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 10.0;
            }
        }

        public Centimeter(double v)
            : base(v)
        {
        }
    }
}
