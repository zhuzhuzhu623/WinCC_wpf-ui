using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing.Printing;
using System.Security.Policy;
using System.Xml.Linq;
using CommonModels.BllModel;
using FileController.DapperDal;
using Vision.CameraPro;
using Vision.VisionPro;
using FileController.FileDal;
using CommonModels;
using WinCC.Motion;
using WinCC.Motion.Hust;
namespace WinCC.Bll
{
    public class AppSession
    {
        public AppSession() 
        {

        }
       /// <summary>
       ///  机台系统数据
       /// </summary>
        public static SystemSetting SystemSetting { get; set; }
        /// <summary>
        /// 基础数据库访问工具
        /// </summary>
        public static IDapper Dapper = null;
        /// <summary>
        /// 控制器访问工具
        /// </summary>
        public static IMotionBase Motion = null;

        /// <summary>
        /// 相机列表
        /// </summary>
        public static CameraVisionPro CameraVisionPro = null;
        /// <summary>
        /// 视觉工具列表-对应相机数量
        /// </summary>
        public static List<VisionProService> VisionProServices = new List<VisionProService>();
        //public static VisionPro VisionPro = null;   

        /// <summary>
        /// 软件初始化系统参数
        /// </summary>
        /// <returns></returns>
        public static BllResult InitSystemSetting()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + "\\SystemSetting.txt";

            var result = FileHelper.Load<SystemSetting>(strPath);
            if(!result.Success)
            {
                return BllResultFactory.Error();
            }
            SystemSetting = result.Data;
            // Dapper = new DapperHelper("Data Source=WIN-1OA85801VP6\\WINCC;Initial Catalog=WinCC_Wcs;Persist Security Info=True;User ID=sa;Password=123456", 0);
            return BllResultFactory.Sucess();
        }


        /// <summary>
        /// 软件初始化相机
        /// </summary>
        /// <returns></returns>
        public static BllResult InitVision()
        {
            CameraVisionPro = new CameraVisionPro();
            CameraVisionPro.InitCamera(SystemSetting.CameraDatas);
            return BllResultFactory.Sucess();
        }

        /// <summary>
        /// 软件初始化控制器
        /// </summary>
        /// <returns></returns>
        public static BllResult InitMotion()
        {
            return BllResultFactory.Sucess();

            Motion = new HustService();           
            var result = Motion.Init();
            if (result.Success)
                return BllResultFactory.Sucess();
            else
                return BllResultFactory.Error(result.Msg);   
        }

        /// <summary>
        /// 软件初始化其他
        /// </summary>
        /// <returns></returns>
        public static BllResult InitOthers()
        {

      
            return BllResultFactory.Sucess();
        }

        public static BllResult SaveSystemSetting()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + "\\SystemSetting.txt";

            var result = FileHelper.Save<SystemSetting>(SystemSetting,strPath);
            return BllResultFactory.Sucess();
        }

    }
}
