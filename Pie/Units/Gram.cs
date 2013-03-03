using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Gram : Weight
    {
        public override string Unit
        {
            get
            {
                return "g";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1000.0;
            }
        }

        public Gram(double v)
            : base(v)
        {
        }
    }
}
