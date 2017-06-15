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
        public FrmListQCMMain()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void FrmListQCMMain_Activated(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

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

        private void btnCreerQCM_Click(object sender, EventArgs e)
        {
            _frmNext = new FrmCreateQCM();
            _frmNext.ShowDialog();
        }

        public void RefreshDataGridView()
        {
            dgvQCM.Rows.Clear();
            foreach (KeyValuePair<int, string> item in QCMController.GetListQCM())
            {
                dgvQCM.Rows.Add(new string[] { item.Key.ToString(), item.Value });
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _frmNext = new FrmExportSelect(QCMController.GetListModeles());
            _frmNext.ShowDialog();
        }
    }
}
