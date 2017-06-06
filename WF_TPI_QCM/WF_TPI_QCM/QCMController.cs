using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public enum Modes { Create, Update, Delete }; //Permet de faire les types (https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/enumeration-types)

    class QCMController
    {
        #region Select

        public QCMController()
        {
            DAO.CreateConnection();
        }

        public Dictionary<int, string> GetQCM()
        {
            return DAO.SelectAllQCM();
        }

        public int GetLevelByIdQCM(int idQCM)
        {
            return DAO.SelectLevelByIdQCM(idQCM);
        }

        public Dictionary<int, string> GetQuestionsByIdQCM(int idQCM)
        {
            return DAO.SelectAllQuestionByIdQCM(idQCM);
        }

        public Dictionary<int, string> GetMotsClesByIdQCM(int idQCM)
        {
            return DAO.SelectAllMotCleByIdQCM(idQCM);
        }

        public Dictionary<string, bool> GetReponsesByIdQuestion(int idQuestion)
        {
            return DAO.SelectAllReponseByIdQuestion(idQuestion);
        }

        public string GetTitreQCMByIdQCM(int idQCM)
        {
            return DAO.SelectTitreQCMByIdQCM(idQCM);
        }

        public string GetTextQuestionByIdQuestion(int idQuestion)
        {
            return DAO.SelectTextQuestionByIdQuestion(idQuestion);
        }

        #endregion

        public string InsertQCM(string titreQCM, int levelQCM)
        {
            return DAO.InsertQCM(titreQCM, levelQCM.ToString());
        }

        public string UpdateQCMByIdQCM(int idQCM, string nouveauTitreQCM, int nouveauLevelQCM)
        {
            return DAO.UpdateQCMByIdQCM(nouveauTitreQCM, nouveauLevelQCM.ToString(), idQCM);
        }

        public string DeleteQCMByIdQCM(int idQCM)
        {
            return DAO.DeleteQCMByIdQCM(idQCM);
        }

        public string DeleteQuestionByIdQuestion(int idQuestion)
        {
            return DAO.DeleteQuestionByIdQuestion(idQuestion);
        }

        public string InsertQuestion(int idQCM, string question, Dictionary<string, bool> reponses)
        {
            if (reponses.Count < 4)
                return "Il a pas assez de réponses !";
            else if (reponses.Count > 6)
                return "Il a trop de réponses !";
            else if (!reponses.ContainsValue(true))
                return "Il a pas de réponse correcte !";
            else
            {
                return DAO.InsertQuestion(idQCM, question, reponses);
            }
        }

        public string UpdateQuestionByIdQuestion(int idQCM, int idQuestion, string question, Dictionary<string, bool> reponses)
        {
            if (reponses.Count < 4)
                return "Il a pas assez de réponses !";
            else if (reponses.Count > 6)
                return "Il a trop de réponses !";
            else if (!reponses.ContainsValue(true))
                return "Il a pas de réponse correcte !";
            else
            {

                string tempError = DeleteQuestionByIdQuestion(idQuestion);
                return (tempError + Environment.NewLine + InsertQuestion(idQCM, question, reponses)).Trim();
            }
        }

        public string InsertMotCle(int idQCM, string[] motCle)
        {
            if (motCle.Length > 4)
                return "Il a trop de mots-clés !";
            else
            {
                string tempError = "";
                foreach (string item in motCle)
                {
                    tempError += DAO.InsertMotCle(idQCM, item);
                }
                return tempError;
            }
        }

        public string UpdateMotCle(int _idQCM, Dictionary<int,string> motCle)
        {
            if(motCle.Count > 4)
                return "Il a trop de mots-clés !";
            else
            {
                string tempError = "";
                foreach (KeyValuePair<int, string> item in motCle)
                {
                    tempError += DAO.DeleteMotCleByIdMotCle(item.Key);
                }
                tempError += InsertMotCle(_idQCM, motCle.Values.ToArray());
                return tempError;
            }
        }
    }
}
