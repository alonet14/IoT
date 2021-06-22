using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConnectDevice.Utils
{

    // State object for reading client data asynchronously  
    class ConnectClientUtils {

        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 8082;
        static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void ExecuteServer()
        {
            //IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddress = iPHostEntry.AddressList[0];
            //IPEndPoint localEndpoint = new IPEndPoint(ipAddress, 8082);
            //Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");

                TcpListener listener = new TcpListener(address, PORT_NUMBER);
                
                // 1. listen
                listener.Start();

                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                Socket socket = listener.AcceptSocket();
                Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

                // 2. receive
                byte[] data = new byte[BUFFER_SIZE];
            
                socket.Receive(data);

                string str = encoding.GetString(data);
                Console.WriteLine(str);
                //Console.WriteLine(str);
                // 3. send
                socket.Send(encoding.GetBytes("Hello how are you"));


                // 4. close
                socket.Close();
                listener.Stop();

            }
            catch(Exception e)
            {
                //Console.WriteLine(e.Message);
            }
        }
        public static void SendMessToClient()
        {

        } 
        
    }

    
}
