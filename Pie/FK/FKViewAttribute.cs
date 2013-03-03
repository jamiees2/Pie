using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.FK
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class FKViewAttribute : Attribute
    {
    }
}
