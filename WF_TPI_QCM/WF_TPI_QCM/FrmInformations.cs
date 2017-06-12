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
            _qcmController = new QCMController(idQCM);
            InitializeComponent();
            RefreshQuestion();

            this.Text = "QCM: " + _qcmController.GetTitreQCM();
            tbxNomQCM.Text = _qcmController.GetTitreQCM();
            nudLevel.Value = _qcmController.GetLevelByIdQCM();

            foreach (KeyValuePair<int, string> item in _qcmController.GetMotsCles())
            {
                dgvMotCle.Rows.Add(new string[] { item.Key.ToString(), item.Value });
            }
        }

        private void RefreshQuestion()
        {
            dgvQuestion.Rows.Clear();
            foreach (KeyValuePair<int, QuestionDatas> item in _qcmController.GetQuestions())
            {
                dgvQuestion.Rows.Add(new string[] { item.Key.ToString(), item.Value.Question });
            }
        }

        private void dgvQuestion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestion.SelectedRows.Count > 0)
            {
                dgvReponse.Rows.Clear();
                foreach (KeyValuePair<int, ReponseDatas> item in _qcmController.GetReponsesByIdQuestion(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value)))
                {
                    dgvReponse.Rows.Add(new string[] { item.Key.ToString(), item.Value.Reponse, item.Value.BonneReponse.ToString() });
                }
            }
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _qcmController.CreateQuestionReponse();
            RefreshQuestion();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_qcmController.UpdateQCM(tbxNomQCM.Text, Convert.ToInt32(nudLevel.Value)));
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce QCM ?", "Suppression de QCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(_qcmController.DeleteQCM());
                this.Close();
            }
        }

        private void dgvQuestion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue != null)
                if (e.FormattedValue.ToString().Trim() != "")
                    if (e.FormattedValue != dgvQuestion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                        if (_qcmController.UpdateQuestionByIdQuestion(Convert.ToInt32(dgvQuestion.Rows[e.RowIndex].Cells[0].Value), e.FormattedValue.ToString()))
                            MessageBox.Show("Question modifiée avec succès !");
                        else
                        {
                            MessageBox.Show("Impossible de modifier la question !");
                            e.Cancel = true;
                        }
        }

        private void dgvQuestion_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_qcmController.DeleteQuestionByIdQuestion(Convert.ToInt32(dgvQuestion.Rows[e.Row.Index].Cells[0].Value)))
                MessageBox.Show("Question supprimée avec succès !");
            else
            {
                MessageBox.Show("Impossible de supprimer la question !");
                e.Cancel = true;
            }
        }

        private void dgvReponse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                _qcmController.ChooseCorrectAnswer(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value));
            }
        }

        private void dgvReponse_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            if (_qcmController.DeleteReponseByIdReponse(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value), Convert.ToInt32(dgvReponse.Rows[e.Row.Index].Cells[0].Value)))
                MessageBox.Show("Réponse supprimée avec succès !");
            else
            {
                MessageBox.Show("Impossible de supprimer la réponse !");
                e.Cancel = true;
            }

            if (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) /*AddedRow*/ == 4 + 1 /*Ligne entrain de se faire supprimer*/)
                dgvReponse.AllowUserToDeleteRows = false;
            dgvReponse.AllowUserToAddRows = true;
        }

        private void dgvReponse_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvReponse.AllowUserToDeleteRows = true;
            if (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) == 6)
                dgvReponse.AllowUserToAddRows = false;
        }

        private void dgvReponse_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgvReponse_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvReponse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                if (dgvReponse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    if (dgvReponse.Rows[e.RowIndex].Cells[1].Value != null)
                    {
                        int idQuestion = Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value);
                        string reponseText = dgvReponse.Rows[e.RowIndex].Cells[1].Value.ToString();
                        bool bonneReponse = Convert.ToBoolean(dgvReponse.Rows[e.RowIndex].Cells[2].Value);
                        if (dgvReponse.Rows[e.RowIndex].Cells[0].Value == null) //Create
                        {
                            if (_qcmController.InsertReponse(idQuestion, reponseText, bonneReponse) != null)
                            {
                                MessageBox.Show("Réponse créée avec succès !");
                                dgvReponse.Rows[e.RowIndex].Cells[0].Value = _qcmController.GetReponsesByIdQuestion(idQuestion).Last().Key;
                            }
                            else
                            {
                                MessageBox.Show("Impossible de créer la réponse !");
                                e.Cancel = true;
                            }

                        }
                        else
                        {
                            if (reponseText.Trim() != "")
                            {
                                KeyValuePair<bool, string> retour = _qcmController.UpdateReponseByIdQuestionAndIdReponse(idQuestion, Convert.ToInt32(dgvReponse.Rows[e.RowIndex].Cells[0].Value), new ReponseDatas(reponseText, bonneReponse));
                                if (retour.Value != null)
                                {
                                    MessageBox.Show(retour.Value);
                                    if (retour.Key)
                                        e.Cancel = true;
                                }
                            }
                        }
                    }
        }
    }
}
