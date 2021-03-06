﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using WhuGIS.BaseInterface;

namespace WhuGIS.Forms.FormMain
{
    internal interface IMainPresenter:IBasePresent
    {
        void LoadMxdFile(string file);        //读取Mxd文件
        void LoadMdbFile(string file);        //读取Mdb文件
        void LoadShapeFile(string filepath,string filename);      //读取ShapeFile文件
        void SaveAs(string filepath);                             //文件另存为

        //呼出其他窗体部分
        void CallOutFormExport(bool isAllRegion = true, IPolygon polygon = null);              //呼出地图导出窗体
        void CallOutFormAttr(IFeatureLayer layer);                //呼出属性查看窗体
        void CallOutFormPathSolve();                              //呼出最短路径分析窗口
        void CallOutFormMonitor();                                //呼出监控范围分析窗口
        void CallOutFormSchoolInfo();                             //呼出校园公共消息窗口
        void CallOutFormPhoto();                                  //呼出图像查询窗口
        void CallOutFormClassroomQuery();                         //呼出教室查询窗口
    } 
}
