using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Inch : Length
    {
        public override string Unit
        {
            get
            {
                return "in";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 25.4;
            }
        }

        public Inch(double v)
            : base(v)
        {
        }
    }
}
