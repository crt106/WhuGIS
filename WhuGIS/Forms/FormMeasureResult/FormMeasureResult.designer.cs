namespace WhuGIS.Forms.FormMeasureResult
{
    partial class FormMeasureResult
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblMeasureResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(18, 20);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(65, 12);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "量测结果：";
            // 
            // lblMeasureResult
            // 
            this.lblMeasureResult.AutoSize = true;
            this.lblMeasureResult.Location = new System.Drawing.Point(85, 20);
            this.lblMeasureResult.Name = "lblMeasureResult";
            this.lblMeasureResult.Size = new System.Drawing.Size(101, 12);
            this.lblMeasureResult.TabIndex = 1;
            this.lblMeasureResult.Text = "lblMeasureResult";
            // 
            // FormMeasureResult
            // 
            this.AutoHidePortion = 220D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(292, 68);
            this.Controls.Add(this.lblMeasureResult);
            this.Controls.Add(this.lblResult);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HideOnClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMeasureResult";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "测量结果";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMeasureResult_FormClosed);
            this.Load += new System.EventHandler(this.FormMeasureResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        public System.Windows.Forms.Label lblMeasureResult;
    }
}