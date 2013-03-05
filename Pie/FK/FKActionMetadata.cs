using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Pie.FK
{
    /// <summary>
    /// A container class for actions
    /// </summary>
    internal class FKActionMetadata
    {
        /// <summary>
        /// The action method
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// The name, given by the action attribute
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description, given by the action attribute
        /// </summary>
        public string Description { get; set; }

        /// <see cref="object.ToString()"/>
        public override string ToString()
        {
            return this.Name + (this.Description != null ? ":\t" + this.Description : "");
        }
    }
}
