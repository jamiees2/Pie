using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Kilometer : Length
    {
        public override string Unit
        {
            get
            {
                return "km";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1000000.0;
            }
        }

        public Kilometer(double v)
            : base(v)
        {
        }
    }
}
