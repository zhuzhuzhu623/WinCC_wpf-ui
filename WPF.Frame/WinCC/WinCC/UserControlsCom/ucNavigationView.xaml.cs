using System;
using System.Collections.Generic;
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

namespace WinCC.UserControlsCom
{
    /// <summary>
    /// ucNavigationView.xaml 的交互逻辑
    /// </summary>
    public partial class ucNavigationView : UserControl
    {

        public static ucNavigationView _Instance = null;
        private static readonly object _lockObj = new object();

        /// <summary>
        /// 获取窗体实例
        /// </summary>
        /// <returns></returns>
        public static ucNavigationView GetWindow()
        {
            if (_Instance == null)
            {
                lock (_lockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = new ucNavigationView();
                    }
                }
            }
            return _Instance;
        }

        public ucNavigationView()
        {
            InitializeComponent();
        }
    }
}
