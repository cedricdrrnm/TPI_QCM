namespace WF_TPI_QCM
{
    partial class frmListMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvQCM = new System.Windows.Forms.TreeView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnExporter = new System.Windows.Forms.Button();
            this.btnRaffraichir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvQCM
            // 
            this.tvQCM.Location = new System.Drawing.Point(13, 13);
            this.tvQCM.Name = "tvQCM";
            this.tvQCM.Size = new System.Drawing.Size(818, 373);
            this.tvQCM.TabIndex = 0;
            this.tvQCM.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvQCM_BeforeExpand);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(11, 392);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(131, 46);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Créer";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(183, 392);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(131, 46);
            this.btnModifier.TabIndex = 2;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(355, 392);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(131, 46);
            this.btnSupprimer.TabIndex = 3;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnExporter
            // 
            this.btnExporter.Location = new System.Drawing.Point(527, 392);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(131, 46);
            this.btnExporter.TabIndex = 4;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.UseVisualStyleBackColor = true;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click);
            // 
            // btnRaffraichir
            // 
            this.btnRaffraichir.Location = new System.Drawing.Point(699, 392);
            this.btnRaffraichir.Name = "btnRaffraichir";
            this.btnRaffraichir.Size = new System.Drawing.Size(131, 46);
            this.btnRaffraichir.TabIndex = 5;
            this.btnRaffraichir.Text = "Raffraichir";
            this.btnRaffraichir.UseVisualStyleBackColor = true;
            // 
            // frmListMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 455);
            this.Controls.Add(this.btnRaffraichir);
            this.Controls.Add(this.btnExporter);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tvQCM);
            this.Name = "frmListMain";
            this.Text = "Liste des QCMs";
            this.Load += new System.EventHandler(this.frmListMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvQCM;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.Button btnRaffraichir;
    }
}

