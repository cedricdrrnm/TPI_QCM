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

        Modes _modeDatabase; // Permet de dire si c'est un nouveau QCM, si c'est une simple édition ou si c'est déjà dans la base de données

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
        /// <param name="question">Question</param>
        /// <param name="modeDatabase">Mode de la question dans la base de données</param>
        public QuestionDatas(string question, Modes modeDatabase)
        {
            Question = question;
            DictReponseModele = new Dictionary<int, ReponseDatas>();
            ModeDatabase = modeDatabase;
        }

        /// <summary>
        /// Ajoute une réponse à la question
        /// </summary>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="reponse">réponse</param>
        public void AddReponse(int idReponse, ReponseDatas reponse)
        {
            if (!DictReponseModele.Keys.Contains(idReponse))
                DictReponseModele.Add(idReponse, reponse);
        }
    }
}
