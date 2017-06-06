namespace WF_TPI_QCM
{
    partial class FrmSelectDatas
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
            this.tvDatas = new System.Windows.Forms.TreeView();
            this.btnChoisir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvDatas
            // 
            this.tvDatas.Location = new System.Drawing.Point(13, 13);
            this.tvDatas.Name = "tvDatas";
            this.tvDatas.Size = new System.Drawing.Size(583, 354);
            this.tvDatas.TabIndex = 0;
            // 
            // btnChoisir
            // 
            this.btnChoisir.Location = new System.Drawing.Point(13, 374);
            this.btnChoisir.Name = "btnChoisir";
            this.btnChoisir.Size = new System.Drawing.Size(583, 30);
            this.btnChoisir.TabIndex = 1;
            this.btnChoisir.Text = "Choisir";
            this.btnChoisir.UseVisualStyleBackColor = true;
            this.btnChoisir.Click += new System.EventHandler(this.btnChoisir_Click);
            // 
            // FrmSelectDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 416);
            this.Controls.Add(this.btnChoisir);
            this.Controls.Add(this.tvDatas);
            this.Name = "FrmSelectDatas";
            this.Text = "FrmSelectDatas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvDatas;
        private System.Windows.Forms.Button btnChoisir;
    }
}