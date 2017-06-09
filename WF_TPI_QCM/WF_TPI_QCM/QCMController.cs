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
        static QCMModele qcm;
        private Dictionary<QuestionModele, Modes> _listEditedQuestion;
        private Dictionary<ReponseModele, Modes> _listEditedReponse;
        private FrmSelectDatas _frmSelectDatas;

        #region Select

        public QCMController()
        {
            DAO.CreateConnection();
            _listEditedQuestion = new Dictionary<QuestionModele, Modes>();
            _listEditedReponse = new Dictionary<ReponseModele, Modes>();
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

        public Dictionary<int, QuestionModele> GetQuestionsByIdQCM(int idQCM)
        {
            return qcm.DictQuestionModele;
        }

        public Dictionary<int, string> GetMotsClesByIdQCM(int idQCM)
        {
            return qcm.DictMotCle;
        }

        public Dictionary<int, ReponseModele> GetReponsesByIdQuestion(int idQuestion)
        {
            foreach (KeyValuePair<int, QuestionModele> item in qcm.DictQuestionModele)
            {
                if (item.Key == idQuestion)
                {
                    return item.Value.DictReponseModele;
                }
            }
            return null;
        }

        public string GetTitreQCMByIdQCM(int idQCM)
        {
            return qcm.NomQCM;
        }

        public int GetIdQCM()
        {
            return qcm.IdQCM;
        }

        public string GetTextQuestionByIdQuestion(int idQuestion)
        {
            foreach (KeyValuePair<int, QuestionModele> item in qcm.DictQuestionModele)
            {
                if (item.Key == idQuestion)
                {
                    return item.Value.Question;
                }
            }
            return null;
        }

        #endregion

        public int GetNextIdQuestion()
        {
            return qcm.NextIdQuestion;
        }

        public int GetNextIdReponse()
        {
            return qcm.NextIdReponse;
        }

        public int GetNextIdMotCle()
        {
            return qcm.NextIdMotCle;
        }



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

        public string InsertQuestion(string question, Dictionary<string, bool> reponses)
        {
            if (reponses.Count < 4)
                return "Il a pas assez de réponses !";
            else if (reponses.Count > 6)
                return "Il a trop de réponses !";
            else if (!reponses.ContainsValue(true))
                return "Il a pas de réponse correcte !";
            else
            {
                QuestionModele qm = new QuestionModele(question);
                foreach (KeyValuePair<string, bool> item in reponses)
                {
                    qm.AddReponse(0, new ReponseModele(item.Key, item.Value));
                    qcm.NextIdReponse++;
                }
                _listEditedQuestion.Add(qm, Modes.Create);
                string rep = qcm.AddQuestion(qcm.NextIdQuestion, qm);
                qcm.NextIdQuestion++;
                return rep;
            }
        }

        public string UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseModele reponseModele)
        {
            QuestionModele qm;
            if (qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                ReponseModele rm;
                if (qm.DictReponseModele.TryGetValue(idReponse, out rm))
                {
                    if (rm.Reponse != reponseModele.Reponse || rm.BonneReponse != reponseModele.BonneReponse)
                    {
                        rm.Reponse = reponseModele.Reponse;
                        rm.BonneReponse = reponseModele.BonneReponse;
                        return "Réponse modifiée !";
                    }
                    else
                        return "";
                }
                else
                {
                    return "Réponse introuvable !";
                }
            }
            else
            {
                return "Question introuvable !";
            }
        }

        public string InsertReponse(int idQuestion, string reponseText, bool bonneReponse)
        {
            QuestionModele qm = null;
            foreach (KeyValuePair<int, QuestionModele> item in qcm.DictQuestionModele)
            {
                if (item.Key == idQuestion)
                {
                    qm = item.Value;
                }
            }
            if (qm != null)
            {
                if (qm.DictReponseModele.Count >= 6)
                    return "Il a trop de réponses !";
                else
                {
                    ReponseModele rm = new ReponseModele(reponseText, bonneReponse);
                    qm.AddReponse(qcm.NextIdReponse, rm);
                    qcm.NextIdReponse++;
                    _listEditedReponse.Add(rm, Modes.Create);
                    return "Réponse créé avec succès !";
                }
            }
            return "Cette question est introuvable !";
        }

        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            QuestionModele qm;
            if (qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.DictReponseModele.Remove(idReponse);
                return true;
            }
            else
            {
                return false;
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
                return (tempError + Environment.NewLine + InsertQuestion(question, reponses)).Trim();
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
            foreach (KeyValuePair<int, QuestionModele> item in qcm.DictQuestionModele)
            {
                dictQuestionModele.Add(item.Key, item.Value.Question);
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
        public int Ask(Dictionary<int, string> datas)
        {
            _frmSelectDatas = new FrmSelectDatas(datas);
            _frmSelectDatas.ShowDialog();
            return _frmSelectDatas.ReturnId;
        }
    }
}
