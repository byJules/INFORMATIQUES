 private void buttonAfficher_Click(object sender, EventArgs e)
 {
           // MessageBox.Show("Vous avez séléctionné " + listBoxAnimaux.SelectedItem
           //     + " dont l'index est de " + listBoxAnimaux.SelectedIndex);

            //sélection multiple: Pour la ListBoxAnimaux, la propriété "SelectionMode" est "MultiExtended"
            //Création d'un tableau de type string (stockage de chaînes de caractères)
            string[] Tab = new string[10];
            //index du tableau
            int i = 0;
            //Récupération du nombre d'éléments sélectionnés dans la liste.
            int NbElement = listBoxAnimaux.SelectedIndices.Count;
			//Récupération du nombre d'éléments de la liste.
			int NbElement2 = listBoxAnimaux.Items.Count;
            //Conserver NbElement
            int Nb = NbElement;

            //Tant qu'il reste des éléments sélectionnés.
            while(Nb >= 1)
            {
               //Stockage de chaque élément sélectionné dans le tableau.
                Tab[i] = listBoxAnimaux.SelectedItems[i].ToString();
               Nb--;
               //incrémentation de l'index du tableau
                i++;
              
             
            }

            //Affichage de chaque élément du tableau
            for (int j = 0; j < NbElement; j++)
            {
                MessageBox.Show(Tab[j]);
            }
			
}
