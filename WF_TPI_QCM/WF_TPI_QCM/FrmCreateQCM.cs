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
    public partial class FrmCreateQCM : Form
    {
        QCMController _qcmController;
        const string TEXT_CREATE = "Créer";
        const string TEXT_UPDATE = "Modifier";

        /// <summary>
        /// Constructeur (Create)
        /// </summary>
        public FrmCreateQCM()
        {
            InitializeComponent();
            _qcmController = new QCMController(0);
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnAction"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnAction_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_qcmController.InsertQCM(tbxTitreQCM.Text, Convert.ToInt32(nudLevelQCM.Value)));
        }
    }
}
