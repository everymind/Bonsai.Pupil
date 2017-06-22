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
    /// Represents a three-dimensional sphere.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Sphere : IEquatable<Sphere>
    {
        /// <summary>
        /// The center of the sphere.
        /// </summary>
        public Point3d Center;

        /// <summary>
        /// The radius of the sphere.
        /// </summary>
        public double Radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sphere"/> structure with the
        /// specified center and radius.
        /// </summary>
        /// <param name="center">The coordinates of the center of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        public Sphere(Point3d center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Sphere"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Sphere"/> structure.</returns>
        public override int GetHashCode()
        {
            return Center.GetHashCode() ^ Radius.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is a <see cref="Sphere"/> structure
        /// with the same center and radius as this <see cref="Sphere"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Sphere"/> and has the same
        /// center and radius as this <see cref="Sphere"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Sphere)
            {
                return Equals((Sphere)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same center and radius
        /// as a specified <see cref="Sphere"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Sphere"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same center and radius as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Sphere other)
        {
            return Center == other.Center && Radius == other.Radius;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Sphere"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the center and radius of this
        /// <see cref="Sphere"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{Center={0}, Radius={1}}}", Center, Radius);
        }

        /// <summary>
        /// Tests whether two <see cref="Sphere"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Sphere"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Sphere"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal center and radius;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Sphere left, Sphere right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Sphere"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Sphere"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Sphere"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in center or radius;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Sphere left, Sphere right)
        {
            return !left.Equals(right);
        }
    }
}
