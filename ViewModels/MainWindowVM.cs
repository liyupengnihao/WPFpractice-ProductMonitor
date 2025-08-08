using ProductMonitor.Models;
using ProductMonitor.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProductMonitor.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowVM()
        {
            #region 初始化环境数据
            if(_EnviromentList==null)
            {
                _EnviromentList=new List<EnviromentModel>();
            }
            _EnviromentList.Add(new EnviromentModel{EnItemName="光照（Lux）",EnItemValue=123 });
            _EnviromentList.Add(new EnviromentModel{EnItemName="噪音（db）",EnItemValue=55 });
            _EnviromentList.Add(new EnviromentModel{EnItemName="温度（℃）",EnItemValue=80 });
            _EnviromentList.Add(new EnviromentModel{EnItemName="湿度（%）",EnItemValue=43 });
            _EnviromentList.Add(new EnviromentModel{EnItemName="PM2.5（m³）",EnItemValue=20 });
            _EnviromentList.Add(new EnviromentModel{EnItemName="硫化氢（ppm）",EnItemValue=15 });
            _EnviromentList.Add(new EnviromentModel{EnItemName="氮气（ppm）",EnItemValue=18 });
            #endregion
        }

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
        #region 时间 日期
        #region 后端不用通知
        /// <summary>
        /// 时间，小时：分钟
        /// </summary>
        public string TimerStr
        {
            get
            {
                return DateTime.Now.ToString("HH:mm");
            }
        }
        #endregion

        #region 后端要通知时
        //private string _TimerStr;

        //public string TimerStr
        //{
        //    get { return _TimerStr; }
        //    set
        //    {
        //        _TimerStr = value;
        //        if(PropertyChanged!=null)
        //        {
        //            PropertyChanged(this,new PropertyChangedEventArgs("TimerStr"));
        //        }
        //    }
        //}
        #endregion

        /// <summary>
        /// 日期
        /// </summary>
        public string DateStr
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 星期
        /// </summary>
        public string WeekStr
        {
            get
            {
                int index = (int)DateTime.Now.DayOfWeek;
                string[] week = new string[7] { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                return week[index];
                //switch (index)
                //{
                //    case 0:
                //        return "星期天";

                //    default:
                //        return "其他";
                //}
            }
        }
        #endregion

        #region 计数
        /// <summary>
        /// 机台总数
        /// </summary>
        private string _MachineCount = "0298";

        public string MachineCount
        {
            get { return _MachineCount; }
            set
            {
                _MachineCount = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MachineCount"));
                }
            }
        }
        /// <summary>
        /// 生产计数
        /// </summary>
        private string _ProductCount = "1699943";

        public string ProductCount
        {
            get { return _ProductCount; }
            set
            {
                _ProductCount = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductCount"));
                }
            }
        }
        /// <summary>
        /// 不良计数
        /// </summary>
        private string _BadCount = "0043";

        public string BadCount
        {
            get { return _BadCount; }
            set
            {
                _BadCount = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BadCount"));
                }
            }
        }
        #endregion

        #region 环境监控数据
        private List<EnviromentModel> _EnviromentList;

        public List<EnviromentModel> EnviromentList
        {
            get
            {
                return _EnviromentList;
            }
            set
            {
                _EnviromentList = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EnviromentList"));
                }
            }
        }

        #endregion
    }
}
