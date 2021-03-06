﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using CefSharp.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace WhuGIS.Forms.FormSchoolInfo
{
    public partial class FormSchoolInfo : DockContent,ISchoolView
    {
        public ISchoolPresenter presenter;
        public const string URL_GEIFEN = "120.79.7.230/whuseats_web/geifen.html";
        public const string URL_HALL = "http://hall.future.org.cn/main.php";
        public FormSchoolInfo()
        {
            InitializeComponent();
            presenter=new Presenter(this);
        }

        #region 接口实现

        public Form FormInstance
        {
            get { return this; }
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region UI字段

        private ChromiumWebBrowser Cwebview;

        #endregion


        /// <summary>
        /// TabControl切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void 校园公共信息_Load(object sender, EventArgs e)
        {
            //加载浏览器
            Cwebview = new ChromiumWebBrowser(URL_GEIFEN);
            panel_Geifen.Controls.Add(Cwebview);  
        }

        /// <summary>
        /// 刷新共享单车数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            presenter.RefreshofoInfo();
            presenter.RefreshmobikeInfo();
        }

        /// <summary>
        /// 场地查询页面进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage_Hall_Enter(object sender, EventArgs e)
        {
            Cwebview =new ChromiumWebBrowser(URL_HALL);
            panel_Hall.Controls.Add(Cwebview);
        }

        /// <summary>
        /// 给分页面进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPage_Geifen_Enter(object sender, EventArgs e)
        {
            Cwebview = new ChromiumWebBrowser(URL_GEIFEN);
            panel_Geifen.Controls.Add(Cwebview);
        }

    }
}
