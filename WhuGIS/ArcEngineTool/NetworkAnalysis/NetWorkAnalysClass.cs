using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.NetworkAnalyst;
using WhuGIS.Forms.FormMain;
using Label = System.Reflection.Emit.Label;

namespace WhuGIS.ArcEngineTool.NetworkAnalysis
{
    /// <summary>
    /// 网络分析工具类 因为此类基本不对外暴露
    /// 故没有归类进Utils
    /// <see cref="WhuGIS.ArcEngineTool.NetworkAnalysis.AddNetBarries">链接到添加障碍物工具</see>
    /// <see cref="WhuGIS.ArcEngineTool.NetworkAnalysis.AddNetStops">连接到添加站点工具</see>
    /// <see cref="WhuGIS.ArcEngineTool.NetworkAnalysis.GetPathSolve">连接到计算最短路径工具</see>
    /// </summary>
    static class NetWorkAnalysClass
    {
        
        #region 工作空间和数据集字段
        /// <summary>
        /// 外部GDB数据库文件目录
        /// </summary>
        public static string OutSourceGDBDatabasePath;

        /// <summary>
        /// MDB或者ShapFile数据库文件目录
        /// </summary>
        public static string MDBorSHP_FilePath;

        
        #endregion


        #region 本类提供的内存工作空间

        private static IWorkspaceFactory workspaceFactory;
        private static IWorkspaceName pWSName;
        private static IName pName;

