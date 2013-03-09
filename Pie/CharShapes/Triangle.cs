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
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                builder.Append(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                builder.AppendLine(symbol.ToString().PadLeft(i * 2, symbol));//Print symbol
            }
            return builder.ToString();
        }
        
        public void FTriangleSpace(int size, char symbol)//Filled Triangle with spaces
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                builder.Append(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                builder.AppendLine(Regex.Replace(symbol.ToString().PadLeft(i, symbol), "\" + symbol, " "+symbol));
            }
        }
        
        public void HTriangle(int size, char symbol)//Hollow Triangle
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size-1; i++)
            {
                builder.Append(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                builder.AppendLine(symbol.ToString().PadLeft(i * 2, ' '));//Print symbol
            }
            builder.AppendLine(symbol.ToString().PadLeft((size*2)-1, symbol));//Triangle base
        }
        
        public void HalfFTriangle(int size, char symbol)//Half Filled Triangle
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size; i++)
            {
                builder.Append(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                builder.AppendLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
        }
        
        public void HalfFTriangleR(int size, char symbol)//Half Filled Triangle Reversed
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i < size; i++)
            {
                builder.AppendLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
        }
        
        public void HalfFTriangleRR(int size, char symbol)//Half Filled Triangle Reversed Reversed... Don't ask
        {
            StringBuilder builder = new StringBuilder();
            for (int i = size; i < 0; i--)
            {
                builder.AppendLine(symbol.ToString().PadLeft(i, symbol));//Print symbol
            }
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
        }
        
        public void HalfHTriangle(int size, char symbol)//Half Hollow Triangle
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size - 1; i++)
            {
                builder.Append(symbol.ToString().PadLeft((size - i), ' '));//Whitespace before printing symbol
                builder.AppendLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            builder.AppendLine(symbol.ToString().PadLeft(size, symbol));//Triangle base
        }
        
        public void HalfHTriangleR(int size, char symbol)//Half Hollow Triangle Reversed
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Top of triangle
            for (int i = 1; i < size - 1; i++)
            {
                builder.AppendLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            builder.AppendLine(symbol.ToString().PadLeft(size, symbol));//Triangle base
        }
        
        public void HalfHTriangleRR(int size, char symbol)//Half Hollow Triangle Reversed Reversed.. Don't ask
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(symbol.ToString().PadLeft(size, symbol));//Triangle base... on top
            for (int i = size; i < 0; i--)
            {
                builder.AppendLine(symbol.ToString().PadLeft(i, ' '));//Print symbol
            }
            builder.AppendLine(symbol.ToString().PadLeft(size, ' '));//Bottom of triangle
        }
    }
}
