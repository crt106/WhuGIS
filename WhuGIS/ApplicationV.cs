using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;

namespace WhuGIS
{
    /// <summary>
    /// 存放一些比较难处理的全局变量
    /// </summary>
    public static class ApplicationV
    {
        //数据根目录
        public static string DatarootPath
        {
            get { return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\data"; }
        }

        //最短路径分析图片位置
        public static string Data_ImgPath
        {
            get { return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\data\\Img"; }
        }

        //摄像头分析缓存
        public static string Data_MonitorPath
        {
            get { return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\data\\Monitor"; }
        }

        static ApplicationV()
        {
            //检查各个路径是否创建
            if(!Directory.Exists(DatarootPath))
            {
                Directory.CreateDirectory(DatarootPath);
            }
            if (!Directory.Exists(Data_ImgPath))
            {
                Directory.CreateDirectory(Data_ImgPath);
            }
            if (!Directory.Exists(Data_MonitorPath))
            {
                Directory.CreateDirectory(Data_MonitorPath);
            }
        }

        public static AxMapControl GlobalMapControl;
        public static AxTOCControl GlobalTocControl;
    }
}
