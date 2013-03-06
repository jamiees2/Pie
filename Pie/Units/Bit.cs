using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    /// <summary>
    /// A class representing an arbitrary number of bits
    /// </summary>
    public class Bit : BitSize
    {
        /// <see cref="BitSize.Unit"/>
        public override string Unit
        {
            get
            {
                return "b";
            }
        }

        /// <see cref="BitSize.BaseValue"/>
        public override double BaseValue
        {
            get
            {
                return 1.0;
            }
        }

        /// <see cref="BitSize"/>
        public Bit(double v)
            : base(v)
        {
        }
    }

}
