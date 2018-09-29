﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
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
        void CallOutFormExport();                                 //呼出地图导出窗体
        void CallOutFormAttr(IFeatureLayer layer);
    } 
}
