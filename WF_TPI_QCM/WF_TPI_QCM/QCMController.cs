using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_TPI_QCM
{
    public class QCMController
    {
        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";
        FrmExportSelect _frmExportSelect;
        QCMModele _qcmModele;
        private FrmCreateQuestionReponse _frmCreateQuestionReponse;

        public QCMController(int idQCM)
        {
            _qcmModele = new QCMModele(idQCM);
        }

        #region QCM

        public static Dictionary<int, string> GetListQCM()
        {
            return QCMModele.GetListQCM();
        }

        public int GetLevelByIdQCM()
        {
            return _qcmModele.GetLevelByIdQCM();
        }

        public string GetTitreQCM()
        {
            return _qcmModele.GetTitreQCM();
        }

        public int GetIdQCM()
        {
            return _qcmModele.GetIdQCM();
        }

        public string InsertQCM(string titreQCM, int levelQCM)
        {
            return _qcmModele.InsertQCM(titreQCM, levelQCM);
        }

        public string DeleteQCM()
        {
            return _qcmModele.DeleteQCM();
        }

        public string UpdateQCM(string nouveauText, int nouveauLevel)
        {
            return _qcmModele.UpdateQCM(nouveauText, nouveauLevel);
        }

        #endregion

        #region Questions
    
        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return _qcmModele.GetQuestions();
        }

        public string InsertQuestion(string text, Dictionary<string, bool> dictReponses)
        {
            return _qcmModele.InsertQuestion(text, dictReponses);
        }

        public bool DeleteQuestionByIdQuestion(int idQuestion)
        {
            return _qcmModele.DeleteQuestionByIdQuestion(idQuestion);
        }

        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            return _qcmModele.UpdateQuestionByIdQuestion(idQuestion, nouveauTexte);
        }

        #endregion

        #region Reponses
        
        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            return _qcmModele.GetReponsesByIdQuestion(idQuestion);
        }

        public KeyValuePair<bool, string> UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseDatas reponseModele)
        {
            return _qcmModele.UpdateReponseByIdQuestionAndIdReponse(idQuestion, idReponse, reponseModele);
        }

        public string InsertReponse(int idQuestion, string reponseText, bool bonneReponse)
        {
            return _qcmModele.InsertReponse(idQuestion, reponseText, bonneReponse);
        }

        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            return _qcmModele.DeleteReponseByIdReponse(idQuestion, idReponse);
        }

        #endregion

        #region Mots-Clés

        public Dictionary<int, string> GetMotsCles()
        {
            return _qcmModele.GetMotsCles();
        }

        public string InsertMotCle(string text)
        {
            return _qcmModele.InsertMotCle(text);
        }

        public string UpdateMotCle(int idMotCle, string textMotCle)
        {
            return _qcmModele.UpdateMotCle(idMotCle, textMotCle);
        }

        public bool DeleteMotCleByIdMotCle(int idMotCle)
        {
            return _qcmModele.DeleteMotCleByIdMotCle(idMotCle);
        }

        #endregion

        #region GetIncrements

        public int GetNextIdReponse()
        {
            return _qcmModele.GetNextIdReponse();
        }

        public int GetNextIdQuestion()
        {
            return _qcmModele.GetNextIdQuestion();
        }

        public int GetNextIdMotCle()
        {
            return _qcmModele.GetNextIdMotCle();
        }

        #endregion

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

        public void Save()
        {
            _qcmModele.Save();
        }
    }
}
