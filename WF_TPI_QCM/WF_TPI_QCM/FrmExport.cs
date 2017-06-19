using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_TPI_QCM
{
    public partial class FrmExport : Form
    {
        private string _filenameModel;
        private List<int> _listSelectedIdQCMs;
        SaveFileDialog _sfd;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listSelectedIdQCMs">Liste des Ids de QCM à utiliser dans l'exportation</param>
        /// <param name="marques">Marques utilisées pour faire le Latex (donnée seulement pour les mettre dans la ListBox située à gauche de la vue)</param>
        /// <param name="filenameModel">Chemin d'accès du modèle utilisé pour le Latex</param>
        public FrmExport(List<int> listSelectedIdQCMs, string[] marques, string filenameModel) : this(listSelectedIdQCMs, marques, filenameModel, null)
        { }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="listSelectedIdQCMs">Liste des Ids de QCM à utiliser dans l'exportation</param>
        /// <param name="marques">Marques utilisées pour faire le Latex (donnée seulement pour les mettre dans la ListBox située à gauche de la vue)</param>
        /// <param name="filenameModel">Chemin d'accès des modèles</param>
        /// <param name="modelName">Nom du modèle utilisé pour l'exportation</param>
        public FrmExport(List<int> listSelectedIdQCMs, string[] marques, string filenameModel, string modelName)
        {
            InitializeComponent();
            _filenameModel = filenameModel;

            this._listSelectedIdQCMs = listSelectedIdQCMs;
            if (modelName != null)
                LoadModel(modelName);

            foreach (string item in QCMController.GetListModeles())
            {
                tsmiModel.DropDownItems.Add(item, null, ExportToolStripMenuItem_Click);
            }

            lsbMarkers.Items.AddRange(marques);
        }

        /// <summary>
        /// Charge le modèle s'il existe et l'écrit dans la propriété Text de la TextBox.
        /// </summary>
        /// <param name="modelName"></param>
        private void LoadModel(string modelName)
        {
            //https://msdn.microsoft.com/en-us/library/system.environment.specialfolder%28v=vs.110%29.aspx
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + _filenameModel + "\\" + modelName))
            {
                if (!QCMController.GetListModeles().Contains(modelName))
                {
                    MessageBox.Show("Ce modèle n'existe pas !");
                    return;
                }
            }
            tbxContent.Text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + _filenameModel + "\\" + modelName);
        }

        /// <summary>
        /// Evenement effectué lors d'un clic sur le bouton "btnExport"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string stringLatex = QCMController.ExportLatex(tbxNameOfDocument.Text, tbxContent.Text, _listSelectedIdQCMs);
            if (stringLatex != null)
            {
                _sfd = new SaveFileDialog();
                _sfd.Filter = "Format texte (*.txt) | *.txt";
                if (_sfd.ShowDialog() == DialogResult.OK)
                {
                    if (_sfd.FileName.Split('.').Last() != "txt")
                        _sfd.FileName += ".txt";
                    File.WriteAllText(_sfd.FileName, stringLatex);
                }
            }
            else
            {
                MessageBox.Show("Le latex est incorrecte, merci de prendre exemple sur le Latex déjà créé !");
            }
        }

        /// <summary>
        /// Evenement effectué lors d'un clic sur le ToolStripMenuItem "ExportToolStripMenuItem"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                LoadModel((sender as ToolStripMenuItem).Text);
            }
        }

        /// <summary>
        /// Evenement effectué lors d'un clic sur un des items dans la ListBox "lsbMarkers".
        /// Elle sert à insérer un marqueur dans la TextBox.
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Event</param>
        private void lsbMarkers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsbMarkers.SelectedItem != null)
            {
                tbxContent.Text = tbxContent.Text.Remove(tbxContent.SelectionStart, tbxContent.SelectionLength);
                //https://stackoverflow.com/questions/526540/how-do-i-find-the-position-of-a-cursor-in-a-text-box-c-sharp
                int selectedIndex = tbxContent.SelectionStart;
                tbxContent.Text = tbxContent.Text.Insert(selectedIndex, lsbMarkers.SelectedItem.ToString());
                tbxContent.SelectionStart = selectedIndex + lsbMarkers.SelectedItem.ToString().Length; //Replace le curseur après l'insertion (pas à 0)
            }
        }
    }
}
