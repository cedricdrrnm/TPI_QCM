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
        #region Constantes Exportation

        private const string MARQUE_LOOP_QUESTION = "%loopQuestion%";
        private const string MARQUE_LOOP_BAD_ANSWER = "%loopBadAnswer%";
        private const string MARQUE_LOOP_GOOD_ANSWER = "%loopGoodAnswer%";
        private const string MARQUE_TEXT_QUESTION = "%textQuestion%";
        private const string MARQUE_TEXT_BAD_ANSWER = "%badAnswer%";
        private const string MARQUE_TEXT_GOOD_ANSWER = "%goodAnswer%";
        private const string MARQUE_AUTHOR = "%author%";
        private const string MARQUE_TITLE = "%title%";

        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";
        #endregion

        QCMModele _qcmModele;
        private FrmCreateQuestionReponse _frmCreateQuestionReponse;
        private static Dictionary<int, FrmInformations> _dictQCMOpened;
        
        public QCMController(int idQCM)
        {
            _qcmModele = new QCMModele(idQCM);
        }

        #region QCM

        /// <summary>
        /// Récupère la liste des QCMs
        /// </summary>
        /// <returns>Liste des QCMs</returns>
        public static Dictionary<int, string> GetListQCM()
        {
            return QCMModele.GetListQCM();
        }

        /// <summary>
        /// Récupère le niveau (level) du QCM
        /// </summary>
        /// <returns>Niveau du QCM</returns>
        public int GetLevelByIdQCM()
        {
            return _qcmModele.GetLevel();
        }

        /// <summary>
        /// Récupère le titre du QCM
        /// </summary>
        /// <returns>Titre du QCM</returns>
        public string GetTitreQCM()
        {
            return _qcmModele.GetTitreQCM();
        }

        /// <summary>
        /// Récupère l'id du QCM
        /// </summary>
        /// <returns>Id du QCM</returns>
        public int GetIdQCM()
        {
            return _qcmModele.GetIdQCM();
        }

        /// <summary>
        /// Insère un QCM
        /// </summary>
        /// <param name="titreQCM">Titre du QCM</param>
        /// <param name="levelQCM">Niveau du QCM</param>
        /// <returns>Vrai si réussi ,false sinon</returns>
        public bool InsertQCM(string titreQCM, int levelQCM)
        {
            if (!_qcmModele.CheckExists(titreQCM))
            {
                _qcmModele.InsertQCM(titreQCM, levelQCM);
                OpenFormContents();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Supprime un QCM
        /// </summary>
        /// <returns>Message</returns>
        public string DeleteQCM()
        {
            return _qcmModele.DeleteQCM();
        }

        /// <summary>
        /// Mets à jour un QCM avec les novuelles informations
        /// </summary>
        /// <param name="nouveauText">Nouveau texte</param>
        /// <param name="nouveauLevel">Nouveau niveau</param>
        /// <returns>Message</returns>
        public string UpdateQCM(string nouveauText, int nouveauLevel)
        {
            return _qcmModele.UpdateQCM(nouveauText, nouveauLevel);
        }

        #endregion

        #region Questions

        /// <summary>
        /// Récupère les questions du QCM
        /// </summary>
        /// <returns>Question du QCM</returns>
        public Dictionary<int, QuestionDatas> GetQuestions()
        {
            return _qcmModele.GetQuestions();
        }

        /// <summary>
        /// Insère une nouvelle question avec les informations fournies
        /// </summary>
        /// <param name="text">Texte de la question</param>
        /// <param name="dictReponses">Réponses à la question</param>
        /// <returns>Message</returns>
        public string InsertQuestion(string text, Dictionary<string, bool> dictReponses)
        {
            return _qcmModele.InsertQuestion(text, dictReponses);
        }

        /// <summary>
        /// Supprime une question par son id
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Vrai si réussi, false sinon</returns>
        public bool DeleteQuestionByIdQuestion(int idQuestion)
        {
            return _qcmModele.DeleteQuestionByIdQuestion(idQuestion);
        }

        /// <summary>
        /// Mets à jour une question avec les informations fournies
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="nouveauTexte">Nouveau texte</param>
        /// <returns>Vrai si réussi, false sinon</returns>
        public bool UpdateQuestionByIdQuestion(int idQuestion, string nouveauTexte)
        {
            return _qcmModele.UpdateQuestionByIdQuestion(idQuestion, nouveauTexte);
        }

        #endregion

        #region Reponses

        /// <summary>
        /// Récupère les réponses par l'id de la question
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Réponses à la question</returns>
        public Dictionary<int, ReponseDatas> GetReponsesByIdQuestion(int idQuestion)
        {
            return _qcmModele.GetReponsesByIdQuestion(idQuestion);
        }

        /// <summary>
        /// Modifie une réponse par les informations fournies
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <param name="reponseModele">Réponse</param>
        /// <returns>Message</returns>
        public KeyValuePair<bool, string> UpdateReponseByIdQuestionAndIdReponse(int idQuestion, int idReponse, ReponseDatas reponseModele)
        {
            return _qcmModele.UpdateReponseByIdQuestionAndIdReponse(idQuestion, idReponse, reponseModele);
        }

        /// <summary>
        /// Insère une nouvelle question avec les informations fournies
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="reponseText">Réponse à la question</param>
        /// <param name="bonneReponse">Bonne réponse ou non</param>
        /// <returns>Message</returns>
        public string InsertReponse(int idQuestion, string reponseText, bool bonneReponse)
        {
            return _qcmModele.InsertReponse(idQuestion, reponseText, bonneReponse);
        }

        /// <summary>
        /// Supprime une réponse par l'id
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <param name="idReponse">Id de la réponse</param>
        /// <returns>True si réussi, false sinon</returns>
        public bool DeleteReponseByIdReponse(int idQuestion, int idReponse)
        {
            return _qcmModele.DeleteReponseByIdReponse(idQuestion, idReponse);
        }

        #endregion

        #region Mots-Clés

        /// <summary>
        /// Récupère les mots-clés
        /// </summary>
        /// <returns>Mots-clés</returns>
        public Dictionary<int, MotsClesDatas> GetMotsCles()
        {
            return _qcmModele.GetMotsCles();
        }

        /// <summary>
        /// Insère un mot clé avec son texte
        /// </summary>
        /// <param name="text">Texte du mot-clé</param>
        /// <returns>Message</returns>
        public string InsertMotCle(string text)
        {
            return _qcmModele.InsertMotCle(text);
        }

        /// <summary>
        /// Mets à jour un mot-clé par l'id et son nouveau texte
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <param name="textMotCle">Texte du mot-clé</param>
        /// <returns>Message</returns>
        public string UpdateMotCle(int idMotCle, string textMotCle)
        {
            return _qcmModele.UpdateMotCle(idMotCle, textMotCle);
        }

        /// <summary>
        /// Supprime un mot-clé par l'id
        /// </summary>
        /// <param name="idMotCle">Id du mot-clé</param>
        /// <returns>True si réussi, sinon false</returns>
        public bool DeleteMotCleByIdMotCle(int idMotCle)
        {
            return _qcmModele.DeleteMotCleByIdMotCle(idMotCle);
        }

        #endregion

        #region GetIncrements

        /// <summary>
        /// Récupère le prochaine id de réponses
        /// </summary>
        /// <returns>Prochaine id de réponses</returns>
        public int GetNextIdReponse()
        {
            return _qcmModele.GetNextIdReponse();
        }

        /// <summary>
        /// Récupère le prochaine id de questions
        /// </summary>
        /// <returns>Prochaine id de questions</returns>
        public int GetNextIdQuestion()
        {
            return _qcmModele.GetNextIdQuestion();
        }

        /// <summary>
        /// Récupère le prochaine id de mots-clés
        /// </summary>
        /// <returns>Prochaine id de mots-clés</returns>
        public int GetNextIdMotCle()
        {
            return _qcmModele.GetNextIdMotCle();
        }

        #endregion

        /// <summary>
        /// Choisir une nouvelle réponse
        /// </summary>
        /// <param name="idQuestion">Id de la question</param>
        /// <returns>Message</returns>
        public string ChooseCorrectAnswer(int idQuestion)
        {
            Dictionary<int, string> dictReponse = new Dictionary<int, string>();
            foreach (KeyValuePair<int, ReponseDatas> item in GetReponsesByIdQuestion(idQuestion))
            {
                dictReponse.Add(item.Key, item.Value.Reponse);
            }
            FrmChoixReponseJuste _frmCCA = new FrmChoixReponseJuste(dictReponse);
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

        /// <summary>
        /// Récupère la liste des modèles pour le Latex
        /// </summary>
        /// <returns></returns>
        public static List<string> GetListModeles()
        {
            return QCMModele.GetListModeles();
        }

        /// <summary>
        /// Créer une nouvelle question (et des réponses)
        /// </summary>
        public void CreateQuestionReponse()
        {
            _frmCreateQuestionReponse = new FrmCreateQuestionReponse(this);
            _frmCreateQuestionReponse.ShowDialog();
        }

        /// <summary>
        /// Permet l'exportation
        /// </summary>
        public static void Export()
        {
            FrmExportSelect _frmExportSelect = new FrmExportSelect(GetListModeles());
            _frmExportSelect.ShowDialog();
            KeyValuePair<string, List<int>> itemsForExport = _frmExportSelect.ReturnItem;

            if (itemsForExport.Value != null)
                if (itemsForExport.Value.Count > 0)
                {
                    FrmExport _frmExport = new FrmExport(itemsForExport.Value, new string[] { MARQUE_LOOP_QUESTION, MARQUE_LOOP_BAD_ANSWER, MARQUE_LOOP_GOOD_ANSWER, MARQUE_TEXT_QUESTION, MARQUE_TEXT_BAD_ANSWER, MARQUE_TEXT_GOOD_ANSWER }, FILENAME_ACCESS, itemsForExport.Key);
                    _frmExport.ShowDialog();
                }            
        }

        /// <summary>
        /// Permet de transformer les marqueurs et en faire un Latex.
        /// </summary>
        /// <param name="nameOfDocument">Nom du document</param>
        /// <param name="textLatex">Texte du latex (avant)</param>
        /// <param name="listIds">Liste des ids des QCMs</param>
        /// <returns>Texte transformé</returns>
        public static string ExportLatex(string nameOfDocument, string textLatex, List<int> listIds)
        {
            //https://stackoverflow.com/questions/8928601/how-can-i-split-a-string-with-a-string-delimiter  
            string[] str = textLatex.Split(new string[] { MARQUE_LOOP_QUESTION, MARQUE_LOOP_BAD_ANSWER, MARQUE_LOOP_GOOD_ANSWER }, StringSplitOptions.None);
            if (str.Length == 7)
            {
                //https://msdn.microsoft.com/en-us/library/system.environment.username%28v=vs.110%29.aspx
                string stringLatex = str[0].Replace(MARQUE_AUTHOR, ValidateLatexString(Environment.UserName)).Replace(MARQUE_TITLE, ValidateLatexString(nameOfDocument));
                foreach (int idQCM in listIds)
                {
                    QCMController _controller = new QCMController(idQCM);
                    foreach (KeyValuePair<int, QuestionDatas> question in _controller.GetQuestions())
                    {
                        stringLatex += str[1].Replace(MARQUE_TEXT_QUESTION, ValidateLatexString(question.Value.Question));
                        foreach (KeyValuePair<int, ReponseDatas> reponse in question.Value.DictReponseModele)
                        {
                            if (!reponse.Value.BonneReponse)
                                stringLatex += str[2].Replace(MARQUE_TEXT_BAD_ANSWER, ValidateLatexString(reponse.Value.Reponse));
                            else
                                stringLatex += str[4].Replace(MARQUE_TEXT_GOOD_ANSWER, ValidateLatexString(reponse.Value.Reponse));
                        }
                        stringLatex += str[5];
                    }
                }

                stringLatex += str[6];
                return stringLatex;
            }
            return null;
        }

        /// <summary>
        /// Empêche le bug de formules mathématiques en Latex.
        /// </summary>
        /// <param name="text">Texte bugé</param>
        /// <returns>Texte débugé</returns>
        private static string ValidateLatexString(string text)
        {
            return text
                .Replace("\\", "\\textbackslash")
                .Replace("#", "\\#")
                .Replace("$", "\\$")
                .Replace("%", "\\%")
                .Replace("^", "\\^{}")
                .Replace("&", "\\&")
                .Replace("_", "\\_")
                .Replace("{", "\\{")
                .Replace("}", "\\}")
                .Replace("~", "\\~{}");
        }

        /// <summary>
        /// Ouvre une nouvelle FrmInformation
        /// </summary>
        public void OpenFormContents()
        {
            FrmInformations _frm = new FrmInformations(this);
            _frm.Show();
        }

        /// <summary>
        /// Ouvre une nouvelle FrmInformation avec l'id donnée
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        public static void OpenFormContents(int idQCM)
        {
            if (_dictQCMOpened == null)
                _dictQCMOpened = new Dictionary<int, FrmInformations>();

            if (!_dictQCMOpened.ContainsKey(idQCM))
            {
                FrmInformations frmInformations = new FrmInformations(idQCM);
                frmInformations.FormClosing += FrmInformations_FormClosing;
                frmInformations.Show();
                _dictQCMOpened.Add(idQCM, frmInformations);
            }
            else
            {
                FrmInformations frmInformations;
                _dictQCMOpened.TryGetValue(idQCM, out frmInformations);
                frmInformations.BringToFront();
            }
        }

        /// <summary>
        /// S'effectue lors de la fermeture de la Form "FrmInformations"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private static void FrmInformations_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (sender is FrmInformations)
                if (_dictQCMOpened.ContainsKey((sender as FrmInformations).IdQCM))
                {
                    _dictQCMOpened.Remove((sender as FrmInformations).IdQCM);
                }
        }

        /// <summary>
        /// Sauvegarde le modèle dans la base
        /// </summary>
        public void Save()
        {
            _qcmModele.Save();
        }
    }
}
