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
    /// Represents a two-dimensional ellipse.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Ellipse : IEquatable<Ellipse>
    {
        /// <summary>
        /// The coordinates of the center of the ellipse.
        /// </summary>
        public Point2d Center;

        /// <summary>
        /// The rotation angle of the ellipse.
        /// </summary>
        public double Angle;

        /// <summary>
        /// The size of the ellipse major and minor axes.
        /// </summary>
        public Point2d Axes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> structure with the
        /// specified center, angle and axes.
        /// </summary>
        /// <param name="center">The coordinates of the center of the ellipse.</param>
        /// <param name="angle">The rotation angle of the ellipse.</param>
        /// <param name="axes">The size of the ellipse major and minor axes.</param>
        public Ellipse(Point2d center, double angle, Point2d axes)
        {
            Center = center;
            Angle = angle;
            Axes = axes;
        }

        /// <summary>
        /// Returns a hash code for this <see cref="Ellipse"/> structure.
        /// </summary>
        /// <returns>An integer value that specifies a hash value for this <see cref="Ellipse"/> structure.</returns>
        public override int GetHashCode()
        {
            return Center.GetHashCode() ^ Angle.GetHashCode() ^ Axes.GetHashCode();
        }

        /// <summary>
        /// Tests to see whether the specified object is an <see cref="Ellipse"/> structure
        /// with the same center, angle and axes as this <see cref="Ellipse"/> structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to test.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="obj"/> is a <see cref="Ellipse"/> and has the same
        /// center, angle and axes as this <see cref="Ellipse"/>; otherwise, <b>false</b>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Ellipse)
            {
                return Equals((Ellipse)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating whether this instance has the same center, angle and axes
        /// as a specified <see cref="Ellipse"/> structure.
        /// </summary>
        /// <param name="other">The <see cref="Ellipse"/> structure to compare to this instance.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="other"/> has the same center, angle and axes as
        /// this instance; otherwise, <b>false</b>.
        /// </returns>
        public bool Equals(Ellipse other)
        {
            return Center == other.Center && Angle == other.Angle && Axes == other.Axes;
        }

        /// <summary>
        /// Creates a <see cref="String"/> representation of this <see cref="Ellipse"/>
        /// structure.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> containing the center, angle and axes of this
        /// <see cref="Ellipse"/> structure.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{{Center={0}, Angle={1}, Axes={2}}}", Center, Angle, Axes);
        }

        /// <summary>
        /// Tests whether two <see cref="Ellipse"/> structures are equal.
        /// </summary>
        /// <param name="left">The <see cref="Ellipse"/> structure on the left of the equality operator.</param>
        /// <param name="right">The <see cref="Ellipse"/> structure on the right of the equality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> have equal center, angle and axes;
        /// otherwise, <b>false</b>.
        /// </returns>
        public static bool operator ==(Ellipse left, Ellipse right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests whether two <see cref="Ellipse"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Ellipse"/> structure on the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Ellipse"/> structure on the right of the inequality operator.</param>
        /// <returns>
        /// <b>true</b> if <paramref name="left"/> and <paramref name="right"/> differ in center, angle or axes;
        /// <b>false</b> if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator !=(Ellipse left, Ellipse right)
        {
            return !left.Equals(right);
        }
    }
}
