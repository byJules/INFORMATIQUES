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


namespace TestSocketClient
{
        
    public partial class FormClient : Form
    {
        Socket sock;
        Thread myThread;
        string recu;
        
                
        
        public FormClient()
        {
            InitializeComponent();
            timerAffichage.Enabled = false;
            recu = "";
            //création de l'objet socle de communication
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            myThread = new Thread(new ThreadStart(ThreadLoop));
            timerAffichage.Enabled = true;
        }


        public void ThreadLoop()
        {
            // Tant que le thread n'est pas tué, on travaille

            while (Thread.CurrentThread.IsAlive)
            {
                byte[] buffer = new byte[100];

                //Lecture de la réponse du client, création d'un tableau dynamique.

                //receive lit les données dans une mémoire tampon de réception
                //si le nombre de caractères envoyés par le serveur est > à 50, il faut
                //appeler de nouveau Receive().Receive()est bloquant (lecture synchrone)
                int n = sock.Receive(buffer);
                recu = ASCIIEncoding.Default.GetString(buffer);
                //MessageBox.Show(recu);



            }
        }
        
        
        
        
        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            
            //Retrouve l'IP du serveur à partir de son nom
            /*IPHostEntry he = Dns.GetHostEntry("mobile-yves");
            IPAddress[] TabIP = he.AddressList;
            MessageBox.Show(TabIP[2].ToString());
            //demande de connexion au serveur, adresse IP et Port du serveur.
            sock.Connect(new IPEndPoint(TabIP[2],4000));*/
            try
            {
                sock.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.23"), 4000));
            }

            catch(Exception Ex1)
            {
                MessageBox.Show("erreur de connexion au serveur");
            }

            //timerAffichage.Enabled = true;
            myThread.Start();
            


        }

        private void buttonFermer_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            timerAffichage.Enabled = false;
            //fin de l'émission et reception
            sock.Shutdown(SocketShutdown.Both);
            //fermeture la liaison par socle
            sock.Close();
            //ferme l'application
            this.Close();
         
        }

        private void buttonEnvoyer_Click(object sender, EventArgs e)
        {
            byte[] tab = new byte[50];
            string AEnvoyer = textBoxEmission.Text;
            
            tab = ASCIIEncoding.Default.GetBytes(AEnvoyer);
            sock.Send(tab);
            
            
        }

        private void timerAffichage_Tick(object sender, EventArgs e)
        {
            textBoxReception.Text = recu;
        }
    }
}
