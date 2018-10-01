namespace WhuGIS.Forms.FormPathSolve
{
    partial class FormPathSolve
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
            System.Windows.Forms.GroupBox groupbox;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label LabelChoosedLayer;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.buttonAddStop = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonAddBarrier = new System.Windows.Forms.Button();
            this.textBox_DataSetName = new System.Windows.Forms.TextBox();
            this.textBox_DataBasename = new System.Windows.Forms.TextBox();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.textBoxFolderpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.LabelDataStatus = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonLayerSearch = new System.Windows.Forms.Button();
            groupbox = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            LabelChoosedLayer = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            groupbox.SuspendLayout();
            groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupbox
            // 
            groupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupbox.Controls.Add(this.buttonAddStop);
            groupbox.Controls.Add(this.buttonClear);
            groupbox.Controls.Add(this.buttonSolve);
            groupbox.Controls.Add(this.buttonAddBarrier);
            groupbox.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            groupbox.Location = new System.Drawing.Point(9, 455);
            groupbox.Name = "groupbox";
            groupbox.Size = new System.Drawing.Size(257, 197);
            groupbox.TabIndex = 5;
            groupbox.TabStop = false;
            groupbox.Text = "路径操作";
            // 
            // buttonAddStop
            // 
            this.buttonAddStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddStop.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddStop.Location = new System.Drawing.Point(49, 33);
            this.buttonAddStop.Name = "buttonAddStop";
            this.buttonAddStop.Size = new System.Drawing.Size(151, 31);
            this.buttonAddStop.TabIndex = 0;
            this.buttonAddStop.Text = "添加站点";
            this.buttonAddStop.UseVisualStyleBackColor = true;
            this.buttonAddStop.Click += new System.EventHandler(this.buttonAddStop_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonClear.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonClear.Location = new System.Drawing.Point(49, 144);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(151, 31);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "清除当前成果";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSolve
            // 
            this.buttonSolve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSolve.Font = new System.Drawing.Font("黑体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSolve.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonSolve.Location = new System.Drawing.Point(49, 107);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(151, 31);
            this.buttonSolve.TabIndex = 2;
            this.buttonSolve.Text = "计算最短路径";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonAddBarrier
            // 
            this.buttonAddBarrier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddBarrier.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddBarrier.Location = new System.Drawing.Point(49, 70);
            this.buttonAddBarrier.Name = "buttonAddBarrier";
            this.buttonAddBarrier.Size = new System.Drawing.Size(151, 31);
            this.buttonAddBarrier.TabIndex = 3;
            this.buttonAddBarrier.Text = "添加障碍点";
            this.buttonAddBarrier.UseVisualStyleBackColor = true;
            this.buttonAddBarrier.Click += new System.EventHandler(this.buttonAddBarrier_Click);
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.buttonLayerSearch);
            groupBox1.Controls.Add(this.textBox_DataSetName);
            groupBox1.Controls.Add(this.textBox_DataBasename);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(LabelChoosedLayer);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(this.buttonAddFile);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(this.textBoxFolderpath);
            groupBox1.Controls.Add(this.label1);
            groupBox1.Controls.Add(this.buttonChooseFolder);
            groupBox1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(254, 340);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "数据集设置";
            // 
            // textBox_DataSetName
            // 
            this.textBox_DataSetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_DataSetName.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_DataSetName.Location = new System.Drawing.Point(99, 286);
            this.textBox_DataSetName.Name = "textBox_DataSetName";
            this.textBox_DataSetName.ReadOnly = true;
            this.textBox_DataSetName.Size = new System.Drawing.Size(146, 20);
            this.textBox_DataSetName.TabIndex = 11;
            // 
            // textBox_DataBasename
            // 
            this.textBox_DataBasename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_DataBasename.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_DataBasename.Location = new System.Drawing.Point(99, 243);
            this.textBox_DataBasename.Name = "textBox_DataBasename";
            this.textBox_DataBasename.ReadOnly = true;
            this.textBox_DataBasename.Size = new System.Drawing.Size(146, 20);
            this.textBox_DataBasename.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(8, 289);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(82, 15);
            label6.TabIndex = 9;
            label6.Text = "数据集名称";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 245);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(82, 15);
            label5.TabIndex = 8;
            label5.Text = "数据库名称";
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label4.Location = new System.Drawing.Point(2, 211);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(251, 2);
            label4.TabIndex = 7;
            label4.Text = "label4";
            // 
            // LabelChoosedLayer
            // 
            LabelChoosedLayer.AutoSize = true;
            LabelChoosedLayer.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            LabelChoosedLayer.ForeColor = System.Drawing.Color.DeepSkyBlue;
            LabelChoosedLayer.Location = new System.Drawing.Point(69, 175);
            LabelChoosedLayer.Name = "LabelChoosedLayer";
            LabelChoosedLayer.Size = new System.Drawing.Size(110, 17);
            LabelChoosedLayer.TabIndex = 6;
            LabelChoosedLayer.Text = "当前选择图层";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label3.Location = new System.Drawing.Point(6, 141);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 12);
            label3.TabIndex = 5;
            label3.Text = "从图层选择";
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddFile.Location = new System.Drawing.Point(187, 86);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(58, 23);
            this.buttonAddFile.TabIndex = 4;
            this.buttonAddFile.Text = "浏览...";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.Location = new System.Drawing.Point(6, 86);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(119, 12);
            label2.TabIndex = 3;
            label2.Text = "网络数据集(mdb,shp)";
            // 
            // textBoxFolderpath
            // 
            this.textBoxFolderpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolderpath.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxFolderpath.Location = new System.Drawing.Point(11, 42);
            this.textBoxFolderpath.Multiline = true;
            this.textBoxFolderpath.Name = "textBoxFolderpath";
            this.textBoxFolderpath.Size = new System.Drawing.Size(168, 18);
            this.textBoxFolderpath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据文件夹(GDB)";
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChooseFolder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonChooseFolder.Location = new System.Drawing.Point(190, 42);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(58, 23);
            this.buttonChooseFolder.TabIndex = 0;
            this.buttonChooseFolder.Text = "浏览...";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // LabelDataStatus
            // 
            this.LabelDataStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelDataStatus.AutoSize = true;
            this.LabelDataStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelDataStatus.ForeColor = System.Drawing.Color.Red;
            this.LabelDataStatus.Location = new System.Drawing.Point(55, 375);
            this.LabelDataStatus.Name = "LabelDataStatus";
            this.LabelDataStatus.Size = new System.Drawing.Size(168, 16);
            this.LabelDataStatus.TabIndex = 7;
            this.LabelDataStatus.Text = "当前网络数据集不可用";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "选择GDB数据库目录";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "ShapeFile|*.shp|MDB文件|*.mdb";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Tag = "选择网络数据集";
            // 
            // buttonLayerSearch
            // 
            this.buttonLayerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLayerSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLayerSearch.Location = new System.Drawing.Point(187, 136);
            this.buttonLayerSearch.Name = "buttonLayerSearch";
            this.buttonLayerSearch.Size = new System.Drawing.Size(58, 23);
            this.buttonLayerSearch.TabIndex = 12;
            this.buttonLayerSearch.Text = "搜索";
            this.buttonLayerSearch.UseVisualStyleBackColor = true;
            this.buttonLayerSearch.Click += new System.EventHandler(this.buttonLayerSearch_Click);
            // 
            // FormPathSolve
            // 
            this.AutoHidePortion = 0.1D;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(286, 674);
            this.Controls.Add(this.LabelDataStatus);
            this.Controls.Add(groupBox1);
            this.Controls.Add(groupbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPathSolve";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "最短路径分析";
            this.Load += new System.EventHandler(this.FormPathSolve_Load);
            groupbox.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddStop;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonAddBarrier;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.TextBox textBoxFolderpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChooseFolder;
        private System.Windows.Forms.Label LabelDataStatus;
        private System.Windows.Forms.TextBox textBox_DataSetName;
        private System.Windows.Forms.TextBox textBox_DataBasename;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonLayerSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}