using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.SpatialAnalystTools;
using WeifenLuo.WinFormsUI.Docking;
using WhuGIS.Utils;
using Visibility=ESRI.ArcGIS.SpatialAnalystTools.Visibility;
using RasterCalculator=ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator;
using Con=ESRI.ArcGIS.SpatialAnalystTools.Con;

namespace WhuGIS.Forms.FormMonitor
{
    /// <summary>
    /// 校园监控分析窗体
    /// 由于这个窗体好像真的比较简单 故不采用MVP模式了
    /// </summary>
    public partial class FormMonitor : DockContent
    {
        //总图层链表
        private List<ILayer> TotalLayers = new List<ILayer>();
        private List<ILayer> RasterLayers=new List<ILayer>();
        
 
        //与主地图控件的连接
        private AxMapControl mainMapControl;

        private double buffersize
        {
            //这里就是个近似计算了
            get { return ((double) numericUpDown.Value)/30.9/3600; }
            set { numericUpDown.Value = (decimal) value; }
        }                            //监控器缓冲区大小数值
        private ILayer CameraLayer;                              //输入监控位置图层
        private ILayer BuildingLayer;                            //输入建筑栅格图层

                 
        
        public FormMonitor(AxMapControl a)
        {
            InitializeComponent();
            mainMapControl = a;
            InitLayers();
            try
            {
                comboBox_list.SelectedIndex = 0;
                comboBox_building.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("当前图层状态异常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 初始化图层链表们
        /// </summary>
        private void InitLayers()
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                var thislayer = mainMapControl.get_Layer(i);
                TotalLayers.Add(thislayer);
                if (thislayer is IRasterLayer)
                {
                    RasterLayers.Add(thislayer);
                }
            }
            RefreshData();
        }

        private void RefreshData()
        {
            //显示数据
            comboBox_list.DataSource = null;
            comboBox_list.DisplayMember = "Name";
            comboBox_list.DataSource = TotalLayers;

            comboBox_building.DataSource = null;
            comboBox_building.DisplayMember = "Name";
            comboBox_building.DataSource = RasterLayers;
        }

       


        #region 按钮事件


        //开始处理
        private void buttonOK_Click(object sender, EventArgs e)
        {
            ViewAnalyze();
        }

        /// <summary>
        /// 当Combobox改变时刷新所选摄像头点位图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_list.SelectedIndex >= 0 && comboBox_list.SelectedIndex < TotalLayers.Count) 
            CameraLayer = TotalLayers[comboBox_list.SelectedIndex];
        }

        /// <summary>
        /// 当ComboBoxBuilding改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_building_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_building.SelectedIndex >= 0 && comboBox_building.SelectedIndex < RasterLayers.Count)
                BuildingLayer = RasterLayers[comboBox_list.SelectedIndex];
        }
        #endregion

        /// <summary>
        /// 最终版-------视域分析------
        /// </summary>
        /// <returns></returns>
        public void ViewAnalyze()
        {
            Geoprocessor g = new Geoprocessor();    //实例化一个GP对象
            g.OverwriteOutput = true;
            try
            {
                var filename1 = ApplicationV.Data_MonitorPath + "\\va_original";
                Visibility v = new Visibility();
                v.in_raster = (BuildingLayer as IRasterLayer).Raster;
                v.in_observer_features = (CameraLayer as IFeatureLayer).FeatureClass;
                v.out_raster = filename1;
                //创建Visibility分析工具
                v.z_factor = 1;
                v.outer_radius = buffersize.ToString();
                g.Execute(v, null);
                object sev="";
                Console.WriteLine(g.GetMessages(ref sev));
            }
            catch (Exception e)
            {
                object sev = "";
                MessageBox.Show(g.GetMessages(ref sev));
                return;
            }


            //添加第一步处理后的数据 这里还要进行【条件函数】

            //新建工作空间
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();

            IWorkspace workspace = workspaceFactory.OpenFromFile(ApplicationV.Data_MonitorPath, 0);
            IRasterWorkspace rasterWorkspace = (IRasterWorkspace)workspace;
            IRasterDataset firstDataset = rasterWorkspace.OpenRasterDataset("va_original");
            IRaster firstraster = firstDataset.CreateDefaultRaster();
            var pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromRaster(firstraster);
            ILayer pLayer = pRasterLayer as ILayer;
            pLayer.Visible = false;
            mainMapControl.AddLayer(pLayer,mainMapControl.LayerCount-1);


            try
            {
                var filename2 = ApplicationV.Data_MonitorPath + "\\va_result";
                var con = new Con();
                con.in_conditional_raster = firstraster;
                con.where_clause = "value=0";
                con.in_true_raster_or_constant = 0;
                con.in_false_raster_or_constant = 120;
                con.out_raster = filename2;
                g.Execute(con, null);
            }
            catch (Exception e)
            {
                object sev = "";
                MessageBox.Show(g.GetMessages(ref sev));
                return;
            }

            //最终导入图层
            IRasterDataset SecondDataset = rasterWorkspace.OpenRasterDataset("va_result");
            IRaster secondraster = SecondDataset.CreateDefaultRaster();
            var ppRasterLayer = new RasterLayerClass();
            ppRasterLayer.CreateFromRaster(secondraster);
            ILayer ppLayer = ppRasterLayer as ILayer;
            mainMapControl.AddLayer(ppLayer, MapUtils.GetLayerIndex("建筑")+1);
        }

        /// <summary>
        /// 清空本次运算缓存
        /// </summary>
        public static void DelectDir()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(ApplicationV.Data_MonitorPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
        
    }
}
