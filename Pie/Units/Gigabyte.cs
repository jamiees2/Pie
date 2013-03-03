using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Gigabyte : BitSize
    {
        public override string Unit
        {
            get
            {
                return "GB";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 8589934592.0;
            }
        }

        public Gigabyte(double v)
            : base(v)
        {
        }
    }
}
