using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class QCMModele
    {
        private const int MIN_VALUE_LEVEL = 1;
        private const int MAX_VALUE_LEVEL = 4;

        private const int MIN_MOTS_CLES = 0;
        private const int MAX_MOTS_CLES = 4;

        private int _idQCM;
        private string _nomQCM;
        private int _level;
        private Dictionary<int, string> _dictMotCle;
        private List<QuestionModele> _listQuestionModele;

        public int IdQCM
        {
            get
            {
                return _idQCM;
            }

            set
            {
                _idQCM = value;
            }
        }

        public string NomQCM
        {
            get
            {
                return _nomQCM;
            }

            set
            {
                _nomQCM = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }

        public List<QuestionModele> ListQuestionModele
        {
            get
            {
                return _listQuestionModele;
            }

            set
            {
                _listQuestionModele = value;
            }
        }

        public Dictionary<int, string> DictMotCle
        {
            get
            {
                return _dictMotCle;
            }

            set
            {
                _dictMotCle = value;
            }
        }

        /*public QCMModele(int idQCM, string nomQCM) : this(idQCM, nomQCM, 1, new Dictionary<QuestionModele, List<ReponseModele>>())
        { }

        public QCMModele(int idQCM, string nomQCM, int level) : this(idQCM, nomQCM, level, new Dictionary<QuestionModele, List<ReponseModele>>())
        { }*/

        public QCMModele(int idQCM, string nomQCM, int level)
        {
            IdQCM = idQCM;
            NomQCM = nomQCM;
            Level = level;

            DictMotCle = new Dictionary<int, string>();
            ListQuestionModele = new List<QuestionModele>();
        }

        public void AddQuestion(QuestionModele questionModele)
        {
            ListQuestionModele.Add(questionModele);
        }

        public void AddMotsCles(int idMotCle, string motCle)
        {
            if (!DictMotCle.ContainsKey(idMotCle))
                DictMotCle.Add(idMotCle, motCle);
        }
    }
}
