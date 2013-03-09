using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Pie;

namespace Pie.CharShapes
{   
    public class Triangle
    {
        public void FTriangle(int size, char symbol)//Filled Triangle
        {
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                PieConsole.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                PieConsole.WriteLine(symbol.ToString().PadLeft(i * 2, symbol));//Print symbol
            }
        }
        
        public void FTriangleSpace(int size, char symbol)//Filled Triangle with spaces
        {
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                PieConsole.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                PieConsole.WriteLine(Regex.Replace(symbol.ToString().PadLeft(i, symbol), "\" + symbol, " "+symbol));
            }
        }
        
        public void HTriangle(int size, char symbol)//Hollow Triangle
        {
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size-1; i++)
            {
                PieConsole.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                PieConsole.WriteLine(symbol.ToString().PadLeft(i * 2, ' '));//Print symbol
            }
            PieConsole.WriteLine(symbol.ToString().PadLeft((size*2)-1, symbol));//Triangle base
        }
        
        public void HalfFTriangle(int size, char symbol)//Half Filled Triangle
        {
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                PieConsole.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                PieConsole.WriteLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
        }
        
        public void HalfFTriangleR(int size, char symbol)//Half Filled Triangle Reversed
        {
            for (int i = 1; i < size; i++)
            {
                PieConsole.WriteLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
        }
        
        public void HalfFTriangleRR(int size, char symbol)//Half Filled Triangle Reversed Reversed... Don't ask
        {
            for (int i = size; i < 0; i--)
            {
                PieConsole.WriteLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
        }
        
        public void HalfHTriangle(int size, char symbol)//Half Hollow Triangle
        {
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size - 1; i++)
            {
                PieConsole.Write(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                PieConsole.WriteLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, symbol));//Triangle base
        }
        
        public void HalfHTriangleR(int size, char symbol)//Half Hollow Triangle Reversed
        {
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size - 1; i++)
            {
                PieConsole.WriteLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, symbol));//Triangle base
        }
        
        public void HalfHTriangleRR(int size, char symbol)//Half Hollow Triangle Reversed Reversed.. Don't ask
        {
            
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, symbol));//Triangle base... on top
            for (int i = size; i < 0; i--)
            {
                PieConsole.WriteLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            PieConsole.WriteLine(symbol.ToString().PadLeft(size, ' '));//Bottom of triangle
        }
    }
}
