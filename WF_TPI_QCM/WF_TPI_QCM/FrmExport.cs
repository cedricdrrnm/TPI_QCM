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
        private const string MARQUE_LOOP_QUESTION = "%loopQuestion%";
        private const string MARQUE_LOOP_BAD_ANSWER = "%loopBadAnswer%";
        private const string MARQUE_LOOP_GOOD_ANSWER = "%loopGoodAnswer%";
        private const string MARQUE_TEXT_QUESTION = "%textQuestion%";
        private const string MARQUE_TEXT_BAD_ANSWER = "%badAnswer%";
        private const string MARQUE_TEXT_GOOD_ANSWER = "%goodAnswer%";
        private const string MARQUE_AUTHOR = "%author%";
        private const string MARQUE_TITLE = "%title%";

        private const string FILENAME_ACCESS = ".TPI_QCM\\Models";
        private List<int> _listSelectedIdQCMs;
        QCMController _qcmController;
        SaveFileDialog _sfd;

        public FrmExport(List<int> listSelectedIdQCMs) : this(listSelectedIdQCMs, null)
        { }

        public FrmExport(List<int> listSelectedIdQCMs, string modelName)
        {
            InitializeComponent();

            this._listSelectedIdQCMs = listSelectedIdQCMs;
            _qcmController = new QCMController(0);
            if (modelName != null)
                LoadModel(modelName);

            foreach (string item in QCMController.GetListModeles())
            {
                tsmiModel.DropDownItems.Add(item, null, ExportToolStripMenuItem_Click);
            }

            lsbMarkers.Items.AddRange(new string[] { MARQUE_LOOP_QUESTION, MARQUE_LOOP_BAD_ANSWER, MARQUE_LOOP_GOOD_ANSWER, MARQUE_TEXT_QUESTION, MARQUE_TEXT_BAD_ANSWER, MARQUE_TEXT_GOOD_ANSWER });
        }

        private void LoadModel(string modelName)
        {
            //https://msdn.microsoft.com/en-us/library/system.environment.specialfolder%28v=vs.110%29.aspx
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS + "\\" + modelName))
            {
                if (!QCMController.GetListModeles().Contains(modelName))
                {
                    MessageBox.Show("Ce modèle n'existe pas !");
                    return;
                }
            }
            tbxContent.Text = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + FILENAME_ACCESS + "\\" + modelName);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/8928601/how-can-i-split-a-string-with-a-string-delimiter

            string[] str = tbxContent.Text.Split(new string[] { MARQUE_LOOP_QUESTION, MARQUE_LOOP_BAD_ANSWER, MARQUE_LOOP_GOOD_ANSWER }, StringSplitOptions.None);
            if (str.Length == 7)
            {
                //https://msdn.microsoft.com/en-us/library/system.environment.username%28v=vs.110%29.aspx
                string returnString = str[0].Replace(MARQUE_AUTHOR, Environment.UserName).Replace(MARQUE_TITLE, tbxNameOfDocument.Text);
                foreach (int idQCM in _listSelectedIdQCMs)
                {
                    foreach (KeyValuePair<int,QuestionDatas> question in _qcmController.GetQuestions())
                    {
                        returnString += str[1].Replace(MARQUE_TEXT_QUESTION, question.Value.Question);
                        foreach (KeyValuePair<int, ReponseDatas> reponse in _qcmController.GetReponsesByIdQuestion(question.Key))
                        {
                            if (!reponse.Value.BonneReponse)
                                returnString += str[2].Replace(MARQUE_TEXT_BAD_ANSWER, reponse.Value.Reponse);
                            else
                                returnString += str[4].Replace(MARQUE_TEXT_GOOD_ANSWER, reponse.Value.Reponse);
                        }
                        returnString += str[5];
                    }
                }

                returnString += str[6];
                _sfd = new SaveFileDialog();
                _sfd.Filter = "Format texte (*.txt) | *.txt";
                if (_sfd.ShowDialog() == DialogResult.OK)
                {
                    if (_sfd.FileName.Split('.').Last() != "txt")
                        _sfd.FileName += ".txt";
                    File.WriteAllText(_sfd.FileName, returnString);
                }
            }
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                LoadModel((sender as ToolStripMenuItem).Text);
            }
        }

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
