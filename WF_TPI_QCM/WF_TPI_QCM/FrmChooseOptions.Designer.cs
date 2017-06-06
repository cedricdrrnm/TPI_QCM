namespace WF_TPI_QCM
{
    partial class FrmChooseOptions
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
            this.btnQCM = new System.Windows.Forms.Button();
            this.btnQuestion = new System.Windows.Forms.Button();
            this.btnReponse = new System.Windows.Forms.Button();
            this.btnMotCle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQCM
            // 
            this.btnQCM.Location = new System.Drawing.Point(13, 13);
            this.btnQCM.Name = "btnQCM";
            this.btnQCM.Size = new System.Drawing.Size(507, 68);
            this.btnQCM.TabIndex = 0;
            this.btnQCM.Text = "QCM";
            this.btnQCM.UseVisualStyleBackColor = true;
            // 
            // btnQuestion
            // 
            this.btnQuestion.Location = new System.Drawing.Point(13, 87);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Size = new System.Drawing.Size(507, 68);
            this.btnQuestion.TabIndex = 0;
            this.btnQuestion.Text = "Question";
            this.btnQuestion.UseVisualStyleBackColor = true;
            // 
            // btnReponse
            // 
            this.btnReponse.Location = new System.Drawing.Point(13, 161);
            this.btnReponse.Name = "btnReponse";
            this.btnReponse.Size = new System.Drawing.Size(507, 68);
            this.btnReponse.TabIndex = 0;
            this.btnReponse.Text = "Reponse";
            this.btnReponse.UseVisualStyleBackColor = true;
            // 
            // btnMotCle
            // 
            this.btnMotCle.Location = new System.Drawing.Point(13, 235);
            this.btnMotCle.Name = "btnMotCle";
            this.btnMotCle.Size = new System.Drawing.Size(507, 68);
            this.btnMotCle.TabIndex = 0;
            this.btnMotCle.Text = "Mot-Clé";
            this.btnMotCle.UseVisualStyleBackColor = true;
            // 
            // FrmChooseOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 313);
            this.Controls.Add(this.btnMotCle);
            this.Controls.Add(this.btnReponse);
            this.Controls.Add(this.btnQuestion);
            this.Controls.Add(this.btnQCM);
            this.Name = "FrmChooseOptions";
            this.Text = "Choix d\'options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQCM;
        private System.Windows.Forms.Button btnQuestion;
        private System.Windows.Forms.Button btnReponse;
        private System.Windows.Forms.Button btnMotCle;
    }
}