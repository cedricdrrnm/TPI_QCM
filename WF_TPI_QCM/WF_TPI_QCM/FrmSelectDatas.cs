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
    public partial class FrmSelectDatas : Form
    {
        private int _returnValue;
        public FrmSelectDatas(Dictionary<int, string> datas)
        {
            InitializeComponent();
            ReturnValue = 0;
            foreach (KeyValuePair<int, string> item in datas)
            {
                tvDatas.Nodes.Add(item.Key.ToString(), item.Value);
            }
        }

        public int ReturnValue
        {
            get
            {
                return _returnValue;
            }

            set
            {
                _returnValue = value;
            }
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (tvDatas.SelectedNode != null)
            {
                ReturnValue = Convert.ToInt32(tvDatas.SelectedNode.Name);
                this.Close();
            }
        }
    }
}
