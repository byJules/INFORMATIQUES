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

namespace UdpClientGraphique
{
    public partial class Form1 : Form
    {
        int NumSeq;
        string cmd;
        bool etat = false;
        IPEndPoint ipSend;
        Socket Client;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Connexion();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            Connexion();
        }

        private void btnAtterrir_Click(object sender, EventArgs e)
        {
            if (etat == true)
                Atterir();
        }

        private void btnGauche_Click(object sender, EventArgs e)
        {
            if (etat == true)
                Gauche();
        }

        private void btnReculer_Click(object sender, EventArgs e)
        {
            if (etat == true)
                Reculer();
        }

        private void btnAvancerGauche_Click(object sender, EventArgs e)
        {
            if (etat == true)
                AvancerGauche();
        }

        private void btnAvancerDroite_Click(object sender, EventArgs e)
        {
            if (etat == true)
                AvancerDroite();
        }

        private void btnDecoller_Click_1(object sender, EventArgs e)
        {
            if (etat == true)
                decollage();
        }

        private void btnReculerGauche_Click(object sender, EventArgs e)
        {
            if (etat == true)
                ReculerGauche();
        }

        private void btnReculerDroit_Click(object sender, EventArgs e)
        {
            if (etat == true)
                ReculerDroite();
        }

        private void btnDroite_Click(object sender, EventArgs e)
        {
            if (etat == true)
                Droite();
        }

        private void btnArretUrgence_Click(object sender, EventArgs e)
        {
            if(etat==true)
                ArretUrgence();
        }

        private void Atterir()
        {
            cmd = "AT*REF=" + NumSeq + ",290717696";
        }


        private void PositionInitial()
        {
            cmd = "AT*PCMD=" + NumSeq + ",0,0,0,0,0";
        }

        public void decollage()
        {
            cmd = "AT*REF="+ NumSeq +",290717208";
        }

        public void Avancer()
        {
            cmd = "AT*PCMD=" + NumSeq + ",0,0,-1,0,0";
        }

 
        private void Connexion()
        {
            ipSend = new IPEndPoint(IPAddress.Parse("192.168.1.2"), 5556);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            etat = true;
            cmd = "AT*CONFIG=1,\"general:navdata_demo\",\"FALSE\"\r";
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            //data = Encoding.ASCII.GetBytes("AT*ZAP=2,0\r");
            //Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*PMODE=4,2\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*MISC=5,2,20,2000,3000\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*CONFIG=6,\"control:outdoor\",\"FALSE\"\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*CONFIG=7,\"control:flight_without_shell\",\"FALSE\"\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*CONFIG=8,\"control:altitude_max\",\"1000\"\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*CONFIG=9,\"control:altitude_min\",\"500\"\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*CONFIG=10,\"video:bitrate_ctrl_mode\", \"0\"\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            data = Encoding.ASCII.GetBytes("AT*ZAP=11,0\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            cmd = "AT*FTRIM=12\r";
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            cmd = "AT*COMWDG=13\r";

            timerEnvoi.Start();
            NumSeq = 13;

        }

        private void Gauche()
        {
            cmd = "AT*PCMD=" + NumSeq + ",0,-1,0,0,0";
        }

        private void Reculer()
        {
            cmd = "AT*PCMD=" + NumSeq + ",0,0,1,0,0";
        }



        private void AvancerGauche()
        {
            cmd = "Le drone effectue une progression diagonale vers l'avant gauche ...";
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
        }

        private void AvancerDroite()
        {
            cmd = "Le drone effectue une progression diagonale vers l'avant droite ...";
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
        }

        private void ReculerGauche()
        {
            cmd = "Le drone effectue une progression diagonale vers l'arrière gauche ...";
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
        }

        private void ReculerDroite()
        {
            cmd = "Le drone effectue une progression diagonale vers l'arrière droit ...";
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
        }

        private void Droite()
        {
            cmd = "AT*PCMD=" + NumSeq + ",0,1,0,0,0";
        }

        private void ArretUrgence()
        {
            cmd = "AT*REF = "+ NumSeq +",290717952" + (char) 13;
        }

        private void timerEnvoi_Tick(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(cmd + "\r");
            Client.SendTo(data, data.Length, SocketFlags.None, ipSend);
            NumSeq++;
            cmd = "AT*COMWDG=" + NumSeq + "";
        }

        private void btnAvancer_MouseDown(object sender, MouseEventArgs e)
        {
            if (etat == true)
                Avancer();
        }

        private void btnAvancer_MouseUp(object sender, MouseEventArgs e)
        {
            if (etat == true)
                PositionInitial();
        }

        private void btnReculer_MouseDown(object sender, MouseEventArgs e)
        {
            if (etat == true)
                Reculer();
        }

        private void btnReculer_MouseUp(object sender, MouseEventArgs e)
        {
            if (etat == true)
                PositionInitial();
        }

        private void btnGauche_MouseDown(object sender, MouseEventArgs e)
        {
            if (etat == true)
                Gauche();
        }

        private void btnGauche_MouseUp(object sender, MouseEventArgs e)
        {
            if (etat == true)
                PositionInitial();
        }

        private void btnDroite_MouseDown(object sender, MouseEventArgs e)
        {
            if (etat == true)
                Droite();
        }

        private void btnDroite_MouseUp(object sender, MouseEventArgs e)
        {
            if (etat == true)
                PositionInitial();
        }



        


    }
}
