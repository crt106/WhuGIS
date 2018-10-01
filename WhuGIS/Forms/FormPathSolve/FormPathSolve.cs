using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;
using WeifenLuo.WinFormsUI.Docking;
using WhuGIS.ArcEngineTool.NetworkAnalysis;
using WhuGIS.ArcEngineTool.NetworkAnalysis.AddNetBarries;
using WhuGIS.ArcEngineTool.NetworkAnalysis.AddNetStops;
using WhuGIS.ArcEngineTool.NetworkAnalysis.GetPathSolve;
using WhuGIS.BaseInterface;

namespace WhuGIS.Forms.FormPathSolve
{
    /// <summary>
    /// 计算最短路径操作窗体
    /// </summary>
    public partial class FormPathSolve : DockContent,ISolveView
    {
        //与主地图控件的连接
        private AxMapControl mainMapControl;
        private ISolvePresenter presenter;
        public FormPathSolve(AxMapControl mainMap)
        {
            InitializeComponent();
            mainMapControl = mainMap;
            presenter= new Presenter(this);
        }
        private void FormPathSolve_Load(object sender, EventArgs e)
        {
            SetNetWorkDataStatusText(false);
        }


        #region 接口实现
        ///<see cref="ISolveView"/>


        /// <summary>
        /// 用于展示外部数据库路径
        /// </summary>
        public string OutGDBFolder
        {
            get { return textBoxFolderpath.Text; }
            set { textBoxFolderpath.Text = value; }
        }

        public string DataBaseName
        {
            get { return textBox_DataBasename.Text; }
            set { textBox_DataBasename.Text = value; }
        }
        public string DataSetname
        {
            get { return textBox_DataSetName.Text; }
            set { textBox_DataSetName.Text = value; }
        }

        public Form FormInstance
        {
            get { return this; }
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void SetNetWorkDataStatusText(bool isable)
        {
            if (isable)
            {
                LabelDataStatus.Text = "已获取到网络数据集";
                LabelDataStatus.ForeColor=Color.Aquamarine;
                buttonAddStop.Enabled = true;
                buttonAddBarrier.Enabled = true;
                buttonSolve.Enabled = true;
                buttonClear.Enabled = true;
            }
            else
            {
                LabelDataStatus.Text = "当前网络数据集不可用";
                LabelDataStatus.ForeColor = Color.Red;
                buttonAddStop.Enabled = false;
                buttonAddBarrier.Enabled = false;
                buttonSolve.Enabled = false;
                buttonClear.Enabled = false;
            }
        }

        #endregion


        

        #region 按钮点击事件

        /// <summary>
        /// 选择外部DataBase路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseFolder_Click(object sender, EventArgs e)
        {

            var dialog = folderBrowserDialog;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OutGDBFolder = dialog.SelectedPath;
                presenter.SetNetWorkDataset_GDBFolder();
            }
        }
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NetWorkAnalysClass.MDBorSHP_FilePath = openFileDialog1.FileName;
                string filetype = openFileDialog1.SafeFileName.Split('.')[1];
                //如果是Shp文件
                if (filetype.ToLower().Equals("shp"))
                {
                    presenter.SetNetWorkDataset_Shapfile();
                }
                else if (filetype.ToLower().Equals("mdb"))
                {
                    presenter.SetNetWorkDataset_MDBFile();
                }
            }
        }

        //搜索图层
        private void buttonLayerSearch_Click(object sender, EventArgs e)
        {
            presenter.SetNetWorkDataset_Layers();
        }
        //添加站点
        private void buttonAddStop_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            ICommand pCommand;
            pCommand = new AddNetStopsTool();
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pCommand as ITool;
            pCommand = null;
        }

        //添加障碍点
        private void buttonAddBarrier_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            ICommand pCommand;
            pCommand = new AddNetBarriesTool();
            pCommand.OnCreate(mainMapControl.Object);
            mainMapControl.CurrentTool = pCommand as ITool;
            pCommand = null;
        }

        //计算最短路径
        private void buttonSolve_Click(object sender, EventArgs e)
        {
            mainMapControl.CurrentTool = null;
            ICommand pCommand;
            pCommand = new ShortPathSolveCommand();
            pCommand.OnCreate(mainMapControl.Object);
            pCommand.OnClick();
            pCommand = null;
        }

        /// <summary>
        /// 清除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            presenter.ClearPathResult();
        }
        
        #endregion

        

        

        

        
        
    }
}
