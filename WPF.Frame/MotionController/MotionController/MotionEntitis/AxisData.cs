using MotionController.MotionEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionController.MotionEntities
{
    public class AxisData
    {
        /// <summary>
        /// 轴类型
        /// </summary>
        public EmAxisType AxisType { get; set; }
        /// <summary>
        /// 轴方向
        /// </summary>
        public EmDirectionType TypeEnum { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 归零顺序
        /// </summary>
        public EmGoHome GoHomeOrder { get; set; }
        /// <summary>
        /// 轴运行设定参数
        /// </summary>
        public AxisParameter AxisParameter { get; set; }

        /// <summary>
        /// 内存，轴点动模式
        /// </summary>
        public bool JopAxis { get; set; } = false;
    }
}
