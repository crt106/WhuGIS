namespace WhuGIS.Forms.FormPhoto
{
    partial class FormPhoto
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
            this.DataPointAttr = new System.Windows.Forms.DataGridView();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonleft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataPointAttr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("黑体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(99, 340);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(134, 17);
            label1.TabIndex = 2;
            label1.Text = "当前特征点图像";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label2.Font = new System.Drawing.Font("楷体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.ForeColor = System.Drawing.Color.Red;
            label2.Location = new System.Drawing.Point(14, 191);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(10);
            label2.Size = new System.Drawing.Size(304, 88);
            label2.TabIndex = 4;
            label2.Text = "   受限于手机GPS精度问题\r\n   以及GCj02坐标系和WGS84坐标系\r\n   之间的换算关系影响\r\n   部分点位偏差较大.";
            // 
            // DataPointAttr
            // 
            this.DataPointAttr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataPointAttr.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataPointAttr.Location = new System.Drawing.Point(0, 0);
            this.DataPointAttr.Name = "DataPointAttr";
            this.DataPointAttr.RowTemplate.Height = 23;
            this.DataPointAttr.Size = new System.Drawing.Size(332, 178);
            this.DataPointAttr.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox.Location = new System.Drawing.Point(0, 366);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(332, 300);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            this.pictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_LoadCompleted);
            this.pictureBox.LoadProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.pictureBox_LoadProgressChanged);
            // 
            // buttonleft
            // 
            this.buttonleft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonleft.Location = new System.Drawing.Point(4, 314);
            this.buttonleft.Name = "buttonleft";
            this.buttonleft.Size = new System.Drawing.Size(75, 23);
            this.buttonleft.TabIndex = 5;
            this.buttonleft.Text = "逆时针90";
            this.buttonleft.UseVisualStyleBackColor = true;
            this.buttonleft.Click += new System.EventHandler(this.buttonleft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.Location = new System.Drawing.Point(245, 314);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 23);
            this.buttonRight.TabIndex = 6;
            this.buttonRight.Text = "顺时针90";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // FormPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 666);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonleft);
            this.Controls.Add(label2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.DataPointAttr);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPhoto";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "特征图像查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPhoto_FormClosing);
            this.Load += new System.EventHandler(this.FormPhoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataPointAttr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataPointAttr;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonleft;
        private System.Windows.Forms.Button buttonRight;
    }
}