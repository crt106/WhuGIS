using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace WhuGIS.ArcEngineTool.NetworkAnalysis.AddNetBarries
{
    /// <summary>
    /// Summary description for AddNetBarriesTool.
    /// 最短路径分析-添加障碍物工具
    /// </summary>
    public sealed class AddNetBarriesTool : BaseTool
    {      
        private IHookHelper m_hookHelper = null;
        private IFeatureWorkspace pFWorkspace;
        private IFeatureClass barriesFClass;
        string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        public AddNetBarriesTool()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "NetWorkAnalysClass";   
            base.m_caption = "添加障碍点";              
            base.m_message = "在地图上添加障碍点";   
            base.m_toolTip = "添加障碍点";              
            base.m_name = "AddBarriesTool";          //唯一ID, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
            pFWorkspace = NetWorkAnalysClass.MemoryWorkspace as IFeatureWorkspace;
            //如果未建立FeatureClass 则创建
            try
            {
                barriesFClass = pFWorkspace.OpenFeatureClass("Barries");
            }
            catch (Exception e)
            {

                barriesFClass = NetWorkAnalysClass.CreateFeatureClass(pFWorkspace, "Barries");
            }
        }

        /// <summary>
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add AddNetBarriesTool.OnClick implementation
            

            if (barriesFClass.FeatureCount(null) > 0)
            {
                ITable pTable = barriesFClass as ITable;
                pTable.DeleteSearchedRows(null);
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add AddNetBarriesTool.OnMouseDown implementation
            try
            {
                IPoint pStopsPoint = new PointClass();
                pStopsPoint = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);

                IFeature newPointFeature = barriesFClass.CreateFeature();
                try
                {
                    newPointFeature.Shape = pStopsPoint;
                }
                catch
                {
                    IGeometry pGeo = pStopsPoint;
                    IZAware pZAware = pGeo as IZAware;
                    pZAware.ZAware = false;

                    newPointFeature.Shape = pGeo;
                }
                newPointFeature.Store();

                IGraphicsContainer pGrap = m_hookHelper.ActiveView as IGraphicsContainer;
                IColor pColor;
                IRgbColor pRgbColor = new RgbColorClass();
                pRgbColor.Red = 255;
                pRgbColor.Green = 255;
                pRgbColor.Blue = 255;
                pColor = pRgbColor as IColor;
                IPictureMarkerSymbol pms = new PictureMarkerSymbolClass();
                pms.BitmapTransparencyColor = pColor;

                //添加自定义障碍点图片
                pms.CreateMarkerSymbolFromFile(esriIPictureType.esriIPictureBitmap, ApplicationV.Data_ImgPath+"\\barries.bmp");
                
                pms.Size = 18;
                IMarkerElement pMarkerEle = new MarkerElementClass();
                pMarkerEle.Symbol = pms as IMarkerSymbol;
                pStopsPoint.SpatialReference = m_hookHelper.ActiveView.FocusMap.SpatialReference;
                IElement pEle = pMarkerEle as IElement;
                pEle.Geometry = pStopsPoint;
                pGrap.AddElement(pEle, 1);
                m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
            catch
            {
                MessageBox.Show("障碍点添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add AddNetBarriesTool.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add AddNetBarriesTool.OnMouseUp implementation
        }
        #endregion
    }
}
