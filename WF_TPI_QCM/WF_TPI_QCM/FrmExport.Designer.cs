namespace WF_TPI_QCM
{
    partial class FrmExport
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
            this.tvQCM = new System.Windows.Forms.TreeView();
            this.lblQCM = new System.Windows.Forms.Label();
            this.btnExporter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvQCM
            // 
            this.tvQCM.Location = new System.Drawing.Point(13, 41);
            this.tvQCM.Name = "tvQCM";
            this.tvQCM.Size = new System.Drawing.Size(199, 355);
            this.tvQCM.TabIndex = 0;
            // 
            // lblQCM
            // 
            this.lblQCM.AutoSize = true;
            this.lblQCM.Location = new System.Drawing.Point(13, 13);
            this.lblQCM.Name = "lblQCM";
            this.lblQCM.Size = new System.Drawing.Size(180, 13);
            this.lblQCM.TabIndex = 1;
            this.lblQCM.Text = "Listes des QCMs (faire sa sélection) :";
            // 
            // btnExporter
            // 
            this.btnExporter.Location = new System.Drawing.Point(219, 41);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(322, 47);
            this.btnExporter.TabIndex = 2;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.UseVisualStyleBackColor = true;
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 408);
            this.Controls.Add(this.btnExporter);
            this.Controls.Add(this.lblQCM);
            this.Controls.Add(this.tvQCM);
            this.Name = "FrmExport";
            this.Text = "FrmExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvQCM;
        private System.Windows.Forms.Label lblQCM;
        private System.Windows.Forms.Button btnExporter;
    }
}