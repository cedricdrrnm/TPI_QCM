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
    public partial class FrmChoixReponseJuste : Form
    {
        private int _returnId;

        /// <summary>
        /// Id de la réponse juste sélectionné avant de quitter la Form.
        /// </summary>
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="reponses">Toutes les réponses</param>
        public FrmChoixReponseJuste(Dictionary<int, string> reponses)
        {
            InitializeComponent();
            foreach (KeyValuePair<int, string> item in reponses)
            {
                cmbReponseJuste.Items.Add(item.Key + ": " + item.Value);
            }
            cmbReponseJuste.SelectedIndex = 0;
        }

        /// <summary>
        /// Evenement lors d'un clic sur le bouton "btnValider"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cmbReponseJuste.SelectedItem != null)
                ReturnId = Convert.ToInt32(cmbReponseJuste.SelectedItem.ToString().Split(':').First());
            this.Close();
        }
    }
}
