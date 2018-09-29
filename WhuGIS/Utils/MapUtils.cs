using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;

namespace WhuGIS.Utils
{
    public class MapUtils
    {
        /// <summary>
        /// 获取地图单位
        /// </summary>
        /// <param name="_esriMapUnit"></param>
        /// <returns></returns>
        public static string GetMapUnit(esriUnits _esriMapUnit)
        {
            string sMapUnits = string.Empty;
            switch (_esriMapUnit)
            {
                case esriUnits.esriCentimeters:
                    sMapUnits = "厘米";
                    break;
                case esriUnits.esriDecimalDegrees:
                    sMapUnits = "十进制";
                    break;
                case esriUnits.esriDecimeters:
                    sMapUnits = "分米";
                    break;
                case esriUnits.esriFeet:
                    sMapUnits = "尺";
                    break;
                case esriUnits.esriInches:
                    sMapUnits = "英寸";
                    break;
                case esriUnits.esriKilometers:
                    sMapUnits = "千米";
                    break;
                case esriUnits.esriMeters:
                    sMapUnits = "米";
                    break;
                case esriUnits.esriMiles:
                    sMapUnits = "英里";
                    break;
                case esriUnits.esriMillimeters:
                    sMapUnits = "毫米";
                    break;
                case esriUnits.esriNauticalMiles:
                    sMapUnits = "海里";
                    break;
                case esriUnits.esriPoints:
                    sMapUnits = "点";
                    break;
                case esriUnits.esriUnitsLast:
                    sMapUnits = "UnitsLast";
                    break;
                case esriUnits.esriUnknownUnits:
                    sMapUnits = "未知单位";
                    break;
                case esriUnits.esriYards:
                    sMapUnits = "码";
                    break;
                default:
                    break;
            }
            return sMapUnits;
        }

        /// <summary>
        /// 绘制多边形
        /// </summary>
        /// <param name="mapCtrl"></param>
        /// <returns></returns>
        public static IPolygon DrawPolygon(AxMapControl mapCtrl)
        {
            IGeometry pGeometry = null;
            if (mapCtrl == null) return null;
            IRubberBand rb = new RubberPolygonClass();
            pGeometry = rb.TrackNew(mapCtrl.ActiveView.ScreenDisplay, null);
            return pGeometry as IPolygon;
        }


