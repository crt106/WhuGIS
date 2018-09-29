using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhuGIS.BaseInterface
{
    /// <summary>
    /// view层基类接口
    /// </summary>
    public interface IBaseView
    {
        Form FormInstance { get; }
        void ShowMessage(string msg);                  //messagebox显示消息
        void ShowError(string msg);                  //messagebox显示消息
        void ShowWarning(string msg);                  //messagebox显示消息
    }
}
