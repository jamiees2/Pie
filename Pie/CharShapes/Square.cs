using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pie.CharShapes
{
    public class Square
    {
        public void FSquare(int size, char symbol)//Filled Square
        {
            for (int i = 0; i < size; i++)
            {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, symbol));//Fill the square
            }
        }

        public void HSquare(int size, char symbol)//Hollow Square
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(size, symbol));//Top of square
            for (int i = 0; i < (size - 2); i++)
            {
                System.Console.WriteLine(symbol + symbol.ToString().PadLeft(size - 1, ' '));
            }
            if (size != 1)
                System.Console.WriteLine(symbol.ToString().PadLeft(size, symbol));//Bottom of square
        }

        public void FXYSquare(int x, int y, char symbol)//Filled Different width an height square
        {
            for (int i = 0; i < y; i++)
            {
                System.Console.WriteLine(symbol.ToString().PadLeft(x, symbol));
            }
        }

        public void HXYSquare(int x, int y, char symbol)//Hollow Different width and height square
        {
            System.Console.WriteLine(symbol.ToString().PadLeft(x, symbol));
            for (int i = 0; i < (y-2); i++)
            {
                if(x!=1)
                System.Console.WriteLine(symbol+symbol.ToString().PadLeft(x-1, symbol));
                else
                    System.Console.WriteLine(symbol);
            }
            if(y!=1)
                System.Console.WriteLine(symbol.ToString().PadLeft(x, symbol));
        }

        public void FSquareSpace(int size, char symbol)//Filled Square with some spaces
        {
            for (int i = 0; i < size; i++)
            {
                System.Console.WriteLine(Regex.Replace(symbol.ToString().PadLeft(size, symbol), "\\" + symbol, symbol+" "));
            }
        }

        public void FXYSquareSpace(int x, int y, char symbol)//Filled Different width an height square with spaces
        {
            for (int i = 0; i < y; i++)
            {
                System.Console.WriteLine(Regex.Replace(symbol.ToString().PadLeft(x, symbol), "\\" + symbol, symbol + " "));
            }
        }
    }
}
