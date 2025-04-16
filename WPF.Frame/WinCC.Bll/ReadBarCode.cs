using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinCC.Bll
{
    class ReadBarCode
    {
        //(1)  输入图像
        //  pImgBuff	图像指针      
        //  lImgWidth	图像宽度   
        //  lImgHeight	图像高度 
        [DllImport("QRCode.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetImage(byte[] pImgBuff, long lImgWidth, long lImgHeight);

        //(2)  设置检测区域
        //  检测区域中心跟图像中心重合
        //  lRoiWidth	检测区域宽度(如果设为 0 取图片宽度)
        //  lRoiHeight	检测区域高度(如果设为 0 取图片高度)
        [DllImport("QRCode.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetROI(long lRoiWidth, long lRoiHeight);


        //(3)  获取二维码
        //  cCode 为返回的字串 
        //  lMode 0 = 不区分, 1 = 128条码，2 = DM 码, 3= QR 码，4 = Aztec 码
        //  lFlag 0 = 白色背景|黑色码, 1= 黑色背景|白色码
        [DllImport("QRCode.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool GetCode([MarshalAs(UnmanagedType.LPStr)] StringBuilder cCode, long lMode, long lFlag);

        public static int GetBarCodeForHalcon([MarshalAs(UnmanagedType.LPStr)] StringBuilder pQRCode, byte[] pImgBuff, long lRoiWidth, long lRoiHeight, long lImgWidth, long lImgHeight, long lMode, long lFlag = 0)
        {
            bool bResult = false;
            bResult = SetImage(pImgBuff, lImgWidth, lImgHeight);
            if (!bResult)
                return -1;
            bResult = SetROI(lRoiWidth, lRoiHeight);
            if (!bResult)
                return -1;
            long type = 0;
            switch (lMode)
            {
                case 0:
                    type = lMode;
                    break;
                case 1:
                    type = lMode;
                    break;
                case 2:
                    type = lMode;
                    break;
                case 3:
                    type = lMode;
                    break;
                case 16:
                    type = 4;
                    break;
            }
            bResult = GetCode(pQRCode, lMode, lFlag);
            string str = pQRCode.ToString();
            if (!bResult)
                return -1;
            return 1;
        }

        /// <summary>
        /// 用halcon读码
        /// </summary>
        /// <param name="iCamera">0=垂直相机，1=同轴相机</param>
        /// <param name="iBarcodeType">1=128条码， 2=DM, 3=QR, 0=不区分</param>
        /// <param name="iSearchW"></param>
        /// <param name="iSearchH"></param>
        /// <param name="str">读码内容</param>
        /// <returns></returns>
        public static int ReadBarcodeForHalcon(Bitmap bitmap,int iBarcodeType, int iSearchW, int iSearchH, ref string str)
        {
            int iR = 1;
            try
            {
                byte[] bytes = null;
                int bmpStride = 0, bmpHeight = 0;
               // iR = CogImgToBytes(bitmap, ref bytes, ref bmpStride, ref bmpHeight);

                if (iR < 0)
                    iR = -1;
                StringBuilder strContent = new StringBuilder();
                int bR = GetBarCodeForHalcon(strContent, bytes, iSearchW, iSearchH, bmpStride, bmpHeight, iBarcodeType);
                str = strContent.ToString();

                return bR;
            }
            catch (Exception ex)
            {
               
                iR = -999;
            }
            return iR;
        }
    }
}
