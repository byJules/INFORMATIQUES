using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EssaiSerie
{
    public partial class Form1 : Form
    {

        string MaChaineAEmettre;
        string MaChaineCompleteRecue;
        Thread myThread;
        
        
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            MaChaineCompleteRecue = "";
            myThread = new Thread(new ThreadStart(ThreadLoop));
                     
        }
               
                 
        
        
        
        public void ThreadLoop()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                string MaChaineRecue = "";  
                MaChaineRecue = serialPort1.ReadExisting();
                MaChaineCompleteRecue = MaChaineCompleteRecue + MaChaineRecue;
                
            }
        }
        
        
        
        private void BInit_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM7";
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bouton Ouvrir Port
            serialPort1.Open();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write(MaChaineAEmettre);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Bouton Fermer port            
            timer1.Enabled = false;
            serialPort1.Close();
            myThread.Abort();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            MaChaineAEmettre = textBox1.Text;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {                    
            textBox2.Text = MaChaineCompleteRecue;
        }

        private void buttonReception_Click(object sender, EventArgs e)
        {
            //Demarrage du Timer pour le Rafraichissement de l'affichage
            timer1.Enabled = true;
            //Démarrage du Thread de réception des caractères.
            myThread.Start();
            
        }
    }
}
