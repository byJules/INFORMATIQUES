using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ClientClasseTcpClient
{
    public partial class Form1 : Form
    {

        TcpClient Client;
        Thread myThread;
        string Recu;

        public Form1()
        {
            InitializeComponent();
            Client = new TcpClient();
            myThread = new Thread(new ThreadStart(ThreadReception));
            timerAffichage.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPEndPoint IpPort = new IPEndPoint(IPAddress.Parse("192.168.1.2"), 4000);
            Client.Connect(IpPort);
            myThread.Start();

        }

        public void ThreadReception()
        {
            while (Thread.CurrentThread.IsAlive)
            {

                byte[] buffer = new byte[100];
                NetworkStream flux = Client.GetStream();
                flux.Read(buffer,0,100);
                Recu = ASCIIEncoding.Default.GetString(buffer);




            }
        }

        private void timerAffichage_Tick(object sender, EventArgs e)
        {
            textBoxReception.Text = Recu;
        }

        private void BtnFemer_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            timerAffichage.Enabled = false;
            
            //fermeture la liaison par socle
            Client.Close();
            //ferme l'application
            this.Close();
        }

        

    }
}



