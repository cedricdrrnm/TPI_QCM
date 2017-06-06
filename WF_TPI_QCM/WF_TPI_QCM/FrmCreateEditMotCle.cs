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
    public partial class FrmCreateEditMotCle : Form
    {
        QCMController _qcmController;
        const string TEXT_CREATE = "Créer";
        const string TEXT_UPDATE = "Modifier";
        const string TEXT_LBL_QCM = "QCM: ";
        int _idQCM;
        Modes _mode;
        private TextBox[] _tbxMotCleTab;

        public FrmCreateEditMotCle(int idQCM)
        { }
        public FrmCreateEditMotCle(int idQCM, Modes mode)
        {
            InitializeComponent();
            _idQCM = idQCM;
            _mode = mode;

            _qcmController = new QCMController();
            _tbxMotCleTab = new TextBox[] { tbxMotCle1, tbxMotCle2, tbxMotCle3, tbxMotCle4 };
            Text = ((mode == Modes.Create) ? TEXT_CREATE : TEXT_UPDATE) + " des mots-clés";
            btnAction.Text = (mode == Modes.Create) ? TEXT_CREATE : TEXT_UPDATE;

            lblQCM.Text = TEXT_LBL_QCM + _qcmController.GetTitreQCMByIdQCM(idQCM);
            int index = 0;
            foreach (KeyValuePair<int, string> item in _qcmController.GetMotsClesByIdQCM(idQCM))
            {
                if (index < _tbxMotCleTab.Length)
                {
                    _tbxMotCleTab[index].Tag = item.Key;
                    _tbxMotCleTab[index].Text = item.Value;

                    if (mode == Modes.Create)
                        _tbxMotCleTab[index].Enabled = false;
                }
                index++;
            }
            if (mode == Modes.Update)
                for (int j = index; j < _tbxMotCleTab.Length; j++)
                {
                    _tbxMotCleTab[j].Enabled = false;
                }

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (_mode == Modes.Create)
            {
                List<string> listMotCles = new List<string>();
                foreach (var item in _tbxMotCleTab)
                {
                    if (item.Enabled && item.Text.Trim() != "")
                        listMotCles.Add(item.Text);
                }
                string error = _qcmController.InsertMotCle(_idQCM, listMotCles.ToArray());
                if (error == "")
                    MessageBox.Show("Création du QCM avec succès !");
                else
                    MessageBox.Show("[QCM] Erreur: " + error);
            }
            else
            {
                Dictionary<int, string> dictMotCles = new Dictionary<int, string>();
                foreach (var item in _tbxMotCleTab)
                {
                    if (item.Enabled)
                        if (item.Tag != null && item.Tag is int && item.Text.Trim() != "")
                            dictMotCles.Add(Convert.ToInt32(item.Tag), item.Text);
                }
                string error = _qcmController.UpdateMotCle(_idQCM, dictMotCles);
                if (error == "")
                    MessageBox.Show("Modification du QCM avec succès !");
                else
                    MessageBox.Show("[QCM] Erreur: " + error);

            }
        }
    }
}
