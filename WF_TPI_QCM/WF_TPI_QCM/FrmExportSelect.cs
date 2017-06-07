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
        private QCMController _controller;
        private FrmExport _frmExport;

        public FrmExportSelect(List<string> listModels)
        {
            InitializeComponent();
            _controller = new QCMController();
            _listModel = listModels;

            foreach (string item in listModels)
            {
                lsbModeles.Items.Add(item);
            }

            foreach (KeyValuePair<int, string> item in _controller.GetQCM())
            {
                tvQCM.Nodes.Add(item.Key.ToString(), item.Value);
            }
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            List<int> ListSelectedIdQCMs = new List<int>();
            foreach (TreeNode item in tvQCM.Nodes)
            {
                if (item.Checked)
                    ListSelectedIdQCMs.Add(Convert.ToInt32(item.Name));
            }

            if (lsbModeles.SelectedItem != null)
                _frmExport = new FrmExport(ListSelectedIdQCMs, lsbModeles.SelectedItem.ToString());
            else
                _frmExport = new FrmExport(ListSelectedIdQCMs);
            _frmExport.ShowDialog();
        }
    }
}
