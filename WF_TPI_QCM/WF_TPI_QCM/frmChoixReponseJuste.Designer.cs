namespace WF_TPI_QCM
{
    partial class frmChoixReponseJuste
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
            this.lblChoixReponseJuste = new System.Windows.Forms.Label();
            this.cmbReponseJuste = new System.Windows.Forms.ComboBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChoixReponseJuste
            // 
            this.lblChoixReponseJuste.AutoSize = true;
            this.lblChoixReponseJuste.Location = new System.Drawing.Point(13, 13);
            this.lblChoixReponseJuste.Name = "lblChoixReponseJuste";
            this.lblChoixReponseJuste.Size = new System.Drawing.Size(75, 13);
            this.lblChoixReponseJuste.TabIndex = 0;
            this.lblChoixReponseJuste.Text = "Réponse juste";
            // 
            // cmbReponseJuste
            // 
            this.cmbReponseJuste.FormattingEnabled = true;
            this.cmbReponseJuste.Location = new System.Drawing.Point(95, 10);
            this.cmbReponseJuste.Name = "cmbReponseJuste";
            this.cmbReponseJuste.Size = new System.Drawing.Size(528, 21);
            this.cmbReponseJuste.TabIndex = 1;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(16, 43);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(607, 30);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // frmChoixReponseJuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 85);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.cmbReponseJuste);
            this.Controls.Add(this.lblChoixReponseJuste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmChoixReponseJuste";
            this.Text = "Choisissez la réponse juste";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoixReponseJuste;
        private System.Windows.Forms.ComboBox cmbReponseJuste;
        private System.Windows.Forms.Button btnValider;
    }
}