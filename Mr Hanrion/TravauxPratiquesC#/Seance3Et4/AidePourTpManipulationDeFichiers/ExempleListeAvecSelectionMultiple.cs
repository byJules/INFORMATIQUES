 private void buttonAfficher_Click(object sender, EventArgs e)
 {
           // MessageBox.Show("Vous avez s�l�ctionn� " + listBoxAnimaux.SelectedItem
           //     + " dont l'index est de " + listBoxAnimaux.SelectedIndex);

            //s�lection multiple: Pour la ListBoxAnimaux, la propri�t� "SelectionMode" est "MultiExtended"
            //Cr�ation d'un tableau de type string (stockage de cha�nes de caract�res)
            string[] Tab = new string[10];
            //index du tableau
            int i = 0;
            //R�cup�ration du nombre d'�l�ments s�lectionn�s dans la liste.
            int NbElement = listBoxAnimaux.SelectedIndices.Count;
			//R�cup�ration du nombre d'�l�ments de la liste.
			int NbElement2 = listBoxAnimaux.Items.Count;
            //Conserver NbElement
            int Nb = NbElement;

            //Tant qu'il reste des �l�ments s�lectionn�s.
            while(Nb >= 1)
            {
               //Stockage de chaque �l�ment s�lectionn� dans le tableau.
                Tab[i] = listBoxAnimaux.SelectedItems[i].ToString();
               Nb--;
               //incr�mentation de l'index du tableau
                i++;
              
             
            }

            //Affichage de chaque �l�ment du tableau
            for (int j = 0; j < NbElement; j++)
            {
                MessageBox.Show(Tab[j]);
            }
			
}
