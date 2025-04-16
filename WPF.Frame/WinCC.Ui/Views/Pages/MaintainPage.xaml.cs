using CommonModels.SystemEnums;
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
using WinCC.Bll.BllService;
using WinCC.Ui.Views.CameraView;
using WinCC.Ui.Views.CommonView;

namespace WinCC.Ui.Views.Pages
{
    /// <summary>
    /// MaintainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MaintainPage : Page
    {
        public MaintainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UcOperationRun.Content = OperationManualView.GetWindow();
            UcCameraDisplay.Content = CameraDisplayView.GetWindow();         
            UcLogView.Content = LogView.GetWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logger.Log("测试数据",EmLogLevel.DEBUG);
        }
    }
}
