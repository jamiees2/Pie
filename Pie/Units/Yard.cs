using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Yard : Length
    {
        public override string Unit
        {
            get
            {
                return "yd";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 914.4;
            }
        }

        public Yard(double v)
            : base(v)
        {
        }
    }
}
