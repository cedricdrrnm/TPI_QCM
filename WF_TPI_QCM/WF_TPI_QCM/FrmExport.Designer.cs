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
            this.msExport = new System.Windows.Forms.MenuStrip();
            this.tsmiModel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbxContent = new System.Windows.Forms.TextBox();
            this.lsbMarkers = new System.Windows.Forms.ListBox();
            this.msExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // msExport
            // 
            this.msExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiModel});
            this.msExport.Location = new System.Drawing.Point(0, 0);
            this.msExport.Name = "msExport";
            this.msExport.Size = new System.Drawing.Size(851, 24);
            this.msExport.TabIndex = 0;
            this.msExport.Text = "menuStrip1";
            // 
            // tsmiModel
            // 
            this.tsmiModel.Name = "tsmiModel";
            this.tsmiModel.Size = new System.Drawing.Size(58, 20);
            this.tsmiModel.Text = "Models";
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExport.Location = new System.Drawing.Point(0, 429);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(851, 59);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Exporter";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tbxContent
            // 
            this.tbxContent.Location = new System.Drawing.Point(0, 27);
            this.tbxContent.Multiline = true;
            this.tbxContent.Name = "tbxContent";
            this.tbxContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxContent.Size = new System.Drawing.Size(661, 384);
            this.tbxContent.TabIndex = 2;
            // 
            // lsbMarkers
            // 
            this.lsbMarkers.FormattingEnabled = true;
            this.lsbMarkers.Location = new System.Drawing.Point(667, 27);
            this.lsbMarkers.Name = "lsbMarkers";
            this.lsbMarkers.Size = new System.Drawing.Size(172, 381);
            this.lsbMarkers.TabIndex = 3;
            this.lsbMarkers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbMarkers_MouseDoubleClick);
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 488);
            this.Controls.Add(this.lsbMarkers);
            this.Controls.Add(this.tbxContent);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.msExport);
            this.MainMenuStrip = this.msExport;
            this.Name = "FrmExport";
            this.Text = "FrmExport";
            this.msExport.ResumeLayout(false);
            this.msExport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msExport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbxContent;
        private System.Windows.Forms.ToolStripMenuItem tsmiModel;
        private System.Windows.Forms.ListBox lsbMarkers;
    }
}