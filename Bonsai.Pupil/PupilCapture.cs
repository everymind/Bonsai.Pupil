using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace Bonsai.Pupil
{
    public class PupilCapture : Source<PupilDataFrame>
    {
        public PupilCapture()
        {
            HostName = "localhost";
            Port = 50020;
        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public override IObservable<PupilDataFrame> Generate()
        {
            return Observable.Create<PupilDataFrame>((observer, cancellationToken) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    using (var context = new ZContext())
                    {
                        int port;
                        var hostName = HostName;
                        using (var request = new ZSocket(context, ZSocketType.REQ))
                        {
                            var endpoint = string.Format("tcp://{0}:{1}", hostName, Port);
                            request.Connect(endpoint);
                            using (var frame = new ZFrame("SUB_PORT"))
                            {
                                request.Send(frame);
                            }

                            using (var reply = request.ReceiveFrame())
                            {
                                if (!int.TryParse(reply.ReadString(), out port))
                                {
                                    throw new InvalidOperationException("Invalid subscribe port received from Pupil Remote.");
                                }
                            }
                        }

                        using (var subscribe = new ZSocket(context, ZSocketType.SUB))
                        {
                            const string PupilTopic = "pupil";
                            var endpoint = string.Format("tcp://{0}:{1}", hostName, port);
                            subscribe.Connect(endpoint);
                            subscribe.SetOption(ZSocketOption.SUBSCRIBE, PupilTopic);

                            while (!cancellationToken.IsCancellationRequested)
                            {
                                using (var message = subscribe.ReceiveMessage())
                                {
                                    if (message.Count < 2) continue;
                                    var output = PupilDataFrame.FromStream(message[1]);
                                    observer.OnNext(output);
                                }
                            }
                        }
                    }
                },
                cancellationToken,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
            });
        }
    }
}
