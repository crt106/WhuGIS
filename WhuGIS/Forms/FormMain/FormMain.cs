using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using WeifenLuo.WinFormsUI.Docking;
using WhuGIS.BaseInterface;
using WhuGIS.Utils;
using Point = ESRI.ArcGIS.Geometry.Point;

namespace WhuGIS.Forms.FormMain
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class FormMain : DockContent , IMainView
    {
        //与Presenter的连接
        private IMainPresenter presenter;

        #region 实现接口

        public Form FormInstance
        {
            get { return this; }
        } 

        public AxMapControl Map {
            get { return axMapControl;}
            
         }

        public AxMapControl Eagle
        {
            get { return EagleEyeMapControl; }
        }

        public AxTOCControl TocControl
        {
            get { return axTOCControl; }
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

        public void StatusBarInfoSet(string msg)
        {
            //线程安全的调用方法
            statusStrip1.Invoke(new Action(() => { statusStrip1.Text = msg;}));
        }

        public Action SyncEagleView
        {
            get { return () => SynchronizeEagleEye(); }
        }

        #endregion

        public FormMain()
        {
            InitializeComponent();
            presenter=new Presenter(this);
            //赋值到全局变量
            ApplicationV.GlobalMapControl = this.Map;
            ApplicationV.GlobalTocControl = this.TocControl;
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        private void ClearAllData()
        {
            if (Map.Map != null && Map.Map.LayerCount > 0)
            {
                //新建mainMapControl中Map
                IMap dataMap = new MapClass();
                dataMap.Name = "Map";
                Map.DocumentFilename = string.Empty;
                Map.Map = dataMap;

                //新建EagleEyeMapControl中Map
                IMap eagleEyeMap = new MapClass();
                eagleEyeMap.Name = "eagleEyeMap";
                EagleEyeMapControl.DocumentFilename = string.Empty;
                EagleEyeMapControl.Map = eagleEyeMap;
            }
        }

        #region 文件操作

        //打开mxd地图文件
        private void ToolStripMenuItem_Openmxd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op=new OpenFileDialog();
                op.Filter = "mxd文件|*.mxd";
                op.Multiselect = false;
                if (op.ShowDialog() == DialogResult.OK)
                {
                    ClearAllData();
                    presenter.LoadMxdFile(op.FileName);  
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }        
        }

        //打开Mdb文件
        private void ToolStripMenuItem_OpenGDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "mdb文件|*.mdb";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
                ClearAllData();
                presenter.LoadMdbFile(op.FileName);
            }  
        }

        //打开ShapeFile
        private void ToolStripMenuItem_OpenShapfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "shapefile文件|*.shp";
            op.Multiselect = false;
            if (op.ShowDialog() == DialogResult.OK)
            {
//              ClearAllData();
                string path=System.IO.Path.GetDirectoryName(op.FileName);
                presenter.LoadShapeFile(path,op.SafeFileName.Split('.')[0]);
            } 
        }

        //文件另存为
        private void ToolStripMenuItem_SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog pSaveFileDialog = new SaveFileDialog();
            pSaveFileDialog.Title = "另存为";
            pSaveFileDialog.OverwritePrompt = true;
            pSaveFileDialog.Filter = "ArcMap文档（*.mxd）|*.mxd|ArcMap模板（*.mxt）|*.mxt";
            pSaveFileDialog.RestoreDirectory = true;
            if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = pSaveFileDialog.FileName;
                presenter.SaveAs(sFilePath);
            }         
        }

        //全域导出
        private void ToolStripMenuItem_全域导出_Click(object sender, EventArgs e)
        {
            if (Map != null && !Map.IsDisposed)
            {
                presenter.CallOutFormExport();
            }
            else
            {
                ShowError("地图为空");
            }
        }

        //区域导出
        private string pMouseOperate;                     //鼠标操作

        private void ToolStripMenuItem_区域导出_Click(object sender, EventArgs e)
        {
            Map.CurrentTool = null;
            Map.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            pMouseOperate = "ExportRegion";  
        }

        #endregion


        #region 鹰眼操作

        //鹰眼同步
        private bool bCanDrag;              //鹰眼地图上的矩形框可移动的标志
        private IPoint pMoveRectPoint;      //记录在移动鹰眼地图上的矩形框时鼠标的位置
        private IEnvelope pEnv;             //记录数据视图的Extent

        /// <summary>
        /// 同步鹰眼
        /// </summary>
        private void SynchronizeEagleEye()
        {
            try
            {
                if (EagleEyeMapControl.LayerCount > 0)
                {
                    EagleEyeMapControl.ClearLayers();
                }
                //设置鹰眼和主地图的坐标系统一致
                EagleEyeMapControl.SpatialReference = Map.SpatialReference;
                for (int i = Map.LayerCount - 1; i >= 0; i--)
                {
                    //使鹰眼视图与数据视图的图层上下顺序保持一致
                    ILayer pLayer = Map.get_Layer(i);
                    if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                    {
                        ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                        for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                        {
                            ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                            IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                            if (pFeatureLayer != null)
                            {
                                //由于鹰眼地图较小，所以过滤点图层不添加
                                if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                                    && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                                {
                                    EagleEyeMapControl.AddLayer(pLayer);
                                }
                            }
                        }
                    }
                    else
                    {
                        IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                                && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                            {
                                EagleEyeMapControl.AddLayer(pLayer);
                            }
                        }
                    }

                    //设置鹰眼地图全图显示  
                    EagleEyeMapControl.Extent = Map.FullExtent;
                    pEnv = Map.Extent as IEnvelope;
                    DrawRectangle(pEnv);
                    EagleEyeMapControl.ActiveView.Refresh();
                }
            }
            catch (Exception e)
            {
                ShowError("鹰眼地图刷新失败\n"+e.Message);
            }
        }

        /// <summary>
        /// 在鹰眼地图上面画矩形框
        /// </summary>
        /// <param name="pEnvelope"></param>
        private void DrawRectangle(IEnvelope pEnvelope)
        {
            //在绘制前，清除鹰眼中之前绘制的矩形框
            IGraphicsContainer pGraphicsContainer = EagleEyeMapControl.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            //得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            //设置矩形框（实质为中间透明度面）
            IRgbColor pColor = new RgbColorClass();
            pColor = ColorUtils.GetRgbColor(255, 0, 0);
            pColor.Transparency = 255;
            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 2;
            pOutLine.Color = pColor;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            //向鹰眼中添加矩形框
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement) pFillShapeElement, 0);
            //刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        #endregion


        #region 主地图控件事件

        //加载地图时同步鹰眼
        private void axMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
        }

        //视图改变时同步
        private void axMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //得到当前视图范围
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        //地图漫游
        private void axMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            switch (e.button)
            {
                case (4):
                {
                    Map.Pan();
                    break;
                }           
            }
        }

        #endregion


        #region 鹰眼地图控件事件

        //鼠标按下
        private void EagleEyeMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            try
            {
                if (EagleEyeMapControl.Map.LayerCount > 0)
                {
                    //按下鼠标左键移动矩形框
                    if (e.button == 1)
                    {
                        //如果指针落在鹰眼的矩形框中，标记可移动
                        if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
                        {
                            bCanDrag = true;
                        }
                        pMoveRectPoint = new PointClass();
                        pMoveRectPoint.PutCoords(e.mapX, e.mapY);  //记录点击的第一个点的坐标
                    }
                    //按下鼠标右键绘制矩形框
                    else if (e.button == 2)
                    {
                        IEnvelope pEnvelope = EagleEyeMapControl.TrackRectangle();

                        IPoint pTempPoint = new PointClass();
                        pTempPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);
                        Map.Extent = pEnvelope;
                        //矩形框的高宽和数据试图的高宽不一定成正比，这里做一个中心调整
                        Map.CenterAt(pTempPoint);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception); 
            }
        }
        //鼠标移动中 移动矩形框
        private void EagleEyeMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (pEnv != null && e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
            {
                //如果鼠标移动到矩形框中，鼠标换成小手，表示可以拖动
                EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerHand;
                if (e.button == 2) //如果在内部按下鼠标右键，将鼠标演示设置为默认样式
                {
                    EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
                }
            }
            else
            {
                //在其他位置将鼠标设为默认的样式
                EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }

            if (bCanDrag)
            {
                double Dx, Dy;  //记录鼠标移动的距离
                Dx = e.mapX - pMoveRectPoint.X;
                Dy = e.mapY - pMoveRectPoint.Y;
                pEnv.Offset(Dx, Dy); //根据偏移量更改 pEnv 位置
                pMoveRectPoint.PutCoords(e.mapX, e.mapY);
                DrawRectangle(pEnv);
                Map.Extent = pEnv;
            }
        }

        private void EagleEyeMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {

            if (e.button == 1 && pMoveRectPoint != null)
            {
                if (e.mapX == pMoveRectPoint.X && e.mapY == pMoveRectPoint.Y)
                {
                    Map.CenterAt(pMoveRectPoint);
                }
                bCanDrag = false;
            }
        }

        #endregion


        #region TOC右键菜单的添加及功能实现

        private Point pMoveLayerPoint = new Point();      //鼠标在TOC中左键按下时点的位置
        private ILayer pMoveLayer;                        //需要调整显示顺序的图层
        private IFeatureLayer pTocFeatureLayer;           //选中的特征图层
        private int toIndex;                              //存放拖动图层移动到的索引号   

        //TOC右键菜单的添加
        private void axTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            try
            {
                //按下右键根据所选内容弹出菜单
                if (e.button == 2)
                {
                    esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                    IBasicMap pMap = null;
                    ILayer pLayer = null;
                    object unk = null;
                    object data = null;
                    axTOCControl.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                    pTocFeatureLayer = pLayer as IFeatureLayer;
                    if (pItem == esriTOCControlItem.esriTOCControlItemLayer && pTocFeatureLayer != null)
                    {
                        TocContextMenu.Show(Control.MousePosition);
                    }
                }
                //按下左键准备移动图层
                if (e.button == 1)
                {
                    esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                    IBasicMap pMap = null; object unk = null;
                    object data = null; ILayer pLayer = null;
                    axTOCControl.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                    if (pLayer == null) return;

                    pMoveLayerPoint.PutCoords(e.x, e.y);
                    if (pItem == esriTOCControlItem.esriTOCControlItemLayer)
                    {
                        if (pLayer is IAnnotationSublayer)
                        {
                            return;
                        }
                        else
                        {
                            pMoveLayer = pLayer;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void axTOCControl_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            try
            {
                if (e.button == 1 && pMoveLayer != null && pMoveLayerPoint.Y != e.y)
                {
                    esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                    IBasicMap pBasicMap = null; object unk = null;
                    object data = null; ILayer pLayer = null;
                    axTOCControl.HitTest(e.x, e.y, ref pItem, ref pBasicMap, ref pLayer, ref unk, ref data);
                    IMap pMap = Map.ActiveView.FocusMap;
                    if (pItem == esriTOCControlItem.esriTOCControlItemLayer || pLayer != null)
                    {
                        if (pMoveLayer != pLayer)
                        {
                            ILayer pTempLayer;
                            //获得鼠标弹起时所在图层的索引号
                            for (int i = 0; i < pMap.LayerCount; i++)
                            {
                                pTempLayer = pMap.get_Layer(i);
                                if (pTempLayer == pLayer)
                                {
                                    toIndex = i;
                                }
                            }
                        }
                    }
                    //移动到最前面
                    else if (pItem == esriTOCControlItem.esriTOCControlItemMap)
                    {
                        toIndex = 0;
                    }
                    //移动到最后面
                    else if (pItem == esriTOCControlItem.esriTOCControlItemNone)
                    {
                        toIndex = pMap.LayerCount - 1;
                    }
                    pMap.MoveLayer(pMoveLayer, toIndex);
                    Map.ActiveView.Refresh();
                    axTOCControl.Update();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //打开属性表
        private void MenuSeeAttr_Click(object sender, EventArgs e)
        {
            if (pTocFeatureLayer == null)
            {
                return;
            }
            presenter.CallOutFormAttr(pTocFeatureLayer);
        }
       
        #endregion


        #region 数据分析操作

        private void ToolStripMenuItem_最短路径分析_Click(object sender, EventArgs e)
        {
            presenter.CallOutFormPathSolve();
        }

        #endregion

        #region 信息查询操作

       
        //呼出摄像头范围分析窗体
        private void 摄像头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.CallOutFormMonitor();
        }

        #endregion

        

        

        

        

        

        



    }
}
