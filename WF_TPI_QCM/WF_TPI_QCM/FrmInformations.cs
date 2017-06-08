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
    public partial class FrmInformations : Form
    {
        private QCMController _qcmController;
        public FrmInformations(int idQCM)
        {
            InitializeComponent();
            _qcmController = new QCMController();
            if (!_qcmController.GetQCMById(idQCM))
            {
                MessageBox.Show("Ce QCM n'existe pas !");
                this.Close();
            }
            foreach (QuestionModele item in _qcmController.GetQuestionsByIdQCM(idQCM))
            {
                dgvQuestion.Rows.Add(new string[] { item.IdQuestion.ToString(), item.Question });
            }
            this.Text = "QCM: " + _qcmController.GetTitreQCMByIdQCM(idQCM);
        }

        private void dgvQuestion_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}
