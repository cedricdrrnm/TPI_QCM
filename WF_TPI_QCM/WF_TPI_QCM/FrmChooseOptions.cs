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
    public partial class FrmChooseOptions : Form
    {
        QCMController _qcmController;
        FrmSelectDatas _frmSelectDatas;
        Modes _mode;
        Form _nextForm;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="mode">Types de choix (Création, Edition, Suppression)</param>
        public FrmChooseOptions(Modes mode)
        {
            InitializeComponent();
            _mode = mode;
            _qcmController = new QCMController();
        }


        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnQCM"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnQCM_Click(object sender, EventArgs e)
        {
            int idQCM;
            switch (_mode)
            {
                case Modes.Create:
                    _nextForm = new FrmCreateEditQCM();
                    _nextForm.ShowDialog();
                    break;
                case Modes.Update:
                    idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                    {
                        _nextForm = new FrmCreateEditQCM(idQCM);
                        _nextForm.ShowDialog();
                    }
                    break;
                case Modes.Delete:
                    /*idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                        if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce QCM ?", "Suppression d'un QCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string error = _qcmController.DeleteQCMByIdQCM(idQCM);
                            if (error == "")
                                MessageBox.Show("Suppression du QCM avec succès !");
                            else
                                MessageBox.Show("[QCM] Erreur: " + error);
                        }
                    break;*/
                default:
                    new NotImplementedException();
                    break;
            }
        }


        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnQuestion"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            int idQCM;
            int idQuestion;
            switch (_mode)
            {
                case Modes.Create:
                    idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                    {
                        _nextForm = new FrmCreateEditQuestionReponse(idQCM);
                        _nextForm.ShowDialog();
                    }
                    break;
                case Modes.Update:
                    idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                    {
                        idQuestion = _qcmController.AskQuestion();
                        if (idQuestion != 0)
                        {
                            _nextForm = new FrmCreateEditQuestionReponse(idQCM, idQuestion);
                            _nextForm.ShowDialog();
                        }
                    }
                    break;
                case Modes.Delete:
                    idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                    {
                        idQuestion = _qcmController.AskQuestion();
                        if (idQuestion != 0)
                        {
                            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette question ?", "Suppression d'une question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string error = _qcmController.DeleteQuestionByIdQuestion(idQuestion);
                                if (error == "")
                                    MessageBox.Show("Suppression de la question avec succès !");
                                else
                                    MessageBox.Show("[Question] Erreur: " + error);
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnMotCle"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnMotCle_Click(object sender, EventArgs e)
        {
            int idQCM;
            int idMotCle;
            switch (_mode)
            {
                case Modes.Create:
                case Modes.Update:
                    idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                    {
                        _nextForm = new FrmCreateEditMotCle(idQCM, _mode);
                        _nextForm.ShowDialog();
                    }
                    break;
                case Modes.Delete:
                    idQCM = _qcmController.Ask(_qcmController.GetListQCM());
                    if (idQCM != 0)
                    {
                        idMotCle = _qcmController.Ask(_qcmController.GetMotsClesByIdQCM(idQCM));
                        if (idMotCle != 0)
                        {
                            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce mot-clé ?", "Suppression d'un mot-clé", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string error = _qcmController.DeleteMotCleByIdMotCle(idMotCle);
                                if (error == "")
                                    MessageBox.Show("Suppression du mot-clé avec succès !");
                                else
                                    MessageBox.Show("[Mot-Clé] Erreur: " + error);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
