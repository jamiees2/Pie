using System;

namespace Pie.Units
{
    public abstract class Length
    {
        public abstract string Unit { get; }

        public abstract double BaseValue { get; }

        public double Value { get; set; }

        public Length(double v)
        {
            this.Value = v;
        }

        public static implicit operator double(Length v)
        {
            return v.Value;
        }

        public TResult As<TValue, TResult>()
            where TValue : Length, new()
            where TResult : Length, new()
        {
            TResult instance = Activator.CreateInstance<TResult>();
            instance.Value = Activator.CreateInstance<TValue>().Value * (Activator.CreateInstance<TValue>().BaseValue / this.BaseValue);
            return instance;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public string ToString(bool unit)
        {
            return this.Value.ToString() + (unit ? " " + this.Unit : "");
        }

        public string ToString(bool unit, Func<double, string> result)
        {
            return result(this.Value) + (unit ? " " + this.Unit : "");
        }
    }
}
