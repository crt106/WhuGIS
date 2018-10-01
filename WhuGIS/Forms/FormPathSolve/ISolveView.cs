using WhuGIS.BaseInterface;

namespace WhuGIS.Forms.FormPathSolve
{
    public interface ISolveView:IBaseView
    {
        string OutGDBFolder { get; set; }                   //外部GDB数据路径
        string DataBaseName { get; set; }                   //数据库名称
        string DataSetname { get; set; }                    //具体要素类的名称

        void SetNetWorkDataStatusText(bool isable);         //设置NetWorkDataSet的状态文字
    }
}