﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;
using SharpBag.Strings;

namespace SharpBag.Math.ForComplex
{
    /// <summary>
    /// A vector.
    /// </summary>
    public class Vector : VectorBase<Complex, Vector>
    {
        #region Properties

        /// <summary>
        /// Gets the length.
        /// </summary>
        public override Complex Length
        {
            get
            {
                Complex sum = 0;
                for (int i = 0; i < this.Dimension; i++) sum += this.Elements[i] * this.Elements[i];
                return Complex.Sqrt(sum);
            }
        }

        /// <summary>
        /// Gets the reverse.
        /// </summary>
        public override Vector Reverse
        {
            get
            {
                Vector result = new Vector(this.Dimension);
                VectorBase<Complex, Vector>.InternalReverse(result, this);
                return result;
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        public Vector(int dimension) : base(dimension) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="elements">The elements.</param>
        public Vector(Complex[] elements) : base(elements) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector"/> class.
        /// </summary>
        /// <param name="other">Another vector to copy.</param>
        public Vector(Vector other) : base(other.Elements) { }

        #endregion Constructors

        #region Casting

        /// <summary>
        /// Performs an implicit conversion from an array of numbers to <see cref="SharpBag.Math.ForComplex.Vector"/>.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Vector(Complex[] elements) { return new Vector(elements); }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SharpBag.Math.ForComplex.Vector"/> to an array of numbers.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Complex[](Vector vector) { return vector.Elements; }

        #endregion Casting

        #region Operators

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator +(Vector left, Vector right) { return Vector.Add(left, right); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator -(Vector left, Vector right) { return Vector.Subtract(left, right); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator -(Vector vector) { return Vector.Negate(vector); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right number.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator *(Vector left, Complex right) { return Vector.Multiply(left, right); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="left">The left number.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Vector operator *(Complex left, Vector right) { return Vector.Multiply(left, right); }

        #endregion Operators

        #region Methods

        /// <summary>
        /// Adds the specified vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The result.</returns>
        public static Vector Add(Vector left, Vector right)
        {
            Contract.Requires(left.Dimension == right.Dimension);
            Vector result = new Vector(left);
            for (int i = 0; i < result.Dimension; i++) result[i] += right[i];
            return result;
        }

        /// <summary>
        /// Subtracts the specified vectors.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The result.</returns>
        public static Vector Subtract(Vector left, Vector right)
        {
            Contract.Requires(left.Dimension == right.Dimension);
            Vector result = new Vector(left);
            for (int i = 0; i < result.Dimension; i++) result[i] -= right[i];
            return result;
        }

        /// <summary>
        /// Multiplies the specified elements.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right number.</param>
        /// <returns>The result.</returns>
        public static Vector Multiply(Vector left, Complex right)
        {
            Vector result = new Vector(left);
            for (int i = 0; i < result.Dimension; i++) result[i] *= right;
            return result;
        }

        /// <summary>
        /// Multiplies the specified elements.
        /// </summary>
        /// <param name="left">The left number.</param>
        /// <param name="right">The right vector.</param>
        /// <returns></returns>
        public static Vector Multiply(Complex left, Vector right) { return Vector.Multiply(right, left); }

        /// <summary>
        /// Negates the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The negated vector.</returns>
        public static Vector Negate(Vector vector) { return -1 * vector; }

        /// <summary>
        /// Calculates the dot product.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The dot product.</returns>
        public static Complex DotProduct(Vector left, Vector right)
        {
            Contract.Requires(left.Dimension == right.Dimension);
            Complex sum = 0;
            for (int i = 0; i < left.Dimension; i++) sum += left[i] * right[i];
            return sum;
        }

        /// <summary>
        /// Calculates the cross product.
        /// </summary>
        /// <param name="left">The left vector.</param>
        /// <param name="right">The right vector.</param>
        /// <returns>The cross product.</returns>
        public static Vector CrossProduct(Vector left, Vector right)
        {
            Contract.Requires(left.Dimension == 3 && right.Dimension == 3);
            return new Complex[] { -left[2] * right[1] + left[1] * right[2], left[2] * right[0] - left[0] * right[2], -left[1] * right[0] + left[0] * right[1] };
        }

        /// <summary>
        /// Converts the vector to a column matrix.
        /// </summary>
        /// <returns>The column matrix.</returns>
        public Matrix ToColumnMatrix()
        {
            Matrix result = new Matrix(this.Dimension, 1);
            VectorBase<Complex, Vector>.InternalToColumnMatrix(result, this);
            return result;
        }

        /// <summary>
        /// Converts the vector to a row matrix.
        /// </summary>
        /// <returns>The row matrix.</returns>
        public Matrix ToRowMatrix()
        {
            Matrix result = new Matrix(1, this.Dimension);
            VectorBase<Complex, Vector>.InternalToRowMatrix(result, this);
            return result;
        }

        #endregion Methods

        #region Comparing / Ordering

        /// <summary>
        /// Determines whether the specified vector is equal to this instance.
        /// </summary>
        /// <param name="other">The vector to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified vector is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(Vector other) { return VectorBase<Complex, Vector>.InternalEquals(this, other); }

        /// <summary>
        /// Determines whether the specified vector is equal to this instance.
        /// </summary>
        /// <param name="obj">The vector to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified vector is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) { return obj.GetType() == typeof(Vector) && this.Equals((Vector)obj); }

        #endregion Comparing / Ordering

        #region Other

        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <returns>The copy.</returns>
        public override Vector Copy() { return new Vector(this); }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return Utils.Hash(this.Elements);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().Append("[ ");
            for (int i = 0; i < this.Dimension; i++)
            {
                if (i != 0) sb.Append('\t');
                sb.Append(this[i].ToComplexString());
            }

            return sb.Append(" ]").ToString();
        }

        #endregion Other
    }
}