using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using WeifenLuo.WinFormsUI.Docking;
using WhuGIS.Utils;

namespace WhuGIS.Forms.FormPhoto
{
    public partial class FormPhoto : DockContent
    {
        public AxMapControl mainMapControl;

        /// <summary>
        /// 存放接收照片的列表
        /// </summary>
        List<Photo> PhotoList=new List<Photo>();
        //当前选中照片的Osspath
        private string NowPhotoOssPath;

        #region 本实例工作空间
        private static IWorkspaceFactory workspaceFactory;
        private static IWorkspaceName pWSName;
        private static IName pName;

        /// <summary>
        /// 本实例的内存工作空间
        /// </summary>
        /// <param name="strGDBName"></param>
        /// <returns></returns>
        public static IFeatureWorkspace MemoryWorkspace
        {
            get
            {
                //如果为空则创建
                if (workspaceFactory == null)
                {
                    workspaceFactory = new InMemoryWorkspaceFactoryClass();
                    pWSName = workspaceFactory.Create("", "Temp", null, 0);
                    pName = (IName)pWSName;
                }
                return ((IWorkspace)pName.Open()) as IFeatureWorkspace;
            }
        }

        
        #endregion

        /// <summary>
        /// 本实例创建的图层
        /// </summary>
        private ILayer PhotoLayer;

        /// <summary>
        /// 窗体开启时注册事件
        /// </summary>
        /// <param name="a"></param>
        public FormPhoto(AxMapControl a)
        {
            InitializeComponent();
            mainMapControl = a;
            mainMapControl.OnMouseDown += MainmapCLick_Extend;
            NetUtils.GetPhotoList(out PhotoList);
            //关闭主地图点击事件
            ApplicationV.IsBanFormMainMapClick = true;

        }

        private void FormPhoto_Load(object sender, EventArgs e)
        {
            PhotoLayer = GetPhotosLayer();
            mainMapControl.AddLayer(PhotoLayer);
            mainMapControl.Refresh();
            ApplicationV.IsBanFormMainMapClick = true;
        }

        /// <summary>
        /// 窗体关闭时取消注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainMapControl.OnMouseDown -= MainmapCLick_Extend;
            try
            {
                pictureBox.Image.Dispose();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            ApplicationV.IsBanFormMainMapClick = false;
        }

        ITopologicalOperator pTopo;
        IGeometry pGeometry;
        IFeature pFeature;
        IFeatureLayer pFeatureLayer;
        IFeatureCursor pCursor;
        ISpatialFilter pFilter;
        DataTable dataTable;

