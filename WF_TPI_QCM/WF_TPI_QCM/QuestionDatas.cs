using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public class QuestionDatas
    {
        private string _question;
        private Dictionary<int, ReponseDatas> _dictReponseModele;
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

        public Dictionary<int, ReponseDatas> DictReponseModele
        {
            get
            {
                return _dictReponseModele;
            }

            set
            {
                if (value.Count <= 6 && value.Count >= 4)
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

        public QuestionDatas(string question)
        {
            Question = question;
            DictReponseModele = new Dictionary<int, ReponseDatas>();
        }

        public void AddReponse(int idReponse, ReponseDatas reponse)
        {
            if (!DictReponseModele.Keys.Contains(idReponse))
                DictReponseModele.Add(idReponse, reponse);
        }
    }
}