        /// <summary>
        /// 打开工作空间修改... 这里三个Tool都用一个[内存]工作空间
        /// </summary>
        /// <param name="strGDBName"></param>
        /// <returns></returns>
        public static IWorkspace MemoryWorkspace
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
                return (IWorkspace)pName.Open();
            }
        }       
        #endregion

        #region 本类提供的网络数据集

        public static INetworkDataset NetWorkDataSet;

        #endregion

        


        /// <summary>
        /// 加载参与分析的点要素
        /// 按住Ctrl点击下行链接[Onclick]查看使用
        /// <see cref="WhuGIS.ArcEngineTool.NetworkAnalysis.GetPathSolve.ShortPathSolveCommand.OnClick"/>
        /// </summary>
        /// <param name="strNAClassName"></param>
        /// <param name="inputFC"></param>
        /// <param name="m_NAContext"></param>
        /// <param name="snapTolerance"></param>
        public static void LoadNANetworkLocations(string strNAClassName, IFeatureClass inputFC, INAContext m_NAContext,
            double snapTolerance)
        {
            ITable b1 = inputFC as ITable;
            int i1 = b1.RowCount(null);
            INAClass naClass;
            INamedSet classes;
            classes = m_NAContext.NAClasses;
            naClass = classes.get_ItemByName(strNAClassName) as INAClass;
            ITable b2 = naClass as ITable;
            int i2 = b2.RowCount(null);
            naClass.DeleteAllRows();
            ITable b3 = naClass as ITable;
            int i3 = b2.RowCount(null);
            INAClassLoader classLoader = new NAClassLoader();
            classLoader.Locator = m_NAContext.Locator;
            if (snapTolerance > 0) classLoader.Locator.SnapTolerance = snapTolerance; //设置容差
            classLoader.NAClass = naClass;

            //设置字段映射
            INAClassFieldMap fieldMap = null;
            fieldMap = new NAClassFieldMap();
            fieldMap.set_MappedField("FID", "FID");
            classLoader.FieldMap = fieldMap;
            int rowsIn = 0;
            int rowLocated = 0;
            IFeatureCursor featureCursor = inputFC.Search(null, true);
            classLoader.Load((ICursor) featureCursor, null, ref rowsIn, ref rowLocated);
            INAClass na = classLoader.NAClass;
            ITable b5 = na as ITable;
            int i5 = b2.RowCount(null);
            ITable b4 = inputFC as ITable;
            int i4 = b1.RowCount(null);

            ((INAContextEdit) m_NAContext).ContextChanged();
        }

        /// <summary>
        /// 根据网络数据集创建网络分析上下文
        /// </summary>
        /// <param name="networkDataset"></param>
        /// <returns></returns>
        public static INAContext CreatePathSolverContext(INetworkDataset networkDataset)
        {
            IDENetworkDataset deNDS = GetPathDENetworkDataset(networkDataset);
            INASolver naSolver;
            naSolver = new NARouteSolver();
            INAContextEdit contextEdit = naSolver.CreateContext(deNDS, naSolver.Name) as INAContextEdit;
            contextEdit.Bind(networkDataset, new GPMessagesClass());
            return contextEdit as INAContext;
        }
        private static IDENetworkDataset GetPathDENetworkDataset(INetworkDataset networkDataset)
        {
            IDatasetComponent dsComponent;
            dsComponent = networkDataset as IDatasetComponent;
            return dsComponent.DataElement as IDENetworkDataset;
        }
        

        //打开网络数据集 默认
        [Obsolete("书本上原来的弱智方法")]
        public static INetworkDataset OpenPathNetworkDataset(IWorkspace networkDatasetWorkspace,
            string networkDatasetName, string featureDatasetName)
        {
            if (networkDatasetWorkspace == null || networkDatasetName == "" || featureDatasetName == null)
            {
                return null;
            }
            IDatasetContainer3 datasetContainer3 = null;
            IFeatureWorkspace featureWorkspace = networkDatasetWorkspace as IFeatureWorkspace;
            IFeatureDataset featureDataset;
            featureDataset = featureWorkspace.OpenFeatureDataset(featureDatasetName);
            IFeatureDatasetExtensionContainer featureDatasetExtensionContainer =
                featureDataset as IFeatureDatasetExtensionContainer;
            IFeatureDatasetExtension featureDatasetExtension =
                featureDatasetExtensionContainer.FindExtension(esriDatasetType.esriDTNetworkDataset);
            datasetContainer3 = featureDatasetExtension as IDatasetContainer3;
            if (datasetContainer3 == null)
                return null;
            IDataset dataset =
                datasetContainer3.get_DatasetByName(esriDatasetType.esriDTNetworkDataset, networkDatasetName);
            return dataset as INetworkDataset;
        }


        /// <summary>
        /// 创建指定名称的FeatureClass 适用于创建Stops和Barriers
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="name"></param>
        /// <param name="spatialReference">与主窗体上的axMapcontrol的连接吧...</param>
        public static IFeatureClass CreateFeatureClass(IFeatureWorkspace workspace, string name, ISpatialReference spatialReference = null)
        {
            if(spatialReference == null)
            spatialReference = ApplicationV.GlobalMapControl.ActiveView.FocusMap.SpatialReference;

            //创建字段集
            IFeatureClassDescription fcDescription = new FeatureClassDescriptionClass();
            IObjectClassDescription ocDescription = (IObjectClassDescription)fcDescription;

            //创建字段组
            IFields pFields = new FieldsClass ();
            IFieldsEdit pFieldsEdit = (IFieldsEdit) pFields;

            IField Field_OID = new FieldClass();
            IFieldEdit Field_OID_EDIT = Field_OID as IFieldEdit;
            Field_OID_EDIT.Name_2 = "OBJECTID";
            Field_OID_EDIT.Type_2 = esriFieldType.esriFieldTypeOID;
            Field_OID_EDIT.IsNullable_2 = false;
            Field_OID_EDIT.Required_2 = false;
            pFieldsEdit.AddField(Field_OID);

            //创建一个必要的东西          
            IGeometryDef geoDef = new GeometryDefClass();
            IGeometryDefEdit geoDefEdit = (IGeometryDefEdit) geoDef;
            geoDefEdit.AvgNumPoints_2 = 5;
            geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            geoDefEdit.GridCount_2 = 1;
            geoDefEdit.HasM_2 = false;
            geoDefEdit.HasZ_2 = false;
            geoDefEdit.SpatialReference_2 = spatialReference;


            //创建SHAPE字段
            IField Field_SHAPE = new FieldClass();
            IFieldEdit pFieldEdit_SHAPE = (IFieldEdit)Field_SHAPE;
            pFieldEdit_SHAPE.Name_2 = "SHAPE";
            pFieldEdit_SHAPE.Type_2 = esriFieldType.esriFieldTypeGeometry;
            pFieldEdit_SHAPE.GeometryDef_2 = geoDef;

            //放入组
            pFieldsEdit.AddField(Field_SHAPE);


            //正式创建要素类
            return workspace.CreateFeatureClass(name, pFields, ocDescription.ClassExtensionCLSID, ocDescription.ClassExtensionCLSID, esriFeatureType.esriFTSimple, fcDescription.ShapeFieldName, "");
        }


        /// <summary>
        /// 打开NetWorkDataType的方式
        /// </summary>
        public enum OpenNetWorkDataType
        {
            GDBFolder,
            MDB,
            ShapeFile,
            Layers,
        }
        /// <summary>
        /// 搜寻合适的NetWorkDataSet
        /// </summary>
        /// <returns></returns>
        public static bool SearchForNetWorkData(OpenNetWorkDataType type,Tuple<string,string> OutParas = null)
        {

            switch (type)
            {
                #region 以GDB形式打开NetworkData
                case (OpenNetWorkDataType.GDBFolder):
                {
                    //遍历GDB 
                    IWorkspaceFactory m_pWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
                    IWorkspace pCarWorkspace = m_pWorkspaceFactory.OpenFromFile(OutSourceGDBDatabasePath, 0);
                    return SearchInDataBase(pCarWorkspace);
                }  
                #endregion

                #region 以MDB方式打开NetworkData

                case (OpenNetWorkDataType.MDB):
                {
                    //遍历MDB
                    IWorkspaceFactory pWSFact = new AccessWorkspaceFactoryClass();
                    IWorkspace pWor = pWSFact.OpenFromFile(MDBorSHP_FilePath, 0);
                    return SearchInDataBase(pWor);
                }
                #endregion

                #region 以ShapFile方式打开NetworkData
             
                //其实就是添加一个图层到主地图中 然后再在图层中搜索
                case (OpenNetWorkDataType.ShapeFile):
                {
                    
                    string fileFolder= System.IO.Path.GetDirectoryName(MDBorSHP_FilePath);
                    string filename=System.IO.Path.GetFileNameWithoutExtension(MDBorSHP_FilePath);
                    ApplicationV.GlobalMapControl.AddShapeFile(fileFolder,filename);
                    return SearchInLayers();
                }
                    

                #endregion

                #region 在Layers中搜寻

                     
                case (OpenNetWorkDataType.Layers):
                {
                    return SearchInLayers();  
                }                   
                #endregion
                
            }
            return false;
        }

        /// <summary>
        /// 子方法 在数据库中寻找网络数据集
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        private static bool SearchInDataBase(IWorkspace workspace)
        {

            //获取全部的数据库
            IEnumDataset FeatureEnumDataset = workspace.get_Datasets(esriDatasetType.esriDTFeatureDataset);

            if (FeatureEnumDataset == null)
            {
                return false;
            }
            FeatureEnumDataset.Reset();

            //获取下一个数据库
            IDataset pDataset = FeatureEnumDataset.Next();

            while (pDataset is IFeatureDataset)
            {

                //试图遍历该数据集合里的所有子数据
                try
                {
                    IEnumDataset SubDataset = pDataset.Subsets;
                    var pFeatureObject = SubDataset.Next();
                    while (pFeatureObject != null)
                    {
                        //如果找到了NetworkDataset
                        if (pFeatureObject is INetworkDataset)
                        {
                            string datasetname = pFeatureObject.Name;
                            //询问是否使用这个DataSet
                            if (MessageBox.Show(String.Format("找到一个合适的网络数据集:{0},是否使用", datasetname), "提示",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                NetWorkDataSet = pFeatureObject as INetworkDataset;
                                //OutParas = new Tuple<string, string>(pDataset.Name, datasetname);
                                return true;
                            }
                        }
                        pFeatureObject = SubDataset.Next();
                    }
                }
                catch
                {

                }
                //寻找下一个数据集
                pDataset = FeatureEnumDataset.Next();
            }
            return false;
        }
        /// <summary>
        /// 子方法 在图层中寻找网络数据集
        /// </summary>
        /// <returns></returns>
        private static bool SearchInLayers()
        {
            IMap iMap = ApplicationV.GlobalMapControl.ActiveView.FocusMap;
            for (int i = 0; i < iMap.LayerCount; i++)
            {
                ILayer ipLayer = iMap.get_Layer(i);
                INetworkLayer iNetworkLayer=ipLayer as INetworkLayer;
                if (iNetworkLayer != null)
                {
                    string datasetname = ipLayer.Name;
                    //询问是否使用这个DataSet
                    if (MessageBox.Show(String.Format("找到一个合适的网络数据集:{0},是否使用", datasetname), "提示",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        NetWorkDataSet = iNetworkLayer.NetworkDataset;
                        return true;
                    }    
                }
            }

            return false;
        }
    }
}
