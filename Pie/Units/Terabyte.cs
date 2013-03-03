using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Terabyte : BitSize
    {
        public override string Unit
        {
            get
            {
                return "TB";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 8796093020000.0;
            }
        }

        public Terabyte(double v)
            : base(v)
        {
        }
    }
}
