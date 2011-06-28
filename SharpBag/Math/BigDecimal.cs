﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBag.Math
{
#if DOTNET4

	using System.Diagnostics.Contracts;
	using System.Numerics;

	/// <summary>
	/// An arbitrary big decimal.
	/// </summary>
	public struct BigDecimal : IComparable<BigDecimal>, IEquatable<BigDecimal>
	{
		#region Properties

		private const int DefaultPrecision = 32;

		private const int Radix = 10;

		private const int RadixPow2 = 100;

		private int _Precision;

		/// <summary>
		/// The maximum amount of digits after the decimal point.
		/// </summary>
		public int Precision
		{
			get { return _Precision; }
			private set
			{
				bool fix = value < _Precision;
				_Precision = value;
				if (fix) this.FixPrecision();
			}
		}

		private BigInteger _Mantissa;

		private BigInteger Mantissa { get { return _Mantissa; } set { _Mantissa = value; } }

		private int _Exponent;

		private int Exponent { get { return _Exponent; } set { _Exponent = value; } }

		private bool _Normalized;

		private bool Normalized { get { return _Normalized; } set { _Normalized = value; } }

		#endregion Properties

		#region Static Instances

		/// <summary>
		/// A positive one.
		/// </summary>
		public static readonly BigDecimal PositiveOne = new BigDecimal(1);

		/// <summary>
		/// A negative one.
		/// </summary>
		public static readonly BigDecimal NegativeOne = new BigDecimal(-1);

		/// <summary>
		/// A zero.
		/// </summary>
		public static readonly BigDecimal Zero = new BigDecimal(0);

		#endregion Static Instances

		#region Constructors / Factories

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		public BigDecimal(int value) : this(value, 0, DefaultPrecision, false) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		public BigDecimal(int value, int precision) : this(value, 0, precision, false) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		public BigDecimal(long value) : this(value, 0, DefaultPrecision, false) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		public BigDecimal(long value, int precision) : this(value, 0, precision, false) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		public BigDecimal(BigInteger value, int precision) : this(value, 0, precision, false) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		public BigDecimal(BigInteger value) : this(value, 0, DefaultPrecision, false) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		public BigDecimal(float value) : this(value, DefaultPrecision) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		public BigDecimal(float value, int precision) : this(value, DefaultPrecision, false) { }

		private BigDecimal(float value, int precision, bool normalized)
		{
			Contract.Requires(precision >= 0);
			string[] srep = value.ToString("R").Split('E');
			BigDecimal parsed = BigDecimal.Parse(srep[0]);

			_ToStringCache = null;
			_Mantissa = parsed.Mantissa;
			_Exponent = srep.Length == 2 ? (parsed.Exponent + Convert.ToInt32(srep[1])) : parsed.Exponent;
			_Precision = precision;
			_Normalized = normalized;

			this.FixPrecision();
			this.Normalize();
		}

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		public BigDecimal(double value) : this(value, DefaultPrecision) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		public BigDecimal(double value, int precision) : this(value, precision, false) { }

		private BigDecimal(double value, int precision, bool normalized)
		{
			Contract.Requires(precision >= 0);
			string[] srep = value.ToString("R").Split('E');
			BigDecimal parsed = BigDecimal.Parse(srep[0]);

			_ToStringCache = null;
			_Mantissa = parsed.Mantissa;
			_Exponent = srep.Length == 2 ? (parsed.Exponent + Convert.ToInt32(srep[1])) : parsed.Exponent;
			_Precision = precision;
			_Normalized = normalized;

			this.FixPrecision();
			this.Normalize();
		}

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		public BigDecimal(BigDecimal value) : this(value.Mantissa, value.Exponent, value.Precision, value.Normalized) { }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="value">The value of the decimal.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		public BigDecimal(BigDecimal value, int precision) : this(value.Mantissa, value.Exponent, precision, value.Normalized) { }

		private BigDecimal(BigInteger value, int exponent, int precision, bool normalized)
		{
			Contract.Requires(precision >= 0);
			_ToStringCache = null;
			_Mantissa = value;
			_Exponent = exponent;
			_Precision = precision;
			_Normalized = normalized;

			this.FixPrecision();
			this.Normalize();
		}

		/// <summary>
		/// Parse the specified string.
		/// </summary>
		/// <param name="value">The specified string.</param>
		/// <returns>The BigDecimal represented by the string.</returns>
		public static BigDecimal Parse(string value)
		{
			BigDecimal parsed = BigDecimal.Parse(value, Int32.MaxValue);
			int precision = parsed.Precision;
			precision = -parsed.Exponent;
			if (precision < DefaultPrecision) precision = DefaultPrecision;
			if (precision != parsed.Precision) parsed.Precision = precision;
			return parsed;
		}

		/// <summary>
		/// Parse the specified string.
		/// </summary>
		/// <param name="value">The specified string.</param>
		/// <param name="precision">The maximum amount of digits after the decimal point.</param>
		/// <returns>The BigDecimal represented by the string.</returns>
		public static BigDecimal Parse(string value, int precision)
		{
			Contract.Requires(precision >= 0);
			value = value.Trim();
			int exp = 0;
			BigInteger mantissa = 0;
			bool foundComma = false;
			int i = 0;
			bool neg = false;
			if (value[0] == '-')
			{
				neg = true;
				i++;
			}

			for (; i < value.Length; i++)
			{
				if (value[i] == '.' || value[i] == ',')
				{
					if (foundComma) throw new FormatException();
					foundComma = true;
					continue;
				}

				if (!Char.IsDigit(value[i])) throw new FormatException();
				if (foundComma) exp--;
				mantissa *= 10;
				mantissa += value[i] - '0';
			}

			return new BigDecimal(neg ? -mantissa : mantissa, exp, precision, false);
		}

		#endregion Constructors / Factories

		#region Operators

		/// <summary>
		/// The + operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>Left + Right</returns>
		public static BigDecimal operator +(BigDecimal left, BigDecimal right) { return left.Add(right); }

		/// <summary>
		/// The - operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>Left - Right</returns>
		public static BigDecimal operator -(BigDecimal left, BigDecimal right) { return left.Subtract(right); }

		/// <summary>
		/// The * operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>Left * Right</returns>
		public static BigDecimal operator *(BigDecimal left, BigDecimal right) { return left.Multiply(right); }

		/// <summary>
		/// The / operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>Left / Right</returns>
		public static BigDecimal operator /(BigDecimal left, BigDecimal right) { return left.Divide(right); }

		/// <summary>
		/// The - operator.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>-Left</returns>
		public static BigDecimal operator -(BigDecimal value) { return value.Negate(); }

		private BigDecimal Add(BigDecimal right, bool normalize)
		{
			BigDecimal.Normalize(ref this, ref right);
			BigDecimal result = new BigDecimal(this.Mantissa + right.Mantissa, this.Exponent, this.Precision > right.Precision ? this.Precision : right.Precision, false);

			if (normalize)
			{
				this.Normalize();
				right.Normalize();
			}

			return result;
		}

		private BigDecimal Add(BigDecimal right)
		{
			return this.Add(right, true);
		}

		private BigDecimal Subtract(BigDecimal right, bool normalize)
		{
			BigDecimal.Normalize(ref this, ref right);
			BigDecimal result = new BigDecimal(this.Mantissa - right.Mantissa, this.Exponent, this.Precision > right.Precision ? this.Precision : right.Precision, false);

			if (normalize)
			{
				this.Normalize();
				right.Normalize();
			}

			return result;
		}

		private BigDecimal Subtract(BigDecimal right)
		{
			return this.Subtract(right, true);
		}

		private BigDecimal Negate()
		{
			return new BigDecimal(-this.Mantissa, this.Exponent, this.Precision, this.Normalized);
		}

		private BigDecimal Multiply(BigDecimal right)
		{
			int z = this.Exponent + right.Exponent;
			BigInteger m = this.Mantissa * right.Mantissa;
			return new BigDecimal(m, z, this.Precision > right.Precision ? this.Precision : right.Precision, false);
		}

		private BigDecimal Divide(BigDecimal right)
		{
			int precision = (this.Precision > right.Precision ? this.Precision : right.Precision) + 2,
				exponent = this.Exponent - right.Exponent,
				iterations = 0;

			bool leftPos = this.Mantissa >= 0,
				 rightPos = right.Mantissa >= 0,
				 pos = !(leftPos ^ rightPos);

			BigInteger remainder,
					   lastRemainder = 0, digit,
					   mantissa = BigInteger.DivRem(leftPos ? this.Mantissa : -this.Mantissa, rightPos ? right.Mantissa : -right.Mantissa, out remainder);

			while (remainder > 0 && iterations < precision)
			{
				exponent--;
				mantissa *= 10;
				remainder *= 10;
				mantissa += digit = BigInteger.DivRem(remainder, rightPos ? right.Mantissa : -right.Mantissa, out remainder);
				lastRemainder = remainder;
				if (mantissa != 0) iterations++;
			}

			return new BigDecimal(pos ? mantissa : -mantissa, exponent, precision - 2, false);
		}

		/// <summary>
		/// Raise the BigDecimal to the specified power.
		/// </summary>
		/// <param name="value">The BigDecimal.</param>
		/// <param name="power">The power.</param>
		/// <returns>The BigDecimal raised to the specified power.</returns>
		public static BigDecimal Pow(BigDecimal value, int power)
		{
			Contract.Requires(power >= 0);
			if (power == 0) return new BigDecimal(1, 0, value.Precision, true);
			if (power == 1) return new BigDecimal(value);
			if (power == 2) return value.Multiply(value);
			if (power == 3) return value.Multiply(value).Multiply(value);

			if (power % 2 == 0)
			{
				BigDecimal temp = BigDecimal.Pow(value, power / 2);
				return temp.Multiply(temp);
			}
			else
			{
				BigDecimal temp = BigDecimal.Pow(value, (power - 1) / 2);
				return temp.Multiply(temp).Multiply(value);
			}
		}

		/// <summary>
		/// The base-10 logarithm of the BigDecimal.
		/// </summary>
		/// <param name="value">The BigDecimal.</param>
		/// <returns>The base-10 logarithm of the BigDecimal.</returns>
		public static BigDecimal Log10(BigDecimal value)
		{
			if (value < 1) throw new ArgumentOutOfRangeException("value");
			int a = (int)BigInteger.Log10(value.Mantissa) + value.Exponent;
			BigDecimal m = value;
			BigInteger mantissa = a;
			int digits = 0;

			while (digits < value.Precision)
			{
				m = BigDecimal.Pow(new BigDecimal(m, value.Precision).Divide(BigInteger.Pow(10, a)), 10);
				a = (int)BigInteger.Log10(m.Mantissa) + m.Exponent;
				mantissa = mantissa * 10 + a;
				digits++;
			}

			return new BigDecimal(mantissa, -digits, value.Precision, false).RoundLastDigit();
		}

		/// <summary>
		/// The logarithm of the BigDecimal in the specified base.
		/// </summary>
		/// <param name="value">The BigDecimal.</param>
		/// <param name="logBase">The specified base.</param>
		/// <returns>The logarithm of the BigDecimal in the specified base.</returns>
		public static BigDecimal Log(BigDecimal value, BigDecimal logBase)
		{
			return BigDecimal.Log10(value).Divide(BigDecimal.Log10(logBase));
		}

		/// <summary>
		/// The square root of the BigDecimal.
		/// </summary>
		/// <param name="value">The BigDecimal.</param>
		/// <returns>The square root.</returns>
		public static BigDecimal Sqrt(BigDecimal value)
		{
			Contract.Requires(value >= 0);
			if (value.Mantissa == 0) return new BigDecimal(0, 0, value.Precision, true);
			BigDecimal sqrt = new BigDecimal(1, value.Precision + 1), last, two = new BigDecimal(2, value.Precision + 1);

			do
			{
				last = sqrt;
				sqrt = sqrt - ((sqrt * sqrt) - value) / (two * sqrt);
			}
			while (sqrt != last);

			sqrt.Precision--;
			return sqrt;
		}

		/// <summary>
		/// The reciprocal of the BigDecimal.
		/// </summary>
		/// <param name="value">The BigDecimal.</param>
		/// <returns>The reciprocal of the BigDecimal.</returns>
		public static BigDecimal Reciprocal(BigDecimal value)
		{
			return BigDecimal.PositiveOne / value;
		}

		#endregion Operators

		#region Ordering

		/// <summary>
		/// The > operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>True if Left > Right</returns>
		public static bool operator >(BigDecimal left, BigDecimal right) { return left.CompareTo(right) > 0; }

		/// <summary>
		/// The >= operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>True if Left >= Right</returns>
		public static bool operator >=(BigDecimal left, BigDecimal right) { return left.CompareTo(right) >= 0; }

		/// <summary>
		/// The &lt; operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>True if Left %lt; Right</returns>
		public static bool operator <(BigDecimal left, BigDecimal right) { return left.CompareTo(right) < 0; }

		/// <summary>
		/// The &lt;= operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>True if Left %lt;= Right</returns>
		public static bool operator <=(BigDecimal left, BigDecimal right) { return left.CompareTo(right) <= 0; }

		/// <summary>
		/// The == operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>True if Left == Right</returns>
		public static bool operator ==(BigDecimal left, BigDecimal right) { return left.Equals(right); }

		/// <summary>
		/// The != operator.
		/// </summary>
		/// <param name="left">The left BigDecimal.</param>
		/// <param name="right">The right BigDecimal.</param>
		/// <returns>True if Left != Right</returns>
		public static bool operator !=(BigDecimal left, BigDecimal right) { return !left.Equals(right); }

		private bool Equals(BigDecimal other, bool normalize)
		{
			BigDecimal.Normalize(ref this, ref other);
			bool eq = this.Mantissa.Equals(other.Mantissa);

			if (normalize)
			{
				this.Normalize();
				other.Normalize();
			}

			return eq;
		}

		/// <summary>
		/// IEquatable.Equals()
		/// </summary>
		/// <param name="other">Another BigDecimal.</param>
		/// <returns>Wheter this is equal to the other BigDecimal.</returns>
		public bool Equals(BigDecimal other)
		{
			return this.Equals(other, true);
		}

		/// <summary>
		/// Object.Equals()
		/// </summary>
		/// <param name="obj">Another BigDecimal.</param>
		/// <returns>Wheter this is equal to the other BigDecimal.</returns>
		public override bool Equals(object obj)
		{
			return obj.GetType() == typeof(BigDecimal) && this.Equals((BigDecimal)obj);
		}

		private int CompareTo(BigDecimal other, bool normalize)
		{
			BigDecimal.Normalize(ref this, ref other);
			int cmp = this.Mantissa.CompareTo(other.Mantissa);

			if (normalize)
			{
				this.Normalize();
				other.Normalize();
			}

			return cmp;
		}

		/// <summary>
		/// IComparable.CompareTo()
		/// </summary>
		/// <param name="other">Another BigDecimal.</param>
		/// <returns>The order of the BigDecimals.</returns>
		public int CompareTo(BigDecimal other)
		{
			return this.CompareTo(other, true);
		}

		#endregion Ordering

		#region Casting

		/// <summary>
		/// A casting operator.
		/// </summary>
		/// <param name="n">A value.</param>
		/// <returns>The result.</returns>
		public static implicit operator BigDecimal(int n) { return new BigDecimal(n); }

		/// <summary>
		/// A casting operator.
		/// </summary>
		/// <param name="n">A value.</param>
		/// <returns>The result.</returns>
		public static implicit operator BigDecimal(long n) { return new BigDecimal(n); }

		/// <summary>
		/// A casting operator.
		/// </summary>
		/// <param name="n">A value.</param>
		/// <returns>The result.</returns>
		public static implicit operator BigDecimal(BigInteger n) { return new BigDecimal(n); }

		/// <summary>
		/// A casting operator.
		/// </summary>
		/// <param name="n">A value.</param>
		/// <returns>The result.</returns>
		public static implicit operator BigDecimal(float n) { return new BigDecimal(n); }

		/// <summary>
		/// A casting operator.
		/// </summary>
		/// <param name="n">A value.</param>
		/// <returns>The result.</returns>
		public static implicit operator BigDecimal(double n) { return new BigDecimal(n); }

		#endregion Casting

		private BigDecimal RoundLastDigit()
		{
			this.Normalize();
			if (this.Exponent >= 0 || this.Mantissa % 10 != 9) return new BigDecimal(this);
			return new BigDecimal(this.Mantissa + 1, this.Exponent, this.Precision, false);
		}

		private void FixPrecision()
		{
			if (this.Exponent < 0)
			{
				int n = -this.Exponent - this.Precision;
				if (n > 0)
				{
					this.Mantissa /= BigInteger.Pow(10, n);
					this.Exponent += n;
				}
			}
		}

		private void Normalize()
		{
			if (!this.Normalized)
			{
				if (this.Mantissa != 0)
				{
					while (this.Mantissa % RadixPow2 == 0)
					{
						this.Exponent += 2;
						this.Mantissa /= RadixPow2;
					}

					if (this.Mantissa % Radix == 0)
					{
						this.Exponent++;
						this.Mantissa /= Radix;
					}
				}

				this.Normalized = true;
			}
		}

		private void NormalizeTo(BigDecimal other)
		{
			if (this.Exponent > other.Exponent)
			{
				this.Mantissa *= BigInteger.Pow(Radix, this.Exponent - other.Exponent);
				this.Exponent = other.Exponent;
			}
		}

		private static void Normalize(ref BigDecimal a, ref BigDecimal b)
		{
			if (a.Exponent > b.Exponent) a.NormalizeTo(b);
			else b.NormalizeTo(a);
		}

		/// <summary>
		/// Returns a BigDecimal with the specified precision.
		/// </summary>
		/// <param name="precision">The precision.</param>
		/// <returns>A BigDecimal with the specified precision.</returns>
		public BigDecimal WithPrecision(int precision)
		{
			Contract.Requires(precision >= 0);
			return new BigDecimal(this, precision);
		}

		/// <summary>
		/// Object.GetHashCode();
		/// </summary>
		/// <returns>The hash code of the current instance.</returns>
		public override int GetHashCode()
		{
			return this.Mantissa.GetHashCode() ^ this.Exponent.GetHashCode();
		}

		private string _ToStringCache;

		/// <summary>
		/// Object.ToString()
		/// </summary>
		/// <returns>The string representation of the BigDecimal.</returns>
		public override string ToString()
		{
			if (_ToStringCache != null) return _ToStringCache;
			bool positive = this.Mantissa >= 0;
			StringBuilder sb = new StringBuilder((positive ? this.Mantissa : -this.Mantissa).ToString());

			int exp = this.Exponent,
				index = sb.Length + exp;

			if (index > sb.Length)
			{
				sb.Append('0', index - sb.Length);
			}
			else if (index <= 0)
			{
				sb.Insert(0, "0", -index + 1);
				index = 1;
			}

			bool comma = false;
			if (index < sb.Length)
			{
				sb.Insert(index, '.');
				comma = true;
			}

			if (!positive) sb.Insert(0, '-');
			string res = sb.ToString();
			if (comma) res = res.TrimEnd('0');
			if (res[res.Length - 1] == '.') res = res.Substring(0, res.Length - 1);
			return _ToStringCache = res;
		}
	}

#endif
}