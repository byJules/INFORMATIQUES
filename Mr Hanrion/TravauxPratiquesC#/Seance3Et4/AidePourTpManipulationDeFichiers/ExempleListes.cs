using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Listes
{
    public partial class FormListes : Form
    {
        public FormListes()
        {
            InitializeComponent();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            //listBoxAnimaux.Items.Add("Titeuf");
            listBoxAnimaux.Items.Insert(0,"Titeuf");

        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            //listBoxAnimaux.Items.Remove("Titeuf");
            listBoxAnimaux.Items.RemoveAt(3);
        }

        private void buttonEffacer_Click(object sender, EventArgs e)
        {
            listBoxAnimaux.Items.Clear();
            string essai = Convert.ToString(comboBoxCouleurs.Items[0]);
            MessageBox.Show(essai);
            //int numero =  ncomboBoxCouleurs.SelectedIndex;
        }

        private void buttonAfficher_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vous avez séléctionné " + listBoxAnimaux.SelectedItem
                + " dont l'index est de " + listBoxAnimaux.SelectedIndex);

                            
        }

        
        

    }
}
