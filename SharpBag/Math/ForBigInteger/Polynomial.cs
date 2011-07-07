﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBag.Math.ForBigInteger
{
#if DOTNET4

	using System.Diagnostics.Contracts;
	using System.Numerics;

	/// <summary>
	/// A polynomial.
	/// </summary>
	public class Polynomial
	{
		private BigInteger[] Coefficients;

		/// <summary>
		/// The degree of the polynomial.
		/// </summary>
		public int Degree
		{
			get
			{
				return this.Coefficients.Length - 1;
			}
		}

		/// <summary>
		/// The constructor.
		/// </summary>
		public Polynomial()
		{
			this.Coefficients = new BigInteger[1];
			this.Coefficients[0] = 0;
		}

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="coefficients">The coefficients.</param>
		public Polynomial(params BigInteger[] coefficients)
		{
			int len = coefficients.Length;
			while (len > 0 && coefficients[len - 1] == 0) len--;

			if (len == 0)
			{
				this.Coefficients = new BigInteger[1];
				this.Coefficients[0] = 0;
			}
			else
			{
				this.Coefficients = new BigInteger[len];
				for (int i = 0; i < len; i++) this.Coefficients[i] = coefficients[i];
			}
		}

		/// <summary>
		/// Evalute the polynomial at the specified x.
		/// </summary>
		/// <param name="x">The specified x.</param>
		/// <returns>The result.</returns>
		public BigInteger Evaluate(BigInteger x)
		{
			BigInteger result = 0;
			for (int i = this.Degree; i >= 0; i--)
			{
				result = result * x + this[i];
			}

			return result;
		}

		/// <summary>
		/// The i-th coefficient.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns>The i-th coefficient.</returns>
		public BigInteger this[int i]
		{
			get
			{
				if (i >= this.Coefficients.Length) return 0;
				return this.Coefficients[i];
			}
			set
			{
				if (i >= this.Coefficients.Length)
				{
					int old = this.Coefficients.Length;
					Array.Resize<BigInteger>(ref this.Coefficients, i + 1);
					for (int j = old; j < i; j++)
					{
						this.Coefficients[j] = 0;
					}
				}

				this.Coefficients[i] = value;
			}
		}

		/// <summary>
		/// Add the specified polynomials.
		/// </summary>
		/// <param name="left">The left polynomial.</param>
		/// <param name="right">The right polynomial.</param>
		/// <returns>The result.</returns>
		public static Polynomial operator +(Polynomial left, Polynomial right)
		{
			BigInteger[] added = new BigInteger[left.Coefficients.Length > right.Coefficients.Length ? left.Coefficients.Length : right.Coefficients.Length];
			for (int i = left.Coefficients.Length; i < added.Length; i++) added[i] = 0;
			for (int i = 0; i < left.Coefficients.Length; i++) added[i] = left[i];
			for (int i = 0; i < added.Length; i++) added[i] += right[i];
			return new Polynomial(added);
		}

		/// <summary>
		/// Subtract the specified polynomials.
		/// </summary>
		/// <param name="left">The left polynomial.</param>
		/// <param name="right">The right polynomial.</param>
		/// <returns>The result.</returns>
		public static Polynomial operator -(Polynomial left, Polynomial right)
		{
			BigInteger[] subtracted = new BigInteger[left.Coefficients.Length > right.Coefficients.Length ? left.Coefficients.Length : right.Coefficients.Length];
			for (int i = left.Coefficients.Length; i < subtracted.Length; i++) subtracted[i] = 0;
			for (int i = 0; i < left.Coefficients.Length; i++) subtracted[i] = left[i];
			for (int i = 0; i < subtracted.Length; i++) subtracted[i] -= right[i];
			return new Polynomial(subtracted);
		}

		/// <summary>
		/// Negate the specified polynomial.
		/// </summary>
		/// <param name="value">The polynomial.</param>
		/// <returns>The negated polynomial.</returns>
		public static Polynomial operator -(Polynomial value)
		{
			BigInteger[] negated = new BigInteger[value.Coefficients.Length];
			for (int i = 0; i < value.Coefficients.Length; i++) negated[i] = -value[i];
			return new Polynomial(negated);
		}

		/// <summary>
		/// Multiply the specified polynomials.
		/// </summary>
		/// <param name="left">The left polynomial.</param>
		/// <param name="right">The right polynomial.</param>
		/// <returns>The result.</returns>
		public static Polynomial operator *(Polynomial left, Polynomial right)
		{
			int newLength = left.Degree + right.Degree + 1;
			BigInteger[] multiplied = new BigInteger[newLength];
			for (int i = 0; i < newLength; i++) multiplied[i] = 0;

			for (int a = 0; a <= left.Degree; a++)
			{
				for (int b = 0; b <= right.Degree; b++)
				{
					multiplied[a + b] += left[a] * right[b];
				}
			}

			return new Polynomial(multiplied);
		}

		/// <summary>
		/// Divide the specified polynomials.
		/// </summary>
		/// <param name="left">The left polynomial.</param>
		/// <param name="right">The right polynomial.</param>
		/// <returns>The result.</returns>
		public static Polynomial operator /(Polynomial left, Polynomial right)
		{
			if (left.Degree >= right.Degree)
			{
				Polynomial q = new Polynomial(0);

				while (left.Degree >= right.Degree)
				{
					Polynomial d = right * OfDegree(left.Degree - right.Degree, 1);
					q[left.Degree - right.Degree] = left[left.Degree] / d[d.Degree];
					d = d * q[left.Degree - right.Degree];
					left = left - d;

					if (left.Degree == 0 && right.Degree == 0) return new Polynomial(0);
				}

				return q;
			}
			else
			{
				return new Polynomial(0);
			}
		}

		/// <summary>
		/// Divide the specified polynomials.
		/// </summary>
		/// <param name="left">The left polynomial.</param>
		/// <param name="right">The right polynomial.</param>
		/// <param name="remainder">The remainder.</param>
		/// <returns>The result.</returns>
		public static Polynomial DivRem(Polynomial left, Polynomial right, out Polynomial remainder)
		{
			if (left.Degree >= right.Degree)
			{
				Polynomial q = new Polynomial(0);

				while (left.Degree >= right.Degree)
				{
					Polynomial d = right * Polynomial.OfDegree(left.Degree - right.Degree, 1);
					q[left.Degree - right.Degree] = left[left.Degree] / d[d.Degree];
					d = d * q[left.Degree - right.Degree];
					left = left - d;

					if (left.Degree == 0 && right.Degree == 0)
					{
						remainder = left;
						return new Polynomial(0);
					}
				}

				remainder = left;
				return q;
			}
			else
			{
				remainder = left;
				return new Polynomial(0);
			}
		}

		private static Polynomial OfDegree(int degree, BigInteger coefficient)
		{
			BigInteger[] c = new BigInteger[degree + 1];
			c[degree] = coefficient;
			return new Polynomial(c);
		}

		/// <summary>
		/// An implicit cast to a polynomial.
		/// </summary>
		/// <param name="n">The value to cast.</param>
		/// <returns>The polynomial.</returns>
		public static implicit operator Polynomial(BigInteger n)
		{
			return new Polynomial(n);
		}

		/// <summary>
		/// Finds the derivative of the polynomial.
		/// </summary>
		/// <returns>The derivative of the polynomial.</returns>
		public Polynomial Derivative()
		{
			BigInteger[] coefficients = new BigInteger[this.Degree];

			for (int i = 0; i < this.Degree; i++)
			{
				coefficients[i] = this[i + 1] * (i + 1);
			}

			return new Polynomial(coefficients);
		}

		/// <summary>
		/// Finds the i-th derivative of the polynomial.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <returns>The i-th derivative of the polynomial.</returns>
		public Polynomial Derivative(int i)
		{
#if DOTNET4
			Contract.Requires(i >= 0);
#endif
			Polynomial derivative = this;
			for (int j = 0; j < i; j++)
			{
				derivative = derivative.Derivative();
			}

			return derivative;
		}

		/// <summary>
		/// Object.ToString()
		/// </summary>
		/// <returns>The polynomial as a string.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = this.Degree; i >= 0; i--)
			{
				if (this[i] == 0) continue;
				sb.Append(" + ");
				if (!(i > 0 && this[i] == 1)) sb.Append(this[i].ToString());
				if (i > 0) sb.Append('x');
				if (i > 1) sb.Append('^').Append(i);
			}

			return sb.ToString().TrimStart(' ', '+');
		}
	}

#endif
}