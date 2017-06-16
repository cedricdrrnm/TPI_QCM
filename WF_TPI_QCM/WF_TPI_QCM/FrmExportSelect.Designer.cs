namespace WF_TPI_QCM
{
    partial class FrmExportSelect
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
            this.btnSuivant = new System.Windows.Forms.Button();
            this.lblQCM = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.tvQCM = new System.Windows.Forms.TreeView();
            this.lsbModeles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnSuivant
            // 
            this.btnSuivant.Location = new System.Drawing.Point(13, 369);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(454, 46);
            this.btnSuivant.TabIndex = 1;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = true;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            // 
            // lblQCM
            // 
            this.lblQCM.AutoSize = true;
            this.lblQCM.Location = new System.Drawing.Point(12, 18);
            this.lblQCM.Name = "lblQCM";
            this.lblQCM.Size = new System.Drawing.Size(87, 13);
            this.lblQCM.TabIndex = 3;
            this.lblQCM.Text = "Liste des QCMs: ";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(240, 18);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(97, 13);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "Liste des modèles: ";
            // 
            // tvQCM
            // 
            this.tvQCM.CheckBoxes = true;
            this.tvQCM.Location = new System.Drawing.Point(15, 35);
            this.tvQCM.Name = "tvQCM";
            this.tvQCM.Size = new System.Drawing.Size(222, 316);
            this.tvQCM.TabIndex = 5;
            // 
            // lsbModeles
            // 
            this.lsbModeles.FormattingEnabled = true;
            this.lsbModeles.Location = new System.Drawing.Point(243, 35);
            this.lsbModeles.Name = "lsbModeles";
            this.lsbModeles.Size = new System.Drawing.Size(223, 316);
            this.lsbModeles.TabIndex = 7;
            // 
            // FrmExportSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 422);
            this.Controls.Add(this.lsbModeles);
            this.Controls.Add(this.tvQCM);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblQCM);
            this.Controls.Add(this.btnSuivant);
            this.Name = "FrmExportSelect";
            this.Text = "Exportation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSuivant;
        private System.Windows.Forms.Label lblQCM;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TreeView tvQCM;
        private System.Windows.Forms.ListBox lsbModeles;
    }
}