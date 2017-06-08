namespace WF_TPI_QCM
{
    partial class frmListQCMMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvQCM = new System.Windows.Forms.DataGridView();
            this.btnAfficherQCM = new System.Windows.Forms.Button();
            this.idQCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textQCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQCM
            // 
            this.dgvQCM.AllowUserToDeleteRows = false;
            this.dgvQCM.AllowUserToOrderColumns = true;
            this.dgvQCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQCM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idQCM,
            this.textQCM});
            this.dgvQCM.Location = new System.Drawing.Point(12, 12);
            this.dgvQCM.MultiSelect = false;
            this.dgvQCM.Name = "dgvQCM";
            this.dgvQCM.ReadOnly = true;
            this.dgvQCM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQCM.Size = new System.Drawing.Size(301, 418);
            this.dgvQCM.TabIndex = 0;
            // 
            // btnAfficherQCM
            // 
            this.btnAfficherQCM.Location = new System.Drawing.Point(12, 436);
            this.btnAfficherQCM.Name = "btnAfficherQCM";
            this.btnAfficherQCM.Size = new System.Drawing.Size(301, 23);
            this.btnAfficherQCM.TabIndex = 1;
            this.btnAfficherQCM.Text = "Afficher ce QCM";
            this.btnAfficherQCM.UseVisualStyleBackColor = true;
            this.btnAfficherQCM.Click += new System.EventHandler(this.btnAfficherQCM_Click);
            // 
            // idQCM
            // 
            this.idQCM.HeaderText = "Id du QCM";
            this.idQCM.Name = "idQCM";
            this.idQCM.ReadOnly = true;
            this.idQCM.Width = 121;
            // 
            // textQCM
            // 
            this.textQCM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textQCM.HeaderText = "Texte du QCM";
            this.textQCM.Name = "textQCM";
            this.textQCM.ReadOnly = true;
            // 
            // frmListQCMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 471);
            this.Controls.Add(this.btnAfficherQCM);
            this.Controls.Add(this.dgvQCM);
            this.Name = "frmListQCMMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQCM;
        private System.Windows.Forms.Button btnAfficherQCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn idQCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn textQCM;
    }
}