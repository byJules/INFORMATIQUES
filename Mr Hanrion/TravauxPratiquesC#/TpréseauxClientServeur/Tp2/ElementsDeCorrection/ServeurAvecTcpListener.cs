using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace ServeurHeureClasseTCPListenerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint IpPort = new IPEndPoint(IPAddress.Parse("192.168.1.2"),4000); 
            TcpListener serveur = new TcpListener(IpPort);
            

            serveur.Start();
            //Le serveur se met en attente d'une connexion
            Socket socle = serveur.AcceptSocket();
            //Renvoi de l'heure au client
            string heure = DateTime.Now.ToLongTimeString();
            byte[] tb = ASCIIEncoding.Default.GetBytes(heure);
            //Envoi l'heure au client
            socle.Send(tb);
            Console.Read();


        }
    }
}
