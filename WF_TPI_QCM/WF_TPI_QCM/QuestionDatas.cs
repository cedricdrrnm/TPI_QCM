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

        Modes _modeDatabase;

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
                _dictReponseModele = value;
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

        public QuestionDatas(string question, Modes modeDatabase)
        {
            Question = question;
            DictReponseModele = new Dictionary<int, ReponseDatas>();
            ModeDatabase = modeDatabase;
        }

        public void AddReponse(int idReponse, ReponseDatas reponse)
        {
            if (!DictReponseModele.Keys.Contains(idReponse))
                DictReponseModele.Add(idReponse, reponse);
        }
    }
}
