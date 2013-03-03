using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Megabyte : BitSize
    {
        public override string Unit
        {
            get
            {
                return "MB";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 8388608.0;
            }
        }

        public Megabyte(double v)
            : base(v)
        {
        }
    }
}
