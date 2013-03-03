using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie
{
    /// <summary>
    /// An upgrade to the usual System.Console
    /// </summary>
    public static class PieConsole
    {
        /// <summary>
        /// Writes nothing to the console
        /// </summary>
        /// <returns>An instance of the ConsoleHelper</returns>
        public static ConsoleHelper Write()
        {
            return ConsoleHelper.GetInstance().Write();
        }

        /// <summary>
        /// Writes the current instance to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper Write(object o)
        {
            return ConsoleHelper.GetInstance().Write(o);
        }

        /// <summary>
        /// Writes the current instance to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <param name="format">The format string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper Write(string format, params object[] objects)
        {
            return ConsoleHelper.GetInstance().Write(format, objects);
        }

        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper WriteLine()
        {
            return WriteLine("\n");
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper WriteLine(object o)
        {
            return ConsoleHelper.GetInstance().WriteLine(o);
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper WriteLine(string format, params object[] objects)
        {
            return ConsoleHelper.GetInstance().WriteLine(format, objects);
        }

        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <returns>The string read from the console.</returns>
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLine(out string output)
        {
            output = Console.ReadLine();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>The string read from the console</returns>
        public static string ReadLineQ(string msg, string suffix=": ")
        {
            Write(msg + suffix);
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints out the specified message, and then reads in the input, stores it in the output variable and returns the helper instance
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLineQ(out string output, string msg, string suffix = ": ")
        {
            Write(msg + suffix);
            output = Console.ReadLine();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>The string read from the line converted to type T</returns>
        public static T ReadLineQ<T>(string msg, string suffix = ": ")
        {
            Write(msg + suffix);
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type and stores it in the output variable
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLineQ<T>(out T output, string msg, string suffix = ": ")
        {
            Write(msg + suffix);
            output = Console.ReadLine().As<T>();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <returns>The converted string read from the console.</returns>
        public static T ReadLine<T>()
        {
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLine<T>(out T output)
        {
            output = Console.ReadLine().As<T>();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Waits for the user to press a key
        /// </summary>
        /// <param name="msg">The message to show to the user.</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper Wait(string msg = "Press any key to continue...")
        {
            Write(msg);
            Console.ReadKey();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Waits for the user to press enter
        /// </summary>
        /// <param name="msg">The message to show to the user.</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper WaitLine(string msg = "Press any key to continue...")
        {
            Write(msg);
            ReadLine();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Clears the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper Clear()
        {
            Console.Clear();
            return ConsoleHelper.GetInstance();
        }

    }
}
