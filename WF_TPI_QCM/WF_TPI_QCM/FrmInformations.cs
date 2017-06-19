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
        private int _idQCM;
        private bool _clear;

        public int IdQCM
        {
            get
            {
                return _idQCM;
            }

            set
            {
                _idQCM = value;
            }
        }

        private QCMController QcmController
        {
            get
            {
                return _qcmController;
            }

            set
            {
                _qcmController = value;
            }
        }

        private bool Clear
        {
            get
            {
                return _clear;
            }

            set
            {
                _clear = value;
            }
        }

        #region Reponse

        /// <summary>
        /// S'effectue lors d'un clic sur la dernière colonne de la DataGridView "dgvReponse"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvReponse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                QcmController.ChooseCorrectAnswer(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value));
                RefreshQuestion();
            }
        }

        /// <summary>
        /// S'effectue lors de la suppression d'une ligne par l'utilisateur
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvReponse_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            if (QcmController.DeleteReponseByIdReponse(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value), Convert.ToInt32(dgvReponse.Rows[e.Row.Index].Cells[0].Value)))
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

        /// <summary>
        /// S'effectue lors de l'ajout d'une ligne par l'utilisateur.
        /// Cette méthode de gérer les droits de l'utilisateur sur la suppression et l'ajout.
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvReponse_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dgvReponse.AllowUserToDeleteRows = true;
            if (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) == 6)
                dgvReponse.AllowUserToAddRows = false;
        }

        /// <summary>
        /// S'effectue après la validation d'une ligne de la DataGridView "dgvReponse".
        /// Cette méthode est une des plus importantes, car elle permet la création et l'édition du modèle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvReponse_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!Clear)
                if (dgvReponse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    if (dgvReponse.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                        if (dgvReponse.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            int idQuestion = Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value);
                            string reponseText = dgvReponse.Rows[e.RowIndex].Cells[1].Value.ToString();
                            bool bonneReponse = Convert.ToBoolean(dgvReponse.Rows[e.RowIndex].Cells[2].Value);
                            if (reponseText.Trim() != "")
                            {
                                if (dgvReponse.Rows[e.RowIndex].Cells[0].Value == null) //Create
                                {
                                    string returnText = QcmController.InsertReponse(idQuestion, reponseText, bonneReponse);
                                    if (returnText == "")
                                    {
                                        MessageBox.Show("Réponse créée avec succès !");
                                        dgvReponse.Rows[e.RowIndex].Cells[0].Value = QcmController.GetReponsesByIdQuestion(idQuestion).Last().Key;
                                    }
                                    else
                                    {
                                        MessageBox.Show(returnText);
                                        e.Cancel = true;
                                    }

                                }
                                else
                                {
                                    KeyValuePair<bool, string> retour = QcmController.UpdateReponseByIdQuestionAndIdReponse(idQuestion, Convert.ToInt32(dgvReponse.Rows[e.RowIndex].Cells[0].Value), new ReponseDatas(reponseText, bonneReponse, Modes.Update));
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

        #endregion

        #region Questions

        /// <summary>
        /// Raffraichit les questions
        /// </summary>
        private void RefreshQuestion()
        {
            dgvQuestion.Rows.Clear();
            foreach (KeyValuePair<int, QuestionDatas> item in QcmController.GetQuestions())
            {
                dgvQuestion.Rows.Add(new string[] { item.Key.ToString(), item.Value.Question });
            }
        }

        /// <summary>
        /// S'effectue lorsque la sélection de la question change.
        /// Affiche les réponses de la nouvelle question sélectionée.
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvQuestion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQuestion.SelectedRows.Count > 0)
            {
                Clear = true;
                dgvReponse.Rows.Clear();
                dgvReponse.AllowUserToAddRows = true;
                dgvReponse.AllowUserToDeleteRows = true;
                Clear = false;
                foreach (KeyValuePair<int, ReponseDatas> item in QcmController.GetReponsesByIdQuestion(Convert.ToInt32(dgvQuestion.SelectedRows[0].Cells[0].Value)))
                {
                    dgvReponse.Rows.Add(new string[] { item.Key.ToString(), item.Value.Reponse, item.Value.BonneReponse.ToString() });
                }

                if (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) /*AddedRow*/ == 4 /*Ligne qui se fait supprimer*/)
                    dgvReponse.AllowUserToDeleteRows = false;

                if (dgvReponse.Rows.Count - ((dgvReponse.AllowUserToAddRows) ? 1 : 0) /*AddedRow*/ == 6 /*Ligne qui se fait supprimer*/)
                    dgvReponse.AllowUserToAddRows = false;
            }
        }

        /// <summary>
        /// S'effectue après la validation d'une cellule de la DataGridView "dgvQuestion".
        /// Elle permet l'édition du modèle.
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvQuestion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue != null)
                if (e.FormattedValue.ToString().Trim() != "")
                    if (e.FormattedValue.ToString() != dgvQuestion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        if (QcmController.UpdateQuestionByIdQuestion(Convert.ToInt32(dgvQuestion.Rows[e.RowIndex].Cells[0].Value), e.FormattedValue.ToString()))
                            MessageBox.Show("Question modifiée avec succès !");
                        else
                        {
                            MessageBox.Show("Impossible de modifier la question !");
                            e.Cancel = true;
                        }
        }

        /// <summary>
        /// S'effectue après la suppression d'une ligne du DataGridView "dgvQuestion" par l'utilisateur.
        /// Elle permet la suppression de question du modèle.
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvQuestion_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (QcmController.DeleteQuestionByIdQuestion(Convert.ToInt32(dgvQuestion.Rows[e.Row.Index].Cells[0].Value)))
                MessageBox.Show("Question supprimée avec succès !");
            else
            {
                MessageBox.Show("Impossible de supprimer la question !");
                e.Cancel = true;
            }
        }

        #endregion

        #region MotsCles

        /// <summary>
        /// S'effectue après la validation d'une ligne de la DataGridView "dgvMotCle"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvMotCle_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvMotCle.Rows[e.RowIndex].Cells[1].Value != null)
                if (dgvMotCle.Rows[e.RowIndex].Cells[1].Value.ToString().Trim() != "")
                    if (dgvMotCle.Rows[e.RowIndex].Cells[0].Value == null)
                    {
                        MessageBox.Show(QcmController.InsertMotCle(dgvMotCle.Rows[e.RowIndex].Cells[1].Value.ToString()));
                        dgvMotCle.Rows[e.RowIndex].Cells[0].Value = QcmController.GetNextIdMotCle() - 1;
                    }
                    else
                    {
                        string returnString = QcmController.UpdateMotCle(Convert.ToInt32(dgvMotCle.Rows[e.RowIndex].Cells[0].Value), dgvMotCle.Rows[e.RowIndex].Cells[1].Value.ToString());
                        if (returnString != "")
                            MessageBox.Show(returnString);
                    }

            if (dgvMotCle.Rows.Count - ((dgvMotCle.AllowUserToAddRows) ? 1 : 0) == 4)
                dgvMotCle.AllowUserToAddRows = false;
        }

        /// <summary>
        /// S'effectue lors de la suppression d'une ligne de la DataGridView "dgvMotCle" par l'utilisateur.
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void dgvMotCle_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (QcmController.DeleteMotCleByIdMotCle(Convert.ToInt32(dgvMotCle.Rows[e.Row.Index].Cells[0].Value)))
            {
                MessageBox.Show("Mot-Clé supprimé avec succès !");
                dgvMotCle.AllowUserToAddRows = true;
            }
            else
            {
                MessageBox.Show("Echec lors de la suppression du mot-clé !");
            }
        }

        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="controller">Controlleur</param>
        public FrmInformations(QCMController controller)
        {
            QcmController = controller;
            IdQCM = QcmController.GetIdQCM();
            LoadInformations();
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="idQCM">Id du QCM affiché</param>
        public FrmInformations(int idQCM)
        {
            QcmController = new QCMController(idQCM);
            IdQCM = idQCM;
            LoadInformations();
        }

        /// <summary>
        /// Affiche les informations de la Form
        /// </summary>
        public void LoadInformations()
        {
            InitializeComponent();
            RefreshQuestion();

            this.Text = "QCM: " + QcmController.GetTitreQCM();
            tbxNomQCM.Text = QcmController.GetTitreQCM();
            nudLevel.Value = QcmController.GetLevelByIdQCM();
            Clear = false;

            foreach (KeyValuePair<int, MotsClesDatas> item in QcmController.GetMotsCles())
            {
                dgvMotCle.Rows.Add(new string[] { item.Key.ToString(), item.Value.TextMotCle });
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnModifier"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            MessageBox.Show(QcmController.UpdateQCM(tbxNomQCM.Text, Convert.ToInt32(nudLevel.Value)));
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le ToolStripMenuItem "supprimerToolStripMenuItem"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce QCM ?", "Suppression de QCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show(QcmController.DeleteQCM());
                this.Close();
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le ToolStripMenuItem "ajouterToolStripMenuItem"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QcmController.CreateQuestionReponse();
            RefreshQuestion();
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le ToolStripMenuItem "sauvegarderToolStripMenuItem"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QcmController.Save();
        }
        
        /// <summary>
        /// S'effectue lors de la fermeture de la Form
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void FrmInformations_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Voulez-vous sauvegarder avant de quitter ?", "Sauvegarder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sauvegarderToolStripMenuItem.PerformClick();
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le ToolStripMenuItem "helpToolStripMenuItem"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        public void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QCMController.Help();
        }
    }
}
