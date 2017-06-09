using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class ReponseModele
    {
        private string _reponse;
        private bool _bonneReponse;

        public string Reponse
        {
            get
            {
                return _reponse;
            }

            set
            {
                _reponse = value;
            }
        }

        public bool BonneReponse
        {
            get
            {
                return _bonneReponse;
            }

            set
            {
                _bonneReponse = value;
            }
        }

        /*public ReponseModele(int idReponse, string reponse) : this(idReponse, reponse, false)
        { }
        */

        public ReponseModele(string reponse, bool bonneReponse)
        {
            Reponse = reponse;
            BonneReponse = bonneReponse;
        }
    }
}
