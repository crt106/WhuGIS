using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using WhuGIS.ArcEngineTool.NetworkAnalysis;
using WhuGIS.ArcEngineTool.NetworkAnalysis.GetPathSolve;

namespace WhuGIS.Forms.FormPathSolve
{
    /// <summary>
    /// 相关方法解释见
    /// <see cref="ISolvePresenter"/>
    /// </summary>
    public class Presenter:ISolvePresenter
    {
        private ISolveView View;

        internal Presenter(ISolveView view)
        {
            this.View = view;
        }
        public void SetNetWorkDataset_GDBFolder()
        {
            View.SetNetWorkDataStatusText(false);
            var outTuple=new Tuple<string, string>("","");
            NetWorkAnalysClass.OutSourceGDBDatabasePath = View.OutGDBFolder;
            if (NetWorkAnalysClass.SearchForNetWorkData(NetWorkAnalysClass.OpenNetWorkDataType.GDBFolder,outTuple))
            {
                View.ShowMessage("网络数据集获取成功");
                View.DataBaseName = outTuple.Item1;
                View.DataSetname = outTuple.Item2;
                View.SetNetWorkDataStatusText(true);
            }
            else
            {
                View.ShowError("未找到合适的网络数据集！");
            }
        }

        public void SetNetWorkDataset_MDBFile()
        {
            View.SetNetWorkDataStatusText(false);
            if (NetWorkAnalysClass.SearchForNetWorkData(NetWorkAnalysClass.OpenNetWorkDataType.MDB))
            {
                View.ShowMessage("网络数据集获取成功");
                View.SetNetWorkDataStatusText(true);
            }
            else
            {
                View.ShowError("未找到合适的网络数据集！");
            }
        }

        public void SetNetWorkDataset_Shapfile()
        {
            View.SetNetWorkDataStatusText(false);
            if (NetWorkAnalysClass.SearchForNetWorkData(NetWorkAnalysClass.OpenNetWorkDataType.ShapeFile))
            {
                View.ShowMessage("网络数据集获取成功");
                View.SetNetWorkDataStatusText(true);
            }
            else
            {
                View.ShowError("未找到合适的网络数据集！");
            }
        }

        public void SetNetWorkDataset_Layers()
        {
            View.SetNetWorkDataStatusText(false);
            if (NetWorkAnalysClass.SearchForNetWorkData(NetWorkAnalysClass.OpenNetWorkDataType.Layers))
            {
                View.ShowMessage("网络数据集获取成功");
                View.SetNetWorkDataStatusText(true);
            }
            else
            {
                View.ShowError("未找到合适的网络数据集！");
            }
        }

        public void ClearPathResult()
        {
            ApplicationV.GlobalMapControl.CurrentTool = null;
            try
            {

                //打开工作空间
                IFeatureWorkspace pFWorkspace = NetWorkAnalysClass.MemoryWorkspace as IFeatureWorkspace;
                IGraphicsContainer pGrap = ApplicationV.GlobalMapControl.ActiveView as IGraphicsContainer;
                pGrap.DeleteAllElements();

                //删除所添加的图片要素
                IFeatureClass inputFClass = pFWorkspace.OpenFeatureClass("Stops");
                //删除站点要素
                if (inputFClass.FeatureCount(null) > 0)
                {
                    ITable pTable = inputFClass as ITable;
                    pTable.DeleteSearchedRows(null);
                }

                IFeatureClass barriesFClass = pFWorkspace.OpenFeatureClass("Barries"); //删除障碍点要素
                if (barriesFClass.FeatureCount(null) > 0)
                {
                    ITable pTable = barriesFClass as ITable;
                    pTable.DeleteSearchedRows(null);
                }

                for (int i = 0; i < ApplicationV.GlobalMapControl.LayerCount; i++) //删除分析结果
                {
                    ILayer pLayer = ApplicationV.GlobalMapControl.get_Layer(i);
                    if (pLayer.Name == ShortPathSolveCommand.m_NAContext.Solver.DisplayName)
                    {
                        ApplicationV.GlobalMapControl.DeleteLayer(i);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ApplicationV.GlobalMapControl.Refresh();
        }
    }
}
