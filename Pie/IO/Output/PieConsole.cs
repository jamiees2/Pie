using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.IO.Output
{
    public class PieConsole
    {

        /// <summary>
        /// Reads in the entered input line, and converts it to type T
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="i">The string to print out in front of the input</param>
        /// <param name="endl">The end of the line</param>
        /// <returns>What was entered, but converted to the specified type</returns>
        public static T Read<T>(string i, string endl = ": ")
        {
            Console.Write(i + endl);
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads in the entered input line, and converts it to type T
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <returns>What was entered, but converted to the specified type</returns>
        public static T Read<T>()
        {
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Writes out the format string with the values
        /// </summary>
        /// <param name="i">The format string</param>
        /// <param name="p">The values</param>
        public static void WriteF(string i,params object[] p)
        {
            Console.Write(string.Format(i,p));
        }

        /// <summary>
        /// Writes out the format string on a certain line
        /// </summary>
        /// <param name="i">The format string</param>
        /// <param name="p">The values</param>
        public static void WriteFLine(string i, params object[] p)
        {
            Console.WriteLine(string.Format(i,p));
        }

        /// <summary>
        /// Waits for the user to press a key
        /// </summary>
        /// <param name="msg">The message to show</param>
        public static void Wait(string msg = "Press any key to continue...")
        {
            Console.Write(msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Waits for the user to press a key
        /// </summary>
        /// <remarks>Alias for the method Wait()</remarks>
        /// <param name="msg">The message to show</param>
        public static void __(string msg = "Press any key to continue...")
        {
            Wait(msg);
        }

    }
}
