namespace WF_TPI_QCM
{
    partial class FrmListQCMMain
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreerQCM = new System.Windows.Forms.Button();
            this.textQCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idQCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQCM = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAfficherQCM = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCM)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnAfficherQCM, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCreerQCM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvQCM, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 523);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnCreerQCM
            // 
            this.btnCreerQCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreerQCM.Location = new System.Drawing.Point(3, 406);
            this.btnCreerQCM.Name = "btnCreerQCM";
            this.btnCreerQCM.Size = new System.Drawing.Size(570, 34);
            this.btnCreerQCM.TabIndex = 4;
            this.btnCreerQCM.Text = "Créer un QCM";
            this.btnCreerQCM.UseVisualStyleBackColor = true;
            this.btnCreerQCM.Click += new System.EventHandler(this.btnCreerQCM_Click);
            // 
            // textQCM
            // 
            this.textQCM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textQCM.HeaderText = "Texte du QCM";
            this.textQCM.Name = "textQCM";
            this.textQCM.ReadOnly = true;
            // 
            // idQCM
            // 
            this.idQCM.HeaderText = "Id du QCM";
            this.idQCM.Name = "idQCM";
            this.idQCM.ReadOnly = true;
            this.idQCM.Width = 121;
            // 
            // dgvQCM
            // 
            this.dgvQCM.AllowUserToAddRows = false;
            this.dgvQCM.AllowUserToDeleteRows = false;
            this.dgvQCM.AllowUserToOrderColumns = true;
            this.dgvQCM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQCM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idQCM,
            this.textQCM});
            this.dgvQCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQCM.Location = new System.Drawing.Point(3, 3);
            this.dgvQCM.Name = "dgvQCM";
            this.dgvQCM.ReadOnly = true;
            this.dgvQCM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQCM.Size = new System.Drawing.Size(570, 397);
            this.dgvQCM.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(3, 486);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(570, 34);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Exportation";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnAfficherQCM
            // 
            this.btnAfficherQCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAfficherQCM.Location = new System.Drawing.Point(3, 446);
            this.btnAfficherQCM.Name = "btnAfficherQCM";
            this.btnAfficherQCM.Size = new System.Drawing.Size(570, 34);
            this.btnAfficherQCM.TabIndex = 7;
            this.btnAfficherQCM.Text = "Afficher ce QCM";
            this.btnAfficherQCM.UseVisualStyleBackColor = true;
            this.btnAfficherQCM.Click += new System.EventHandler(this.btnAfficherQCM_Click);
            // 
            // FrmListQCMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 523);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmListQCMMain";
            this.Text = "Liste QCM";
            this.Activated += new System.EventHandler(this.FrmListQCMMain_Activated);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCreerQCM;
        private System.Windows.Forms.DataGridView dgvQCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn idQCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn textQCM;
        private System.Windows.Forms.Button btnAfficherQCM;
        private System.Windows.Forms.Button btnExport;
    }
}