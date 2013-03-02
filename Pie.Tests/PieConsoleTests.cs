using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pie.Output;

namespace Pie.Tests
{
    class PieConsoleTests
    {
        public static void Main(string[] args)
        {
            int inp = PieConsole.Read<int>("Input: ");
            Console.ReadKey();
        }
    }
}
