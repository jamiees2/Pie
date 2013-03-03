using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Millimeter : Length
    {
        public override string Unit
        {
            get
            {
                return "mm";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1.0;
            }
        }

        public Millimeter(double v)
            : base(v)
        {
        }
    }
}
