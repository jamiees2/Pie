using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Mile : Length
    {
        public override string Unit
        {
            get
            {
                return "mi";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 1609344.0;
            }
        }

        public Mile(double v)
            : base(v)
        {
        }
    }
}
