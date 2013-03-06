using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    /// <summary>
    /// A class representing an arbritrary number of Bytes
    /// </summary>
    public class Byte : BitSize
    {
        /// <summary>
        /// <see cref="BitSize.Unit"/>
        /// </summary>
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
