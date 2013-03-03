using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie
{
    /// <summary>
    /// A console helper for method chaining
    /// </summary>
    public class ConsoleHelper
    {
        private static ConsoleHelper Instance { get; set; }

        private ConsoleHelper() { }

        /// <summary>
        /// Returns an instance of the console helper.
        /// </summary>
        /// <returns>An instance of the console helper.</returns>
        public static ConsoleHelper GetInstance()
        {
            if (Instance == null) Instance = new ConsoleHelper();
            return Instance;
        }

        /// <summary>
        /// Writes the specified object to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <returns>The current instance (for chaining).</returns>
        public ConsoleHelper Write<T>(T o)
        {
            Console.Write(o);
            return this;
        }

        /// <summary>
        /// Writes the specified object to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <returns>The current instance (for chaining).</returns>
        public ConsoleHelper WriteLine<T>(T o)
        {
            Console.WriteLine(o);
            return this;
        }

        /// <summary>
        /// Formats the specified string and objects with String.Format and the writes it to the console.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The current instance (for chaining).</returns>
        public ConsoleHelper Write(string format, params object[] args)
        {
            Console.Write(format, args);
            return this;
        }

        /// <summary>
        /// Formats the specified string and objects with String.Format, writes it to the console and the puts the cursor on a new line.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The current instance (for chaining).</returns>
        public ConsoleHelper WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            return this;
        }

        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <returns>The string read from the console.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of PieConsoleHelper</returns>
        public ConsoleHelper ReadLine(out string output)
        {
            output = Console.ReadLine();
            return this;
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>The string read from the console</returns>
        public string ReadLineQ(string msg, string suffix = ": ")
        {
            this.Write(msg + suffix);
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints out the specified message, and then reads in the input, stores it in the output variable and returns the helper instance
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>An instance of PieConsoleHelper</returns>
        public ConsoleHelper ReadLineQ(out string output, string msg, string suffix = ": ")
        {
            this.Write(msg + suffix);
            output = Console.ReadLine();
            return this;
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>The string read from the line converted to type T</returns>
        public T ReadLineQ<T>(string msg, string suffix = ": ")
        {
            this.Write(msg + suffix);
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type and stores it in the output variable
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>An instance of PieConsoleHelper</returns>
        public ConsoleHelper ReadLineQ<T>(out T output, string msg, string suffix = ": ")
        {
            this.Write(msg + suffix);
            output = Console.ReadLine().As<T>();
            return this;
        }

        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <returns>The converted string read from the console.</returns>
        public T ReadLine<T>()
        {
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of PieConsoleHelper</returns>
        public ConsoleHelper ReadLine<T>(out T output)
        {
            output = Console.ReadLine().As<T>();
            return this;
        }

        /// <summary>
        /// Waits for the user to press a key
        /// </summary>
        /// <param name="msg">The message to show to the user.</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper Wait(string msg = "Press any key to continue...")
        {
            Write(msg);
            Console.ReadKey();
            return this;
        }

        /// <summary>
        /// Waits for the user to press enter
        /// </summary>
        /// <param name="msg">The message to show to the user.</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper WaitLine(string msg = "Press any key to continue...")
        {
            Write(msg);
            ReadLine();
            return this;
        }

        /// <summary>
        /// Clears the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper Clear()
        {
            Console.Clear();
            return this;
        }

        /// <see cref="Object.ToString()"/>
        public override string ToString()
        {
            return String.Empty;
        }
    }
}
