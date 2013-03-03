using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Gigabit : BitSize
    {
        public override string Unit
        {
            get
            {
                return "Gb";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1073741824.0;
            }
        }

        public Gigabit(double v)
            : base(v)
        {
        }
    }
}
