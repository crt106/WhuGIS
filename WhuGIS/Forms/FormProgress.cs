using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhuGIS.BaseInterface;

namespace WhuGIS.Forms
{
    public partial class FormProgress : Form
    {
        private static FormProgress instance;
        public static FormProgress Instance
        {
            get
            {
                if (instance == null)
                {
                    instance=new FormProgress();
                }
                return instance;
            }
        }


        /// <summary>
        /// 本窗体采用单例模式 暴露给其他类直接调用静态方法
        /// </summary>
        private FormProgress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示进度窗体
        /// </summary>
        public static void ShowDialog(IBaseView Context)
        {
            try
            {
                Instance.Show(Context.FormInstance);
            }
            catch (Exception e)
            {
                
            }
        }
        /// <summary>
        /// 设置消息文字
        /// </summary>
        public static void SetMessage(string msg)
        {
            try
            {
                Instance.Invoke(new Action(() => { Instance.LabelMsg.Text = msg; }));
            }
            catch (Exception e)
            {
                
            }
        }

        /// <summary>
        /// 设置进度条(可计算的)
        /// </summary>
        /// <param name="process">进度 限制在整数1-100</param>
        public static void SetProcess(int process)
        {
            try
            {
                Instance.ProgressBar.Invoke(new Action(() => { Instance.ProgressBar.Value = process; }));
            }
            catch (Exception e)
            {
                
            }
        }

        /// <summary>
        /// 表演一个进度增加假象
        /// </summary>
        /// <param name="seconddelta">每秒增加的进度值</param>
        public static void PreformProcess(int seconddelta)
        {
            ProgressBar p = Instance.ProgressBar;
            p.Value = 0;
            p.Maximum = 10000 / seconddelta;
            p.Step = 1;
            Task t = new Task(() =>
            {
                while (p.Value < p.Maximum)
                {
                    try
                    {
                        p.Invoke(new Action(() => p.PerformStep()));
                        Thread.Sleep(1);
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            });
            t.Start();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        public static void Dismiss()
        {
            try
            {
                Instance.Invoke(new Action(() => { Instance.Close(); }));
                Instance.Dispose();
                instance = null;              
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
