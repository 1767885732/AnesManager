using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wis.Anes.Framework.Views
{
    /// <summary>
    /// 普通界面的基类
    /// </summary>
    [ToolboxItem(false)]
    public partial class BaseView : XtraUserControl
    {
        private bool _hasDirty = false;
        protected string _caption = string.Empty;

        public BaseView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption
        {
            get
            {
                return
                    _caption;
            }
            set
            {
                _caption = value;
            }
        }

        ///// <summary>
        ///// 是否有脏数据
        ///// </summary>
        //public bool HasDirty
        //{
        //    get
        //    {
        //        return
        //            _hasDirty;
        //    }
        //    set
        //    {
        //        _hasDirty = value;
        //    }
        //}      
        public virtual bool IsDirty
        {
            get
            {
                return
                    _hasDirty;
            }
            set
            {
                _hasDirty = value;
            }
        }
        /// <summary>
        /// 刷新界面数据
        /// </summary>
        public virtual void RefreshData()
        {

        }

        public virtual bool Save()
        {
            return true;
        }
    }
}
