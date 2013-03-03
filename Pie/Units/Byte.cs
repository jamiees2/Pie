using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Byte : BitSize
    {
        public override string Unit
        {
            get
            {
                return "B";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 8.0;
            }
        }

        public Byte(double v)
            : base(v)
        {
        }
    }
}
