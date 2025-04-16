using Cognex.VisionPro;
using CommonModels.SystemEntities;
using CommonModels.SystemEnums;
using MotionController.MotionEntities;
using MotionController.MotionEnums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinCC.Bll;
using WinCC.Bll.BllService;

namespace WinCC.Ui.Views.CameraView
{
    /// <summary>
    /// cogDispalyView.xaml 的交互逻辑
    /// </summary>
    public partial class CogDisplayView : UserControl
    {
        CogCircle Circle;
        CogLineSegment VelLine = new CogLineSegment();
        CogLineSegment HorLine = new CogLineSegment();

        public CameraData CameraData { get; set; }
        public CogDisplayView(CameraData camera)
        {
            InitializeComponent();
            CameraData = camera;

            if (CameraData != null && AppSession.CameraVisionPro != null)
            {
                var result = AppSession.CameraVisionPro.GetCogAcqFifoTool(CameraData.SerialNumber);
                if (result != null)
                    displayView.StartLiveDisplay(result.Operator, false);
            }
            if (CameraData != null)
            {
                HorLine.StartX = 0;
                HorLine.StartY = CameraData.Height / 2;
                HorLine.EndX = CameraData.Width;
                HorLine.EndY = CameraData.Height / 2;
                displayView.InteractiveGraphics.Add(HorLine, "H", true);

                VelLine.StartX = CameraData.Width / 2;
                VelLine.StartY = 0;
                VelLine.EndX = CameraData.Width / 2;
                VelLine.EndY = CameraData.Height;
                displayView.InteractiveGraphics.Add(VelLine, "V", true);

                Circle = new CogCircle();
                Circle.CenterX = CameraData.Width / 2;
                Circle.CenterY = CameraData.Height / 2;
                Circle.Radius = 50;
                Circle.Color = CogColorConstants.Red;
                Circle.LineWidthInScreenPixels = 2;
                Circle.GraphicDOFEnable = CogCircleDOFConstants.Radius;
                displayView.InteractiveGraphics.Add(Circle, "C", true);
            }

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //displayView.GridEnabled = true;

            //displayView.SubPixelGridEnabled = true;
            //displayView.InteractiveGraphicTipsEnabled = true;
            //displayView.MaintainImageRegion = true;
            //displayView.MultiSelectionEnabled = false;

            //displayView.AutoFitWithGraphics = false;
            displayView.BackColor = ColorTranslator.FromHtml("#ffc080");
            displayView.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.UserDefined;
            displayView.PopupMenu = false;
            displayView.AutoFit = true;
            
           
        }
        private void cogdisplay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseMoveForMotion(e.X, e.Y);
        }

