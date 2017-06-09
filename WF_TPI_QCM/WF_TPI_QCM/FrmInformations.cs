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
        private FrmCreateQuestionReponse _frmCreateQuestionReponse;
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
            RefreshQuestion();

            this.Text = "QCM: " + _qcmController.GetTitreQCMByIdQCM(idQCM);

            foreach (KeyValuePair<int, string> item in _qcmController.GetMotsClesByIdQCM(idQCM))
            {
                dgvMotCle.Rows.Add(new string[] { item.Key.ToString(), item.Value });
            }
        }

        private void RefreshQuestion()
        {
            dgvQuestion.Rows.Clear();
            foreach (KeyValuePair<int, QuestionModele> item in _qcmController.GetQuestionsByIdQCM(_qcmController.GetIdQCM()))
            {
                dgvQuestion.Rows.Add(new string[] { item.Key.ToString(), item.Value.Question });
            }
        }

        private void dgvQuestion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestion.SelectedRows.Count > 0)
            {
                dgvReponse.Rows.Clear();
                foreach (KeyValuePair<int, ReponseModele> item in _qcmController.GetReponsesByIdQuestion(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value)))
                {
                    dgvReponse.Rows.Add(new string[] { item.Key.ToString(), item.Value.Reponse, item.Value.BonneReponse.ToString() });
                }
            }
        }

        private void dgvReponse_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

            }
            else if (e.ColumnIndex == 1)
            {

            }
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmCreateQuestionReponse = new FrmCreateQuestionReponse();
            _frmCreateQuestionReponse.ShowDialog();
            RefreshQuestion();
        }

        private void dgvReponse_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReponse.Rows[e.RowIndex].Cells[1].Value != null)
            {
                if (dgvReponse.Rows[e.RowIndex].Cells[0].Value == null) //Insert
                {
                    MessageBox.Show(_qcmController.InsertReponse(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value), dgvReponse.SelectedRows[0].Cells[1].Value.ToString(), Convert.ToBoolean(dgvReponse.SelectedRows[0].Cells[2].Value)));
                    dgvReponse.Rows[e.RowIndex].Cells[0].Value = _qcmController.GetNextIdReponse() - 1;
                    CheckAllows();
                }
                else
                {
                    if (dgvReponse.SelectedRows.Count > 0)
                    {
                        string textRetour = _qcmController.UpdateReponseByIdQuestionAndIdReponse(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value), Convert.ToInt32(dgvReponse.SelectedRows[0].Cells[0].Value), new ReponseModele(dgvReponse.SelectedRows[0].Cells[1].Value.ToString(), Convert.ToBoolean(dgvReponse.SelectedRows[0].Cells[2].Value)));
                        if (textRetour != "")
                        {
                            MessageBox.Show(textRetour);
                        }
                    }
                }
            }
        }

        private void CheckAllows()
        {
            dgvReponse.AllowUserToAddRows = (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) < 6) ? true : false;
            dgvReponse.AllowUserToDeleteRows = (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) > 4) ? true : false;
        }

        private void dgvReponse_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvReponse.Rows[e.RowIndex].Cells[1].Value == null && e.RowIndex != dgvReponse.Rows.Count - 1)
            {
                MessageBox.Show("Vous devez insérer un texte");
                e.Cancel = true;
            }
        }

        private void dgvReponse_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            _qcmController.DeleteReponseByIdReponse(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value), Convert.ToInt32(e.Row.Cells[0].Value));
            dgvReponse.AllowUserToAddRows = true;
            CheckAllows();
        }

        private void dgvReponse_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvReponse.AllowUserToDeleteRows = true;
        }
    }
}
