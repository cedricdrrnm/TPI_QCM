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

        // Permet de dire si c'est un nouveau QCM, si c'est une simple édition ou si c'est déjà dans la base de données
        private Modes _modeDatabase;

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


        /// <summary>
        /// Permet de dire si c'est un nouveau QCM, si c'est une simple édition ou si c'est déjà dans la base de données
        /// </summary>
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

            /// <summary>
            /// Constructeur
            /// </summary>
            /// <param name="idQCM">Id du QCM</param>
            /// <param name="nomQCM">Nom du QCM</param>
            /// <param name="level">Niveau du QCM</param>
            /// <param name="mode">Mode du QCM pour la base de données</param>
        public QCMDatas(int idQCM, string nomQCM, int level, Modes mode)
        {
            IdQCM = idQCM;
            NomQCM = nomQCM;
            Level = level;
            ModeDatabase = mode;

            DictMotCle = new Dictionary<int, MotsClesDatas>();
            DictQuestionModele = new Dictionary<int, QuestionDatas>();
        }

        /// <summary>
        /// Ajoute une question au QCM
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="questionModele">Question</param>
        /// <returns></returns>
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

        /// <summary>
        /// Ajoute une reponse à une question du modèle
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="reponse">Réponse</param>
        public void AddReponseToQuestion(int idQuestion, int idReponse, ReponseDatas reponse)
        {
            QuestionDatas qm;
            if (DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.AddReponse(idReponse, reponse);
            }
        }

        /// <summary>
        /// Ajoute un mot clé
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <param name="motCle">Mot-clé</param>
        /// <returns></returns>
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
