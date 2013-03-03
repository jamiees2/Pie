using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{

    public class Bit : BitSize
    {
        public override string Unit
        {
            get
            {
                return "b";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1.0;
            }
        }

        public Bit(double v)
            : base(v)
        {
        }
    }

}
