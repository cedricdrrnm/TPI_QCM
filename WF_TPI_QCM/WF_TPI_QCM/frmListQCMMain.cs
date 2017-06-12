﻿using System;
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
    public partial class frmListQCMMain : Form
    {
        Form _frmNext;
        public frmListQCMMain()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void btnAfficherQCM_Click(object sender, EventArgs e)
        {
            if (dgvQCM.SelectedRows.Count > 0)
                for (int i = 0; i < dgvQCM.SelectedRows.Count; i++)
                {
                    if (dgvQCM.SelectedRows[i].Cells[0].Value != null)
                    {
                        QCMController.OpenFormContents(Convert.ToInt32(dgvQCM.SelectedRows[i].Cells[0].Value)); 
                    }
                }
        }

        private void btnCreerQCM_Click(object sender, EventArgs e)
        {
            _frmNext = new FrmCreateEditQCM();
            _frmNext.ShowDialog();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dgvQCM.Rows.Clear();
            foreach (KeyValuePair<int, string> item in QCMController.GetListQCM())
            {
                dgvQCM.Rows.Add(new string[] { item.Key.ToString(), item.Value });
            }
        }

        private void btnModifierQCM_Click(object sender, EventArgs e)
        {
            _frmNext = new FrmCreateEditQCM(Convert.ToInt32(dgvQCM.SelectedRows[0].Cells[0].Value));
            _frmNext.ShowDialog();
            RefreshDataGridView();
        }

        private void btnSupprimerQCM_Click(object sender, EventArgs e)
        {

            RefreshDataGridView();
        }
    }
}
