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
    public partial class FrmSelectDatas : Form
    {
        private int _returnId;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="datas">Toutes les données</param>
        public FrmSelectDatas(Dictionary<int, string> datas)
        {
            InitializeComponent();
            ReturnId = 0;
            foreach (KeyValuePair<int, string> item in datas)
            {
                tvDatas.Nodes.Add(item.Key.ToString(), item.Value);
            }
        }

        /// <summary>
        /// Id contenu dans la Form (utilisé pour savoir la sélection)
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
        /// S'effectue lors d'un clic sur le bouton "btnChoisir"
        /// </summary>
        /// <param name="sender">Objet</param>
        /// <param name="e">Evenement</param>
        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (tvDatas.SelectedNode != null)
            {
                ReturnId = Convert.ToInt32(tvDatas.SelectedNode.Name);
                this.Close();
            }
        }
    }
}
