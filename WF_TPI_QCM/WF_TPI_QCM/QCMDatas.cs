using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class QCMDatas
    {
        private const int MIN_VALUE_LEVEL = 1;
        private const int MAX_VALUE_LEVEL = 4;

        private const int MIN_MOTS_CLES = 0;
        private const int MAX_MOTS_CLES = 4;

        private int _idQCM;
        private string _nomQCM;
        private int _level;
        private Dictionary<int, MotsClesDatas> _dictMotCle;
        private Dictionary<int, QuestionDatas> _dictQuestionModele;

        private int _nextIdQuestion;
        private int _nextIdReponse;
        private int _nextIdMotCle;
        private int _nextIdQCM;

        Modes _modeDatabase;

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

        public Dictionary<int, QuestionDatas> DictQuestionModele
        {
            get
            {
                return _dictQuestionModele;
            }

            set
            {
                _dictQuestionModele = value;
            }
        }

        public Dictionary<int, MotsClesDatas> DictMotCle
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

        public int NextIdQuestion
        {
            get
            {
                return _nextIdQuestion;
            }

            set
            {
                _nextIdQuestion = value;
            }
        }

        public int NextIdReponse
        {
            get
            {
                return _nextIdReponse;
            }

            set
            {
                _nextIdReponse = value;
            }
        }

        public int NextIdMotCle
        {
            get
            {
                return _nextIdMotCle;
            }

            set
            {
                _nextIdMotCle = value;
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

        /*public QCMModele(int idQCM, string nomQCM) : this(idQCM, nomQCM, 1, new Dictionary<QuestionModele, List<ReponseModele>>())
        { }

        public QCMModele(int idQCM, string nomQCM, int level) : this(idQCM, nomQCM, level, new Dictionary<QuestionModele, List<ReponseModele>>())
        { }*/

        public QCMDatas(int idQCM, string nomQCM, int level, Modes mode)
        {
            IdQCM = idQCM;
            NomQCM = nomQCM;
            Level = level;
            ModeDatabase = mode;

            DictMotCle = new Dictionary<int, MotsClesDatas>();
            DictQuestionModele = new Dictionary<int, QuestionDatas>();
        }

        public string AddQuestion(int idQuestion, QuestionDatas questionModele)
        {
            if (DictQuestionModele.Keys.Contains(idQuestion))
            {
                return "Cette question existe déjà !";
            }
            else
            {
                DictQuestionModele.Add(idQuestion, questionModele);
                return "Création de la question avec succès !";
            }
        }


        public void AddReponseToQuestion(int idQuestion, int idReponse, ReponseDatas reponse)
        {
            QuestionDatas qm;
            if (DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.AddReponse(idReponse, reponse);
            }
        }

        public string AddMotsCles(int idMotCle, MotsClesDatas motCle)
        {
            if (!DictMotCle.ContainsKey(idMotCle))
            {
                DictMotCle.Add(idMotCle, motCle);
                return "Mot-clé ajouté !";
            }
            else
            {
                return "Mot-clé déjà existant !";
            }
        }
    }
}
