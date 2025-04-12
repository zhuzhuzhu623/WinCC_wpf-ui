using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionController.MotionEntities
{
    public class AxisParameter
    {
        /// <summary>
        /// 起始速度 unit/s
        /// </summary>
        public double MinVel { get; set; }
        /// <summary>
        /// 最大速度 unit/s
        /// </summary>
        public double MaxVel { get; set; }
        /// <summary>
        /// 点动最大速度 unit/s
        /// </summary>
        public double MaxJobVel { get; set; }
        /// <summary>
        /// 加速时间
        /// </summary>
        public double Tacc { get; set; }
        /// <summary>
        /// 减速时间
        /// </summary>
        public double Tdec { get; set; }
        /// <summary>
        /// 停止速度 unit/s
        /// </summary>
        public double StopVel { get; set; }
    }
}