        //这个是判断上一次选择的点
        private IGeometry pLastGeometry;
        /// <summary>
        /// 当本窗体开启时 给主控件添加一个事件
        /// </summary>
        private void MainmapCLick_Extend(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            try
            {
                lock (mainMapControl)
                {
                    if (e.button == 1 && PhotoLayer != null)
                    {
                        Debug.WriteLine("准备选择特征地物点");
                        mainMapControl.CurrentTool = null;

                        var pPoint = new PointClass();
                        pPoint.PutCoords(e.mapX, e.mapY);
                        pTopo = pPoint as ITopologicalOperator;
                        double m_Radius = 0.00008;
                        pGeometry = pTopo.Buffer(m_Radius);

                        if (pGeometry == null)
                            return;

                        //判断是否重复过滤 避免报错
                        if (pLastGeometry != null && pLastGeometry.Equals(pGeometry)) return;
                        pLastGeometry = pGeometry;

                        //选中要素 第三个参数为是否只选中一个
                        mainMapControl.Map.SelectByShape(pGeometry, null, true);

                        //判断选中要素的合法性和合理性
                        pFilter = new SpatialFilterClass();
                        pFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        pFilter.Geometry = pGeometry;

                        

                        pFeatureLayer = PhotoLayer as IFeatureLayer;
                        pCursor = pFeatureLayer.Search(pFilter, false);
                        pFeature = pCursor.NextFeature();

                        


                        //只显示点对象
                        if (pFeature != null && pFeature.Shape.GeometryType ==
                            esriGeometryType.esriGeometryPoint)
                        {
                            //选中要素高亮显示
                            mainMapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                            #region 开始构建属性表格

                            dataTable = new DataTable();
                            for (int k = 0; k < 2; k++)
                            {
                                if (k == 0)
                                {
                                    dataTable.Columns.Add("属性");
                                }

                                if (k == 1)
                                {
                                    dataTable.Columns.Add("值");
                                }
                            }

                            string fieldName;
                            DataRow datarow;
                            for (int j = 0; j < pFeature.Fields.FieldCount; j++)
                            {
                                datarow = dataTable.NewRow();
                                for (int m = 0; m < 2; m++)
                                {
                                    if (m == 0)
                                    {
                                        fieldName = pFeature.Fields.get_Field(j).Name;
                                        datarow[m] = fieldName;
                                    }

                                    if (m == 1)
                                    {
                                        if (pFeature.Fields.get_Field(j).Name == "Shape")
                                        {
                                            datarow[m] = "点";
                                        }
                                        else
                                        {
                                            datarow[m] = pFeature.get_Value(j).ToString();
                                        }

                                        if (pFeature.Fields.get_Field(j).Name == "OSSpath")
                                        {
                                            NowPhotoOssPath = pFeature.get_Value(j).ToString();
                                        }
                                    }
                                }

                                dataTable.Rows.Add(datarow);
                            }

                            DataPointAttr.DataSource = dataTable;
                            DataPointAttr.Refresh();
                            pFeature = null;

                            #endregion
                        }


                        //处理照片显示问题
                        if (!string.IsNullOrEmpty(NowPhotoOssPath))
                        {
                            var task = new Task(() =>
                            {
                               pictureBox.ImageLocation = NowPhotoOssPath;
                            });
                            task.Start();
                        }
                    }
                }
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }


        /// <summary>
        /// 创建照片点集FeatureClass 
        /// </summary>
        private IFeatureClass CreateFeatureClass()
        {
            //创建字段集
            IFeatureClassDescription fcDescription = new FeatureClassDescriptionClass();
            IObjectClassDescription ocDescription = (IObjectClassDescription)fcDescription;

            //创建字段组
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;

            IField Field_OID = new FieldClass();
            IFieldEdit Field_OID_EDIT = Field_OID as IFieldEdit;
            Field_OID_EDIT.Name_2 = "OBJECTID";
            Field_OID_EDIT.Type_2 = esriFieldType.esriFieldTypeOID;
            Field_OID_EDIT.IsNullable_2 = false;
            Field_OID_EDIT.Required_2 = false;
            pFieldsEdit.AddField(Field_OID);

            //创建一个必要的东西          
            IGeometryDef geoDef = new GeometryDefClass();
            IGeometryDefEdit geoDefEdit = (IGeometryDefEdit)geoDef;
            geoDefEdit.AvgNumPoints_2 = 5;
            geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            geoDefEdit.GridCount_2 = 1;
            geoDefEdit.HasM_2 = false;
            geoDefEdit.HasZ_2 = false;
            geoDefEdit.SpatialReference_2 = mainMapControl.SpatialReference;


            //创建SHAPE字段
            IField Field_SHAPE = new FieldClass();
            IFieldEdit pFieldEdit_SHAPE = (IFieldEdit)Field_SHAPE;
            pFieldEdit_SHAPE.Name_2 = "SHAPE";
            pFieldEdit_SHAPE.Type_2 = esriFieldType.esriFieldTypeGeometry;
            pFieldEdit_SHAPE.GeometryDef_2 = geoDef;
            pFieldsEdit.AddField(Field_SHAPE);

            //创建Name字段
            IField Field_Name = new FieldClass();
            IFieldEdit pFieldEdit_Name = (IFieldEdit)Field_Name;
            pFieldEdit_Name.Name_2 = "Name";
            pFieldEdit_Name.Type_2 = esriFieldType.esriFieldTypeString;
            pFieldsEdit.AddField(Field_Name);

            //创建latitude字段
            IField Field_Lat = new FieldClass();
            IFieldEdit pFieldEdit_Lat = (IFieldEdit)Field_Lat;
            pFieldEdit_Lat.Name_2 = "Latitude";
            pFieldEdit_Lat.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldsEdit.AddField(Field_Lat);

            //创建longtitude字段
            IField Field_Log = new FieldClass();
            IFieldEdit pFieldEdit_Log = (IFieldEdit)Field_Log;
            pFieldEdit_Log.Name_2 = "Longtitude";
            pFieldEdit_Log.Type_2 = esriFieldType.esriFieldTypeDouble;
            pFieldsEdit.AddField(Field_Log);

            //创建OssPath字段
            IField Field_OSSpath = new FieldClass();
            IFieldEdit pFieldEdit_OSSpath = (IFieldEdit)Field_OSSpath;
            pFieldEdit_OSSpath.Name_2 = "OSSpath";
            pFieldEdit_OSSpath.Type_2 = esriFieldType.esriFieldTypeString;
            pFieldsEdit.AddField(Field_OSSpath);


            //正式创建要素类
            try
            {
                return MemoryWorkspace.CreateFeatureClass("特征地物照片", pFields, ocDescription.ClassExtensionCLSID, ocDescription.ClassExtensionCLSID, esriFeatureType.esriFTSimple, fcDescription.ShapeFieldName, "");
            }
            //The table already exists. 清除数据重建
            catch (Exception e)
            {
                Console.WriteLine(e);
                IFeatureClass tmp=MemoryWorkspace.OpenFeatureClass("特征地物照片");
                ITable pTable = tmp as ITable;
                pTable.DeleteSearchedRows(null);
                return tmp;
            }

        }


        /// <summary>
        /// 获取最后生成的照片点图层
        /// </summary>
        /// <returns></returns>
        
        public ILayer GetPhotosLayer()
        {
            IFeatureClass featureclass = CreateFeatureClass();
            
            IFeatureCursor featureCursor = featureclass.Insert(true);

            //遍历照片链表 以创建缓存的形式插入数据
            foreach (var p in PhotoList)
            {
                IPoint pPoint = new PointClass();
                //坐标转换
                var t=CoordinateUtils.gcj02_To_Wgs84(p.latitude, p.longtitude);
                pPoint.PutCoords(t.longtitude,t.latitude);
                pPoint.SpatialReference = mainMapControl.SpatialReference;
                pPoint.Project(mainMapControl.SpatialReference);
                IFeatureBuffer featureBuffer = featureclass.CreateFeatureBuffer();
                featureBuffer.Shape = pPoint;
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Name"), p.name);
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Latitude"), p.latitude);
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Longtitude"), p.longtitude);
                featureBuffer.set_Value(featureBuffer.Fields.FindField("OSSpath"), p.osspath);
                featureCursor.InsertFeature(featureBuffer);
            }  
            featureCursor.Flush();

            //创建图层
            IFeatureLayer pFeaturelayer = new FeatureLayerClass();
            pFeaturelayer.FeatureClass = featureclass;
            pFeaturelayer.Name = "特征地物照片点";

            //修饰该图层
            ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbol();
            pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;
            var pRgbColor = ColorUtils.GetRgbColor(186, 114, 208);
            pMarkerSymbol.Color = pRgbColor;
            ISimpleRenderer pSimpleRenderer=new SimpleRendererClass();
            pSimpleRenderer.Symbol = (ISymbol) pMarkerSymbol;
            (pFeaturelayer as IGeoFeatureLayer).Renderer = pSimpleRenderer as IFeatureRenderer;
            return pFeaturelayer as ILayer;
        }


        /// <summary>
        /// pictureBox图像加载完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (pictureBox.Image.Width < pictureBox.Image.Height)
            {
                var image = pictureBox.Image;
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Image = image;
            }
        }

        /// <summary>
        /// pictureBox图像加载进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FormMain.FormMain.FormInstance.StatusBarInfoSet(String.Format("图像加载进度{0}", e.ProgressPercentage));
        }

        /// <summary>
        /// 逆时针旋转90度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonleft_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null) 
            {
                var image = pictureBox.Image;
                image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox.Image = image;
            }
        }
        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                var image = pictureBox.Image;
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox.Image = image;
            }
        }

    }
}
