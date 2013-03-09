using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Pie;
using Pie.Strings;
using Pie.Math;
using Pie.Math.Geometry;
using Pie.Time;
using Pie.Units;
using Pie.IO;
using Pie.FK;
using Console = Pie.PieConsole;

namespace $safeprojectname$
{
    class FK$year$ : FKController
    {
        public FK$year$(string title = null, string[] args = null) : base(title, args) {}

        [FKAction("1", "Problem 1")]
        public void Problem1()
        { 
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            (new FK$year$("FK$year$", args)).Run();
        }
    }
}
