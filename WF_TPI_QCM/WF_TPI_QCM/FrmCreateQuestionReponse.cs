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
        const string TEXT_CREATE = "Créer";
        const string TEXT_UPDATE = "Modifier";
        const string TEXT_QCM = "Titre du QCM: ";
        TextBox[] _tbxReponseTab;
        RadioButton[] _rbReponseTab;
        private Dictionary<string,Dictionary<string,bool>> _returnDatas;

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
        QCMController _qcmController;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="idQCM">Id du QCM</param>
        public FrmCreateQuestionReponse(QCMController qcmController)
        {
            InitializeComponent();
            _qcmController = qcmController;
            _tbxReponseTab = new TextBox[] { tbxReponse1, tbxReponse2, tbxReponse3, tbxReponse4, tbxReponse5, tbxReponse6 };
            _rbReponseTab = new RadioButton[] { rbBonneReponse1, rbBonneReponse2, rbBonneReponse3, rbBonneReponse4, rbBonneReponse5, rbBonneReponse6 };
            lblQCM.Text = TEXT_QCM + _qcmController.GetTitreQCM();
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
            for (int i = 0; i < Math.Min(_tbxReponseTab.Length, _rbReponseTab.Length); i++)
            {
                if (!dictReponses.ContainsKey(_tbxReponseTab[i].Text) && _tbxReponseTab[i].Text != "")
                    dictReponses.Add(_tbxReponseTab[i].Text, _rbReponseTab[i].Checked);
            }
            MessageBox.Show(_qcmController.InsertQuestion(tbxQuestion.Text, dictReponses));
        }
    }
}
