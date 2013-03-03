using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Pie;

namespace Pie.FK
{
    public class FKModel
    {
        public T Read<T>(string q = null, string separator = ": ")
        {
            this.WriteQuestion(q, separator);
            return PieConsole.ReadLine<T>();
        }

        public string Read(string q = null, string separator = ": ")
        {
            this.WriteQuestion(q, separator);
            return Console.ReadLine();
        }

        public int ReadInt(string q = null, string separator = ": ")
        {
            this.WriteQuestion(q, separator);
            return Convert.ToInt32(Console.ReadLine());
        }

        public double ReadDouble(string q = null, string separator = ": ")
        {
            this.WriteQuestion(q, separator);
            return Convert.ToDouble(Console.ReadLine());
        }

        private void WriteQuestion(string q = null, string separator = ": ")
        {
            if (q == null)
                return;
            Console.Write(q);
            Console.Write(separator);
        }

        public string ReadFile(string fileName, Encoding encoding = null)
        {
            Encoding encoding1 = encoding ?? Encoding.Default;
            using (StreamReader streamReader = new StreamReader(fileName, encoding1))
                return streamReader.ReadToEnd();
        }

        public IEnumerable<string> ReadFileLines(string fileName, Encoding encoding = null)
        {
            using (StreamReader streamReader = new StreamReader(fileName, encoding ?? Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                    yield return line;
            }
        }
    }
}
