using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    public class Kelvin : Temperature
    {
        public const string Unit = "K";

        private double Value { get; set; }

        public Kelvin(double v)
        {
            this.Value = v;
        }

        public static implicit operator Kelvin(double v)
        {
            return new Kelvin(v);
        }

        public static implicit operator double(Kelvin v)
        {
            return v.Value;
        }

        public static explicit operator Kelvin(Fahrenheit v)
        {
            return new Kelvin(((double)v + 459.67) * (5.0 / 9.0));
        }

        public static explicit operator Kelvin(Celsius v)
        {
            return new Kelvin((double)v + 273.15);
        }

        public override string ToString()
        {
            return this.Value.ToString() + " K";
        }

        public string ToString(bool unit)
        {
            return this.Value.ToString() + (unit ? " K" : "");
        }

        public string ToString(bool unit, Func<double, string> result)
        {
            return result(this.Value) + (unit ? " K" : "");
        }
    }
}
