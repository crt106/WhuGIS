using WhuGIS.BaseInterface;

namespace WhuGIS.Forms.FormPathSolve
{
    public interface ISolvePresenter:IBasePresent
    {
        void SetNetWorkDataset_GDBFolder();                     //从外部GDB文件夹获取网络数据集
        void SetNetWorkDataset_MDBFile();                       //从外部MDB文件获取网络数据集
        void SetNetWorkDataset_Shapfile();                      //从外部Shapfile文件获取网络数据集
        void SetNetWorkDataset_Layers();                        //从图层获取网络数据集

        void ClearPathResult();                                 //清除已有的最短路径计算结果
    }
}