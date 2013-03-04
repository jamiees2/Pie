using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Pound : Weight
    {
        public override string Unit
        {
            get
            {
                return "lb";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 453592.0;
            }
        }

        public Pound(double v)
            : base(v)
        {
        }
    }
}
