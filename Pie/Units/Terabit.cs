using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Terabit : BitSize
    {
        public override string Unit
        {
            get
            {
                return "Tb";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1099511627776.0;
            }
        }

        public Terabit(double v)
            : base(v)
        {
        }
    }
}
