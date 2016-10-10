using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpBroadcastCapture
{
    class Program
    {
        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // Use the network EGV5-DMU2 to capture from the local IoT devices
        private const int Port = 5005;
        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.5.137"); 
        private static readonly IPAddress IpAddress = IPAddress.Any;
        // Listen for activity on all network interfaces
        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx
        static void Main()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IpAddress, 9998);

            using (UdpClient socket = new UdpClient(Port))
            {
                Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                while (true)
                {
                    
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port, message);
                    using (var v = new WebserviceRef.StudentServiceClient())
                    {

                        var s = message.Split('\n');
                        var lysdata = int.Parse(s[0].Split(' ')[1]);
                        var temps = int.Parse(s[1].Split(' ')[1]);

                        v.InsertData(lysdata, temps);
                    }
                    //Parse(message);
                }
            }
        }

        // To parse data from the IoT devices in the teachers room, Elisagårdsvej
        private static void Parse(string response)
        {
            string[] parts = response.Split(' ');
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
            string temperatureLine = parts[6];
            string temperatureStr = temperatureLine.Substring(temperatureLine.IndexOf(": ") + 2);
            Console.WriteLine(temperatureStr);
        }
    }
}
