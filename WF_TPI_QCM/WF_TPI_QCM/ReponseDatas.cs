using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public class ReponseDatas
    {
        private string _reponse;
        private bool _bonneReponse;

        Modes _modeDatabase;

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

        public Modes ModeDatabase
        {
            get
            {
                return _modeDatabase;
            }

            set
            {
                _modeDatabase = value;
            }
        }

        public ReponseDatas(string reponse, bool bonneReponse, Modes modeDatabase)
        {
            Reponse = reponse;
            BonneReponse = bonneReponse;
            ModeDatabase = modeDatabase;
        }
    }
}
