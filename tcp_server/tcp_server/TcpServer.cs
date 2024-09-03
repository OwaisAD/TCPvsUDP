using System.Net;
using System.Net.Sockets;
using System.Text;

namespace tcp_server;

public class TcpServer
{ 
    private const int Port = 8001;
    
    public static void Main(string[] args)
    {
        try
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var myList = new TcpListener(ipAddress, Port);
            myList.Start();
            
            Console.WriteLine($"Server is now running on port {Port}");
            Console.WriteLine("The local endpoint is: " + myList.LocalEndpoint);

            while (true)
            {
                Console.WriteLine("Waiting for a connection");  
                
                var clientSocket = myList.AcceptSocket();
                Console.WriteLine("Connection accepted from " + clientSocket.RemoteEndPoint);

                var clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occured" + e.Message);
            throw;
        }
    }
    
    private static void HandleClient(Socket clientSocket)
    {
        try
        {
            while (true)
            {
                // data from client
                var buffer = new byte[1024];
                var bytesRead = clientSocket.Receive(buffer);

                if (bytesRead == 0) break;
                    
                // convert from bytes to string
                var clientMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received following message from client: " + clientMessage);
                
                // sending a response back
                var responseBytes = Encoding.UTF8.GetBytes("Message received! :D");
                clientSocket.Send(responseBytes);
            }
            clientSocket.Close();
            Console.WriteLine("Client disconnected..");
            
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while handling a client: " + e.Message);
        }
    }
    
}