namespace WF_TPI_QCM
{
    partial class FrmCreateQCM
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
            this.tbxTitreQCM = new System.Windows.Forms.TextBox();
            this.lblTitreQCM = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.nudLevelQCM = new System.Windows.Forms.NumericUpDown();
            this.lblLevelQCM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelQCM)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxTitreQCM
            // 
            this.tbxTitreQCM.Location = new System.Drawing.Point(91, 13);
            this.tbxTitreQCM.Name = "tbxTitreQCM";
            this.tbxTitreQCM.Size = new System.Drawing.Size(393, 20);
            this.tbxTitreQCM.TabIndex = 0;
            // 
            // lblTitreQCM
            // 
            this.lblTitreQCM.AutoSize = true;
            this.lblTitreQCM.Location = new System.Drawing.Point(12, 16);
            this.lblTitreQCM.Name = "lblTitreQCM";
            this.lblTitreQCM.Size = new System.Drawing.Size(73, 13);
            this.lblTitreQCM.TabIndex = 1;
            this.lblTitreQCM.Text = "Titre du QCM:";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(10, 65);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(474, 43);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Créer";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // nudLevelQCM
            // 
            this.nudLevelQCM.Location = new System.Drawing.Point(104, 39);
            this.nudLevelQCM.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudLevelQCM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLevelQCM.Name = "nudLevelQCM";
            this.nudLevelQCM.Size = new System.Drawing.Size(380, 20);
            this.nudLevelQCM.TabIndex = 3;
            this.nudLevelQCM.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLevelQCM
            // 
            this.lblLevelQCM.AutoSize = true;
            this.lblLevelQCM.Location = new System.Drawing.Point(12, 41);
            this.lblLevelQCM.Name = "lblLevelQCM";
            this.lblLevelQCM.Size = new System.Drawing.Size(86, 13);
            this.lblLevelQCM.TabIndex = 4;
            this.lblLevelQCM.Text = "Niveau du QCM:";
            // 
            // FrmCreateQCM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 118);
            this.Controls.Add(this.lblLevelQCM);
            this.Controls.Add(this.nudLevelQCM);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblTitreQCM);
            this.Controls.Add(this.tbxTitreQCM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCreateQCM";
            this.Text = "FrmCreateEditQCM";
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelQCM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxTitreQCM;
        private System.Windows.Forms.Label lblTitreQCM;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.NumericUpDown nudLevelQCM;
        private System.Windows.Forms.Label lblLevelQCM;
    }
}