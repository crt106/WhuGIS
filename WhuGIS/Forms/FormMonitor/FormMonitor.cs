using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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
                IFeatureClass featclass = (InputLayer as IFeatureLayer).FeatureClass;
                IFeature feature = featclass.GetFeature(featclass.FeatureClassID);
                var iGeom = feature.Shape;
                var ipTO = (ITopologicalOperator) iGeom;
                IGeometry iGeomBuffer = ipTO.Buffer(buffersize);
                //创建缓冲区元素
                IElement pEle=new CircleElementClass();
                pEle.Geometry = iGeomBuffer;
                
                return null;
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
        /// Clip裁剪分析 先并集再裁剪
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

            //先进行Union并集运算
            IFeatureClass pClipFeatureClass = null;
            ITable InputTabel1=List_Clips[0] as ITable;
            for (int i = 1; i < List_Clips.Count; i++)
            {
                ITable InputTabel2=List_Clips[i] as ITable;
                pClipFeatureClass = pBasicGeo.Union(InputTabel1, false, InputTabel2, false, 0.01, pOutPut);
                InputTabel1 = pClipFeatureClass as ITable;
            }
          
            //进行裁剪运算
            IFeatureClass pFeatureClass = pBasicGeo.Clip(pInputFeatureClass as ITable, false, pClipFeatureClass as ITable, false, 0.01, pOutPut);
            return pFeatureClass;
            
        }

        
        
    }
}
