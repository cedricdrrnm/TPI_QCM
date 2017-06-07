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
    public partial class frmListMain : Form
    {
        const string TEXT_QUESTION = "Questions";
        const string TEXT_MOT_CLE = "Mot-Clé";
        const string TEXT_NIVEAU = "Niveau: ";
        const string TEXT_REPONSE = "Réponse";

        QCMController _qcmController;
        FrmChooseOptions _frmChooseOption;

        /// <summary>
        /// Constructeur
        /// </summary>
        public frmListMain()
        {
            InitializeComponent();
            _qcmController = new QCMController();
        }

        /// <summary>
        /// S'effectue lors du chargement de la form
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void frmListMain_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, string> item in _qcmController.GetQCM())
            {
                tvQCM.Nodes.Add(item.Key.ToString(), item.Value).Nodes.Add("");
            }
        }

        /// <summary>
        /// S'effectue avant l'élargissement du noeud
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void tvQCM_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level == 0) //https://msdn.microsoft.com/en-us/library/system.windows.forms.treenode.level%28v=vs.110%29.aspx
            {
                e.Node.Nodes.Clear();
                e.Node.Nodes.AddRange(
                    new TreeNode[] {
                        new TreeNode(TEXT_QUESTION, new TreeNode[] {new TreeNode("")}),
                        new TreeNode(TEXT_MOT_CLE, new TreeNode[] { new TreeNode("") }),
                        new TreeNode(TEXT_NIVEAU + _qcmController.GetLevelByIdQCM(Convert.ToInt32(e.Node.Name)).ToString())
                    });
            }
            else if (e.Node.Level == 1)
            {
                if (e.Node.Text == TEXT_QUESTION)
                {
                    e.Node.Nodes.Clear();
                    foreach (KeyValuePair<int,string> item in _qcmController.GetQuestionsByIdQCM(Convert.ToInt32(e.Node.Parent.Name)))
                    {
                        e.Node.Nodes.Add(item.Key.ToString(), item.Value).Nodes.Add(TEXT_REPONSE).Nodes.Add("");
                    }
                }
                else if (e.Node.Text == TEXT_MOT_CLE)
                {
                    e.Node.Nodes.Clear();
                    foreach (KeyValuePair<int, string> item in _qcmController.GetMotsClesByIdQCM(Convert.ToInt32(e.Node.Parent.Name)))
                    {
                        e.Node.Nodes.Add(item.Key.ToString(), item.Value);
                    }
                }
            }
            else if (e.Node.Level == 3)
            {
                e.Node.Nodes.Clear();
                foreach (KeyValuePair<string, bool> item in _qcmController.GetReponsesByIdQuestion(Convert.ToInt32(e.Node.Parent.Name)))
                {
                    e.Node.Nodes.Add(item.Key.ToString()).ForeColor = ((item.Value) ? Color.Green : Color.Red);
                }
            }
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnCreate"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            _frmChooseOption = new FrmChooseOptions(Modes.Create);
            _frmChooseOption.ShowDialog();
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnModifier"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            _frmChooseOption = new FrmChooseOptions(Modes.Update);
            _frmChooseOption.ShowDialog();
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnSupprimer"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            _frmChooseOption = new FrmChooseOptions(Modes.Delete);
            _frmChooseOption.ShowDialog();
        }
    }
}
