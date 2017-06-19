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
    public partial class FrmExportSelect : Form
    {
        private List<string> _listModel;
        private KeyValuePair<string, List<int>> _returnItem;

        public KeyValuePair<string, List<int>> ReturnItem
        {
            get
            {
                return _returnItem;
            }

            set
            {
                _returnItem = value;
            }
        }

        private List<string> ListModel
        {
            get
            {
                return _listModel;
            }

            set
            {
                _listModel = value;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listModels">Liste des modèles</param>
        public FrmExportSelect(List<string> listModels)
        {
            InitializeComponent();
            ListModel = listModels;

            foreach (string item in listModels)
            {
                lsbModeles.Items.Add(item);
            }

            foreach (KeyValuePair<int, string> item in QCMController.GetListQCM())
            {
                tvQCM.Nodes.Add(item.Key.ToString(), item.Value);
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnSuivant"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            List<int> ListSelectedIdQCMs = new List<int>();
            foreach (TreeNode item in tvQCM.Nodes)
            {
                if (item.Checked)
                    ListSelectedIdQCMs.Add(Convert.ToInt32(item.Name));
            }

            string model = null;
            if (lsbModeles.SelectedItem != null)
                model = lsbModeles.SelectedItem.ToString();

            if (ListSelectedIdQCMs.Count > 0)
            {
                ReturnItem = new KeyValuePair<string, List<int>>(model, ListSelectedIdQCMs);
                this.Close();
            }
            else
            {
                MessageBox.Show("Aucun QCM sélectionné");
            }

        }
    }
}
