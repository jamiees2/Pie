using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysMath = System.Math;

namespace Pie.Units
{
    public static class BaseConverter
    {
        public static string ToBase(string number, int start_base, int target_base)
        {
            return BaseConverter.FromBase10(BaseConverter.ToBase10(number, start_base), target_base);
        }

        public static int ToBase10(string number, int start_base)
        {
            if (start_base < 2 || start_base > 36)
                return 0;
            if (start_base == 10)
                return Convert.ToInt32(number);
            char[] chArray = number.ToCharArray();
            int num1 = chArray.Length - 1;
            int num2 = start_base;
            int num3 = 0;
            foreach (char c in chArray)
            {
                int num4 = !char.IsNumber(c) ? Convert.ToInt32(c) - 55 : int.Parse(c.ToString());
                num3 += num4 * Convert.ToInt32(SysMath.Pow((double)num2, (double)num1));
                --num1;
            }
            return num3;
        }

        public static string FromBase10(int number, int target_base)
        {
            if (target_base < 2 || target_base > 36)
                return "";
            if (target_base == 10)
                return number.ToString();
            int num1 = target_base;
            int num2 = number;
            StringBuilder stringBuilder = new StringBuilder();
            while (num2 >= num1)
            {
                int num3 = num2 % num1;
                num2 /= num1;
                if (num3 < 10)
                    stringBuilder.Insert(0, num3.ToString());
                else
                    stringBuilder.Insert(0, Convert.ToChar(num3 + 55).ToString());
            }
            if (num2 < 10)
                stringBuilder.Insert(0, num2.ToString());
            else
                stringBuilder.Insert(0, Convert.ToChar(num2 + 55).ToString());
            return ((object)stringBuilder).ToString();
        }
    }
}
