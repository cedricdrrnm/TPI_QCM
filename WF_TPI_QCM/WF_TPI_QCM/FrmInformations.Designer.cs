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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnModifier = new System.Windows.Forms.Button();
            this.nudLevel = new System.Windows.Forms.NumericUpDown();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.tlpQuestion = new System.Windows.Forms.TableLayoutPanel();
            this.dgvQuestion = new System.Windows.Forms.DataGridView();
            this.idQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblQCM = new System.Windows.Forms.Label();
            this.tbxNomQCM = new System.Windows.Forms.TextBox();
            this.lblLevelQCM = new System.Windows.Forms.Label();
            this.msMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
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
            this.SuspendLayout();
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
            this.ajouterToolStripMenuItem,
            this.sauvegarderToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter une question";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer ce QCM";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "Aide";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.Controls.Add(this.btnModifier, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudLevel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.scMain, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblQCM, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxNomQCM, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLevelQCM, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.872193F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.12781F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1123, 579);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnModifier
            // 
            this.btnModifier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModifier.Location = new System.Drawing.Point(977, 3);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(143, 23);
            this.btnModifier.TabIndex = 12;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // nudLevel
            // 
            this.nudLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nudLevel.Location = new System.Drawing.Point(727, 3);
            this.nudLevel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(244, 20);
            this.nudLevel.TabIndex = 11;
            this.nudLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // scMain
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.scMain, 5);
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(3, 36);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tlpQuestion);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.sReponse);
            this.scMain.Size = new System.Drawing.Size(1117, 540);
            this.scMain.SplitterDistance = 371;
            this.scMain.TabIndex = 4;
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
            this.tlpQuestion.Size = new System.Drawing.Size(371, 540);
            this.tlpQuestion.TabIndex = 3;
            // 
            // dgvQuestion
            // 
            this.dgvQuestion.AllowUserToAddRows = false;
            this.dgvQuestion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idQuestion,
            this.TextQuestion});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestion.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestion.Location = new System.Drawing.Point(3, 23);
            this.dgvQuestion.MultiSelect = false;
            this.dgvQuestion.Name = "dgvQuestion";
            this.dgvQuestion.RowHeadersVisible = false;
            this.dgvQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestion.Size = new System.Drawing.Size(365, 563);
            this.dgvQuestion.TabIndex = 3;
            this.dgvQuestion.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvQuestion_CellValidating);
            this.dgvQuestion.SelectionChanged += new System.EventHandler(this.dgvQuestion_SelectionChanged);
            this.dgvQuestion.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvQuestion_UserDeletingRow);
            // 
            // idQuestion
            // 
            this.idQuestion.HeaderText = "Id de la question";
            this.idQuestion.Name = "idQuestion";
            this.idQuestion.ReadOnly = true;
            // 
            // TextQuestion
            // 
            this.TextQuestion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TextQuestion.HeaderText = "Texte de la question";
            this.TextQuestion.Name = "TextQuestion";
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
            this.sReponse.Size = new System.Drawing.Size(742, 540);
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
            this.scQuestion.Size = new System.Drawing.Size(742, 540);
            this.scQuestion.SplitterDistance = 262;
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
            this.tlpReponse.Size = new System.Drawing.Size(742, 262);
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
            this.dgvReponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReponse.Location = new System.Drawing.Point(3, 23);
            this.dgvReponse.MultiSelect = false;
            this.dgvReponse.Name = "dgvReponse";
            this.dgvReponse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReponse.Size = new System.Drawing.Size(736, 265);
            this.dgvReponse.TabIndex = 2;
            this.dgvReponse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReponse_CellContentClick);
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
            this.chbBonneReponse.ReadOnly = true;
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
            this.tlbMotsClés.Size = new System.Drawing.Size(742, 274);
            this.tlbMotsClés.TabIndex = 2;
            // 
            // dgvMotCle
            // 
            this.dgvMotCle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMotCle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMotCle,
            this.textMotCle});
            this.dgvMotCle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMotCle.Location = new System.Drawing.Point(3, 23);
            this.dgvMotCle.MultiSelect = false;
            this.dgvMotCle.Name = "dgvMotCle";
            this.dgvMotCle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMotCle.Size = new System.Drawing.Size(736, 274);
            this.dgvMotCle.TabIndex = 2;
            this.dgvMotCle.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMotCle_RowValidating);
            this.dgvMotCle.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMotCle_UserDeletingRow);
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
            // lblQCM
            // 
            this.lblQCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQCM.Location = new System.Drawing.Point(3, 0);
            this.lblQCM.Name = "lblQCM";
            this.lblQCM.Size = new System.Drawing.Size(75, 33);
            this.lblQCM.TabIndex = 0;
            this.lblQCM.Text = "Nom du QCM";
            this.lblQCM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbxNomQCM
            // 
            this.tbxNomQCM.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxNomQCM.Location = new System.Drawing.Point(84, 3);
            this.tbxNomQCM.Name = "tbxNomQCM";
            this.tbxNomQCM.Size = new System.Drawing.Size(542, 20);
            this.tbxNomQCM.TabIndex = 1;
            // 
            // lblLevelQCM
            // 
            this.lblLevelQCM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLevelQCM.Location = new System.Drawing.Point(632, 0);
            this.lblLevelQCM.Name = "lblLevelQCM";
            this.lblLevelQCM.Size = new System.Drawing.Size(89, 33);
            this.lblLevelQCM.TabIndex = 8;
            this.lblLevelQCM.Text = "Niveau du QCM:";
            this.lblLevelQCM.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.msMain);
            this.Name = "FrmInformations";
            this.Text = "FrmInformations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInformations_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.TableLayoutPanel tlpQuestion;
        private System.Windows.Forms.DataGridView dgvQuestion;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel sReponse;
        private System.Windows.Forms.SplitContainer scQuestion;
        private System.Windows.Forms.TableLayoutPanel tlpReponse;
        private System.Windows.Forms.DataGridView dgvReponse;
        private System.Windows.Forms.Label lblReponse;
        private System.Windows.Forms.TableLayoutPanel tlbMotsClés;
        private System.Windows.Forms.DataGridView dgvMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMotCle;
        private System.Windows.Forms.DataGridViewTextBoxColumn textMotCle;
        private System.Windows.Forms.Label lblMotsCles;
        private System.Windows.Forms.Label lblQCM;
        private System.Windows.Forms.TextBox tbxNomQCM;
        private System.Windows.Forms.Label lblLevelQCM;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.NumericUpDown nudLevel;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn textReponse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chbBonneReponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn idQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextQuestion;
    }
}