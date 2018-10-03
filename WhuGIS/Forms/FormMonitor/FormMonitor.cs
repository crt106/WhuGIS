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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessor;
using WeifenLuo.WinFormsUI.Docking;
using Buffer = ESRI.ArcGIS.AnalysisTools.Buffer;

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
        //待加入裁剪要素的图层
        private List<ILayer> List_Layers = new List<ILayer>();
        //裁剪要素图层
        private List<ILayer> List_Clips = new List<ILayer>();
 
        //与主地图控件的连接
        private AxMapControl mainMapControl;

        private double buffersize
        {
            get { return (double) numericUpDown.Value; }
            set { numericUpDown.Value = (decimal) value; }
        }                            //监控器缓冲区大小数值
        private ILayer InputLayer;                              //输入图层

        private IFeatureClass pInputFeatureClass                //输入要素类
        {
            get
            {
                //获取输入要素类进行缓冲之后的要素类
                //缓冲区分析-GP工具调用
                Geoprocessor gp = new Geoprocessor();
                gp.OverwriteOutput = true;
                Buffer pBuffer = new Buffer();
                //获取缓冲区分析图层
                IFeatureLayer featLayer = InputLayer as IFeatureLayer;
                pBuffer.in_features = featLayer;
                //设置生成结果存储路径
                string filename = InputLayer.Name + "_Buffer";
                pBuffer.out_feature_class = ApplicationV.Data_MonitorPath + "\\" + filename + ".shp";
                //设置缓冲区距离
                pBuffer.buffer_distance_or_field = string.Format("{0} Meters", buffersize.ToString("f2"));
                pBuffer.dissolve_option = "ALL";
                //执行缓冲区分析
                gp.Execute(pBuffer, null);
                //添加到地图中
                mainMapControl.AddShapeFile(ApplicationV.DatarootPath, filename);
                //获取该图层
                return (mainMapControl.get_Layer(0) as IFeatureLayer).FeatureClass;
            }
        }               //输入要素类
        
        public FormMonitor(AxMapControl a)
        {
            InitializeComponent();
            mainMapControl = a;
            InitLayers();
            comboBox_list.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化图层链表们
        /// </summary>
        private void InitLayers()
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                List_Layers.Add(mainMapControl.get_Layer(i));
                TotalLayers.Add(mainMapControl.get_Layer(i));
            }
            RefreshData();
        }

        private void RefreshData()
        {
            //显示数据
            comboBox_list.DataSource = null;
            comboBox_list.DisplayMember = "Name";
            comboBox_list.DataSource = TotalLayers;

            ListBox_Layers.DataSource = null;
            ListBox_Layers.DataSource = List_Layers;
            ListBox_Layers.DisplayMember = "Name";

            ListBox_Clips.DataSource = null;
            ListBox_Clips.DisplayMember = "Name";
            ListBox_Clips.DataSource = List_Clips;
        }

       


        #region 按钮事件

        //添加裁剪要素
        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                //如果选中了对象哦
                if (ListBox_Layers.GetSelected(ListBox_Layers.SelectedIndex))
                {
                    var layer = List_Layers[ListBox_Layers.SelectedIndex];
                    List_Layers.Remove(layer);
                    List_Clips.Add(layer);

                    //刷新绑定
                    RefreshData();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //删除裁剪要素
        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            try
            {
                //如果选中了对象哦
                if (ListBox_Clips.GetSelected(ListBox_Clips.SelectedIndex))
                {
                    var layer = List_Clips[ListBox_Clips.SelectedIndex];
                    List_Clips.Remove(layer);
                    List_Layers.Add(layer);
                    //刷新绑定
                    RefreshData();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        //开始处理
        private void buttonOK_Click(object sender, EventArgs e)
        {     
            IFeatureClass outFeatureClass = Clip();
            if (outFeatureClass != null)
            {
                //将结果FeatureClass数据集转为FeatureLayer
                IFeatureLayer pFeatueLayer = new FeatureLayerClass();
                pFeatueLayer.FeatureClass = outFeatureClass;
                pFeatueLayer.Name = outFeatureClass.AliasName;
                //将结果数据加载到地图中，并刷新地图控件
                mainMapControl.AddLayer(pFeatueLayer);
                mainMapControl.Refresh();
                //清除数据
                DelectDir();
            }
        }

        /// <summary>
        /// 当Combobox改变时刷新所选图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_list.SelectedIndex >= 0 && comboBox_list.SelectedIndex < TotalLayers.Count) 
            InputLayer = TotalLayers[comboBox_list.SelectedIndex];
        }
        #endregion


        /// <summary>
        /// Clip裁剪分析 [这里是先并集再裁剪]
        /// </summary>
        /// <returns></returns>
        public IFeatureClass Clip()
        {
            //初始化IBasicGeoprocessor对象，调用Clip方法
            IBasicGeoprocessor pBasicGeo = new BasicGeoprocessorClass();
            pBasicGeo.SpatialReference = mainMapControl.SpatialReference;
            
            //设置输出结果IFeatureClassName相关必备属性
            IFeatureClassName pOutPut = new FeatureClassNameClass();
            pOutPut.ShapeType = pInputFeatureClass.ShapeType;
            pOutPut.ShapeFieldName = pInputFeatureClass.ShapeFieldName;
            pOutPut.FeatureType = esriFeatureType.esriFTSimple;

            //获取shapeFile数据工作空间
            IWorkspaceName pWsN = new WorkspaceNameClass();
            pWsN.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
            pWsN.PathName = ApplicationV.Data_MonitorPath;

            //通过IDatasetName设置输出结果相关参数
            IDatasetName pDatasetName = pOutPut as IDatasetName;
            pDatasetName.Name = "裁剪分析结果";
            pDatasetName.WorkspaceName = pWsN;

            //先进行并集运算
            ITable UnionTable = InnerUnion();
            IFeatureClass pFeatureClass = pBasicGeo.Clip(UnionTable, false, pInputFeatureClass as ITable, false, 0.01, pOutPut);
            return pFeatureClass;
        }

        /// <summary>
        /// 下个方法用的队列组件
        /// </summary>
        private Queue<IFeatureClass> FeatureClassQueue;
        /// <summary>
        /// 上一个方法的Union组件
        /// </summary>
        /// <returns></returns>
        public ITable InnerUnion()
        {
            //如果只有一个待并集对象 直接返回
            if (List_Clips.Count <= 1)
            {
                return (List_Clips[0] as IFeatureLayer).FeatureClass as ITable;
            }

            for (int i = 1; i < List_Clips.Count; i++)
            {
                FeatureClassQueue.Enqueue((List_Clips[i] as IFeatureLayer).FeatureClass);
            }

            //初始化IBasicGeoprocessor对象，调用Clip方法
            IBasicGeoprocessor pBasicGeo = new BasicGeoprocessorClass();
            pBasicGeo.SpatialReference = mainMapControl.SpatialReference;

            //设置输出结果IFeatureClassName相关必备属性
            IFeatureClassName pOutPut = new FeatureClassNameClass();
            pOutPut.ShapeType = pInputFeatureClass.ShapeType;
            pOutPut.ShapeFieldName = pInputFeatureClass.ShapeFieldName;
            pOutPut.FeatureType = esriFeatureType.esriFTSimple;

            //获取shapeFile数据工作空间
            IWorkspaceName pWsN = new WorkspaceNameClass();
            pWsN.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
            pWsN.PathName = ApplicationV.Data_MonitorPath;

            //通过IDatasetName设置输出结果相关参数
            IDatasetName pDatasetName = pOutPut as IDatasetName;
            pDatasetName.Name = "合并分析结果";
            pDatasetName.WorkspaceName = pWsN;

            //开始循环进行并集
            while (FeatureClassQueue.Count>1)
            {
                IFeatureClass queue1 = FeatureClassQueue.Dequeue();
                IFeatureClass queue2 = FeatureClassQueue.Dequeue();
                IFeatureClass result = pBasicGeo.Union(queue1 as ITable, false, queue2 as ITable, false, 0.01, pOutPut);
                FeatureClassQueue.Enqueue(result);
            }

            IFeatureClass FinalResult = FeatureClassQueue.Dequeue();
            return FinalResult as ITable;
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
                throw;
            }
        }
        
    }
}
