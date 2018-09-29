using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using WhuGIS.BaseInterface;

namespace WhuGIS.Forms.FormMain
{
    /// <summary>
    /// 主窗体接口
    /// </summary>
    internal interface IMainView:IBaseView
    {
        
        AxMapControl Map { get; }                      //主地图控件
        AxMapControl Eagle { get; }                    //鹰眼地图控件
        AxTOCControl TocControl { get; }               //TOC图层


        void StatusBarInfoSet(string msg);             //修改主窗体状态栏消息
        Action SyncEagleView { get;}                   //同步鹰眼视图Action 供Presenter调用
    } 
}
