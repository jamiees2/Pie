using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysConsole = System.Console;

namespace Pie.Console
{
    public class PieConsole
    {

        /// <summary>
        /// Reads in the entered input line, and converts it to type T
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="i">The string to print out in front of the input</param>
        /// <returns>What was entered, but converted to the specified type</returns>
        public static T Read<T>(string i)
        {
            SysConsole.Write(i + " ");
            return SysConsole.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads in the entered input line, and converts it to type T
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <returns>What was entered, but converted to the specified type</returns>
        public static T Read<T>()
        {
            return SysConsole.ReadLine().As<T>();
        }

        /// <summary>
        /// Writes out the format string with the values
        /// </summary>
        /// <param name="i">The format string</param>
        /// <param name="p">The values</param>
        public static void WriteF(string i,params object[] p)
        {
            SysConsole.Write(string.Format(i,p));
        }

        /// <summary>
        /// Writes out the format string on a certain line
        /// </summary>
        /// <param name="i">The format string</param>
        /// <param name="p">The values</param>
        public static void WriteFLine(string i, params object[] p)
        {
            SysConsole.WriteLine(string.Format(i,p));
        }
    }
}
