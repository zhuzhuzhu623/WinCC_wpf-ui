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

namespace WinCC.Ui.Views.CameraView
{
    /// <summary>
    /// NavigationImageView.xaml 的交互逻辑
    /// </summary>
    public partial class NavigationImageView : UserControl
    {
        public static NavigationImageView _Instance = null;

        private static readonly object _lockObj = new object();
        public NavigationImageView()
        {
            InitializeComponent();

            displayView.GridEnabled = true;
         
            displayView.SubPixelGridEnabled = true;
            displayView.InteractiveGraphicTipsEnabled = true;
            displayView.MaintainImageRegion = true;
            displayView.MultiSelectionEnabled = false;
            displayView.AutoFitWithGraphics = false;    
            displayView.BackColor = ColorTranslator.FromHtml("#ffc080");
            displayView.PopupMenu = false;
            displayView.AutoFit = true;
        }

        /// <summary>
        /// 获取窗体实例
        /// </summary>
        /// <returns></returns>
        public static NavigationImageView GetWindow()
        {
            if (_Instance == null)
            {
                lock (_lockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = new NavigationImageView();
                    }
                }
            }
            return _Instance;
        }
    }
}
