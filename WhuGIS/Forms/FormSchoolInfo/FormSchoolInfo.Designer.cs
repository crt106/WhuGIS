namespace WhuGIS.Forms.FormSchoolInfo
{
    partial class FormSchoolInfo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage_Chair = new System.Windows.Forms.TabPage();
            this.tabPage_Geifen = new System.Windows.Forms.TabPage();
            this.panel_Geifen = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage_Geifen.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage_Chair);
            this.tabControl1.Controls.Add(this.tabPage_Geifen);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 632);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(364, 606);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TablePage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage_Chair
            // 
            this.tabPage_Chair.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Chair.Name = "tabPage_Chair";
            this.tabPage_Chair.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Chair.Size = new System.Drawing.Size(364, 606);
            this.tabPage_Chair.TabIndex = 1;
            this.tabPage_Chair.Text = "讲座信息";
            this.tabPage_Chair.UseVisualStyleBackColor = true;
            // 
            // tabPage_Geifen
            // 
            this.tabPage_Geifen.Controls.Add(this.panel_Geifen);
            this.tabPage_Geifen.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Geifen.Name = "tabPage_Geifen";
            this.tabPage_Geifen.Size = new System.Drawing.Size(364, 606);
            this.tabPage_Geifen.TabIndex = 2;
            this.tabPage_Geifen.Text = "给分查询";
            this.tabPage_Geifen.UseVisualStyleBackColor = true;
            // 
            // panel_Geifen
            // 
            this.panel_Geifen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Geifen.Location = new System.Drawing.Point(0, 0);
            this.panel_Geifen.Name = "panel_Geifen";
            this.panel_Geifen.Size = new System.Drawing.Size(364, 606);
            this.panel_Geifen.TabIndex = 0;
            // 
            // FormSchoolInfo
            // 
            this.AutoHidePortion = 1.5D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 632);
            this.Controls.Add(this.tabControl1);
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSchoolInfo";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "校园公共信息";
            this.Load += new System.EventHandler(this.校园公共信息_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Geifen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage_Chair;
        private System.Windows.Forms.TabPage tabPage_Geifen;
        private System.Windows.Forms.Panel panel_Geifen;
    }
}