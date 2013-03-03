using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Meter : Length
    {
        public override string Unit
        {
            get
            {
                return "m";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1000.0;
            }
        }

        public Meter(double v)
            : base(v)
        {
        }
    }
}
