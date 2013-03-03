using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Milligram : Weight
    {
        public override string Unit
        {
            get
            {
                return "mg";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1.0;
            }
        }

        public Milligram(double v)
            : base(v)
        {
        }
    }
}
