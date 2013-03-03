using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Kilogram : Weight
    {
        public override string Unit
        {
            get
            {
                return "kg";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1000000.0;
            }
        }

        public Kilogram(double v)
            : base(v)
        {
        }
    }
}
