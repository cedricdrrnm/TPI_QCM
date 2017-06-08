using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class QuestionModele
    {
        private int _idQuestion;
        private string _question;
        private List<ReponseModele> _listReponseModele;

        public int IdQuestion
        {
            get
            {
                return _idQuestion;
            }

            set
            {
                _idQuestion = value;
            }
        }

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

        public List<ReponseModele> ListReponseModele
        {
            get
            {
                return _listReponseModele;
            }

            set
            {
                _listReponseModele = value;
            }
        }

        public QuestionModele(int idQuestion, string question)
        {
            IdQuestion = idQuestion;
            Question = question;
            ListReponseModele = new List<ReponseModele>();
        }

        public void AddReponse(ReponseModele reponseModele)
        {
            ListReponseModele.Add(reponseModele);
        }
    }
}
