using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitor.Models
{
    /// <summary>
    /// 报警数据模型
    /// </summary>
    public class AlarmModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 报警时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 报警时长S
        /// </summary>
        public string Duration { get; set; }

    }
}
