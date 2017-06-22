using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pupil
{
    /// <summary>
    /// Represents a three-dimensional oriented circle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Circle3d : IEquatable<Circle3d>
    {
        /// <summary>
        /// The coordinates of the center of the circle.
        /// </summary>
        public Point3d Center;

        /// <summary>
        /// The radius of the circle.
        /// </summary>
        public double Radius;

        /// <summary>
        /// The vector that is normal to the surface of the circle.
        /// </summary>
        public Point3d Normal;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle3d"/> structure with the
        /// specified center, radius and normal.
        /// </summary>
        /// <param name="center">The coordinates of the center of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="normal">The vector that is normal to the surface of the circle.</param>
        public Circle3d(Point3d center, double radius, Point3d normal)
        {
            Center = center;
            Radius = radius;
            Normal = normal;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Circle3d"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Circle3d"/> structure.</returns>
        public override int GetHashCode()
        {
            return Center.GetHashCode() ^ Radius.GetHashCode() ^ Normal.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is an <see cref="Circle3d"/> structure
        /// with the same center, radius and normal as this <see cref="Circle3d"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Circle3d"/> and has the same
        /// center, radius and normal as this <see cref="Circle3d"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Circle3d)
            {
                return Equals((Circle3d)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same center, radius and normal
        /// as a specified <see cref="Circle3d"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Circle3d"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same center, radius and normal as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Circle3d other)
        {
            return Center == other.Center && Radius == other.Radius && Normal == other.Normal;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Circle3d"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the center, radius and normal of this
        /// <see cref="Circle3d"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{Center={0}, Radius={1}, Normal={2}}}", Center, Radius, Normal);
        }

        /// <summary>
        /// Tests whether two <see cref="Circle3d"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Circle3d"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Circle3d"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal center, radius and normal;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Circle3d left, Circle3d right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Circle3d"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Circle3d"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Circle3d"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in center, radius or normal;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Circle3d left, Circle3d right)
        {
            return !left.Equals(right);
        }
    }
}