        /// <summary>
        /// 加载工作空间里面的要素和栅格数据
        /// </summary>
        /// <param name="pWorkspace"></param>
        public static void AddAllDataset(IWorkspace pWorkspace, AxMapControl mapControl)
        {
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //将Enum数据集中的数据一个个读到DataSet中
            IDataset pDataset = pEnumDataset.Next();
            //判断数据集是否有数据
            while (pDataset != null)
            {
                if (pDataset is IFeatureDataset)  //要素数据集
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    IEnumDataset pEnumDataset1 = pFeatureDataset.Subsets;
                    pEnumDataset1.Reset();
                    IGroupLayer pGroupLayer = new GroupLayerClass();
                    pGroupLayer.Name = pFeatureDataset.Name;
                    IDataset pDataset1 = pEnumDataset1.Next();
                    while (pDataset1 != null)
                    {
                        if (pDataset1 is IFeatureClass)  //要素类
                        {
                            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);
                            if (pFeatureLayer.FeatureClass != null)
                            {
                                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                                pGroupLayer.Add(pFeatureLayer);
                                mapControl.Map.AddLayer(pFeatureLayer);
                            }
                        }
                        pDataset1 = pEnumDataset1.Next();
                    }
                }
                else if (pDataset is IFeatureClass) //要素类
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);

                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mapControl.Map.AddLayer(pFeatureLayer);
                }
                else if (pDataset is IRasterDataset) //栅格数据集
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //影像金字塔判断与创建
                    IRasterPyramid3 pRasPyrmid;
                    pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    if (pRasPyrmid != null)
                    {
                        if (!(pRasPyrmid.Present))
                        {
                            pRasPyrmid.Create(); //创建金字塔
                        }
                    }
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    ILayer pLayer = pRasterLayer as ILayer;
                    mapControl.AddLayer(pLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }

            mapControl.ActiveView.Refresh();  
        }



        public static void ExportView(IActiveView view, IGeometry pGeo, int OutputResolution, int Width, int Height, string ExpPath, bool bRegion)
        {
            IExport pExport = null;
            tagRECT exportRect = new tagRECT();
            IEnvelope pEnvelope = pGeo.Envelope;
            string sType = System.IO.Path.GetExtension(ExpPath);
            switch (sType)
            {
                case ".jpg":
                    pExport = new ExportJPEGClass();
                    break;
                case ".bmp":
                    pExport = new ExportBMPClass();
                    break;
                case ".gif":
                    pExport = new ExportGIFClass();
                    break;
                case ".tif":
                    pExport = new ExportTIFFClass();
                    break;
                case ".png":
                    pExport = new ExportPNGClass();
                    break;
                case ".pdf":
                    pExport = new ExportPDFClass();
                    break;
                default:
                    MessageBox.Show("没有输出格式，默认到JPEG格式");
                    pExport = new ExportJPEGClass();
                    break;
            }
            pExport.ExportFileName = ExpPath;

            exportRect.left = 0; exportRect.top = 0;
            exportRect.right = Width;
            exportRect.bottom = Height;
            if (bRegion)
            {
                view.GraphicsContainer.DeleteAllElements();
                view.Refresh();
            }
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords((double)exportRect.left, (double)exportRect.top, (double)exportRect.right, (double)exportRect.bottom);
            pExport.PixelBounds = envelope;
            view.Output(pExport.StartExporting(), OutputResolution, ref exportRect, pEnvelope, null);
            pExport.FinishExporting();
            pExport.Cleanup();
        }


        /// <summary>
        /// 全域导出
        /// </summary>
        /// <param name="OutputResolution">输出分辨率</param>
        /// <param name="ExpPath">输出路径</param>
        /// <param name="view">视图</param>
        public static void ExportActiveView(int OutputResolution, string ExpPath, IActiveView view)
        {
            IExport pExport = null;
            tagRECT exportRect;
            IEnvelope envelope2 = view.Extent;
            int num = (int)Math.Round(view.ScreenDisplay.DisplayTransformation.Resolution);
            string sType = System.IO.Path.GetExtension(ExpPath);
            switch (sType)
            {
                case ".jpg":
                    pExport = new ExportJPEGClass();
                    break;
                case ".bmp":
                    pExport = new ExportBMPClass();
                    break;
                case ".gif":
                    pExport = new ExportGIFClass();
                    break;
                case ".tif":
                    pExport = new ExportTIFFClass();
                    break;
                case ".png":
                    pExport = new ExportPNGClass();
                    break;
                case ".pdf":
                    pExport = new ExportPDFClass();
                    break;
                default:
                    MessageBox.Show("没有输出格式，默认到JPEG格式");
                    pExport = new ExportJPEGClass();
                    break;
            }
            pExport.ExportFileName = ExpPath;
            exportRect.left = 0; exportRect.top = 0;
            exportRect.right = (int)Math.Round((double)(view.ExportFrame.right * (((double)OutputResolution) / ((double)num))));
            exportRect.bottom = (int)Math.Round((double)(view.ExportFrame.bottom * (((double)OutputResolution) / ((double)num))));
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords((double)exportRect.left, (double)exportRect.top, (double)exportRect.right, (double)exportRect.bottom);
            pExport.PixelBounds = envelope;
            view.Output(pExport.StartExporting(), OutputResolution, ref exportRect, envelope2, null);
            pExport.FinishExporting();
            pExport.Cleanup();
        }


        /// <summary>
        /// 区域导出
        /// </summary>
        /// <param name="pGeo">几何图形</param>
        /// <param name="OutputResolution">输出分辨率</param>
        /// <param name="ExpPath">输出路径</param>
        /// <param name="view">视图</param>
        public static void ExportRegion(IGeometry pGeo, int OutputResolution, string ExpPath, IActiveView view)
        {
            IExport export = null;
            IWorldFileSettings settings = null;
            IEnvelope envelope2 = pGeo.Envelope;
            string str = ExpPath.Substring(ExpPath.Length - 3, 3).ToUpper();
            switch (str)
            {
                case "JPG":
                    settings = new ExportJPEGClass();
                    export = new ExportJPEGClass();
                    settings = export as IWorldFileSettings; ;
                    settings.MapExtent = envelope2;
                    settings.OutputWorldFile = false;
                    break;
                case "BMP":
                    settings = new ExportBMPClass();
                    export = new ExportBMPClass();
                    settings = export as IWorldFileSettings; ;
                    settings.MapExtent = envelope2;
                    settings.OutputWorldFile = false;
                    break;
                case "TIF":
                    settings = new ExportTIFFClass();
                    export = new ExportTIFFClass();
                    settings = export as IWorldFileSettings; ;
                    settings.MapExtent = envelope2;
                    settings.OutputWorldFile = false;
                    break;
                case "PNG":
                    settings = new ExportPNGClass();
                    export = new ExportPNGClass();
                    settings = export as IWorldFileSettings;
                    settings.MapExtent = envelope2;
                    settings.OutputWorldFile = false;
                    break;
                default:
                    break;
            }
            if (settings == null) return;
            export.ExportFileName = ExpPath;
            int num = (int)Math.Round(view.ScreenDisplay.DisplayTransformation.Resolution);
            tagRECT grect2 = new tagRECT();
            IEnvelope envelope3 = new EnvelopeClass();
            view.ScreenDisplay.DisplayTransformation.TransformRect(envelope2, ref grect2, 9);
            grect2.left = 0;
            grect2.top = 0;
            grect2.right = (int)Math.Round((double)((grect2.right - grect2.left) * (((double)OutputResolution) / ((double)num))));
            grect2.bottom = (int)Math.Round((double)((grect2.bottom - grect2.top) * (((double)OutputResolution) / ((double)num))));
            envelope3.PutCoords((double)grect2.left, (double)grect2.top, (double)grect2.right, (double)grect2.bottom);
            export.PixelBounds = envelope3;

            view.GraphicsContainer.DeleteAllElements();
            view.Output(export.StartExporting(), OutputResolution, ref grect2, envelope2, null);
            export.FinishExporting();
            export.Cleanup();
            AddElement(pGeo, view);
        }


        /// <summary>
        /// 视图窗口绘制几何图形元素
        /// </summary>
        /// <param name="pGeometry">几何图形</param>
        /// <param name="activeView">视图</param>
        public static void AddElement(IGeometry pGeometry, IActiveView activeView)
        {
            IRgbColor fillColor = ColorUtils.GetRgbColor(204, 175, 235);
            IRgbColor lineColor = ColorUtils.GetRgbColor(0, 0, 0);
            IElement pEle = CreateElement(pGeometry, lineColor, fillColor);
            IGraphicsContainer pGC = activeView.GraphicsContainer;
            if (pGC != null)
            {
                pGC.AddElement(pEle, 0);
                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pEle, null);
            }
        }


        /// <summary>
        /// 创建图形元素
        /// </summary>
        /// <param name="pGeometry">几何图形</param>
        /// <param name="lineColor">边框颜色</param>
        /// <param name="fillColor">填充颜色</param>
        /// <returns></returns>
        private static IElement CreateElement(IGeometry pGeometry, IRgbColor lineColor, IRgbColor fillColor)
        {
            if (pGeometry == null || lineColor == null || fillColor == null)
            {
                return null;
            }
            IElement pElem = null;
            try
            {
                if (pGeometry is IEnvelope)
                    pElem = new RectangleElementClass();
                else if (pGeometry is IPolygon)
                    pElem = new PolygonElementClass();
                else if (pGeometry is ICircularArc)
                {
                    ISegment pSegCircle = pGeometry as ISegment;//QI
                    ISegmentCollection pSegColl = new PolygonClass();
                    object o = Type.Missing;
                    pSegColl.AddSegment(pSegCircle, ref o, ref o);
                    IPolygon pPolygon = pSegColl as IPolygon;
                    pGeometry = pPolygon as IGeometry;
                    pElem = new CircleElementClass();
                }
                else if (pGeometry is IPolyline)
                    pElem = new LineElementClass();

                if (pElem == null)
                    return null;
                pElem.Geometry = pGeometry;
                IFillShapeElement pFElem = pElem as IFillShapeElement;
                ISimpleFillSymbol pSymbol = new SimpleFillSymbolClass();
                pSymbol.Color = fillColor;
                pSymbol.Outline.Color = lineColor;
                pSymbol.Style = esriSimpleFillStyle.esriSFSCross;
                if (pSymbol == null)
                {
                    return null;
                }
                pFElem.Symbol = pSymbol;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return pElem;
        }
    }
}