namespace WF_TPI_QCM
{
    partial class FrmInformations
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.sReponse = new System.Windows.Forms.Panel();
            this.idQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scQuestion = new System.Windows.Forms.SplitContainer();
            this.dgvReponse = new System.Windows.Forms.DataGridView();
            this.dgvMotCle = new System.Windows.Forms.DataGridView();
            this.idReponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textReponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMotCle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textMotCle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            this.sReponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scQuestion)).BeginInit();
            this.scQuestion.Panel1.SuspendLayout();
            this.scQuestion.Panel2.SuspendLayout();
            this.scQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReponse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotCle)).BeginInit();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Location = new System.Drawing.Point(12, 16);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.dgvQuestion);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.sReponse);
            this.scMain.Size = new System.Drawing.Size(831, 494);
            this.scMain.SplitterDistance = 277;
            this.scMain.TabIndex = 2;
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idQuestion,
            this.NomQuestion});
            this.dgvQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestion.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestion.MultiSelect = false;
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.Size = new System.Drawing.Size(277, 494);
            this.dgvQuestion.TabIndex = 1;
            this.dgvQuestion.SelectionChanged += new System.EventHandler(this.dgvQuestion_SelectionChanged);
            // 
            // sReponse
            // 
            this.sReponse.Controls.Add(this.scQuestion);
            this.sReponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sReponse.Location = new System.Drawing.Point(0, 0);
            this.sReponse.Name = "sReponse";
            this.sReponse.Size = new System.Drawing.Size(550, 494);
            this.sReponse.TabIndex = 2;
            // 
            // idQuestion
            // 
            this.idQuestion.HeaderText = "Id de la question";
            this.idQuestion.Name = "idQuestion";
            this.idQuestion.ReadOnly = true;
            // 
            // NomQuestion
            // 
            this.NomQuestion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomQuestion.HeaderText = "Nom de la question";
            this.NomQuestion.Name = "NomQuestion";
            // 
            // scQuestion
            // 
            this.scQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scQuestion.Location = new System.Drawing.Point(0, 0);
            this.scQuestion.Name = "scQuestion";
            this.scQuestion.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scQuestion.Panel1
            // 
            this.scQuestion.Panel1.Controls.Add(this.dgvReponse);
            // 
            // scQuestion.Panel2
            // 
            this.scQuestion.Panel2.Controls.Add(this.dgvMotCle);
            this.scQuestion.Size = new System.Drawing.Size(550, 494);
            this.scQuestion.SplitterDistance = 244;
            this.scQuestion.TabIndex = 0;
            // 
            // dgvReponse
            // 
            this.dgvReponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReponse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReponse,
            this.textReponse});
            this.dgvReponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReponse.Location = new System.Drawing.Point(0, 0);
            this.dgvReponse.Name = "dgvReponse";
            this.dgvReponse.Size = new System.Drawing.Size(550, 244);
            this.dgvReponse.TabIndex = 0;
            // 
            // dgvMotCle
            // 
            this.dgvMotCle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMotCle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMotCle,
            this.textMotCle});
            this.dgvMotCle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMotCle.Location = new System.Drawing.Point(0, 0);
            this.dgvMotCle.Name = "dgvMotCle";
            this.dgvMotCle.Size = new System.Drawing.Size(550, 246);
            this.dgvMotCle.TabIndex = 0;
            // 
            // idReponse
            // 
            this.idReponse.HeaderText = "Id de la réponse";
            this.idReponse.Name = "idReponse";
            this.idReponse.ReadOnly = true;
            // 
            // textReponse
            // 
            this.textReponse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textReponse.HeaderText = "Texte de la réponse";
            this.textReponse.Name = "textReponse";
            // 
            // idMotCle
            // 
            this.idMotCle.HeaderText = "Id du mot-clé";
            this.idMotCle.Name = "idMotCle";
            this.idMotCle.ReadOnly = true;
            // 
            // textMotCle
            // 
            this.textMotCle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textMotCle.HeaderText = "Texte du mot-clé";
            this.textMotCle.Name = "textMotCle";
            // 
            // FrmInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 522);
            this.Controls.Add(this.scMain);
            this.Name = "FrmInformations";
            this.Text = "FrmInformations";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            this.sReponse.ResumeLayout(false);
            this.scQuestion.Panel1.ResumeLayout(false);
            this.scQuestion.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scQuestion)).EndInit();
            this.scQuestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReponse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotCle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.Panel sReponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn idQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomQuestion;
        private System.Windows.Forms.SplitContainer scQuestion;
        private System.Windows.Forms.DataGridView dgvReponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn textReponse;
        private System.Windows.Forms.DataGridView dgvMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn textMotCle;
    }
}