using CommonModels.BllModel;
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
using WinCC.Ui.Views.CameraView;

namespace WinCC.Ui
{
    /// <summary>
    /// WinLog.xaml 的交互逻辑
    /// </summary>
    public partial class WinLog : Window
    {
        public WinLog()
        {
            InitializeComponent();
        }

        public BllResult Init()
        {
            lblLoad.Dispatcher.Invoke(() => {
                lblLoad.Content = "正在加载系统......";
            });
            var result = AppSession.InitSystemSetting();
            if (!result.Success) return result;
            lblLoad.Dispatcher.Invoke(() => {
                lblLoad.Content = "正在加载配置......";
            });
            ImageResources.Init();
            result = AppSession.InitOthers();
            if (!result.Success) return result;
            lblLoad.Dispatcher.Invoke(() => {
                lblLoad.Content = "正在初始化相机......";
            });
            result = AppSession.InitVision();
            if (!result.Success) return result;
            lblLoad.Dispatcher.Invoke(() => {
                lblLoad.Content = "正在初始化控制器......";
            });

            result = AppSession.InitMotion();

            lblLoad.Dispatcher.Invoke(() => {
                lblLoad.Content = "加载成功......";
            });
            return result;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;
            var result = BllResultFactory.Sucess();
            await Task.Run(() =>
            {
                result = Init();
            });

            if (!result.Success)
            {
                IsEnabled = true;
                return;
            }
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            IsEnabled = true;
            try
            {
                this.Show();
            }
            catch (Exception ex)
            {

            }

            lblLoad.Content = "加载成功......";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // ucCameraFirstContent.Content = _cogDispalyView;
        }
    }
}
