using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using WhuGIS.BaseInterface;

namespace WhuGIS.Forms.FormExportMap
{
    public interface IExportView:IBaseView
    {
        string pSavePath { get; set; }                       //文件存储路径
        IActiveView pActiveView { get; set; }                //与活动的ActiveView连接
        IGeometry pGeometry { get; set; }                    //地图导出空间图形
        bool bRegion { get; set; }

        //输出地图参数
        int resolution { get; set; }                     //输出图片的分辨率
        int width { get; set; }                          //输出图片的宽度，以像素为单位
        int height { get; set; }                         //输出图片的高度，以像素为单位
    }  
}