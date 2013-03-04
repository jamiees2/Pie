using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Ounce : Weight
    {
        public override string Unit
        {
            get
            {
                return "oz";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 28349.5;
            }
        }

        public Ounce(double v)
            : base(v)
        {
        }
    }
}
