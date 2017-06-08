using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public enum Modes { Create, Update, Delete }; //Permet de faire les types (https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/enumeration-types)

    class QCMController
    {
        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";
        FrmExportSelect _frmExportSelect;
        QCMModele qcm;
        private FrmSelectDatas _frmSelectDatas;

        #region Select

        public QCMController()
        {
            DAO.CreateConnection();
        }

        public bool GetQCMById(int idQCM)
        {
            qcm = DAO.SelectQCMById(idQCM);
            return true;
        }

        public Dictionary<int, string> GetListQCM()
        {
            return DAO.SelectAllQCM();
        }

        public int GetLevelByIdQCM(int idQCM)
        {
            return qcm.Level;
        }

        public List<QuestionModele> GetQuestionsByIdQCM(int idQCM)
        {
            return qcm.ListQuestionModele;
        }

        public Dictionary<int, string> GetMotsClesByIdQCM(int idQCM)
        {
            return qcm.DictMotCle;
        }

        public List<ReponseModele> GetReponsesByIdQuestion(int idQuestion)
        {
            foreach (QuestionModele item in qcm.ListQuestionModele)
            {
                if(item.IdQuestion == idQuestion)
                {
                    return item.ListReponseModele;
                }
            }
            return null;
        }

        public string GetTitreQCMByIdQCM(int idQCM)
        {
            return qcm.NomQCM;
        }

        public string GetTextQuestionByIdQuestion(int idQuestion)
        {
            foreach (QuestionModele item in qcm.ListQuestionModele)
            {
                if (item.IdQuestion == idQuestion)
                {
                    return item.Question;
                }
            }
            return null;
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

        /*public string DeleteQCMByIdQCM(int idQCM)
        {
            return DAO.DeleteQCMByIdQCM(idQCM);
        }*/

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

        public string UpdateMotCle(int _idQCM, Dictionary<int, string> motCle)
        {
            if (motCle.Count > 4)
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

        public string DeleteMotCleByIdMotCle(int idMotCle)
        {
            return DAO.DeleteMotCleByIdMotCle(idMotCle);
        }

        public List<string> GetListModeles()
        {
            List<string> listModeles = new List<string>();


            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS);

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS + "\\latex.txt"))
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS + "\\latex.txt", Properties.Resources.latex);
            }

            //http://www.csharp-examples.net/get-files-from-directory/
            foreach (string item in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS))
            {
                listModeles.Add(item.Split('\\').Last());
            }
            return listModeles;
        }

        public void Export()
        {
            _frmExportSelect = new FrmExportSelect(GetListModeles());
            _frmExportSelect.ShowDialog();
        }

        public int AskQuestion()
        {
            Dictionary<int, string> dictQuestionModele = new Dictionary<int, string>();
            foreach (QuestionModele item in qcm.ListQuestionModele)
            {
                dictQuestionModele.Add(item.IdQuestion, item.Question);
            }
            return Ask(dictQuestionModele);
        }

        /*public int AskReponse(int idQuestion)
        {
            Dictionary<int, string> dictReponseModele = new Dictionary<int, string>();
            foreach (QuestionModele question in qcm.ListQuestionModele)
            {
                if(question.IdQuestion == idQuestion)
                    foreach (var reponse in question.ListReponseModele)
                    {
                        dictReponseModele.Add(reponse.IdReponse, reponse.Reponse);
                    }
            }
            return Ask(dictReponseModele);
        }*/

        /// <summary>
        /// Fait s'ouvrir une form pour la sélection des données
        /// </summary>
        /// <param name="datas">Toutes les données</param>
        /// <returns>Donnée sélectionnée</returns>
        public int Ask(Dictionary<int,string> datas)
        {
            _frmSelectDatas = new FrmSelectDatas(datas);
            _frmSelectDatas.ShowDialog();
            return _frmSelectDatas.ReturnId;
        }
    }
}
