using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    class QCMModele
    {
        private QCMDatas _qcm;
        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";

        private QCMDatas Qcm
        {
            get
            {
                return _qcm;
            }

            set
            {
                _qcm = value;
            }
        }

        public QCMModele(int idQCM)
        {
            Qcm = DAO.SelectQCMById(idQCM);
        }

        public int GetLevelByIdQCM()
        {
            return Qcm.Level;
        }

        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return Qcm.DictQuestionModele;
        }

        public Dictionary<int, string> GetMotsCles()
        {
            return Qcm.DictMotCle;
        }

        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            QuestionDatas qm;
            Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm);
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
                qm.AddReponse(Qcm.NextIdReponse, new ReponseDatas(item.Key, item.Value));
                Qcm.NextIdReponse++;
            }

            if (nbReponseJuste == 1)
            {
                if (qm.DictReponseModele.Count >= 4 && qm.DictReponseModele.Count <= 6)
                {
                    Qcm.AddQuestion(Qcm.NextIdQuestion, qm);
                    Qcm.NextIdQuestion++;
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
            return Qcm.NomQCM;
        }

        public int GetIdQCM()
        {
            return Qcm.IdQCM;
        }

        public int GetNextIdQuestion()
        {
            return Qcm.NextIdQuestion;
        }

        public int GetNextIdReponse()
        {
            return Qcm.NextIdReponse;
        }

        public int GetNextIdMotCle()
        {
            return Qcm.NextIdMotCle;
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

        public bool DeleteQuestionByIdQuestion(int idQuestion)
        {
            //_listDeletedQuestion.Add(idQuestion);
            if (Qcm.DictQuestionModele.Remove(idQuestion))
                return true;
            else
                return false;
        }

        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.Question = nouveauTexte;
                return true;
            }
            else
            {
                return false;
            }
        }

        public KeyValuePair<bool, string> UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseDatas reponseModele)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                ReponseDatas rm;
                if (qm.DictReponseModele.TryGetValue(idReponse, out rm))
                {
                    if (rm.Reponse != reponseModele.Reponse || rm.BonneReponse != reponseModele.BonneReponse)
                    {
                        rm.Reponse = reponseModele.Reponse;
                        rm.BonneReponse = reponseModele.BonneReponse;
                        return new KeyValuePair<bool, string>(false, "Réponse modifiée avec succès !");
                    }
                    else
                        return new KeyValuePair<bool, string>(false, null);
                }
            }
            return new KeyValuePair<bool, string>(true, "Echec lors de la modification de la réponse !");
        }

        public string DeleteQCM()
        {
            try
            {
                DAO.DeleteQCMByIdQCM(Qcm.IdQCM);
                Qcm = null;
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
                    DAO.UpdateQCMByIdQCM(Qcm.IdQCM, nouveauText, nouveauLevel);
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
            foreach (KeyValuePair<int, QuestionDatas> item in Qcm.DictQuestionModele)
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
                    qm.AddReponse(Qcm.NextIdReponse, rm);
                    Qcm.NextIdReponse++;
                    return "Réponse créé avec succès !";
                }
            }
            return "Cette question est introuvable !";
        }

        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            QuestionDatas qm;
            if (Qcm.DictQuestionModele.TryGetValue(idQuestion, out qm))
            {
                qm.DictReponseModele.Remove(idReponse);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangeCorrectAnswer(int idQuestion, int idNewReponse)
        {
            foreach (KeyValuePair<int, ReponseDatas> item in GetReponsesByIdQuestion(idQuestion))
            {
                item.Value.BonneReponse = (item.Key == idQuestion) ? true : false;
            }
        }

        public static List<string> GetListModeles()
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

        public static Dictionary<int, string> GetListQCM()
        {
            return DAO.SelectAllQCM();
        }
    }
}
