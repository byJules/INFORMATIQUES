using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace TestConteneur
{
    public partial class Form1 : Form
    {
        public ArrayList MonTableau;
                
        
        public Form1()
        {
            
            InitializeComponent();
            //création du conteneur
            MonTableau = new ArrayList();
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //création d'un objet instance de la classe Machine
            Machine MachineCourante = new Machine();
            //mise à jour d'un attribut (marque) de l'objet créé
            //appel de la méthode SetMarque de la classe Machine.
            MachineCourante.SetMarque(textMarque.Text);
            
            //A compléter pour les autres attributs: Processeur et ram
            //MachineCourante.SetProcesseur.......
            
            //on range l'objet dans le conteneur
            MonTableau.Add(MachineCourante);
            //On passe automatiquement à la case suivante du conteneur
                
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //récupération d'un objet du conteneur
            Machine test = (Machine)MonTableau[0];
            //On peut utiliser un indice
            //int i = 0;
            //Machine test = (Machine)MonTableau[i];
            textMarque.Text = test.GetMarque();
            //A compléter GetProcesseur...
            //GetRam...
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textMarque.Text = "";
            //A compléter avec les autres TextBox
                        
           
        }

       
        

        
    }
}
