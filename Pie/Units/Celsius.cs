using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Celsius : Temperature
    {
        public const string Unit = "°C";

        private double Value { get; set; }

        public Celsius(double v)
        {
            this.Value = v;
        }

        public static implicit operator Celsius(double v)
        {
            return new Celsius(v);
        }

        public static implicit operator double(Celsius v)
        {
            return v.Value;
        }

        public static explicit operator Celsius(Kelvin v)
        {
            return new Celsius((double)v - 273.15);
        }

        public static explicit operator Celsius(Fahrenheit v)
        {
            return new Celsius(((double)v - 32.0) * (5.0 / 9.0));
        }

        public override string ToString()
        {
            return this.Value.ToString() + " °C";
        }

        public string ToString(bool unit)
        {
            return this.Value.ToString() + (unit ? " °C" : "");
        }

        public string ToString(bool unit, Func<double, string> result)
        {
            return result(this.Value) + (unit ? " °C" : "");
        }
    }
}
