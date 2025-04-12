using CommonModels.Entities;
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
using WinCC.UserControlsCom;

namespace WinCC.VisionProView
{
    /// <summary>
    /// ucCameraListView.xaml 的交互逻辑
    /// </summary>
    public partial class ucCameraListView : UserControl
    {

        public static ucCameraListView _Instance = null;
        private static readonly object _lockObj = new object();

        /// <summary>
        /// 获取窗体实例
        /// </summary>
        /// <returns></returns>
        public static ucCameraListView GetWindow()
        {
            if (_Instance == null)
            {
                lock (_lockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = new ucCameraListView();
                    }
                }
            }
            return _Instance;
        }   

        public ucCameraListView()
        {
            InitializeComponent();
        }

        ucCogDisplay _ucCogDisplayFirst;

        ucCogDisplay _ucCogDisplaySceond;

        private  void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _ucCogDisplayFirst = new ucCogDisplay();
                ucCameraFirstContent.Content = _ucCogDisplayFirst;
            }
            catch
            {

            }

        }
    }
}
