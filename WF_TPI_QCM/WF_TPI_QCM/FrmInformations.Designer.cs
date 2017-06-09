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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tlpQuestion = new System.Windows.Forms.TableLayoutPanel();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.idQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.sReponse = new System.Windows.Forms.Panel();
            this.scQuestion = new System.Windows.Forms.SplitContainer();
            this.tlpReponse = new System.Windows.Forms.TableLayoutPanel();
            this.dgvReponse = new System.Windows.Forms.DataGridView();
            this.idReponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textReponse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chbBonneReponse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblReponse = new System.Windows.Forms.Label();
            this.tlbMotsClés = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMotCle = new System.Windows.Forms.DataGridView();
            this.idMotCle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textMotCle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMotsCles = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motCléToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.tlpQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).BeginInit();
            this.sReponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scQuestion)).BeginInit();
            this.scQuestion.Panel1.SuspendLayout();
            this.scQuestion.Panel2.SuspendLayout();
            this.scQuestion.SuspendLayout();
            this.tlpReponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReponse)).BeginInit();
            this.tlbMotsClés.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotCle)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 24);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tlpQuestion);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.sReponse);
            this.scMain.Size = new System.Drawing.Size(1123, 579);
            this.scMain.SplitterDistance = 374;
            this.scMain.TabIndex = 2;
            // 
            // tlpQuestion
            // 
            this.tlpQuestion.ColumnCount = 1;
            this.tlpQuestion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQuestion.Controls.Add(this.dgvQuestion, 0, 1);
            this.tlpQuestion.Controls.Add(this.lblQuestion, 0, 0);
            this.tlpQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQuestion.Location = new System.Drawing.Point(0, 0);
            this.tlpQuestion.Name = "tlpQuestion";
            this.tlpQuestion.RowCount = 2;
            this.tlpQuestion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpQuestion.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpQuestion.Size = new System.Drawing.Size(374, 579);
            this.tlpQuestion.TabIndex = 3;
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idQuestion,
            this.NomQuestion});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestion.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuestion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvQuestion.Location = new System.Drawing.Point(3, 23);
            this.dgvQuestion.MultiSelect = false;
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.RowHeadersVisible = false;
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.Size = new System.Drawing.Size(368, 563);
            this.dgvQuestion.TabIndex = 3;
            this.dgvQuestion.SelectionChanged += new System.EventHandler(this.dgvQuestion_SelectionChanged);
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
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(3, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(60, 13);
            this.lblQuestion.TabIndex = 2;
            this.lblQuestion.Text = "Questions :";
            // 
            // sReponse
            // 
            this.sReponse.Controls.Add(this.scQuestion);
            this.sReponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sReponse.Location = new System.Drawing.Point(0, 0);
            this.sReponse.Name = "sReponse";
            this.sReponse.Size = new System.Drawing.Size(745, 579);
            this.sReponse.TabIndex = 2;
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
            this.scQuestion.Panel1.Controls.Add(this.tlpReponse);
            // 
            // scQuestion.Panel2
            // 
            this.scQuestion.Panel2.Controls.Add(this.tlbMotsClés);
            this.scQuestion.Size = new System.Drawing.Size(745, 579);
            this.scQuestion.SplitterDistance = 285;
            this.scQuestion.TabIndex = 0;
            // 
            // tlpReponse
            // 
            this.tlpReponse.ColumnCount = 1;
            this.tlpReponse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpReponse.Controls.Add(this.dgvReponse, 0, 1);
            this.tlpReponse.Controls.Add(this.lblReponse, 0, 0);
            this.tlpReponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpReponse.Location = new System.Drawing.Point(0, 0);
            this.tlpReponse.Name = "tlpReponse";
            this.tlpReponse.RowCount = 2;
            this.tlpReponse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpReponse.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpReponse.Size = new System.Drawing.Size(745, 285);
            this.tlpReponse.TabIndex = 1;
            // 
            // dgvReponse
            // 
            this.dgvReponse.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReponse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idReponse,
            this.textReponse,
            this.chbBonneReponse});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReponse.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReponse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvReponse.Location = new System.Drawing.Point(3, 23);
            this.dgvReponse.Name = "dgvReponse";
            this.dgvReponse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReponse.Size = new System.Drawing.Size(739, 265);
            this.dgvReponse.TabIndex = 2;
            this.dgvReponse.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvReponse_RowsAdded);
            this.dgvReponse.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvReponse_RowsRemoved);
            this.dgvReponse.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReponse_RowValidated);
            this.dgvReponse.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvReponse_RowValidating);
            this.dgvReponse.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvReponse_UserAddedRow);
            this.dgvReponse.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvReponse_UserDeletingRow);
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
            // chbBonneReponse
            // 
            this.chbBonneReponse.HeaderText = "Bonne réponse";
            this.chbBonneReponse.Name = "chbBonneReponse";
            // 
            // lblReponse
            // 
            this.lblReponse.AutoSize = true;
            this.lblReponse.Location = new System.Drawing.Point(3, 0);
            this.lblReponse.Name = "lblReponse";
            this.lblReponse.Size = new System.Drawing.Size(50, 13);
            this.lblReponse.TabIndex = 0;
            this.lblReponse.Text = "Réponse";
            // 
            // tlbMotsClés
            // 
            this.tlbMotsClés.ColumnCount = 1;
            this.tlbMotsClés.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlbMotsClés.Controls.Add(this.dgvMotCle, 0, 1);
            this.tlbMotsClés.Controls.Add(this.lblMotsCles, 0, 0);
            this.tlbMotsClés.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlbMotsClés.Location = new System.Drawing.Point(0, 0);
            this.tlbMotsClés.Name = "tlbMotsClés";
            this.tlbMotsClés.RowCount = 2;
            this.tlbMotsClés.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlbMotsClés.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbMotsClés.Size = new System.Drawing.Size(745, 290);
            this.tlbMotsClés.TabIndex = 2;
            // 
            // dgvMotCle
            // 
            this.dgvMotCle.AllowUserToAddRows = false;
            this.dgvMotCle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMotCle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMotCle,
            this.textMotCle});
            this.dgvMotCle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvMotCle.Location = new System.Drawing.Point(3, 23);
            this.dgvMotCle.Name = "dgvMotCle";
            this.dgvMotCle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMotCle.Size = new System.Drawing.Size(739, 274);
            this.dgvMotCle.TabIndex = 2;
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
            // lblMotsCles
            // 
            this.lblMotsCles.AutoSize = true;
            this.lblMotsCles.Location = new System.Drawing.Point(3, 0);
            this.lblMotsCles.Name = "lblMotsCles";
            this.lblMotsCles.Size = new System.Drawing.Size(98, 13);
            this.lblMotsCles.TabIndex = 1;
            this.lblMotsCles.Text = "Mots-Clés du QCM:";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(1123, 24);
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip2";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questionToolStripMenuItem,
            this.motCléToolStripMenuItem});
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            // 
            // questionToolStripMenuItem
            // 
            this.questionToolStripMenuItem.Name = "questionToolStripMenuItem";
            this.questionToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.questionToolStripMenuItem.Text = "Question";
            this.questionToolStripMenuItem.Click += new System.EventHandler(this.questionToolStripMenuItem_Click);
            // 
            // motCléToolStripMenuItem
            // 
            this.motCléToolStripMenuItem.Name = "motCléToolStripMenuItem";
            this.motCléToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.motCléToolStripMenuItem.Text = "Mot-Clé";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // FrmInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 603);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.msMain);
            this.Name = "FrmInformations";
            this.Text = "FrmInformations";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.tlpQuestion.ResumeLayout(false);
            this.tlpQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestion)).EndInit();
            this.sReponse.ResumeLayout(false);
            this.scQuestion.Panel1.ResumeLayout(false);
            this.scQuestion.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scQuestion)).EndInit();
            this.scQuestion.ResumeLayout(false);
            this.tlpReponse.ResumeLayout(false);
            this.tlpReponse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReponse)).EndInit();
            this.tlbMotsClés.ResumeLayout(false);
            this.tlbMotsClés.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotCle)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel sReponse;
        private System.Windows.Forms.SplitContainer scQuestion;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblReponse;
        private System.Windows.Forms.Label lblMotsCles;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motCléToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpReponse;
        private System.Windows.Forms.DataGridView dgvReponse;
        private System.Windows.Forms.TableLayoutPanel tlpQuestion;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomQuestion;
        private System.Windows.Forms.TableLayoutPanel tlbMotsClés;
        private System.Windows.Forms.DataGridView dgvMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn textMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn textReponse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chbBonneReponse;
    }
}