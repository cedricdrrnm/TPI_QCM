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
        public FrmChooseOptions(Modes mode)
        {
            InitializeComponent();
            _mode = mode;
            _qcmController = new QCMController();
        }

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
            }
        }

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
                            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette question ?", "Suppression d'un QCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string error = _qcmController.DeleteQuestionByIdQuestion(idQuestion);
                                if (error == "")
                                    MessageBox.Show("Suppression de la question avec succès !");
                                else
                                    MessageBox.Show("[QCM] Erreur: " + error);
                            }
                        }
                    }
                    break;
            }
        }

        private void btnMotCle_Click(object sender, EventArgs e)
        {
            _nextForm = new FrmCreateEditMotCle();
            _nextForm.ShowDialog();
        }

        public int Ask(Dictionary<int, string> datas)
        {
            _frmSelectDatas = new FrmSelectDatas(datas);
            _frmSelectDatas.ShowDialog();
            return _frmSelectDatas.ReturnValue;
        }
    }
}
