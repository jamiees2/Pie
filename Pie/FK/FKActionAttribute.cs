using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.FK
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class FKActionAttribute : Attribute
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Finished { get; set; }

        public FKActionAttribute(string name)
        {
            this.Name = name;
            this.Finished = true;
        }
    }
}
