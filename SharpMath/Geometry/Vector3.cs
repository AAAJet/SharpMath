﻿using System;

namespace SharpMath.Geometry
{
    /// <summary>
    ///     Represents a three-dimensional vector.
    /// </summary>
    public class Vector3 : Vector
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        public Vector3()
            : base(3)
        {
            // We don't need to set anything as value types are initialized by default with the values we want
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="vector">The existing <see cref="Vector3"/> to copy.</param>
        public Vector3(Vector3 vector) 
            : base(vector)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="x">The value of the X-coordinate (X2 in mathematic coordinate systems).</param>
        /// <param name="y">The value of the Y-coordinate (X3 in mathematic coordinate systems).</param>
        /// <param name="z">The value of the Z-coordinate (X1 in mathematic coordinate systems).</param>
        public Vector3(double x, double y, double z)
            : base(x, y, z)
        {
        }

        /// <summary>
        ///     Generates a <see cref="Vector3"/> from the <see cref="Vector"/> base class, if the dimension is correct.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to generate a <see cref="Vector3"/> from.</param>
        /// <returns>The generated <see cref="Vector3"/>.</returns>
        /// <exception cref="ArgumentException">The dimension of the given vector is invalid. It must be 3.</exception>
        public static Vector3 FromVector(Vector vector)
        {
            if (vector.Dimension != 3)
                throw new ArgumentException("The dimension of the given vector is invalid. It must be 3.");
            return new Vector3(vector[0], vector[1], vector[2]);
        }

        /// <summary>
        ///     Gets or sets the value of the X-coordinate (X2 in mathematic coordinate systems).
        /// </summary>
        public double X
        {
            get
            {
                return this[0];
            }
            set
            {
                this[0] = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the Y-coordinate (X3 in mathematic coordinate systems).
        /// </summary>
        public double Y
        {
            get
            {
                return this[1];
            }
            set
            {
                this[1] = value;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the Z-coordinate (X1 in mathematic coordinate systems).
        /// </summary>
        public double Z
        {
            get
            {
                return this[2];
            }
            set
            {
                this[2] = value;
            }
        }

        /// <summary>
        ///     A unit <see cref="Vector3"/> with all values set to zero.
        /// </summary>
        public static Vector3 Zero => new Vector3(0, 0, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/> with all values set to one.
        /// </summary>
        public static Vector3 One => new Vector3(1, 1, 1);

        /// <summary>
        ///     A unit <see cref="Vector3"/> pointing up.
        /// </summary>
        public static Vector3 Up => new Vector3(0, 1, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/> pointing down.
        /// </summary>
        public static Vector3 Down => new Vector3(0, -1, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/> pointing to the left.
        /// </summary>
        public static Vector3 Left => new Vector3(-1, 0, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/> pointing to the right.
        /// </summary>
        public static Vector3 Right => new Vector3(1, 0, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/> pointing forward.
        /// </summary>
        public static Vector3 Forward => new Vector3(0, 0, 1);

        /// <summary>
        ///     A unit <see cref="Vector3"/> pointing backward.
        /// </summary>
        public static Vector3 Back => new Vector3(0, 0, -1);

        /// <summary>
        ///     A unit <see cref="Vector3"/>  with coordinates 1, 0, 0.
        /// </summary>
        public static Vector3 UnitX => new Vector3(1, 0, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/>  with coordinates 0, 1, 0.
        /// </summary>
        public static Vector3 UnitY => new Vector3(0, 1, 0);

        /// <summary>
        ///     A unit <see cref="Vector3"/>  with coordinates 0, 0, 1.
        /// </summary>
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        /// <summary>
        ///     Calculates the <see cref="Vector3"/> that is perpendicular to this and the specified <see cref="Vector3"/>.
        /// </summary>
        /// <param name="other">The other <see cref="Vector3"/> that should be included into the calculation.</param>
        /// <returns>Returns the calculated <see cref="Vector3"/>.</returns>
        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3((Y * other.Z - Z * other.Y), (Z * other.X - X * other.Z), (X * other.Y - Y * other.X)); 
        }

        /// <summary>
        ///     Calculates the <see cref="Vector3"/> that is perpendicular to the specified <see cref="Vector3"/> instances.
        /// </summary>
        /// <param name="firstVector">The first <see cref="Vector3"/> that should be included into the calculation.</param>
        /// <param name="secondVector">The second <see cref="Vector3"/> that should be included into the calculation.</param>
        /// <returns>Returns the calculated <see cref="Vector3"/>.</returns>
        public static Vector3 CrossProduct(Vector3 firstVector, Vector3 secondVector)
        {
            return firstVector.CrossProduct(secondVector);
        }

        /// <summary>
        ///     Calculates the area of the parallelogram that this and the specified <see cref="Vector3"/> instances span.
        /// </summary>
        /// <param name="other">The other <see cref="Vector3"/>.</param>
        /// <returns>Returns the area of the spanned parallelogram.</returns>
        public double Area(Vector3 other)
        {
            return CrossProduct(this, other).Magnitude;
        }

        /// <summary>
        ///     Calculates the area of the parallelogram that the two specified <see cref="Vector3"/> instances span.
        /// </summary>
        /// <param name="firstVector">The first <see cref="Vector3"/>.</param>
        /// <param name="secondVector">The second <see cref="Vector3"/>.</param>
        /// <returns>Returns the area of the spanned parallelogram.</returns>
        public static double Area(Vector3 firstVector, Vector3 secondVector)
        {
            return firstVector.Area(secondVector);
        }
        
        /// <summary>
        ///     Calculates the volume of the parallelepiped that is being created by the three specified <see cref="Vector3"/> instances.
        /// </summary>
        /// <param name="firstVector">The first <see cref="Vector3"/>.</param>
        /// <param name="secondVector">The second <see cref="Vector3"/>.</param>
        /// <param name="thirdVector">The third <see cref="Vector3"/>.</param>
        /// <returns>Returns the calculated volume.</returns>
        public static double ScalarTripleProduct(Vector3 firstVector, Vector3 secondVector, Vector3 thirdVector)
        {
            //var matrix = SquareMatrix.FromMatrix(firstVector.AsHorizontalMatrix().AugmentVertically(secondVector.AsHorizontalMatrix()).AugmentVertically(thirdVector.AsHorizontalMatrix()));
            //return Math.Abs(matrix.Determinant);

            return Math.Abs(ScalarProduct(CrossProduct(firstVector, secondVector), thirdVector));
        }

        /// <summary>
        ///     Implements the operator +.
        /// </summary>
        /// <param name="firstVector">The first <see cref="Vector3"/>.</param>
        /// <param name="secondVector">The second <see cref="Vector3"/>.</param>
        /// <returns>
        ///     The resulting <see cref="Vector3"/>.
        /// </returns>
        public static Vector3 operator +(Vector3 firstVector, Vector3 secondVector)
        {
            return FromVector(Add(firstVector, secondVector));
        }

        /// <summary>
        ///     Implements the operator -.
        /// </summary>
        /// <param name="firstVector">The first vector.</param>
        /// <param name="secondVector">The second vector.</param>
        /// <returns>
        ///     The resulting <see cref="Vector3"/>.
        /// </returns>
        public static Vector3 operator -(Vector3 firstVector, Vector3 secondVector)
        {
            return FromVector(Subtract(firstVector, secondVector));
        }

        /// <summary>
        ///     Implements the operator -.
        /// </summary>
        /// <param name="current">The vector to negate.</param>
        /// <returns>
        ///     The negated <see cref="Vector3"/>.
        /// </returns>
        public static Vector3 operator -(Vector3 current)
        {
            return FromVector(current.Negate());
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3"/>.</param>
        /// <param name="scalar">The scalar.</param>
        /// <returns>
        ///     The resulting <see cref="Vector3"/>.
        /// </returns>
        public static Vector3 operator *(Vector3 vector, double scalar)
        {
            return FromVector(Multiply(vector, scalar));
        }

        /// <summary>
        ///     Implements the operator * for calculating the scalar product of two <see cref="Vector3"/> instances.
        /// </summary>
        /// <param name="firstVector">The first <see cref="Vector3"/>.</param>
        /// <param name="secondVector">The second <see cref="Vector3"/>.</param>
        /// <returns>
        ///     The scalar that has been calculated.
        /// </returns>
        public static double operator *(Vector3 firstVector, Vector3 secondVector)
        {
            return ScalarProduct(firstVector, secondVector);
        }

        /// <summary>
        ///     Transforms the specified <see cref="Vector3"/> with the specified <see cref="Matrix4x4"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector3"/> that should be transformed.</param>
        /// <param name="matrix">The transformation <see cref="Matrix4x4"/>.</param>
        /// <returns>The transformed <see cref="Vector3"/>.</returns>
        public static Vector3 Transform(Vector3 vector, Matrix4x4 matrix)
        {
            var result = matrix * new Vector4(vector.X, vector.Y, vector.Z, 1);
            result.X /= result.W;
            result.Y /= result.W;
            result.Z /= result.W;
            return result.Convert<Vector3>();
        }

        /// <summary>
        ///     Gets the LaTeX-string representing this vector graphically.
        /// </summary>
        public string LaTeXString => @"\left( \begin{array}{c} " + this[0] + @" \\ " + this[1] + @" \\ " + this[2] + @" \end{array} \right)";

        /// <summary>
        ///     Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"X: {this[0]}, Y: {this[1]}, Z: {this[2]}";
        }
    }
}