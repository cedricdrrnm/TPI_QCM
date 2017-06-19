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
    public partial class FrmListQCMMain : Form
    {
        Form _frmNext;

        /// <summary>
        /// Constructeur
        /// </summary>
        public FrmListQCMMain()
        {
            InitializeComponent();
            RefreshDataGridView();
        }
        
        /// <summary>
        /// S'effectue lorsque la Form prend le focus
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void FrmListQCMMain_Activated(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnAfficherQCM"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnAfficherQCM_Click(object sender, EventArgs e)
        {
            if (dgvQCM.SelectedRows.Count > 0)
                for (int i = 0; i < dgvQCM.SelectedRows.Count; i++)
                {
                    if (dgvQCM.SelectedRows[i].Cells[0].Value != null)
                    {
                        QCMController.OpenFormContents(Convert.ToInt32(dgvQCM.SelectedRows[i].Cells[0].Value)); 
                    }
                }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnCreerQCM"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnCreerQCM_Click(object sender, EventArgs e)
        {
            _frmNext = new FrmCreateQCM();
            _frmNext.ShowDialog();
        }

        /// <summary>
        /// Permet de raffraichir la DataGridView "dgvQCM"
        /// </summary>
        public void RefreshDataGridView()
        {
            dgvQCM.Rows.Clear();
            foreach (KeyValuePair<int, string> item in QCMController.GetListQCM())
            {
                dgvQCM.Rows.Add(new string[] { item.Key.ToString(), item.Value });
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnExport"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            QCMController.Export();
        }
    }
}
