using System;
using System.Windows.Forms;
using WhuGIS.Utils;

namespace WhuGIS.Forms.FormExportMap
{
    public class Presenter:IExportPresenter
    {
        private IExportView View;

        internal Presenter(IExportView view)
        {
            this.View = view;
        }

        public void ExportMap()
        {
            try
            {
                MapUtils.ExportView(View.pActiveView, View.pGeometry, View.resolution, View.width, View.height, View.pSavePath, View.bRegion);
                View.pActiveView.GraphicsContainer.DeleteAllElements();
                View.pActiveView.Refresh();
                View.ShowMessage("导出成功！");
                
            }
            catch (Exception e)
            {
                View.ShowError("导出失败！\n"+e.Message);
            }
        }
    }
}