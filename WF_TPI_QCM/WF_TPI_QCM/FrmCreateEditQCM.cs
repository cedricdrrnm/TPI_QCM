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
    public partial class FrmCreateEditQCM : Form
    {
        QCMController _qcmController;
        const string TEXT_CREATE = "Créer";
        const string TEXT_UPDATE = "Modifier";
        int _idQCM;

        public FrmCreateEditQCM() : this(0)
        { }

        public FrmCreateEditQCM(int idQCM)
        {
            InitializeComponent();
            _idQCM = idQCM;
            _qcmController = new QCMController();
            Text = ((idQCM == 0) ? TEXT_CREATE : TEXT_UPDATE) + " un QCM";
            btnAction.Text = (idQCM == 0) ? TEXT_CREATE : TEXT_UPDATE;
            if (idQCM != 0)
            {
                tbxTitreQCM.Text = _qcmController.GetTitreQCMByIdQCM(idQCM);
                nudLevelQCM.Value = _qcmController.GetLevelByIdQCM(idQCM);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (_idQCM == 0)
            {
                string error = _qcmController.InsertQCM(tbxTitreQCM.Text, Convert.ToInt32(nudLevelQCM.Value));
                if (error == "")
                    MessageBox.Show("Création du QCM avec succès !");
                else
                    MessageBox.Show("[QCM] Erreur: " + error);
            }
            else
            {
                string error = _qcmController.UpdateQCMByIdQCM(_idQCM, tbxTitreQCM.Text, Convert.ToInt32(nudLevelQCM.Value));
                if (error == "")
                    MessageBox.Show("Modification du QCM avec succès !");
                else
                    MessageBox.Show("[QCM] Erreur: " + error);

            }
        }
    }
}
