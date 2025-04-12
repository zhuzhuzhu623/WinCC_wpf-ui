using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WinCC
{
    public class ImageResources
    {
       public static System.Windows.Forms.Cursor[] SlowCursor = new System.Windows.Forms.Cursor[8];
        public static System.Windows.Forms.Cursor[] MediumCursor = new System.Windows.Forms.Cursor[8];
        public static System.Windows.Forms.Cursor[] FastCursor = new System.Windows.Forms.Cursor[8];

        public static void Init()
        {
            SlowCursor[0] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Left_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[0] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Left_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[0] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Left_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[1] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Right_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[1] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Right_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[1] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Right_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[2] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Up_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[2] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Up_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[2] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Up_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[3] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Down_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[3] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Down_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[3] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\Down_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[4] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftUp_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[4] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftUp_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[4] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftUp_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[5] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftDown_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[5] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftDown_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[5] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\LeftDown_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[6] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightUp_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[6] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightUp_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[6] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightUp_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
            SlowCursor[7] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightDown_Slow.cur", UriKind.RelativeOrAbsolute)).Stream);
            MediumCursor[7] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightDown_Medium.cur", UriKind.RelativeOrAbsolute)).Stream);
            FastCursor[7] = new System.Windows.Forms.Cursor(System.Windows.Application.GetResourceStream(new Uri("\\Asserts\\MouseMove\\RightDown_Fast.cur", UriKind.RelativeOrAbsolute)).Stream);
        }
    }
}
