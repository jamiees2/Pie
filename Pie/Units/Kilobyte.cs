using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Kilobyte : BitSize
    {
        public override string Unit
        {
            get
            {
                return "KB";
            }
        }

        public override double BaseValue
        {
            get
            {
                return 8192.0;
            }
        }

        public Kilobyte(double v)
            : base(v)
        {
        }
    }
}
