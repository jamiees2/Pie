using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Fahrenheit : Temperature
    {
        public const string Unit = "°F";

        private double Value { get; set; }

        public Fahrenheit(double v)
        {
            this.Value = v;
        }

        public static implicit operator Fahrenheit(double v)
        {
            return new Fahrenheit(v);
        }

        public static implicit operator double(Fahrenheit v)
        {
            return v.Value;
        }

        public static explicit operator Fahrenheit(Kelvin v)
        {
            return new Fahrenheit((double)v * 1.8 - 459.67);
        }

        public static explicit operator Fahrenheit(Celsius v)
        {
            return new Fahrenheit((double)v * 1.8 + 32.0);
        }

        public override string ToString()
        {
            return this.Value.ToString() + " °F";
        }

        public string ToString(bool unit)
        {
            return this.Value.ToString() + (unit ? " °F" : "");
        }

        public string ToString(bool unit, Func<double, string> result)
        {
            return result(this.Value) + (unit ? " °F" : "");
        }
    }
}
