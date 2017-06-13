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
            this.idQCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textQCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAfficherQCM = new System.Windows.Forms.Button();
            this.btnCreerQCM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQCM
            // 
            this.dgvQCM.AllowUserToOrderColumns = true;
            this.dgvQCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQCM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idQCM,
            this.textQCM});
            this.dgvQCM.Location = new System.Drawing.Point(12, 12);
            this.dgvQCM.Name = "dgvQCM";
            this.dgvQCM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQCM.Size = new System.Drawing.Size(551, 418);
            this.dgvQCM.TabIndex = 0;
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
            // btnAfficherQCM
            // 
            this.btnAfficherQCM.Location = new System.Drawing.Point(12, 436);
            this.btnAfficherQCM.Name = "btnAfficherQCM";
            this.btnAfficherQCM.Size = new System.Drawing.Size(551, 23);
            this.btnAfficherQCM.TabIndex = 1;
            this.btnAfficherQCM.Text = "Afficher ce QCM";
            this.btnAfficherQCM.UseVisualStyleBackColor = true;
            this.btnAfficherQCM.Click += new System.EventHandler(this.btnAfficherQCM_Click);
            // 
            // btnCreerQCM
            // 
            this.btnCreerQCM.Location = new System.Drawing.Point(13, 465);
            this.btnCreerQCM.Name = "btnCreerQCM";
            this.btnCreerQCM.Size = new System.Drawing.Size(551, 23);
            this.btnCreerQCM.TabIndex = 2;
            this.btnCreerQCM.Text = "Créer un QCM";
            this.btnCreerQCM.UseVisualStyleBackColor = true;
            this.btnCreerQCM.Click += new System.EventHandler(this.btnCreerQCM_Click);
            // 
            // frmListQCMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 496);
            this.Controls.Add(this.btnCreerQCM);
            this.Controls.Add(this.btnAfficherQCM);
            this.Controls.Add(this.dgvQCM);
            this.Name = "frmListQCMMain";
            this.Text = "Liste QCM";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQCM;
        private System.Windows.Forms.Button btnAfficherQCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn idQCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn textQCM;
        private System.Windows.Forms.Button btnCreerQCM;
    }
}