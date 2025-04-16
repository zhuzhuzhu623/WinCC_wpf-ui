using CommonModels.SystemEntities;
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
using System.Windows.Shapes;

using WinCC.Bll;

namespace WinCC.Ui.Views.CameraView
{
    /// <summary>
    /// CameraDisplayView.xaml 的交互逻辑
    /// </summary>
    public partial class CameraDisplayView : UserControl
    {
        public static CameraDisplayView _Instance = null;
        private static readonly object _lockObj = new object();

        CogDisplayView cogDisplayViewFirst;

        /// <summary>
        /// 获取窗体实例
        /// </summary>
        /// <returns></returns>
        public static CameraDisplayView GetWindow()
        {
            if (_Instance == null)
            {
                lock (_lockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = new CameraDisplayView();
                    }
                }
            }
            return _Instance;
        }

        public CameraDisplayView()
        {
            InitializeComponent();

            CameraData camera = null;
            if (AppSession.SystemSetting != null)
            {
                camera = AppSession.SystemSetting.CameraDatas[0];
            }
            cogDisplayViewFirst = new CogDisplayView(camera);
             
        }
      
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CameraFirst.Content = cogDisplayViewFirst;
        }
    }
}
