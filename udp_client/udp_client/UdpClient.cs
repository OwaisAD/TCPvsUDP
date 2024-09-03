using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udp_client;

public class UdpClient
{
    public static void Main(string[] args)
    {
        // initialize a new Socket object configured for UDP communication (SocketType.Dgram) using the IPv4 address family (AddressFamily.InterNetwork).
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        IPAddress broadcast = IPAddress.Parse("127.0.0.1");
        Console.WriteLine("Enter a message to be sent via UDP");

        var msg = Console.ReadLine();

        while (msg != string.Empty)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            IPEndPoint ep = new IPEndPoint(broadcast, 8001);

            s.SendTo(buffer, ep);

            Console.WriteLine("Message sent!");

            msg = Console.ReadLine();
        }

        Console.ReadLine();
    }
}