using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;



namespace ConsoleServeurUdp
{
    class Program
    {
        private const int listenPort = 5556;
        
             
        
        
        
        static void Main(string[] args)
        {

            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            string received_data;
            byte[] receive_byte_array;
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for udp packet");
                    
                    // Note that this is a synchronous or blocking call.
                    receive_byte_array = listener.Receive(ref groupEP);
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);
                    Console.WriteLine("data follows \n{0}\n\n", received_data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            listener.Close();
            







        }
    }
}
