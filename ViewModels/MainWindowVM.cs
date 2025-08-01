using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProductMonitor.UserControls;

namespace ProductMonitor.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public static object ReadOnly = new object();
        /// <summary>
        /// 监控用户控件
        /// </summary>
        private UserControl _MonitorUC;
        /// <summary>
        /// 监控用户控件
        /// </summary>
        public UserControl MonitorUC
        {
            get
            {
                if (_MonitorUC==null)
                {
                    lock (ReadOnly)
                    {
                        if (_MonitorUC==null)
                            _MonitorUC=new ProductMonitor.UserControls.MointorUC();
                    }

                }
                //if (_MonitorUC==null)
                //{
                //    _MonitorUC=new ProductMonitor.UserControls.MointorUC();
                //}
                return _MonitorUC;
            }
            set
            {
                _MonitorUC = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MonitorUC"));
                }
            }
        }

    }
}
