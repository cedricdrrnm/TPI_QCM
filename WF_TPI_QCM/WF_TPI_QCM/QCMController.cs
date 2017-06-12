using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public enum Modes { Create, Update, Delete }; //Permet de faire les types (https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/enumeration-types)

    public class QCMController
    {
        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";
        FrmExportSelect _frmExportSelect;
        QCMModele _qcmModele;
        private FrmCreateQuestionReponse _frmCreateQuestionReponse;

        #region Select

        public QCMController(int idQCM)
        {
            DAO.CreateConnection();
            _qcmModele = new QCMModele(idQCM);
        }

        public static Dictionary<int, string> GetListQCM()
        {
            return QCMModele.GetListQCM();
        }

        public int GetLevelByIdQCM()
        {
            return _qcmModele.GetLevelByIdQCM();
        }

        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return _qcmModele.GetQuestions();
        }

        public Dictionary<int, string> GetMotsCles()
        {
            return _qcmModele.GetMotsCles();
        }

        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            return _qcmModele.GetReponsesByIdQuestion(idQuestion);
        }

        public string InsertQuestion(string text, Dictionary<string, bool> dictReponses)
        {
            return _qcmModele.InsertQuestion(text, dictReponses);
        }

        public string GetTitreQCM()
        {
            return _qcmModele.GetTitreQCM();
        }

        public int GetIdQCM()
        {
            return _qcmModele.GetIdQCM();
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
            return _qcmModele.GetNextIdQuestion();
        }

        public int GetNextIdReponse()
        {
            return _qcmModele.GetNextIdReponse();
        }

        public int GetNextIdMotCle()
        {
            return _qcmModele.GetNextIdMotCle();
        }

        public string InsertQCM(string titreQCM, int levelQCM)
        {
            return _qcmModele.InsertQCM(titreQCM, levelQCM);
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
            return _qcmModele.DeleteQuestionByIdQuestion(idQuestion);
        }

        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            return _qcmModele.UpdateQuestionByIdQuestion(idQuestion, nouveauTexte);
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

        public KeyValuePair<bool,string> UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseDatas reponseModele)
        {
            return _qcmModele.UpdateReponseByIdQuestionAndIdReponse(idQuestion, idReponse, reponseModele);
        }

        public string DeleteQCM()
        {
            return _qcmModele.DeleteQCM();
        }

        public string UpdateQCM(string nouveauText, int nouveauLevel)
        {
            return _qcmModele.UpdateQCM(nouveauText, nouveauLevel);
        }

        public string InsertReponse(int idQuestion, string reponseText, bool bonneReponse)
        {
            return _qcmModele.InsertReponse(idQuestion, reponseText, bonneReponse);
        }

        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            return _qcmModele.DeleteReponseByIdReponse(idQuestion, idReponse);
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
                _qcmModele.ChangeCorrectAnswer(idQuestion, _frmCCA.ReturnId);
                return "Bonne réponse changée !";
            }
            else
            {
                return "La bonne réponse n'a pas changé";
            }
        }

        public static List<string> GetListModeles()
        {
            return QCMModele.GetListModeles();
        }

        public void CreateQuestionReponse()
        {
            _frmCreateQuestionReponse = new FrmCreateQuestionReponse(this);
            _frmCreateQuestionReponse.ShowDialog();
        }

        public void Export()
        {
            _frmExportSelect = new FrmExportSelect(GetListModeles());
            _frmExportSelect.ShowDialog();
        }

        public static void OpenFormContents(int idQCM)
        {
            FrmInformations _frm = new FrmInformations(idQCM);
            _frm.Show();
        }
    }
}
