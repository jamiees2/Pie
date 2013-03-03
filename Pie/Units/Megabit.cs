using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Megabit : BitSize
    {
        public override string Unit
        {
            get
            {
                return "Mb";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1048576.0;
            }
        }

        public Megabit(double v)
            : base(v)
        {
        }
    }
}
