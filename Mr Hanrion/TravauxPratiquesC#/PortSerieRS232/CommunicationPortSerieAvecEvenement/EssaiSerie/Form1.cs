using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EssaiSerie
{
    public partial class Form1 : Form
    {

        string MaChaineAEmettre;
        string MaChaineCompleteRecue;
        
        public Form1()
        {
            InitializeComponent();
            MaChaineCompleteRecue = "";
        }

        private void BInit_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM2";
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            //CR LF en fin de chaine à emettre.
            serialPort1.NewLine = "\r\n";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine(MaChaineAEmettre);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            MaChaineAEmettre = textBox1.Text;
            
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string MaChaineRecue;
            //MaChaineRecue = serialPort1.ReadLine();
            //MaChaineRecue = serialPort1.ReadByte();
            MaChaineRecue = serialPort1.ReadExisting();
            MaChaineCompleteRecue = MaChaineCompleteRecue + MaChaineRecue;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = MaChaineCompleteRecue;
        }


        
        
        
        
        
    }
}
