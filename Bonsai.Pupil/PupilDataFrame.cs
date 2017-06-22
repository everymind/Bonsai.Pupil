using MsgPack;
using OpenCV.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Pupil
{
    public class PupilDataFrame
    {
        static readonly Dictionary<string, Action<MsgPackReader, PupilDataFrame>> ParserMap = new
        Dictionary<string,Action<MsgPackReader,PupilDataFrame>>
        {
            { "topic", (reader, frame) => reader.ReadString("pupil") },
            { "id", (reader, frame) => frame.Id = reader.ReadSigned() },
            { "method", (reader, frame) => frame.Method = reader.ReadString() },
            { "timestamp", (reader, frame) => frame.Timestamp = reader.ReadDouble() },
            { "confidence", (reader, frame) => frame.Confidence = reader.ReadDouble() },
            { "model_id", (reader, frame) => frame.ModelId = reader.ReadSigned() },
            { "model_birth_timestamp", (reader, frame) => frame.ModelBirthTimestamp = reader.ReadDouble() },
            { "model_confidence", (reader, frame) => frame.ModelConfidence = reader.ReadDouble() },
            { "norm_pos", (reader, frame) => frame.NormalizedPosition = reader.ReadPoint2d() },
            { "diameter", (reader, frame) => frame.Diameter = reader.ReadDouble() },
            { "diameter_3d", (reader, frame) => frame.Diameter3d = reader.ReadDouble() },
            { "theta", (reader, frame) => frame.Theta = reader.ReadDouble() },
            { "phi", (reader, frame) => frame.Phi = reader.ReadDouble() },
            { "sphere", (reader, frame) => frame.Sphere = reader.ReadSphere() },
            { "ellipse", (reader, frame) => frame.Ellipse = reader.ReadEllipse() },
            { "projected_sphere", (reader, frame) => frame.ProjectedSphere = reader.ReadEllipse() },
            { "circle_3d", (reader, frame) => frame.Circle3d = reader.ReadCircle3d() },
        };

        public PupilDataFrame()
        {
        }

        public int Id { get; private set; }

        public string Method { get; private set; }

        public double Timestamp { get; private set; }

        public double Confidence { get; private set; }

        public int ModelId { get; private set; }

        public double ModelBirthTimestamp { get; private set; }

        public double ModelConfidence { get; private set; }

        public Point2d NormalizedPosition { get; private set; }

        public double Diameter { get; private set; }

        public double Diameter3d { get; private set; }

        public double Theta { get; private set; }

        public double Phi { get; private set; }

        public Sphere Sphere { get; private set; }

        public Ellipse Ellipse { get; private set; }

        public Ellipse ProjectedSphere { get; private set; }

        public Circle3d Circle3d { get; private set; }

        public static PupilDataFrame FromStream(Stream stream)
        {
            var reader = new MsgPackReader(stream);
            var frame = new PupilDataFrame();
            reader.ReadPrefix(TypePrefixes.Map16);
            while (reader.Read() && reader.Type == TypePrefixes.FixRaw)
            {
                var key = reader.ReadRawString();
                Action<MsgPackReader, PupilDataFrame> setter;
                if (ParserMap.TryGetValue(key, out setter))
                {
                    setter(reader, frame);
                }
            }
            return frame;
        }
    }
}
