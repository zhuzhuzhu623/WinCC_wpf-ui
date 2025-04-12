using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels.Enums
{
    public enum EmTaskType
    {
        整盘入库 = 100,
        空容器入库 = 500,
        整盘出库 = 300,
        空容器出库 = 600,
        补充入库 = 200,
        分拣出库 = 400,
        盘点 = 700,
        移库 = 800,
        出库查看 = 900
    }
}
