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
            this.tabPage_bike = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.tabPage_Geifen = new System.Windows.Forms.TabPage();
            this.panel_Geifen = new System.Windows.Forms.Panel();
            this.tabPage_Hall = new System.Windows.Forms.TabPage();
            this.panel_Hall = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage_bike.SuspendLayout();
            this.tabPage_Geifen.SuspendLayout();
            this.tabPage_Hall.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage_bike);
            this.tabControl1.Controls.Add(this.tabPage_Geifen);
            this.tabControl1.Controls.Add(this.tabPage_Hall);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(343, 632);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_bike
            // 
            this.tabPage_bike.Controls.Add(this.label2);
            this.tabPage_bike.Controls.Add(this.label1);
            this.tabPage_bike.Controls.Add(this.buttonRefresh);
            this.tabPage_bike.Location = new System.Drawing.Point(4, 4);
            this.tabPage_bike.Name = "tabPage_bike";
            this.tabPage_bike.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_bike.Size = new System.Drawing.Size(335, 606);
            this.tabPage_bike.TabIndex = 0;
            this.tabPage_bike.Text = "校园共享单车分布";
            this.tabPage_bike.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.OliveDrab;
            this.label2.Location = new System.Drawing.Point(94, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 69);
            this.label2.TabIndex = 2;
            this.label2.Text = "ofo的数据总显示\r\n有几个车在操场上\r\n笑死我了\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(49, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "实时数据来源:\r\nofo和mobike微信小程序\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRefresh.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRefresh.Location = new System.Drawing.Point(75, 242);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(185, 64);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "刷新数据";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // tabPage_Geifen
            // 
            this.tabPage_Geifen.Controls.Add(this.panel_Geifen);
            this.tabPage_Geifen.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Geifen.Name = "tabPage_Geifen";
            this.tabPage_Geifen.Size = new System.Drawing.Size(335, 606);
            this.tabPage_Geifen.TabIndex = 2;
            this.tabPage_Geifen.Text = "给分查询";
            this.tabPage_Geifen.UseVisualStyleBackColor = true;
            this.tabPage_Geifen.Enter += new System.EventHandler(this.tabPage_Geifen_Enter);
            // 
            // panel_Geifen
            // 
            this.panel_Geifen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Geifen.Location = new System.Drawing.Point(0, 0);
            this.panel_Geifen.Name = "panel_Geifen";
            this.panel_Geifen.Size = new System.Drawing.Size(335, 606);
            this.panel_Geifen.TabIndex = 0;
            // 
            // tabPage_Hall
            // 
            this.tabPage_Hall.Controls.Add(this.panel_Hall);
            this.tabPage_Hall.Location = new System.Drawing.Point(4, 4);
            this.tabPage_Hall.Name = "tabPage_Hall";
            this.tabPage_Hall.Size = new System.Drawing.Size(335, 606);
            this.tabPage_Hall.TabIndex = 3;
            this.tabPage_Hall.Text = "场地占用查询";
            this.tabPage_Hall.UseVisualStyleBackColor = true;
            this.tabPage_Hall.Enter += new System.EventHandler(this.tabPage_Hall_Enter);
            // 
            // panel_Hall
            // 
            this.panel_Hall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Hall.Location = new System.Drawing.Point(0, 0);
            this.panel_Hall.Name = "panel_Hall";
            this.panel_Hall.Size = new System.Drawing.Size(335, 606);
            this.panel_Hall.TabIndex = 0;
            // 
            // FormSchoolInfo
            // 
            this.AutoHidePortion = 0.1D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 632);
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
            this.tabPage_bike.ResumeLayout(false);
            this.tabPage_bike.PerformLayout();
            this.tabPage_Geifen.ResumeLayout(false);
            this.tabPage_Hall.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_bike;
        private System.Windows.Forms.TabPage tabPage_Geifen;
        private System.Windows.Forms.Panel panel_Geifen;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage_Hall;
        private System.Windows.Forms.Panel panel_Hall;
    }
}