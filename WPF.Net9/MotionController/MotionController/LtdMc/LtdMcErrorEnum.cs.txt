using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC.Motion.LtdMc
{
    public enum LtdMcErrorEnum
    {
        [Description("Er00001")]
        无错误 = 0,
        [Description("Er000-1")]
        内部的一些空指针返回值 = -1,
        [Description("Er00002")]
        动态库层参数错误 = 2,
        [Description("Er00003")]
        PCI通讯超时 = 3,
        [Description("Er00004")]
        动态库层检测到轴处于运动中 = 4,
        [Description("Er00006")]
        连续插补错误 = 6,
        [Description("Er00008")]
        无法连接错误 = 8,
        [Description("Er00009")]
        动态库层卡号错误 = 9,
        [Description("Er00010")]
        动态库层发送数据失_请检查PCI槽位是否松动 = 10,
        [Description("Er00012")]
        固件文件错误 = 12,
        [Description("Er00014")]
        动态库层下载固件与控制卡_器型号不匹配 = 14,
        [Description("Er00017")]
        不支持的功能_预留_不能更改 = 17,
        [Description("Er00002")]
        链接对应型号类型不匹配 = 2,
        [Description("Er00002")]
        固件参数错误 = 2,
        [Description("Er00002")]
        固件当前状态不允许操作 = 2,
        [Description("Er00002")]
        固件不支持功能_保留原版本的错误码 = 2,
        [Description("Er00002")]
        密码错误 = 2,
        [Description("Er00002")]
        密码错误输入次数受限 = 2,
        [Description("Er00002")]
        设置的轴号超出最大轴数或伺服轴数允许范围 = 2,
        [Description("Er00002")]
        该轴已经被其它运动占用_不支持对该轴进行操作 = 2,
        [Description("Er00002")]
        不支持该操作_轴或坐标系处于运动中_或轴_CHECK_DOWN_未完成 = 2,
        [Description("Er00002")]
        不支持该操作_轴或坐标系处于运动或暂停中 = 2,
        [Description("Er00002")]
        轴映射列表为空 = 2,
        [Description("Er00002")]
        设置脉冲计数值和编码器反馈值之间差值的报警阀值为0 = 2,
        [Description("Er00002")]
        设置编码器和指令位置跟踪误差使能信号错误_使能信号不是0或1 = 2,
        [Description("Er00002")]
        设置编码器和指令位置跟踪误差停止模式错误_停止模式不是0或1 = 2,
        [Description("Er00002")]
        设置的脉冲当量小于等于0 = 2,
        [Description("Er00002")]
        QUEUE队列初始化参数错误_初始化空间大小小于0 = 2,
        [Description("Er00002")]
        不支持该功能 = 2,
        [Description("Er00002")]
        SPICRC校验码错误 = 2,
        [Description("Er00002")]
        中断通道超限 = 2,
        [Description("Er00002")]
        中断配置参数有误 = 2,
        [Description("Er00002")]
        中断逻辑电平错误 = 2,
        [Description("Er00002")]
        设置轴的目标位置大于轴软件正限位位置 = 2,
        [Description("Er00002")]
        设置轴的目标位置小于轴软件负限位位置 = 2,
        [Description("Er00002")]
        软件负限位位置大于或等于正限位位置_允许使能限位功能 = 2,
        [Description("Er00002")]
        圆弧区域限位 = 2,
        [Description("Er00002")]
        区域限位半径为0 = 2,
        [Description("Er00002")]
        设置的限位维数大于2维 = 2,
        [Description("Er00002")]
        设置的二维限位轴号相同 = 2,
        [Description("Er00002")]
        设置的限位停止模式大于1取值只能0和1 = 2,
        [Description("Er00002")]
        设置两轴碰撞检测时_两轴轴号相同 = 2,
    }
}
