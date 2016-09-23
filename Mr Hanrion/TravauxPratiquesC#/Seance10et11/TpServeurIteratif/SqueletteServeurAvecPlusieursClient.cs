using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TchServeur
{
    public partial class Form1 : Form
    {
        Socket socleserveur;
        //déclaration du conteneur d'objets client (ArrayList ou List)
		..........
        


        public Form1()
        {
            InitializeComponent();

        }

        

        public void attenteConnexion(){
            while (true)
            {


					Client client;
                
                    Socket sockClient = socleserveur.Accept();
                    client = new Client(sockClient);

                 //Ajouter l'objet client au conteneur
				..................	
               
                //création et lancement du thread ReceptionClient de l'objet Client
                ..................
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           	socleserveur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            socleserveur.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.7"), 4000));
            //Socle serveur à l'écoute
			..........................
            
			//Création  et Lancement du thread attenteConnexion
            ..................................
        }
		
		public void envoi(string msg)
		{
            //i à gérer, ListeClient est le nom du conteneur
            ListeClient[i].send(msg);
           
        }

        

        


        
        }
    }



    public class Client:Form1
    {
       
        Socket socle;
        public Client(Socket socle)
        {
            this.socle = socle;
            
            
        }


        public void ReceptionClient()
        {
            while....
            {
                byte[] Buffer = new byte[255];
                
                    socle.Receive(Buffer);
					string reponse = "ok";
					envoi(reponse);
                   
               
                
                    
                    
                
            }
            
        }



        

        
    }
   
   
}