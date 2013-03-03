using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Pie.FK
{
    internal class FKActionMetadata
    {
        public MethodInfo Method { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name + (this.Description != null ? ":\t" + this.Description : "");
        }
    }
}
