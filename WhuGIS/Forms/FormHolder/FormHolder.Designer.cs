using WeifenLuo.WinFormsUI.Docking;

namespace WhuGIS.Forms.FormHolder
{
    partial class FormHolder
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
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1237, 686);
            this.dockPanel1.TabIndex = 1;
            // 
            // FormHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 686);
            this.Controls.Add(this.dockPanel1);
            this.DoubleBuffered = true;
            this.HideOnClose = true;
            this.IsMdiContainer = true;
            this.Name = "FormHolder";
            this.Text = "WHUGIS";
            this.Load += new System.EventHandler(this.FormHolder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DockPanel dockPanel1;

        
    }
}