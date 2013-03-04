using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pie.CharShapes
{
    public class Triangle
    {
        public void FTriangle(int size, char symbol)//Filled Triangle
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                System.Console.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                System.Console.WriteLine(symbol.ToString().PadLeft(i * 2, symbol));//Print symbol
            }
        }

        public void FTriangleSpace(int size, char symbol)//Filled Triangle with spaces
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                System.Console.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                System.Console.WriteLine(Regex.Replace(symbol.ToString().PadLeft(i, symbol), "\\" + symbol, " "+symbol));
            }
        }

        public void HTriangle(int size, char symbol)//Hollow Triangle
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size-1; i++)
            {
                System.Console.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                System.Console.WriteLine(symbol.ToString().PadLeft(i * 2, ' '));//Print symbol
            }
            System.Console.WriteLine(symbol.ToString().PadLeft((size*2)-1, symbol));//Triangle base
        }

        public void HalfFTriangle(int size, char symbol)//Half Filled Triangle
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                System.Console.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                System.Console.WriteLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
        }

        public void HalfHTriangle(int size, char symbol)//Half Hollow Triangle
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size - 1; i++)
            {
                System.Console.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                System.Console.WriteLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            System.Console.WriteLine(symbol.ToString().PadLeft(size, symbol));//Triangle base
        }
    }
}
