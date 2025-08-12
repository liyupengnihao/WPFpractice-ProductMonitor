using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 设备数据模型
    /// </summary>
    public class DeviceModel
    {
        /// <summary>
        /// 设备监控项目名称
        /// </summary>
        public string DeviceItem { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public double Value { get; set; }
    }
}
