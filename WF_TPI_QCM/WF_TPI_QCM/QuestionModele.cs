using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class QuestionModele
    {
        private string _question;
        private Dictionary<int, ReponseModele> _dictReponseModele;
        private bool _addedInTheBase;

        public string Question
        {
            get
            {
                return _question;
            }

            set
            {
                _question = value;
            }
        }

        public Dictionary<int, ReponseModele> DictReponseModele
        {
            get
            {
                return _dictReponseModele;
            }

            set
            {
                _dictReponseModele = value;
            }
        }

        public bool AddedInTheBase
        {
            get
            {
                return _addedInTheBase;
            }

            set
            {
                _addedInTheBase = value;
            }
        }

        public QuestionModele(string question)
        {
            Question = question;
            DictReponseModele = new Dictionary<int, ReponseModele>();
        }

        public void AddReponse(int idReponse, ReponseModele reponse)
        {
            if (!DictReponseModele.Keys.Contains(idReponse))
                DictReponseModele.Add(idReponse, reponse);
        }
    }
}
