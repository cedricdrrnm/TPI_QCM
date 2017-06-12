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
        static QCMDatas _qcm;
        private Dictionary<QuestionDatas, Modes> _listEditedQuestion;
        private Dictionary<ReponseDatas, Modes> _listEditedReponse;

        #region Select

        public QCMController()
        {
            DAO.CreateConnection();
            _listEditedQuestion = new Dictionary<QuestionDatas, Modes>();
            _listEditedReponse = new Dictionary<ReponseDatas, Modes>();
        }

        public bool GetQCMById(int idQCM)
        {
            try
            {
                _qcm = DAO.SelectQCMById(idQCM);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Dictionary<int, string> GetListQCM()
        {
            return QCMModele.GetListQCM();
        }

        public int GetLevelByIdQCM()
        {
            return _qcm.Level;
        }

        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return _qcm.DictQuestionModele;
        }

        public Dictionary<int, string> GetMotsCles()
        {
            return _qcm.DictMotCle;
        }

        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            QuestionDatas qm;
            _qcm.DictQuestionModele.TryGetValue(idQuestion, out qm);
            return qm.DictReponseModele;
        }

        public string InsertQuestion(string text, Dictionary<string, bool> dictReponses)
        {
            QuestionDatas qm = new QuestionDatas(text);
            int nbReponseJuste = 0;
            foreach (KeyValuePair<string, bool> item in dictReponses)
            {
                if (item.Value)
                    nbReponseJuste++;
                qm.AddReponse(_qcm.NextIdReponse, new ReponseDatas(item.Key, item.Value));
                _qcm.NextIdReponse++;
            }

            if (nbReponseJuste == 1)
            {
                if (qm.DictReponseModele.Count >= 4 && qm.DictReponseModele.Count <= 6)
                {
                    _qcm.AddQuestion(_qcm.NextIdQuestion, qm);
                    _qcm.NextIdQuestion++;
                    return "Question insérée avec succès !";
                }
                else
                {
                    return "Il n'y a pas le nombre adéquat de réponse !";
                }
            }
            else
            {
                return "Nombre de réponses justes incorrecte !";
            }
        }

        public string GetTitreQCM()
        {
            return _qcm.NomQCM;
        }

        public int GetIdQCM()
        {
            return _qcm.IdQCM;
        }

        /*public string GetTextQuestionByIdQuestion(int idQuestion)
        {
            foreach (KeyValuePair<int, QuestionModele> item in qcm.DictQuestionModele)
            {
                if (item.Key == idQuestion)
                {
                    return item.Value.Question;
                }
            }
            return null;
        }*/

        #endregion

        public int GetNextIdQuestion()
        {
            return _qcm.NextIdQuestion;
        }

        public int GetNextIdReponse()
        {
            return _qcm.NextIdReponse;
        }

        public int GetNextIdMotCle()
        {
            return _qcm.NextIdMotCle;
        }

        public string InsertQCM(string titreQCM, int levelQCM)
        {
            try
            {
                DAO.InsertQCM(titreQCM, levelQCM);
                return "Ce qcm a bien été créé !";
            }
            catch (Exception ex)
            {
                return "Erreur lors de l'insertion du QCM: " + ex.Message;
            }
        }

        /*public string UpdateQCMByIdQCM(int idQCM, string nouveauTitreQCM, int nouveauLevelQCM)
        {
            return DAO.UpdateQCMByIdQCM(nouveauTitreQCM, nouveauLevelQCM.ToString(), idQCM);
        }*/

        /*public string DeleteQCMByIdQCM(int idQCM)
        {
            return DAO.DeleteQCMByIdQCM(idQCM);
        }*/

        public bool DeleteQuestionByIdQuestion(int idQuestion)
        {
            //_listDeletedQuestion.Add(idQuestion);
            if (_qcm.DictQuestionModele.Remove(idQuestion))
                return true;
            else
                return false;
        }

        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            QuestionDatas qm;
            if (_qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.Question = nouveauTexte;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public string InsertQuestion(string question, Dictionary<string, bool> reponses)
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
        }*/

        public string UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseDatas reponseModele)
        {
            QuestionDatas qm;
            if (_qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                ReponseDatas rm;
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

        public string DeleteQCM()
        {
            try
            {
                DAO.DeleteQCMByIdQCM(_qcm.IdQCM);
                _qcm = null;
                return "Supprimé avec succès !";
            }
            catch (Exception ex)
            {
                return "Erreur lors de la suppression: " + ex.Message;
            }

        }

        public string UpdateQCM(string nouveauText, int nouveauLevel)
        {
            if (nouveauText.Trim() != "")
            {
                try
                {
                    DAO.UpdateQCMByIdQCM(_qcm.IdQCM, nouveauText, nouveauLevel);
                    return "Modifié avec succès !";
                }
                catch (Exception ex)
                {
                    return "Erreur lors de la modification: " + ex.Message;
                }
            }
            return "Nom vide !";
        }

        public string InsertReponse(int idQuestion, string reponseText, bool bonneReponse)
        {
            QuestionDatas qm = null;
            foreach (KeyValuePair<int, QuestionDatas> item in _qcm.DictQuestionModele)
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
                    ReponseDatas rm = new ReponseDatas(reponseText, bonneReponse);
                    qm.AddReponse(_qcm.NextIdReponse, rm);
                    _qcm.NextIdReponse++;
                    _listEditedReponse.Add(rm, Modes.Create);
                    return "Réponse créé avec succès !";
                }
            }
            return "Cette question est introuvable !";
        }

        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            QuestionDatas qm;
            if (_qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.DictReponseModele.Remove(idReponse);
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public string UpdateQuestionByIdQuestion(int idQCM, int idQuestion, string question, Dictionary<string, bool> reponses)
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
        }*/

        /*public string InsertMotCle(int idQCM, string[] motCle)
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
        }*/

        /*public string UpdateMotCle(int _idQCM, Dictionary<int, string> motCle)
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
        }*/

        /*public string DeleteMotCleByIdMotCle(int idMotCle)
        {
            return DAO.DeleteMotCleByIdMotCle(idMotCle);
        }*/

        public string ChooseCorrectAnswer(int idQuestion)
        {
            Dictionary<int, string> dictReponse = new Dictionary<int, string>();
            foreach (KeyValuePair<int, ReponseDatas> item in GetReponsesByIdQuestion(idQuestion))
            {
                dictReponse.Add(item.Key, item.Value.Reponse);
            }
            frmChoixReponseJuste _frmCCA = new frmChoixReponseJuste(dictReponse);
            _frmCCA.ShowDialog();
            if (_frmCCA.ReturnId != 0)
            {
                ChangeCorrectAnswer(idQuestion, _frmCCA.ReturnId);
                return "Bonne réponse changée !";
            }
            else
            {
                return "La bonne réponse n'a pas changé";
            }
        }

        private void ChangeCorrectAnswer(int idQuestion, int idNewReponse)
        {
            foreach (KeyValuePair<int, ReponseDatas> item in GetReponsesByIdQuestion(idQuestion))
            {
                item.Value.BonneReponse = (item.Key == idQuestion) ? true : false;
            }
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
    }
}
