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
        /// Writes nothing to the console
        /// </summary>
        /// <returns>An instance of the ConsoleHelper</returns>
        public ConsoleHelper Write()
        {
            Console.Write("");
            return this;
        }

        /// <summary>
        /// Writes the current instance to the console.
        /// </summary>
        /// <param name="o">The specified object.</param>
        /// <returns>A console helper.</returns>
        public ConsoleHelper Write(object o)
        {
            Console.Write(o);
            return this;
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
            Console.Write(format, objects);
            return this;
        }

        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper WriteLine()
        {
            Console.WriteLine();
            return this;
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <returns>A console helper.</returns>
        public ConsoleHelper WriteLine(object o)
        {
            Console.WriteLine(o);
            return this;
        }

        /// <summary>
        /// Writes the current instance to the console, and then puts the cursor on a new line.
        /// </summary>
        /// <param name="format">The format string.</param>
        /// <param name="objects">The objects.</param>
        /// <returns>A console helper.</returns>
        public ConsoleHelper WriteLine(string format, params object[] objects)
        {
            Console.WriteLine(format, objects);
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
        /// Reads the input, runs a validation function on it, and the input if valid, othewise the default value;
        /// </summary>
        /// <param name="validate">The validation function</param>
        /// <param name="def">The default value</param>
        /// <returns>The string read in, if it passes the validation function, otherwise the default value</returns>
        public string ReadLineV(Func<string, bool> validate, string def = default(string))
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
        /// Reads a string from the console.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLine(out string output)
        {
            output = Console.ReadLine();
            return this;
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
            output = Console.ReadLine();
            if (!validate(output))
            {
                output = def;
            }
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
            Write(msg + suffix);
            return Console.ReadLine();
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then returns it if it passes the validation function
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public string ReadLineQV(string msg, Func<string, bool> validate, string def = default(string), string suffix = ": ")
        {
            string output = ReadLineQ(msg, suffix);
            if (validate(output))
            {
                return output;
            }
            return def;
        }

        /// <summary>
        /// Prints out the specified message, and then reads in the input, stores it in the output variable and returns the helper instance
        /// </summary>
        /// <param name="output"></param>
        /// <param name="msg"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public ConsoleHelper ReadLineQ(out string output, string msg, string suffix = ": ")
        {
            Write(msg + suffix);
            output = Console.ReadLine();
            return this;
        }

        /// <summary>
        /// Reads the line into the output, aslong as it passes the validation function
        /// </summary>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLineQV(out string output, string msg, Func<string, bool> validate, string def = default(string), string suffix = ": ")
        {
            output = ReadLineQ(msg, suffix);
            if (!validate(output))
            {
                output = def;
            }
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
            Write(msg + suffix);
            return Console.ReadLine().As<T>();
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then converts it to the specified type.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="suffix"></param>
        /// <returns>The value if it passes the validation function</returns>
        public T ReadLineQV<T>(string msg, Func<T, bool> validate, T def = default(T), string suffix = ": ")
        {
            T output = ReadLineQ<T>(msg, suffix);
            if (validate(output))
            {
                return output;
            }
            return def;
        }

        /// <summary>
        /// Reads a string form the console and converts it to the specified type and stores it in the output variable
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="msg">The message</param>
        /// <param name="output">The output variable</param>
        /// <param name="suffix">The suffix to the message</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLineQ<T>(out T output, string msg, string suffix = ": ")
        {
            Write(msg + suffix);
            output = Console.ReadLine().As<T>();
            return this;
        }

        /// <summary>
        /// Reads a string from the console, but prepends it with the specified message, then converts it to the specified type.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <param name="suffix"></param>
        /// <returns>The value if it passes the validation function</returns>
        public ConsoleHelper ReadLineQV<T>(out T output, string msg, Func<T, bool> validate, T def = default(T), string suffix = ": ")
        {
            output = ReadLineQ<T>(msg, suffix);
            if (!validate(output))
            {
                output = def;
            }
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public T ReadLine<T>(Func<T, bool> validate, T def = default(T))
        {
            T output = ReadLine<T>();
            if (validate(output))
            {
                return output;
            }
            return def;
        }

        /// <summary>
        /// Reads a string from the console and then converts it to the specified type.
        /// </summary>
        /// <param name="output">The output variable</param>
        /// <returns>An instance of ConsoleHelper</returns>
        public ConsoleHelper ReadLine<T>(out T output)
        {
            output = Console.ReadLine().As<T>();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="output"></param>
        /// <param name="validate"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public ConsoleHelper ReadLine<T>(out T output, Func<T, bool> validate, T def = default(T))
        {
            output = ReadLine<T>();
            if (!validate(output))
            {
                output = def;
            }
            return this;
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadLines(string postfix = null)
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
        /// <param name="suffix"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadLinesQ(string msg, string postfix = null, string suffix = ": ")
        {
            int i = 1;
            while (true)
            {
                Console.Write(msg + suffix, i);
                yield return Console.ReadLine();
                if (postfix != null) WriteLine(postfix);
                i++;
            }
        }

        /// <summary>
        /// Yields an IEnumerable containing the read in strings forever
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns></returns>
        public IEnumerable<T> ReadLines<T>(string postfix = null)
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
        /// <param name="suffix"></param>
        /// <returns></returns>
        public IEnumerable<T> ReadLinesQ<T>(string msg, string postfix = null, string suffix = ": ")
        {
            int i = 1;
            while (true)
            {
                Console.Write(msg + suffix, i);
                yield return Console.ReadLine().As<T>();
                if (postfix != null) WriteLine(postfix);
                i++;
            }
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

        /// <see cref="Object.ToStr
        /// g()"/>
        public override string ToString()
        {
            return String.Empty;
        }
    }
}
