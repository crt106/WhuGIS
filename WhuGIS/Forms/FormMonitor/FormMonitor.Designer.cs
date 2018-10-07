namespace WhuGIS.Forms.FormMonitor
{
    partial class FormMonitor
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.comboBox_list = new System.Windows.Forms.ComboBox();
            this.ListBox_Layers = new System.Windows.Forms.ListBox();
            this.ListBox_Clips = new System.Windows.Forms.ListBox();
            this.buttonAdd2 = new System.Windows.Forms.Button();
            this.buttonDelete2 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new System.Drawing.Point(89, 48);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(100, 19);
            label1.TabIndex = 1;
            label1.Text = "监控器分布图层";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Sitka Banner", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(31, 118);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(143, 18);
            label2.TabIndex = 8;
            label2.Text = "监控器理想视野范围(m)";
            // 
            // comboBox_list
            // 
            this.comboBox_list.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_list.FormattingEnabled = true;
            this.comboBox_list.Location = new System.Drawing.Point(38, 77);
            this.comboBox_list.Name = "comboBox_list";
            this.comboBox_list.Size = new System.Drawing.Size(203, 20);
            this.comboBox_list.TabIndex = 0;
            this.comboBox_list.SelectedIndexChanged += new System.EventHandler(this.comboBox_list_SelectedIndexChanged);
            // 
            // ListBox_Layers
            // 
            this.ListBox_Layers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ListBox_Layers.FormattingEnabled = true;
            this.ListBox_Layers.ItemHeight = 12;
            this.ListBox_Layers.Location = new System.Drawing.Point(16, 166);
            this.ListBox_Layers.Name = "ListBox_Layers";
            this.ListBox_Layers.Size = new System.Drawing.Size(112, 172);
            this.ListBox_Layers.TabIndex = 2;
            // 
            // ListBox_Clips
            // 
            this.ListBox_Clips.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ListBox_Clips.FormattingEnabled = true;
            this.ListBox_Clips.ItemHeight = 12;
            this.ListBox_Clips.Location = new System.Drawing.Point(149, 166);
            this.ListBox_Clips.Name = "ListBox_Clips";
            this.ListBox_Clips.Size = new System.Drawing.Size(113, 172);
            this.ListBox_Clips.TabIndex = 3;
            // 
            // buttonAdd2
            // 
            this.buttonAdd2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAdd2.Location = new System.Drawing.Point(98, 356);
            this.buttonAdd2.Name = "buttonAdd2";
            this.buttonAdd2.Size = new System.Drawing.Size(83, 23);
            this.buttonAdd2.TabIndex = 4;
            this.buttonAdd2.Text = ">>>";
            this.buttonAdd2.UseVisualStyleBackColor = true;
            this.buttonAdd2.Click += new System.EventHandler(this.buttonAdd2_Click);
            // 
            // buttonDelete2
            // 
            this.buttonDelete2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDelete2.Location = new System.Drawing.Point(98, 385);
            this.buttonDelete2.Name = "buttonDelete2";
            this.buttonDelete2.Size = new System.Drawing.Size(83, 23);
            this.buttonDelete2.TabIndex = 5;
            this.buttonDelete2.Text = "<<<";
            this.buttonDelete2.UseVisualStyleBackColor = true;
            this.buttonDelete2.Click += new System.EventHandler(this.buttonDelete2_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOK.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOK.Location = new System.Drawing.Point(91, 470);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(97, 29);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "分析";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown.Location = new System.Drawing.Point(187, 115);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(60, 21);
            this.numericUpDown.TabIndex = 7;
            this.numericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // FormMonitor
            // 
            this.AutoHidePortion = 0.1D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 553);
            this.Controls.Add(label2);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonDelete2);
            this.Controls.Add(this.buttonAdd2);
            this.Controls.Add(this.ListBox_Clips);
            this.Controls.Add(this.ListBox_Layers);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBox_list);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMonitor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "校园监控范围分析";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_list;
        private System.Windows.Forms.ListBox ListBox_Layers;
        private System.Windows.Forms.ListBox ListBox_Clips;
        private System.Windows.Forms.Button buttonAdd2;
        private System.Windows.Forms.Button buttonDelete2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}