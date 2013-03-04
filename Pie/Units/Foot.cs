using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Foot : Length
    {
        public override string Unit
        {
            get
            {
                return "ft";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 304.8;
            }
        }

        public Foot(double v)
            : base(v)
        {
        }
    }
}
