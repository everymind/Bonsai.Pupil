using Bonsai.Pupil.Properties;
using MsgPack;
using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pupil
{
    static class MsgPackExtensions
    {
        public static void ReadPrefix(this MsgPackReader reader, TypePrefixes prefix)
        {
            if (!reader.Read() || reader.Type != prefix)
            {
                throw new InvalidOperationException(Resources.ParseError);
            }
        }

        public static string ReadString(this MsgPackReader reader)
        {
            reader.ReadPrefix(TypePrefixes.FixRaw);
            return reader.ReadRawString();
        }

        public static void ReadString(this MsgPackReader reader, string value)
        {
            reader.ReadPrefix(TypePrefixes.FixRaw);
            if (reader.ReadRawString() != value)
            {
                throw new InvalidOperationException(Resources.ParseError);
            }
        }

        public static double ReadDouble(this MsgPackReader reader)
        {
            if (!reader.Read() || !(reader.Type == TypePrefixes.Double || reader.Type == TypePrefixes.PositiveFixNum))
            {
                throw new InvalidOperationException(Resources.ParseError);
            }

            return reader.ValueDouble;
        }

        public static int ReadSigned(this MsgPackReader reader)
        {
            if (!reader.Read() ||
                !(reader.Type == TypePrefixes.PositiveFixNum ||
                  reader.Type == TypePrefixes.NegativeFixNum ||
                  reader.Type == TypePrefixes.UInt16))
            {
                throw new InvalidOperationException(Resources.ParseError);
            }

            return reader.ValueSigned;
        }

        public static Point2d ReadPoint2d(this MsgPackReader reader)
        {
            reader.ReadPrefix(TypePrefixes.FixArray);
            var x = reader.ReadDouble();
            var y = reader.ReadDouble();
            return new Point2d(x, y);
        }

        public static Point3d ReadPoint3d(this MsgPackReader reader)
        {
            reader.ReadPrefix(TypePrefixes.FixArray);
            var x = reader.ReadDouble();
            var y = reader.ReadDouble();
            var z = reader.ReadDouble();
            return new Point3d(x, y, z);
        }

        public static Sphere ReadSphere(this MsgPackReader reader)
        {
            var sphere = new Sphere();
            reader.ReadPrefix(TypePrefixes.FixMap);
            for (int i = 0; i < 2; i++)
            {
                var key = reader.ReadString();
                switch (key)
                {
                    case "center": sphere.Center = reader.ReadPoint3d(); break;
                    case "radius": sphere.Radius = reader.ReadDouble(); break;
                    default: throw new InvalidOperationException(Resources.ParseError);
                }
            }
            return sphere;
        }

        public static Ellipse ReadEllipse(this MsgPackReader reader)
        {
            var ellipse = new Ellipse();
            reader.ReadPrefix(TypePrefixes.FixMap);
            for (int i = 0; i < 3; i++)
            {
                var key = reader.ReadString();
                switch (key)
                {
                    case "center": ellipse.Center = reader.ReadPoint2d(); break;
                    case "angle": ellipse.Angle = reader.ReadDouble(); break;
                    case "axes": ellipse.Axes = reader.ReadPoint2d(); break;
                    default: throw new InvalidOperationException(Resources.ParseError);
                }
            }
            return ellipse;
        }

        public static Circle3d ReadCircle3d(this MsgPackReader reader)
        {
            var circle = new Circle3d();
            reader.ReadPrefix(TypePrefixes.FixMap);
            for (int i = 0; i < 3; i++)
            {
                var key = reader.ReadString();
                switch (key)
                {
                    case "center": circle.Center = reader.ReadPoint3d(); break;
                    case "radius": circle.Radius = reader.ReadDouble(); break;
                    case "normal": circle.Normal = reader.ReadPoint3d(); break;
                    default: throw new InvalidOperationException(Resources.ParseError);
                }
            }
            return circle;
        }
    }
}
