using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Stone : Weight
    {
        public override string Unit
        {
            get
            {
                return "st";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 6350290;
            }
        }

        public Stone(double v)
            : base(v)
        {
        }
    }
}
