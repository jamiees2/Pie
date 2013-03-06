using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.Units
{
    /// <summary>
    /// An interface for bits/bytes to implement
    /// </summary>
    public abstract class BitSize
    {
        /// <summary>
        /// The unit of the current instance
        /// </summary>
        public abstract string Unit { get; }

        /// <summary>
        /// The base value of the current instance (When is it one?)
        /// </summary>
        public abstract double BaseValue { get; }

        /// <summary>
        /// The value of the current instance (The actual value)
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// The simple constructor
        /// </summary>
        /// <param name="v">The value to use</param>
        public BitSize(double v)
        {
            this.Value = v;
        }

        /// <summary>
        /// An implicit overload, so that this can be cast to double easily
        /// </summary>
        /// <param name="v"></param>
        /// <returns>The value as a double</returns>
        public static implicit operator double(BitSize v)
        {
            return v.Value;
        }

        /// <summary>
        /// Converts the current object to another instance
        /// </summary>
        /// <typeparam name="TValue">The type of the current instance</typeparam>
        /// <typeparam name="TResult">The type of the instance to convert to</typeparam>
        /// <returns>An object of type TResult with the instance set</returns>
        public TResult As<TValue, TResult>()
            where TValue : BitSize, new()
            where TResult : BitSize, new()
        {
            TResult instance = Activator.CreateInstance<TResult>();
            instance.Value = Activator.CreateInstance<TValue>().Value * (Activator.CreateInstance<TValue>().BaseValue / this.BaseValue);
            return instance;
        }

        /// <summary>
        /// Converts the instance to a string
        /// </summary>
        /// <returns>A string representing the current value of the instance</returns>
        public override string ToString()
        {
            return this.Value.ToString();
        }

        /// <summary>
        /// Converts the instance to a string, with the unit
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The string representing the current value of the instance</returns>
        public string ToString(bool unit)
        {
            return this.Value.ToString() + (unit ? " " + this.Unit : "");
        }

        /// <summary>
        /// Converts the current instance to a string, using a function
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="result"></param>
        /// <returns>The output of the function passed with a string</returns>
        public string ToString(bool unit, Func<double, string> result)
        {
            return result(this.Value) + (unit ? " " + this.Unit : "");
        }
    }
}
