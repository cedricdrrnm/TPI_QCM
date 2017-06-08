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
    public partial class frmListQCMMain : Form
    {
        QCMController _qcmController;
        FrmInformations _frmInfo;
        public frmListQCMMain()
        {
            InitializeComponent();
            _qcmController = new QCMController();
            foreach (KeyValuePair<int,string> item in _qcmController.GetListQCM())
            {
                dgvQCM.Rows.Add(new string[] { item.Key.ToString(), item.Value });
            }
        }

        private void btnAfficherQCM_Click(object sender, EventArgs e)
        {
            _frmInfo = new FrmInformations(Convert.ToInt32(dgvQCM.SelectedRows[0].Cells[0].Value));
            _frmInfo.ShowDialog();
        }
    }
}
