using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConteneur
{
    class Machine
    {
        private string Marque;
        private string Processeur;
        private string Ram;

        public string GetMarque()
        {
            return Marque;
        }

        public void SetMarque(string Marque)
        {
            this.Marque = Marque;

        }

        //A compléter (même chose) Get et Set pour Processeur
        //A compléter (même chose) Get et Set pour RAM
    }


}