        private void cogdisplay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseDownForMotion(e.X, e.Y);
        }

        private void cogdisplay_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (AppSession.Motion != null)
                AppSession.Motion.StopManualMove();
        }

        private void MouseMoveForMotion(int pointX, int pointY)
        {
            var resultX = pointX;
            var resultY = pointY;
            int visionWidth = displayView.Width;
            int visionHeight = displayView.Height;
            int x = 0;
            int y = 0;
            int dirX = 0;
            int dirY = 0;
            int moveSpeed = 0;
            var i = GetMoveCursor(resultX, resultY, visionWidth, visionHeight, ref x, ref y, ref dirX, ref dirY, ref moveSpeed);         
            switch (moveSpeed)
            {
                case 0:
                    displayView.UserDefinedMouseCursor = ImageResources.SlowCursor[i];
                    break;
                case 1:
                    displayView.UserDefinedMouseCursor = ImageResources.MediumCursor[i];
                    break;
                case 2:
                   displayView.UserDefinedMouseCursor = ImageResources.FastCursor[i];
                    break;
            }

           
        }

        /// <summary>
        /// 按钮按下，解析点动命令
        /// </summary>
        /// <param name="obj"></param>
        private void MouseDownForMotion(int pointX, int pointY)
        {
            var resultX = pointX;
            var resultY = pointY;
            int visionWidth = displayView.Width;
            int visionHeight = displayView.Height;
            int x = 0;
            int y = 0;
            int dirX = 0;
            int dirY = 0;
            int moveSpeed = 0;
            GetMoveCursor(resultX, resultY, visionWidth, visionHeight, ref x, ref y, ref dirX, ref dirY, ref moveSpeed);
            List<AxisData> axisList = new List<AxisData>();
            if (x == 1)
                axisList.Add(new AxisData() { AxisType = EmAxisType.X, TypeEnum = dirX == 1 ? EmDirectionType.Reverse : EmDirectionType.Positive });
            if (y == 1)
                axisList.Add(new AxisData() { AxisType = EmAxisType.Y, TypeEnum = dirY == 1 ? EmDirectionType.Reverse : EmDirectionType.Positive });
            if (AppSession.Motion != null)
                AppSession.Motion.StartManualMove(axisList, moveSpeed);
        }
        /// <summary>
        /// 坐标换算出当前需要显示的光标
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="iVisionWidth"></param>
        /// <param name="iVisionHeight"></param>
        /// <param name="iX"></param>
        /// <param name="iY"></param>
        /// <param name="iDirX"></param>
        /// <param name="iDirY"></param>
        /// <param name="iSpeed"></param>
        /// <returns></returns>
        private int GetMoveCursor(double dx, double dy, int iVisionWidth, int iVisionHeight, ref int iX, ref int iY, ref int iDirX, ref int iDirY, ref int iSpeed)
        {
            int iCursor = 0;
            double ddx = dx, ddy = dy;
            if (dx <= iVisionWidth / 2)
            {
                if (dy < iVisionHeight / 2)
                {
                    dx /= iVisionWidth;
                    dy /= iVisionHeight;
                    if (dx > dy)
                    {
                        iY = 1; iDirY = 1; iCursor = 2;
                    }
                    else
                    {
                        iX = 1; iDirX = 0; iCursor = 0;
                    }
                }
                else
                {
                    dx /= iVisionWidth;
                    dy = (iVisionHeight - dy) / iVisionHeight;
                    if (dx < dy)
                    {
                        iX = 1; iDirX = 0; iCursor = 0;
                    }
                    else
                    {
                        iY = 1; iDirY = 0; iCursor = 3;
                    }
                }
            }
            else
            {
                if (dy < iVisionHeight / 2)
                {
                    dx = (dx - iVisionWidth / 2) / iVisionWidth;
                    dy = (iVisionHeight / 2 - dy) / iVisionHeight;
                    if (dx > dy)
                    {
                        iX = 1; iDirX = 1; iCursor = 1;
                    }
                    else
                    {
                        iY = 1; iDirY = 1; iCursor = 2;
                    }
                }
                else
                {
                    dx = (dx - iVisionWidth / 2) / iVisionWidth;
                    dy = (dy - iVisionHeight / 2) / iVisionHeight;
                    if (dx < dy)
                    {
                        iY = 1; iDirY = 0; iCursor = 3;
                    }
                    else
                    {
                        iX = 1; iDirX = 1; iCursor = 1;
                    }
                }
            }
            iSpeed = 0;
            if (((ddx < iVisionWidth / 3)) || (ddx > (2 * iVisionWidth / 3)))
            {
                iSpeed = 1;
            }

            if ((ddy < iVisionHeight / 3) || (ddy > (2 * iVisionHeight / 3)))
            {
                iSpeed = 1;
            }
            if (((ddx < iVisionWidth / 6)) || (ddx > (5 * iVisionWidth / 6)))
            {
                iSpeed = 2;
            }

            if ((ddy < iVisionHeight / 6) || (ddy > (5 * iVisionHeight / 6)))
            {
                iSpeed = 2;
            }

            if ((ddx < iVisionWidth / 3) && (ddy < iVisionHeight / 3))
            {
                iX = 1; iDirX = 0;
                iY = 1; iDirY = 1; iCursor = 4; //iSpeed = 2;
            }
            else if ((ddx > (2 * iVisionWidth / 3)) && (ddy < iVisionHeight / 3))
            {
                iX = 1; iDirX = 1;
                iY = 1; iDirY = 1; iCursor = 6; //iSpeed = 2;
            }
            else if ((ddx > (2 * iVisionWidth / 3)) && (ddy > (2 * iVisionHeight / 3)))
            {
                iX = 1; iDirX = 1;
                iY = 1; iDirY = 0; iCursor = 7; //iSpeed = 2;
            }
            else if ((ddx < iVisionWidth / 3) && (ddy > (2 * iVisionHeight / 3)))
            {
                iX = 1; iDirX = 0;
                iY = 1; iDirY = 0; iCursor = 5; //iSpeed = 2;
            }
            return iCursor;
        }
    }
}
