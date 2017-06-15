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
    public partial class frmChoixReponseJuste : Form
    {
        private int _returnId;

        public int ReturnId
        {
            get
            {
                return _returnId;
            }

            set
            {
                _returnId = value;
            }
        }

        public frmChoixReponseJuste(Dictionary<int, string> reponses)
        {
            InitializeComponent();
            foreach (KeyValuePair<int, string> item in reponses)
            {
                cmbReponseJuste.Items.Add(item.Key + ": " + item.Value);
            }
            cmbReponseJuste.SelectedIndex = 0;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cmbReponseJuste.SelectedItem != null)
                ReturnId = Convert.ToInt32(cmbReponseJuste.SelectedItem.ToString().Split(':').First());
            this.Close();
        }
    }
}
