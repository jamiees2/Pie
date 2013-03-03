using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Kilobit : BitSize
    {
        public override string Unit
        {
            get
            {
                return "Kb";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1024.0;
            }
        }

        public Kilobit(double v)
            : base(v)
        {
        }
    }
}
