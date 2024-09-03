using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udp_server;

public class UdpServer
{
    private const int Port = 8001;
    
    public static void Main(string[] args)
    {
        // create a udp client
        var listener = new UdpClient(Port);
        var remoteEndpoint = new IPEndPoint(IPAddress.Any, Port); // Represents the remote endpoint from which data is received

        try
        {
            while (true)
            {
                Console.WriteLine("Waiting for messages");
                
                // Receives a message from any client and stores it in the bytes array
                // also stores the sender's endpoint in 'remoteEndpoint' using ref
                byte[] bytes = listener.Receive(ref remoteEndpoint);

                Console.WriteLine($"Received message from {remoteEndpoint}");
                Console.WriteLine($"{Encoding.UTF8.GetString(bytes, 0, bytes.Length)}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            listener.Close();    
        }
        
    }
}