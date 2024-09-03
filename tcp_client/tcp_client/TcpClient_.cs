using System.Net.Sockets;
using System.Text;

namespace tcp_client;

public class TcpClient_
{
    private const int Port = 8001;
    
    public static void Main(string[] args)
    {
        try
        {
            var tcpClient = new TcpClient();
            Console.WriteLine("Connecting...");
            tcpClient.Connect("127.0.0.1", Port);
            Console.WriteLine("Connected successfully");

            Console.WriteLine("Enter a message to send to the TCP Server (type 'q' to quit):");
            
            var stream = tcpClient.GetStream();
            string msg;
            
            // Loop to keep reading input until 'q' is typed
            while ((msg = Console.ReadLine()) != null && msg.ToLower() != "q")
            {
                // Convert message to bytes
                var clientMessageInBytes = Encoding.UTF8.GetBytes(msg);
                Console.WriteLine("Transmitting...");

                // Write the message to the server
                stream.Write(clientMessageInBytes, 0, clientMessageInBytes.Length);

                // Receive the response from the server
                var buffer = new byte[1024]; // Increased buffer size for larger responses
                var bytesRead = stream.Read(buffer, 0, buffer.Length);

                // Convert the response bytes to a string and display it
                var response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received from server: " + response);

                Console.WriteLine("Enter another message (or type 'q' to quit):");
            }
            
            stream.Close();
            tcpClient.Close();
            Console.WriteLine("Connection closed");
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured" + e.Message);
            throw;
        }
    }   
}