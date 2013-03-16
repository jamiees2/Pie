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
        /// Private string for the Suffix
        /// </summary>
        private static string _Suffix = ": ";

        /// <summary>
        /// The character to use after questions
        /// </summary>
        public static string Suffix { get {return _Suffix; } set { _Suffix = value; } }

        #region Write Methods
        /// <summary>
        /// Writes the current instance to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper Write(object o)
        {
            Console.Write(o);
            return ConsoleHelper.GetInstance();
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
            Console.Write(format, objects);
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper WriteLine()
        {
            Console.WriteLine();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper WriteLine(object o)
        {
            Console.WriteLine(o);
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>A console helper.</returns>
        public static ConsoleHelper WriteLine(string format, params object[] objects)
        {
            Console.WriteLine(format, objects);
            return ConsoleHelper.GetInstance();
        }
        #endregion

        #region Read Methods
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
        /// <param name="Suffix">The Suffix to the message</param>
        /// <returns>The string read from the console</returns>
        public static string ReadLineQ(string msg)
        {
            Write(msg + Suffix);
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints out the specified message, and then reads in the input, stores it in the output variable and returns the helper instance
        /// </summary>
        /// <param name="output"></param>
        /// <param name="msg"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public static ConsoleHelper ReadLineQ(out string output, string msg)
        {
            Write(msg + Suffix);
            output = Console.ReadLine();
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="Suffix">The Suffix to the message</param>
        /// <returns>The string read from the line converted to type T</returns>
        public static T ReadLineQ<T>(string msg)
        {
            Write(msg + Suffix);
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type and stores it in the output variable
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="Suffix">The Suffix to the message</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLineQ<T>(out T output, string msg)
        {
            Write(msg + Suffix);
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
        #endregion

        #region Validation
        /// <summary>
        /// Reads the input, runs a validation function on it, and the input if valid, othewise the default value;
        /// </summary>
        /// <param name="validate">The validation function</param>
        /// <param name="def">The default value</param>
        /// <returns>The string read in, if it passes the validation function, otherwise the default value</returns>
        public static string ReadLineV(Func<string, bool> validate, string def = default(string))
        {
            string line = Console.ReadLine();
            if (validate(line))
            {
                return line;
            }
            else
            {
                return def;
            }
        }

        /// <summary>
        /// Reads the line into the output, aslong as it passes the validation function
        /// </summary>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLineV(out string output, Func<string, bool> validate, string def = default(string))
        {
            output = Console.ReadLine();
            if (!validate(output))
            {
                output = def;
            }
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then returns it if it passes the validation function
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public static string ReadLineQV(string msg, Func<string, bool> validate, string def = default(string))
        {
            string output = ReadLineQ(msg);
            if (validate(output))
            {
                return output;
            }
            return def;
        }

        /// <summary>
        /// Reads the line into the output, aslong as it passes the validation function
        /// </summary>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns>An instance of ConsoleHelper</returns>
        public static ConsoleHelper ReadLineQV(out string output, string msg, Func<string, bool> validate, string def = default(string))
        {
            output = ReadLineQ(msg);
            if (!validate(output))
            {
                output = def;
            }
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then converts it to the specified type.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="Suffix"></param>
        /// <returns>The value if it passes the validation function</returns>
        public static T ReadLineQV<T>(string msg, Func<T, bool> validate, T def = default(T))
        {
            T output = ReadLineQ<T>(msg);
            if (validate(output))
            {
                return output;
            }
            return def;
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
        public static ConsoleHelper ReadLineQV<T>(out T output, string msg, Func<T, bool> validate, T def = default(T))
        {
            output = ReadLineQ<T>(msg);
            if (!validate(output))
            {
                output = def;
            }
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static ConsoleHelper ReadLineV<T>(out T output, Func<T, bool> validate, T def = default(T))
        {
            output = ReadLine<T>();
            if (!validate(output))
            {
                output = def;
            }
            return ConsoleHelper.GetInstance();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T ReadLineV<T>(Func<T, bool> validate, T def = default(T))
        {
            T output = ReadLine<T>();
            if (validate(output))
            {
                return output;
            }
            return def;
        }

        #endregion

        #region Multiple Lines
        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(string postfix = null)
        {
            while (true)
            {
                yield return ReadLine();
                if (postfix != null) WriteLine(postfix);
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLinesQ(string msg, string postfix = null)
        {
            int i = 1;
            while (true)
            {
                Console.Write(msg + Suffix, i);
                yield return Console.ReadLine();
                if (postfix != null) WriteLine(postfix);
                i++;
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static IEnumerable<List<string>> ReadLinesQ(string[] msg, string[] postfix = null)
        {
            int i = 1;
            List<string> vals = new List<string>();
            while (true)
            {
                for (int j = 0; j < msg.Length; j++)
                {
                    Console.Write(msg[j] + Suffix, i);
                    vals.Add(Console.ReadLine());
                    if (postfix != null && postfix.Length > j) WriteLine(postfix[j]);
                }
                yield return vals;
                vals.Clear();
                i++;
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static IEnumerable<Dictionary<object,string>> ReadLinesQ(Dictionary<string,object> msg, Dictionary<object,string> postfix = null)
        {
            int i = 1;
            Dictionary<object, string> vals = new Dictionary<object, string>();
            while (true)
            {
                foreach (var message in msg)
                {
                    Console.Write(message.Key + Suffix, i);
                    vals.Add(message.Value,Console.ReadLine());
                    if (postfix != null && postfix.ContainsKey(message.Value)) WriteLine(postfix[message.Value]);
                }
                yield return vals;
                vals.Clear();
                i++;
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static IEnumerable<T> ReadLines<T>(string postfix = null)
        {
            while (true)
            {
                yield return ReadLine<T>();
                if (postfix != null) WriteLine(postfix);
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <param name="Suffix"></param>
        /// <returns></returns>
        public static IEnumerable<T> ReadLinesQ<T>(string msg, string postfix = null)
        {
            int i = 1;
            while (true)
            {
                Console.Write(msg + Suffix,i);
                yield return Console.ReadLine().As<T>();
                if (postfix != null) WriteLine(postfix);
                i++;
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public static IEnumerable<List<T>> ReadLinesQ<T>(string[] msg, string[] postfix = null)
        {
            int i = 1;
            List<T> vals = new List<T>();
            while (true)
            {
                for (int j = 0; j < msg.Length; j++)
                {
                    Console.Write(msg[j] + Suffix, i);
                    vals.Add(Console.ReadLine().As<T>());
                    if (postfix != null && postfix.Length > j) WriteLine(postfix[j]);
                }
                yield return vals;
                vals.Clear();
                i++;
            }
        }

        #endregion

        #region Other Methods
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

        #endregion

    }
}
