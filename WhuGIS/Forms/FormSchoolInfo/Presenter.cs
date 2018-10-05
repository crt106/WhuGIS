using System;
using System.Collections.Generic;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using WhuGIS.ArcEngineTool.NetworkAnalysis;
using WhuGIS.Utils;

namespace WhuGIS.Forms.FormSchoolInfo
{
    public class Presenter:ISchoolPresenter
    {
        ISchoolView view;

        public IFeatureWorkspace MemoryWorkspace
        {
            get { return NetWorkAnalysClass.MemoryWorkspace as IFeatureWorkspace; }
        }

        public Presenter(ISchoolView v)
        {
            view = v;
        }

        private ILayer ofoLayer;

        /// <summary>
        /// 刷新ofo数据
        /// </summary>
        public void RefreshofoInfo()
        {
            //获取车辆位置信息
            var ofocars=new List<ofoInfo>();
            
            NetUtils.GetofoCars(out ofocars);
            if (ofocars == null)
            {
                view.ShowError("数据出现问题,可能是ofo权限认证出错 返回示例数据");
                ofocars = SampleData.ofoSampleList;
            }

            IFeatureClass featureclass = CreateFeatureClass("ofo");

            IFeatureCursor featureCursor = featureclass.Insert(true);

            //遍历照片链表 以创建缓存的形式插入数据
            foreach (var c in ofocars)
            {
                IPoint pPoint = new PointClass();
                //坐标转换
                var t = CoordinateUtils.gcj02_To_Wgs84(c.lat, c.lng);
                pPoint.PutCoords(t.longtitude, t.latitude);
                pPoint.SpatialReference = ApplicationV.GlobalMapControl.SpatialReference;
                pPoint.Project(ApplicationV.GlobalMapControl.SpatialReference);
                IFeatureBuffer featureBuffer = featureclass.CreateFeatureBuffer();
                featureBuffer.Shape = pPoint;            
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Latitude"), t.latitude);
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Longtitude"), t.longtitude);
                featureCursor.InsertFeature(featureBuffer);
            }
            featureCursor.Flush();

            //创建图层
            IFeatureLayer pFeaturelayer = new FeatureLayerClass();
            pFeaturelayer.FeatureClass = featureclass;
            pFeaturelayer.Name = "ofo分布";

            //修饰该图层
            ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbol();
            pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            var pRgbColor = ColorUtils.GetRgbColor(255, 255, 0);
            pMarkerSymbol.Color = pRgbColor;
            ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
            pSimpleRenderer.Symbol = (ISymbol)pMarkerSymbol;
            (pFeaturelayer as IGeoFeatureLayer).Renderer = pSimpleRenderer as IFeatureRenderer;

            //正式归为图层
            ofoLayer= pFeaturelayer as ILayer;

            ApplicationV.GlobalMapControl.AddLayer(ofoLayer);
            ApplicationV.GlobalMapControl.Refresh();
        }


        /// <summary>
        /// 刷新Mobike数据
        /// </summary>
        public void RefreshmobikeInfo()
        {
            //获取车辆位置信息
            var mobikecars = new List<mobikeInfo>();

            NetUtils.GetmobikeCars(out mobikecars);
            if (mobikecars == null)
            {
                view.ShowError("数据出现问题,可能是mobike用户认证出错 返回示例数据");
                mobikecars = SampleData.mobikeSampleList;
            }

            IFeatureClass featureclass = CreateFeatureClass("mobike");
            IFeatureCursor featureCursor = featureclass.Insert(true);

            //遍历照片链表 以创建缓存的形式插入数据
            foreach (var c in mobikecars)
            {
                IPoint pPoint = new PointClass();
                //坐标转换
                var t = CoordinateUtils.gcj02_To_Wgs84(c.distY, c.distX);
                pPoint.PutCoords(t.longtitude, t.latitude);
                pPoint.SpatialReference = ApplicationV.GlobalMapControl.SpatialReference;
                pPoint.Project(ApplicationV.GlobalMapControl.SpatialReference);
                IFeatureBuffer featureBuffer = featureclass.CreateFeatureBuffer();
                featureBuffer.Shape = pPoint;
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Latitude"), t.latitude);
                featureBuffer.set_Value(featureBuffer.Fields.FindField("Longtitude"), t.longtitude);
                featureCursor.InsertFeature(featureBuffer);
            }
            featureCursor.Flush();

            //创建图层
            IFeatureLayer pFeaturelayer = new FeatureLayerClass();
            pFeaturelayer.FeatureClass = featureclass;
            pFeaturelayer.Name = "mobike分布";

            //修饰该图层
            ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbol();
            pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            var pRgbColor = ColorUtils.GetRgbColor(226, 61, 14);
            pMarkerSymbol.Color = pRgbColor;
            ISimpleRenderer pSimpleRenderer = new SimpleRendererClass();
            pSimpleRenderer.Symbol = (ISymbol)pMarkerSymbol;
            (pFeaturelayer as IGeoFeatureLayer).Renderer = pSimpleRenderer as IFeatureRenderer;

            //正式归为图层
            ofoLayer = pFeaturelayer as ILayer;

            ApplicationV.GlobalMapControl.AddLayer(ofoLayer);
            ApplicationV.GlobalMapControl.Refresh();
        }


        /// <summary>
        /// 创建ofo和mobike数据FeatureClass
        /// </summary>
        private IFeatureClass CreateFeatureClass(string name)
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
            geoDefEdit.SpatialReference_2 = ApplicationV.GlobalMapControl.SpatialReference;


            //创建SHAPE字段
            IField Field_SHAPE = new FieldClass();
            IFieldEdit pFieldEdit_SHAPE = (IFieldEdit)Field_SHAPE;
            pFieldEdit_SHAPE.Name_2 = "SHAPE";
            pFieldEdit_SHAPE.Type_2 = esriFieldType.esriFieldTypeGeometry;
            pFieldEdit_SHAPE.GeometryDef_2 = geoDef;
            pFieldsEdit.AddField(Field_SHAPE);

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

            //正式创建要素类
            try
            {
                return MemoryWorkspace.CreateFeatureClass(name+"分布", pFields, ocDescription.ClassExtensionCLSID, ocDescription.ClassExtensionCLSID, esriFeatureType.esriFTSimple, fcDescription.ShapeFieldName, "");
            }
            //The table already exists. 清除数据重建
            catch (Exception e)
            {
                Console.WriteLine(e);
                IFeatureClass tmp = MemoryWorkspace.OpenFeatureClass(name+"分布");
                ITable pTable = tmp as ITable;
                pTable.DeleteSearchedRows(null);
                return tmp;
            }

        }


    }
}