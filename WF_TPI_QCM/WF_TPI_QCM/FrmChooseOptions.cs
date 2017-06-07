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
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                    {
                        _nextForm = new FrmCreateEditQCM(idQCM);
                        _nextForm.ShowDialog();
                    }
                    break;
                case Modes.Delete:
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                        if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce QCM ?", "Suppression d'un QCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string error = _qcmController.DeleteQCMByIdQCM(idQCM);
                            if (error == "")
                                MessageBox.Show("Suppression du QCM avec succès !");
                            else
                                MessageBox.Show("[QCM] Erreur: " + error);
                        }
                    break;
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
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                    {
                        _nextForm = new FrmCreateEditQuestionReponse(idQCM);
                        _nextForm.ShowDialog();
                    }
                    break;
                case Modes.Update:
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                    {
                        idQuestion = Ask(_qcmController.GetQuestionsByIdQCM(idQCM));
                        if (idQuestion != 0)
                        {
                            _nextForm = new FrmCreateEditQuestionReponse(idQCM, idQuestion);
                            _nextForm.ShowDialog();
                        }
                    }
                    break;
                case Modes.Delete:
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                    {
                        idQuestion = Ask(_qcmController.GetQuestionsByIdQCM(idQCM));
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
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                    {
                        _nextForm = new FrmCreateEditMotCle(idQCM, _mode);
                        _nextForm.ShowDialog();
                    }
                    break;
                case Modes.Delete:
                    idQCM = Ask(_qcmController.GetQCM());
                    if (idQCM != 0)
                    {
                        idMotCle = Ask(_qcmController.GetMotsClesByIdQCM(idQCM));
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
