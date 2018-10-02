using System;
using System.Collections.Generic;
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
    public class ApplicationV
    {
        public static string DatarootPath
        {
            get { return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\data"; }
        }

        public static string Data_ImgPath
        {
            get { return System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\data\\Img"; }
        }

        public static AxMapControl GlobalMapControl;
        public static AxTOCControl GlobalTocControl;
    }
}
