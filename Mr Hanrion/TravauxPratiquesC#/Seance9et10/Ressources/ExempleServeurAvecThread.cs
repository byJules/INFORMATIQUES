using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TestSocket
{
    public partial class Form1 : Form
    {

        Socket sock;
        Socket sockClient;
        Thread myThread;
       
        string recu;
        bool Client;
        
        
        public Form1()
        {
            Client = false;
            InitializeComponent();
            timerAffichage.Enabled = false;
            recu = "";
            //Création de l'objet socle de communication
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            //Pour retrouver le nom de la machine et son adresse IP.
            string NomPc = Dns.GetHostName(); //Obtient le nom de l'ordinateur
            IPHostEntry he = Dns.GetHostEntry(NomPc);
            IPAddress[] TabIP = he.AddressList;
              
            MessageBox.Show(TabIP[1].ToString());
           
            
            //L'adresse IP est dans TabIP[0] ou TabIP[1] pour Windows 7
            //Association du socle à l'adresse IP de la machine et à un numéro de port.
            sock.Bind(new IPEndPoint(TabIP[1],4000));
            //sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"),4000));
            
            myThread = new Thread(new ThreadStart(ThreadLoop));
            
        }


        public void ThreadLoop()
        {
            // Tant que le thread n'est pas tué, on travaille
           
            while (Thread.CurrentThread.IsAlive)
            {
                byte[] buffer = new byte[50];
                
                //Lecture de la réponse du client, création d'un tableau dynamique.
               
                //receive lit les données dans une mémoire tampon de réception
                //si le nombre de caractères envoyés par le serveur est > à 50, il faut
                //appeler de nouveau Receive().Receive()est bloquant (lecture synchrone)
                int n = sockClient.Receive(buffer);
                recu = ASCIIEncoding.Default.GetString(buffer);
                //MessageBox.Show(recu);
                
               

            }
        }
        
        
        
        private void buttonConnecter_Click(object sender, EventArgs e)
        {
            //Serveur à l'écoute
            sock.Listen(1);
            //Le serveur attend la demande de connexion du client (Accept bloquant)
            sockClient = sock.Accept();
            Client = true;
            MessageBox.Show("le client est connecté");
            //le client est connecté, La variable sockClient permet de dialoguer avec le client
            //envoi d'un message au client
            string temps = DateTime.Now.ToLongTimeString();
            string date = DateTime.Now.ToLongDateString();
            string reponse = "Vous êtes connecté au serveur le "+date+" à "+temps;
            byte[] tab = ASCIIEncoding.Default.GetBytes(reponse);
            sockClient.Send(tab);
            timerAffichage.Enabled = true;
            myThread.Start();
            
           


        }

        private void buttonFermer_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            timerAffichage.Enabled = false;
            //Fin de l'émission et réception
            if (Client == true)
            {
                sockClient.Shutdown(SocketShutdown.Both);
                //Fermeture de la liaison par socle
                sockClient.Close();
            }
            sock.Close();
            this.Close();
        }

        private void buttonEnvoi_Click(object sender, EventArgs e)
        {
            string envoi = textBoxEmission.Text;
            byte[] tab = ASCIIEncoding.Default.GetBytes(envoi);
            sockClient.Send(tab);
        }

        private void timerAffichage_Tick(object sender, EventArgs e)
        {
            textBoxReception.Text = recu;
        }

        

        
        
        

        
    }
}
