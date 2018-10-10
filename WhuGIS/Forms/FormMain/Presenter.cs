using System;
using System.Drawing;
using System.Threading.Tasks;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using WeifenLuo.WinFormsUI.Docking;

namespace WhuGIS.Forms.FormMain
{
    /// <summary>
    /// 主窗体Presenter的实现类
    /// </summary>
    internal class Presenter : IMainPresenter
    {
        private IMainView MainView;

        internal Presenter(IMainView view)
        {
            MainView = view;
        }

        /// Override
        /// <summary>
        /// 加载Mxd文件并且显示
        /// </summary>
        /// <param name="file"></param>
        public void LoadMxdFile(string file)
        {
            //FormProgress.ShowDialog(MainView);
            if (MainView.Map.CheckMxFile(file))
            {
//                //异步执行耗时操作
//                Action load = () =>
//                {
//                    try
//                    {
//                        lock (MainView)
//                        {
//                            MainView.Map.LoadMxFile(file, 0, Type.Missing);
//                            MainView.StatusBarInfoSet(String.Format("文件 {0} 打开成功", file));
//                            MainView.SyncEagleView.Invoke();
//                        }                      
//                    }
//                    catch (Exception e)
//                    {
//                        MainView.ShowError(String.Format("打开文件:{0}发生错误\n{1}", file, e.ToString()));
//                    }
//                    finally
//                    {
//                        FormProgress.Dismiss();
//                    }
//                };
//
//                Task loadTask = new Task(load);
//                loadTask.Start();
                MainView.Map.LoadMxFile(file, 0, Type.Missing);
                MainView.StatusBarInfoSet(String.Format("文件 {0} 打开成功", file));
                MainView.SyncEagleView.Invoke();
     
            }
            else
            {
                //FormProgress.Dismiss();
                MainView.ShowMessage("可能这不是一个正确的Mxd文件?");   
            }

        }

        /// Override
        /// <summary>
        /// 加载Geodatabase数据库
        /// </summary>
        /// <param name="filename"></param>
        public void LoadMdbFile(string file)
        {
            ILayer pLayer = OpenGeoDatabaselayer(file);
            MainView.Map.AddLayer(pLayer);
            MainView.SyncEagleView.Invoke();
        }

        /// <summary>
        /// 打开某层Geo数据库
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private IFeatureLayer OpenGeoDatabaselayer(string file)
        {
            IWorkspaceFactory pWorkspaceFactory = new AccessWorkspaceFactory();
            IFeatureWorkspace pWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(file, 0);
            IFeatureClass pFeatureClass = pWorkspace.OpenFeatureClass("房屋");
            return new FeatureLayerClass()
            {
                FeatureClass= pFeatureClass,
            };   
        }

        /// Override
        /// <summary>
        /// 加载ShapeFile文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        public void LoadShapeFile(string filepath, string filename)
        {
            try
            {
                MainView.Map.AddShapeFile(filepath, filename);
                MainView.Map.Extent = MainView.Map.FullExtent;
                MainView.SyncEagleView.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        /// Override
        /// <summary>
        /// 保存文件为
        /// </summary>
        /// <param name="filepath"></param>
        public void SaveAs(string filepath)
        {
            try
            {
                IMapDocument pMapDocument = new MapDocumentClass();
                pMapDocument.New(filepath);
                pMapDocument.ReplaceContents(MainView.Map.Map as IMxdContents);
                pMapDocument.Save(true, true);
                pMapDocument.Close();
            }
            catch (Exception e)
            {
                MainView.ShowError("保存文件时遇到错误\n"+e.Message);
            }
        }

        #region 呼出其他窗体部分

        /// <summary>
        /// 呼出地图导出窗体 这个方法有一定的参数
        /// </summary>
        /// <param name="isAllRegion">是否是全域导出</param>
        public void CallOutFormExport(bool isAllRegion = true, IPolygon polygon = null)
        {
            var tmp=new FormExportMap.FormExportMap(MainView.Map);
            if (isAllRegion)
            {
                tmp.bRegion = false;
                tmp.pGeometry = MainView.Map.ActiveView.Extent;
            }
            else if (polygon != null) 
            {
                tmp.bRegion = true;
                tmp.pGeometry = polygon as IGeometry;
            }
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1,DockState.DockRight);
            tmp.DockPanel.DockRightPortion = 0.2;
        }

        public void CallOutFormAttr(IFeatureLayer layer)
        {
            var tmp = new FormAttr.FormAttr(layer);
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1, DockState.Float);
            tmp.DockPanel.DefaultFloatWindowSize=new Size(800,200);
        }

        public void CallOutFormPathSolve()
        {
            var tmp = new FormPathSolve.FormPathSolve(MainView.Map);
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1, DockState.DockRight);
            tmp.DockPanel.DockRightPortion = 0.2;
        }

        public void CallOutFormMonitor()
        {
            var tmp = new FormMonitor.FormMonitor(MainView.Map);
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1, DockState.DockRight);
            tmp.DockPanel.DockRightPortion = 0.2;
        }

        public void CallOutFormSchoolInfo()
        {
            var tmp = new FormSchoolInfo.FormSchoolInfo();
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1, DockState.DockRight);
            tmp.DockPanel.DockRightPortion = 0.2;
        }

        public void CallOutFormPhoto()
        {
            var tmp = new FormPhoto.FormPhoto(MainView.Map);
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1, DockState.DockRight);
            tmp.DockPanel.DockRightPortion = 0.2;
        }

        public void CallOutFormClassroomQuery()
        {
            var tmp = new FormClassroomQuery.FormClassroomQuery();
            tmp.Show(FormHolder.FormHolder.GetInstance.dockPanel1, DockState.Document);
        }
        #endregion
        
    }
}