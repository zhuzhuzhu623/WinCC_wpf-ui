using CommonModels.BllModel;
using MotionController.MotionEntities;
using MotionController.MotionEntitis;
using MotionController.MotionEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCC.Motion
{
    public interface IMotionBase
    {
        //通用返回值，BllResult成功true，失败false;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        BllResult<string> Init();
        /// <summary>
        /// 断开链接
        /// </summary>
        /// <returns></returns>
        BllResult<short> Close();
        /// <summary>
        /// 急停
        /// </summary>
        /// <returns></returns>
        BllResult<string> EmergencyStop();
        /// <summary>
        /// 点动控制
        /// </summary>
        /// <param name="axisData"></param>
        /// <param name="distValue"></param>
        /// <returns></returns>
        BllResult<int> StartManualMove(AxisData axisData, int distValue);
        /// <summary>
        /// 点动控制
        /// </summary>
        /// <param name="axisDatas"></param>
        /// <param name="distValue"></param>
        /// <returns></returns>
        BllResult<int> StartManualMove(List<AxisData> axisDatas, int distValue);
        /// <summary>
        /// 停止点动
        /// </summary>
        /// <param name="axisData"></param>
        /// <param name="distValue"></param>
        /// <returns></returns>
        BllResult<int> StopManualMove();
        /// <summary>
        /// 归零
        /// </summary>
        /// <param name="axisDatas"></param>
        /// <returns></returns>
        BllResult<string> GoHome(List<AxisData> axisDatas);
        /// <summary>
        /// 读输入I点
        /// </summary>
        /// <param name="iBitEnum"></param>
        /// <returns></returns>
        BllResult<bool> ReadInBit(EmIBit iBitEnum);
        /// <summary>
        /// 读输出O点
        /// </summary>
        /// <param name="oBitEnum"></param>
        /// <returns></returns>
        BllResult<bool> ReadOutBit(EmOBit oBitEnum);
        /// <summary>
        /// 写输出O点
        /// </summary>
        /// <param name="oBitEnum"></param>
        /// <param name="levelEnum"></param>
        /// <returns></returns>
        BllResult<bool> WriteOutBit(EmOBit oBitEnum, EmLevel levelEnum);

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="axisData"></param>
        /// <returns></returns>
        BllResult<int> WriteParameter(Variables variables);
        /// <summary>
        /// 设置轴参数
        /// </summary>
        /// <param name="axisData"></param>
        /// <returns></returns>
        BllResult<int> WriteAxisParameter(AxisData axisData);
        /// <summary>
        /// 单轴运动
        /// </summary>
        /// <param name="axisData"></param>
        /// <returns></returns>
        BllResult<int> SingleAxisMotion(AxisData axisData, int distValue);

        /// <summary>
        /// 多轴运动
        /// </summary>
        /// <param name="axisData"></param>
        /// <returns></returns>
        BllResult<int> MultipleAxisMotion(List<AxisData> axisDatas, int distValue);
        /// <summary>
        /// 获取轴当前值
        /// </summary>
        /// <returns></returns>
        BllResult<AxisCurrentValue> GetAxisCurrentValue();
    }
}
