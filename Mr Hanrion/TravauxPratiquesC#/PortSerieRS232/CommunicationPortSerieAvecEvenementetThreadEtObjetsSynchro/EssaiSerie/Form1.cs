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
        Thread MonThread;
        ManualResetEvent manualEvent;

        
        public Form1()
        {
            InitializeComponent();
            MaChaineCompleteRecue = "";
            MonThread = new Thread(new ThreadStart(ThreadReception));
            manualEvent = new ManualResetEvent(false);
        }



        public void ThreadReception()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {

                manualEvent.WaitOne();
                
                string MaChaineRecue = "";
                MaChaineRecue = serialPort1.ReadExisting();
                MaChaineCompleteRecue = MaChaineCompleteRecue + MaChaineRecue;
                manualEvent.Reset();
           
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
            MonThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(MaChaineAEmettre);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //bouton Fermer Port
            serialPort1.Close();
            MonThread.Abort();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            MaChaineAEmettre = textBox1.Text;
            
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            manualEvent.Set();
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = MaChaineCompleteRecue;
        }


        
        
        
        
        
    }
}
