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
    public partial class FrmCreateQuestionReponse : Form
    {
        private const string TEXT_CREATE = "Créer";
        private const string TEXT_UPDATE = "Modifier";
        private const string TEXT_QCM = "Titre du QCM: ";
        private TextBox[] _tbxReponseTab;
        private RadioButton[] _rbReponseTab;
        private Dictionary<string, Dictionary<string, bool>> _returnDatas;
        private QCMController _qcmController;

        public Dictionary<string, Dictionary<string, bool>> ReturnDatas
        {
            get
            {
                return _returnDatas;
            }

            set
            {
                _returnDatas = value;
            }
        }

        private TextBox[] TbxReponseTab
        {
            get
            {
                return _tbxReponseTab;
            }

            set
            {
                _tbxReponseTab = value;
            }
        }

        private RadioButton[] RbReponseTab
        {
            get
            {
                return _rbReponseTab;
            }

            set
            {
                _rbReponseTab = value;
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        public FrmCreateQuestionReponse(QCMController qcmController)
        {
            InitializeComponent();
            QcmController = qcmController;
            TbxReponseTab = new TextBox[] { tbxReponse1, tbxReponse2, tbxReponse3, tbxReponse4, tbxReponse5, tbxReponse6 };
            RbReponseTab = new RadioButton[] { rbBonneReponse1, rbBonneReponse2, rbBonneReponse3, rbBonneReponse4, rbBonneReponse5, rbBonneReponse6 };
            lblQCM.Text = TEXT_QCM + QcmController.GetTitreQCM();
            ReturnDatas = new Dictionary<string, Dictionary<string, bool>>();
        }

        /// <summary>
        /// S'effectue lors d'un clic sur le bouton "btnAction"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnAction_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> dictReponses = new Dictionary<string, bool>();
            for (int i = 0; i < Math.Min(TbxReponseTab.Length, RbReponseTab.Length); i++)
            {
                if (!dictReponses.ContainsKey(TbxReponseTab[i].Text) && TbxReponseTab[i].Text != "")
                    dictReponses.Add(TbxReponseTab[i].Text, RbReponseTab[i].Checked);
            }
            MessageBox.Show(QcmController.InsertQuestion(tbxQuestion.Text, dictReponses));
        }
    }
}
