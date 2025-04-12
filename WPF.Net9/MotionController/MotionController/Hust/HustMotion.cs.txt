using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinCC.Motion.Hust
{
    public class HustMotion
    {
        //***********************************************************************************//
        //CNC配置
        //***********************************************************************************//
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool addTargetCnc(int cncID, int maxDncCh, string ip, int type);//添加一台控制器


        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long registerVars(int[] address, int count, int cncID = 0);//注册访问的变数地址

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long registerBits(long channel, int type, int[] address, int count, int cncID = 0);//注册访问的Bit地址

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long removeVars(int[] address, int count, int cncID = 0);//移除已注册的变数

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long removeBits(long channel, int type, int[] address, int count, int cncID = 0);//移除已注册的bit

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long clearVars(int cncID = 0);//移除所有注册的变数与bit


        //***********************************************************************************//
        //通讯控制
        //***********************************************************************************//
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool connect(int cncID = 0);
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool disconnect(int cncID = 0);


        //***********************************************************************************//
        //变量访问
        //***********************************************************************************//
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long writeVars(int[] address, int count, int[] value, int cncID = 0);//写入变量

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long readVars(int[] address, int count, int[] value, int cncID = 0);//读取变量

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long readBits(int channel, int type, int[] address, int count, int[] value, int cncID = 0);//读取Bits

        //***********************************************************************************//
        //系统命令
        //***********************************************************************************//
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long reset(long channel, int cncID = 0);//复位

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long cycStart(long channel, string fileName, int cncID = 0);//启动

        //***********************************************************************************//
        //文件传输
        //***********************************************************************************//
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long setTransFileType(long type, long channel, string fileName, int cncID = 0);//设置文件信息

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long overwrite(string txt, long channel, int cncID = 0);//覆写指令

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long append(string txt, long channel, int cncID = 0);//追加指令

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long fileEnd(long channel, int cncID = 0);//文件传输结束


        /**
 * @brief 获取将要传输的文件状态
 *
 * @param type ：=0 MDI文件 =1 DNC文件 =2 CNC文件
 * @param channel ：通道号，范围1~99
 * @param *fileName ：文件名称指针，仅当为fileType = CNC文件时，此名称才有意义,文件名称长度范围1~100
 * @return long ：=0 可以传输 =1传入函数的参数错误  =2 CNC回应超时 =3 通讯命令错误 =7通讯断开 =100系统错误 =102 正在运行中
 */
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long getTransFileState(int type, int channel, string fileName, int cncID = 0);//文件传输状态
                                                                                                           //public OnUpdateMotionDelegate m_OnUpdateMotion;

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]// 
        public static extern IntPtr getCncCurrentError(long channel, int cncID = 0);//读取警讯

        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]// CharSet = CharSet.Ansi,
        public static extern long getErrorDeb(int name, int cncID = 0);//设置生成调试错误信息文件

        /**
         * @brief 获取
         *
         * @param type ：=0 当前警讯 =1 历史警讯
         * @param channel ：通道号，范围1~99
         * @param *stringData ：数据称指针，存储返回的数据
         * @return long ：=0成功
         */
        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]// 
        public static extern long getCurErrString(long channel, long type, IntPtr[] stringData, int cncID = 0);//读取警讯（新接口）



        [DllImport("AsyncCommModule.dll", CallingConvention = CallingConvention.Cdecl)]//读取警讯（新接口，解决部分乱码问题）
        public static extern int getCurErrString2(int tmpChannel, int type, byte[] stringData, int cncID = 0);

       static  Mutex m_Mutex = new Mutex(false);
        const int WAIT_TIMEOUT = 5000;
        public static int SetVar(int iVar, int iVarValue)
        {

            bool b = m_Mutex.WaitOne(WAIT_TIMEOUT);
            if (!b)
                return -10;
            int i = 0;
            try
            {
                int[] iVars = new int[1]; int[] iVarValues = new int[1];
                iVars[0] = iVar; iVarValues[0] = iVarValue;
                long iR = writeVars(iVars, 1, iVarValues);
                if (iR != 0)
                {
                    switch (iR)
                    {
                        case 1: // 传入函数的参数错误
                            i = -1;
                            break;
                        case 2: // CNC回应超时
                            i = -2;
                            break;
                        case 3: // 通讯命令错误
                            i = -3;
                            break;
                        default:
                            break;
                    }
                }
            }
            finally
            {
                m_Mutex.ReleaseMutex();
            }
            return i;
        }

        public static int GetVars(int[] iVars,ref int[] iVarValues)
        {
            bool b = m_Mutex.WaitOne(WAIT_TIMEOUT);
            if (!b)
                return -10;
            int i = 0;
            try
            {
                long iR = writeVars(iVars, iVars.Length, iVarValues);
                if (iR != 0)
                {
                    switch (iR)
                    {
                        case 1: // 传入函数的参数错误
                            i = -1;
                            break;
                        case 2: // CNC回应超时
                            i = -2;
                            break;
                        case 3: // 通讯命令错误
                            i = -3;
                            break;
                        default:
                            break;
                    }
                }
            }
            finally
            {
                m_Mutex.ReleaseMutex();
            }
            return i;
        }
    }



    internal static class ExtensionMethods
    {

        //系统变数的基准地址，绝对地址=基准地址+相对地址
        private const int USR_BASE_ADDR = 0;
        private const int SYS_BASE_ADDR = 10000;
        private const int REG_BASE_ADDR = 40000;
        private const int MCM_BASE_ADDR = 50000;
        private const int BUS_BASE_ADDR = 60000;
        private const int COM_BASE_ADDR = 70000;

        internal static bool IsBitEqualOne(this int o, int bitIndex)
        {
            double a = Math.Pow(2, bitIndex);
            UInt32 refVal = Convert.ToUInt32(a);
            return (o & refVal) == refVal;
        }
        internal static int SetBitZero(this int o, int bitIndex)
        {
            o &= ~(1 << bitIndex);
            return o;
        }
        internal static int SetBitOne(this int o, int bitIndex)
        {
            o |= (1 << bitIndex);
            return o;
        }
        internal static int GetAddrUSR(this int o)
        {
            return o + USR_BASE_ADDR;
        }
        internal static int GetAddrSYS(this int o)
        {
            return o + SYS_BASE_ADDR;
        }
        internal static int GetAddrREG(this int o)
        {
            return o + REG_BASE_ADDR;
        }
        internal static int GetAddrMCM(this int o)
        {
            return o + MCM_BASE_ADDR;
        }
        internal static int GetAddrBUS(this int o)
        {
            return o + BUS_BASE_ADDR;
        }
        internal static int GetAddrCOM(this int o)
        {
            return o + COM_BASE_ADDR;
        }
        internal static void Merge(this Dictionary<int, int> to, Dictionary<int, int> from)
        {
            foreach (var item in from)
            {
                if (!to.ContainsKey(item.Key))
                    to.Add(item.Key, item.Value);
            }
        }

    }
}
