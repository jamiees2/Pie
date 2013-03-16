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


        #region Write Methods
        /// <summary>
        /// Writes the current instance to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <returns>A console helper.</returns>
        public ConsoleHelper Write(object o)
        {
            return PieConsole.Write(o);
        }

        /// <summary>
        /// Writes the current instance to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <param name="format">The format string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>A console helper.</returns>
        public ConsoleHelper Write(string format, params object[] objects)
        {
            return PieConsole.Write(format, objects);
        }

        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper WriteLine()
        {
            return WriteLine("\n");
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <returns>A console helper.</returns>
        public ConsoleHelper WriteLine(object o)
        {
            return PieConsole.WriteLine(o);
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>A console helper.</returns>
        public ConsoleHelper WriteLine(string format, params object[] objects)
        {
            return PieConsole.WriteLine(format, objects);
        }
        #endregion

        #region Read Methods
        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <returns>The string read from the console.</returns>
        public string ReadLine()
        {
            return PieConsole.ReadLine();
        }

        /// <summary>
        /// Reads a string from the console.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLine(out string output)
        {
            output = PieConsole.ReadLine();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="Suffix">The Suffix to the message</param>
        /// <returns>The string read from the console</returns>
        public string ReadLineQ(string msg)
        {
            return PieConsole.ReadLineQ(msg);
        }

        /// <summary>
        /// Prints out the specified message, and then reads in the input, stores it in the output variable and returns the helper instance
        /// </summary>
        /// <param name="output"></param>
        /// <param name="msg"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public ConsoleHelper ReadLineQ(out string output, string msg)
        {
            return PieConsole.ReadLineQ(out output, msg);
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="Suffix">The Suffix to the message</param>
        /// <returns>The string read from the line converted to type T</returns>
        public T ReadLineQ<T>(string msg)
        {
            return PieConsole.ReadLineQ<T>(msg);
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type and stores it in the output variable
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="Suffix">The Suffix to the message</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLineQ<T>(out T output, string msg)
        {
            return PieConsole.ReadLineQ<T>(out output, msg);
        }
        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <returns>The converted string read from the console.</returns>
        public T ReadLine<T>()
        {
            return PieConsole.ReadLine<T>();
        }

        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLine<T>(out T output)
        {
            return PieConsole.ReadLine<T>(out output);
        }
        #endregion

        #region Validation
        /// <summary>
        /// Reads the input, runs a validation function on it, and the input if valid, othewise the default value;
        /// </summary>
        /// <param name="validate">The validation function</param>
        /// <param name="def">The default value</param>
        /// <returns>The string read in, if it passes the validation function, otherwise the default value</returns>
        public string ReadLineV(Func<string, bool> validate, string def = default(string))
        {
            return PieConsole.ReadLineV(validate, def);
        }

        /// <summary>
        /// Reads the line into the output, aslong as it passes the validation function
        /// </summary>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLineV(out string output, Func<string, bool> validate, string def = default(string))
        {
            return PieConsole.ReadLineV(out output, validate, def);
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then returns it if it passes the validation function
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public string ReadLineQV(string msg, Func<string, bool> validate, string def = default(string))
        {
            return PieConsole.ReadLineQV(msg, validate, def);
        }

        /// <summary>
        /// Reads the line into the output, aslong as it passes the validation function
        /// </summary>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLineQV(out string output, string msg, Func<string, bool> validate, string def = default(string))
        {
            return PieConsole.ReadLineQV(out output, msg, validate, def);
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then converts it to the specified type.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="Suffix"></param>
        /// <returns>The value if it passes the validation function</returns>
        public T ReadLineQV<T>(string msg, Func<T, bool> validate, T def = default(T))
        {
            return PieConsole.ReadLineQV<T>(msg, validate, def);
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then converts it to the specified type.
        /// </summary>
        /// <param name="output"></param>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="Suffix"></param>
        /// <returns>The value if it passes the validation function</returns>
        public ConsoleHelper ReadLineQV<T>(out T output, string msg, Func<T, bool> validate, T def = default(T))
        {
            return PieConsole.ReadLineQV<T>(out output, msg, validate, def);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public ConsoleHelper ReadLineV<T>(out T output, Func<T, bool> validate, T def = default(T))
        {
            return PieConsole.ReadLineV<T>(out output, validate, def);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public T ReadLineV<T>(Func<T, bool> validate, T def = default(T))
        {
            return PieConsole.ReadLineV<T>(validate, def);
        }

        #endregion

        #region Multiple Lines
        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadLines(string postfix = null)
        {
            return PieConsole.ReadLines(postfix);
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadLinesQ(string msg, string postfix = null)
        {
            return PieConsole.ReadLinesQ(msg, postfix);
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static IEnumerable<List<string>> ReadLinesQ(string[] msg, string[] postfix = null)
        {
            return PieConsole.ReadLinesQ(msg, postfix);
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public IEnumerable<T> ReadLines<T>(string postfix = null)
        {
            return PieConsole.ReadLines<T>(postfix);
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public IEnumerable<T> ReadLinesQ<T>(string msg, string postfix = null)
        {
            return PieConsole.ReadLinesQ<T>(msg, postfix);
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public IEnumerable<List<T>> ReadLinesQ<T>(string[] msg, string[] postfix = null)
        {
            return PieConsole.ReadLinesQ<T>(msg, postfix);
        }

        #endregion

        #region Other Methods
        /// <summary>
        /// Waits for the user to press a key
        /// </summary>
        /// <param name="msg">The message to show to the user.</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper Wait(string msg = "Press any key to continue...")
        {
            return PieConsole.Wait(msg);
        }

        /// <summary>
        /// Waits for the user to press enter
        /// </summary>
        /// <param name="msg">The message to show to the user.</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper WaitLine(string msg = "Press any key to continue...")
        {
            return PieConsole.WaitLine(msg);
        }

        /// <summary>
        /// Clears the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper Clear()
        {
            return PieConsole.Clear();
        }

        #endregion


        /// <see cref="Object.ToString()"/>
        public override string ToString()
        {
            return String.Empty;
        }
    }
}
