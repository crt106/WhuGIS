using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WhuGIS.Forms.FormMain;

namespace WhuGIS.Forms.FormHolder
{
    /// <summary>
    /// 窗体承载基类
    /// </summary>
    public partial class FormHolder : DockContent
    {
        //本载体采用单例模式
        private static FormHolder instance;

        public static FormHolder GetInstance
        {
            get
            {
                if (instance == null) {
                    instance=new FormHolder();
                }
                return instance;
            }
        }


        #region 承载的其他窗体们
        FormMain.FormMain formMain=new FormMain.FormMain(); 

        #endregion

        private FormHolder()
        {
            InitializeComponent();
        }

        //加载窗体时默认显示FormMain
        private void FormHolder_Load(object sender, EventArgs e)
        {
            formMain.Show(this.dockPanel1,DockState.Document);                     
        }

    }
}
