using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_TPI_QCM
{
    public partial class FrmCreateEditQuestionReponse : Form
    {
        const string TEXT_CREATE = "Créer";
        const string TEXT_UPDATE = "Modifier";
        const string TEXT_QCM = "Titre du QCM: ";
        int _idQCM;
        int _idQuestion;
        QCMController _qcmController;
        TextBox[] _tbxReponseTab;
        RadioButton[] _rbReponseTab;

        /// <summary>
        /// Constructeur (Create)
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        public FrmCreateEditQuestionReponse(int idQCM) : this(idQCM, 0)
        { }

        /// <summary>
        /// Constructeur (Update)
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        /// <param name="idQuestion">Id de la question à modifier, "idQuestion = 0" s'il faut le créer</param>
        public FrmCreateEditQuestionReponse(int idQCM, int idQuestion)
        {
            InitializeComponent();
            _idQCM = idQCM;
            _idQuestion = idQuestion;
            _qcmController = new QCMController();
            _tbxReponseTab = new TextBox[] { tbxReponse1, tbxReponse2, tbxReponse3, tbxReponse4, tbxReponse5, tbxReponse6 };
            _rbReponseTab = new RadioButton[] { rbBonneReponse1, rbBonneReponse2, rbBonneReponse3, rbBonneReponse4, rbBonneReponse5, rbBonneReponse6 };
            lblQCM.Text = TEXT_QCM + _qcmController.GetTitreQCMByIdQCM(idQCM);
            Text = ((idQuestion == 0) ? TEXT_CREATE : TEXT_UPDATE) + " une question";
            btnAction.Text = (idQuestion == 0) ? TEXT_CREATE : TEXT_UPDATE;
            if (idQuestion != 0)
            {
                tbxQuestion.Text = _qcmController.GetTextQuestionByIdQuestion(idQuestion);
                int index = 0;
                foreach (KeyValuePair<string, bool> item in _qcmController.GetReponsesByIdQuestion(idQuestion))
                {
                    if (index < _tbxReponseTab.Length)
                    {
                        _tbxReponseTab[index].Text = item.Key;
                    }

                    if (index < _rbReponseTab.Length)
                    {
                        _rbReponseTab[index].Checked = item.Value;
                    }
                    index++;
                }
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnAction"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnAction_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> dictReponses = new Dictionary<string, bool>();
            for (int i = 0; i < Math.Min(_tbxReponseTab.Length, _rbReponseTab.Length); i++)
            {
                if (!dictReponses.ContainsKey(_tbxReponseTab[i].Text) && _tbxReponseTab[i].Text != "")
                    dictReponses.Add(_tbxReponseTab[i].Text, _rbReponseTab[i].Checked);
            }
            if (_idQuestion == 0)
            {
                string error = _qcmController.InsertQuestion(_idQCM, tbxQuestion.Text, dictReponses);
                if (error == "")
                    MessageBox.Show("Création de la question avec succès !");
                else
                    MessageBox.Show("[Question] Erreur: " + error);
            }
            else
            {
                string error = _qcmController.UpdateQuestionByIdQuestion(_idQCM, _idQuestion, tbxQuestion.Text, dictReponses);
                if (error == "")
                    MessageBox.Show("Modification de la question avec succès !");
                else
                    MessageBox.Show("[Question] Erreur: " + error);

            }
        }
    }
}
