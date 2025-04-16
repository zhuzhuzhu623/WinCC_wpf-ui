using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace VisionProView
{
    public class ImageResources
    {
       public static Cursor[] SlowCursor = new Cursor[8];
        public static Cursor[] MediumCursor = new Cursor[8];
        public static Cursor[] FastCursor = new Cursor[8];

        public static void Init()
        {
            //SlowCursor[0] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Left_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[0] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Left_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[0] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Left_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[1] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Right_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[1] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Right_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[1] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Right_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[2] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Up_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[2] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Up_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[2] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Up_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[3] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Down_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[3] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Down_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[3] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Down_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[4] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftUp_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[4] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftUp_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[4] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftUp_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[5] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftDown_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[5] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftDown_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[5] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftDown_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[6] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightUp_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[6] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightUp_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[6] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightUp_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            //SlowCursor[7] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightDown_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            //MediumCursor[7] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightDown_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            //FastCursor[7] = new Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightDown_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            string strAppPath = Application.StartupPath;
            SlowCursor[0] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Left_Slow.cur");
            MediumCursor[0] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Left_Medium.cur");
            FastCursor[0] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Left_Fast.cur");
            SlowCursor[1] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Right_Slow.cur");
            MediumCursor[1] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Right_Medium.cur");
            FastCursor[1] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Right_Fast.cur");
            SlowCursor[2] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Up_Slow.cur");
            MediumCursor[2] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Up_Medium.cur");
            FastCursor[2] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Up_Fast.cur");
            SlowCursor[3] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Down_Slow.cur");
            MediumCursor[3] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Down_Medium.cur");
            FastCursor[3] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\Down_Fast.cur");
            SlowCursor[4] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\LeftUp_Slow.cur");
            MediumCursor[4] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\LeftUp_Medium.cur");
            FastCursor[4] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\LeftUp_Fast.cur");
            SlowCursor[5] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\LeftDown_Slow.cur");
            MediumCursor[5] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\LeftDown_Medium.cur");
            FastCursor[5] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\LeftDown_Fast.cur");
            SlowCursor[6] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\RightUp_Slow.cur");
            MediumCursor[6] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\RightUp_Medium.cur");
            FastCursor[6] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\RightUp_Fast.cur");
            SlowCursor[7] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\RightDown_Slow.cur");
            MediumCursor[7] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\RightDown_Medium.cur");
            FastCursor[7] = new Cursor(strAppPath + "\\Asserts\\MouseMove\\RightDown_Fast.cur");
        }
    }
}
