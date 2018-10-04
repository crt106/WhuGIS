using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using WeifenLuo.WinFormsUI.Docking;
using WhuGIS.Utils;

namespace WhuGIS.Forms.FormExportMap
{
    public partial class FormExportMap : DockContent,IExportView
    {
        private IExportPresenter presenter;

        #region 接口实现

        public IGeometry pGeometry { get; set; }
        public IActiveView pActiveView { get; set; }
        public string pSavePath { get; set; }
        public bool bRegion { get; set; }

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
        public int resolution
        {
            get { return int.Parse(cboResolution.Text); }
            set { cboResolution.Text = value.ToString(); }
        }
        public int width
        {
            get { return int.Parse(txtWidth.Text); }
            set { txtWidth.Text = value.ToString(); }
        }
        public int height
        {
            get { return int.Parse(txtHeight.Text); }
            set { txtHeight.Text = value.ToString(); }
        }

        #endregion

        public FormExportMap(AxMapControl mainAxMapControl)
        {
            InitializeComponent();
            pActiveView = mainAxMapControl.ActiveView;
            presenter = new Presenter(this);
        }

        private void FormExportMap_Load(object sender, EventArgs e)
        {
            InitFormSize();
        }

        private void InitFormSize()
        {
            cboResolution.Text = pActiveView.ScreenDisplay.DisplayTransformation.Resolution.ToString();
            cboResolution.Items.Add(cboResolution.Text);
            if (bRegion)
            {
                IEnvelope pEnvelope = pGeometry.Envelope;
                tagRECT pRECT = new tagRECT();
                pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnvelope, ref pRECT, 9);
                if (cboResolution.Text != "")
                {
                    txtWidth.Text = pRECT.right.ToString();
                    txtHeight.Text = pRECT.bottom.ToString();
                }
            }
            else
            {
                if (cboResolution.Text != "")
                {
                    txtWidth.Text = pActiveView.ExportFrame.right.ToString();
                    txtHeight.Text = pActiveView.ExportFrame.bottom.ToString();
                }
            }
        }

        private void cboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            double num = (int) Math.Round(pActiveView.ScreenDisplay.DisplayTransformation.Resolution);
            if (cboResolution.Text == "")
            {
                txtWidth.Text = "";
                txtHeight.Text = "";
                return;
            }

            if (bRegion)
            {
                IEnvelope pEnvelope = pGeometry.Envelope;
                tagRECT pRECT = new tagRECT();
                pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnvelope, ref pRECT, 9);
                if (cboResolution.Text != "")
                {
                    txtWidth.Text =
                        Math.Round((double) (pRECT.right * (double.Parse(cboResolution.Text) / (double) num)))
                            .ToString();
                    txtHeight.Text =
                        Math.Round((double) (pRECT.bottom * (double.Parse(cboResolution.Text) / (double) num)))
                            .ToString();
                }
            }
            else
            {
                txtWidth.Text =
                    Math.Round((double) (pActiveView.ExportFrame.right *
                                         (double.Parse(cboResolution.Text) / (double) num))).ToString();
                txtHeight.Text =
                    Math.Round((double) (pActiveView.ExportFrame.bottom *
                                         (double.Parse(cboResolution.Text) / (double) num))).ToString();
            }
        }

        #region 按钮点击事件

        private void btnExPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdExportMap = new SaveFileDialog();
            sfdExportMap.DefaultExt = "jpg|bmp|gig|tif|png|pdf";
            sfdExportMap.Filter =
                "JPGE 文件(*.jpg)|*.jpg|BMP 文件(*.bmp)|*.bmp|GIF 文件(*.gif)|*.gif|TIF 文件(*.tif)|*.tif|PNG 文件(*.png)|*.png|PDF 文件(*.pdf)|*.pdf";
            sfdExportMap.OverwritePrompt = true;
            sfdExportMap.Title = "保存为";
            txtExPath.Text = "";
            if (sfdExportMap.ShowDialog() != DialogResult.Cancel)
            {
                pSavePath = sfdExportMap.FileName;
                txtExPath.Text = sfdExportMap.FileName;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtExPath.Text == "")
            {
                ShowMessage("请先确定导出路径!");
                return;
            }
            else if (cboResolution.Text == "")
            {
                if (txtExPath.Text == "")
                {
                    ShowMessage("请输入分辨率！");
                    return;
                }
            }
            else if (Convert.ToInt16(cboResolution.Text) == 0)
            {
                ShowMessage("请输入正确分辨率");
                return;
            }
            //参数输入正确
            else
            {
                presenter.ExportMap();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //局部导出时没有导出图像就退出
            pActiveView.GraphicsContainer.DeleteAllElements();
            pActiveView.Refresh();
            Dispose();
        }

        #endregion

        private void FormExportMap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //局部导出时没有导出图像就关闭
            pActiveView.GraphicsContainer.DeleteAllElements();
            pActiveView.Refresh();
            Dispose();
        }
    }
}
