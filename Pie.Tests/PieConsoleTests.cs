using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pie.IO.Output;

namespace Pie.Tests
{
    class PieConsoleTests
    {
        public static void Main(string[] args)
        {
            int inp = PieConsole.Read<int>("Input", "? ");
            PieConsole.WriteFLine("{0} input", inp);
            PieConsole.__();
        }
    }
}
