using CommonModels.Entities;
using CommonModels.SystemEnums;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
using WinCC.UserControls;
using WinCC.UserControlsCom;
using WinCC.VisionProView;

namespace WinCC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<RoleMenuOperation> MenuOperation { get; set; }  

        ucAutoRun ucAutoRun = new ucAutoRun();  

       ucProgram ucProgram = new ucProgram();   

        ucMaintain ucMaintain = new ucMaintain();

        ucFactory ucFactory = new ucFactory();  

        ucCameraListView _ucCameraListView;

        ucLogView _ucLogView;  
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MenuOperation = new List<RoleMenuOperation>();  

            RoleMenuOperation roleMenuOperation = new RoleMenuOperation();
            roleMenuOperation.Id = 0;
            roleMenuOperation.Url = "pack://application:,,,/Asserts/Photos/Auto.png";
            roleMenuOperation.MenuName = "自动";
            MenuOperation.Add(roleMenuOperation);

            roleMenuOperation = new RoleMenuOperation();
            roleMenuOperation.Id = 0;
            roleMenuOperation.Url = "pack://application:,,,/Asserts/Photos/Edit.png";
            roleMenuOperation.MenuName = "编程";
            MenuOperation.Add(roleMenuOperation);

            roleMenuOperation = new RoleMenuOperation();
            roleMenuOperation.Id = 0;
            roleMenuOperation.Url = "pack://application:,,,/Asserts/Photos/Manual.png";
            roleMenuOperation.MenuName = "维护";
            MenuOperation.Add(roleMenuOperation);

            roleMenuOperation = new RoleMenuOperation();
            roleMenuOperation.Id = 0;
            roleMenuOperation.Url = "pack://application:,,,/Asserts/Photos/Manual.png";
            roleMenuOperation.MenuName = "原厂";
            MenuOperation.Add(roleMenuOperation);

            listBoxMain.ItemsSource = MenuOperation;
            listBoxMain.SelectedIndex = 0;


            _ucCameraListView = ucCameraListView.GetWindow();
            ucCameraContent.Content = _ucCameraListView;
            
            _ucLogView = new ucLogView();
            ucLogContent.Content = _ucLogView;

            Logger.LogWrite += Logger_LogWrite;

            DialogSnack.DialogSnackbar += Dialog_DialogSnackbar;
        }

        private void Dialog_DialogSnackbar(object sender, LogEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                snackbarOne.MessageQueue.Enqueue(args.Content, null, null, null, false, true, TimeSpan.FromSeconds(2000));
            });
        }

        /// <summary>
        /// 全局日志控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Logger_LogWrite(object sender, LogEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                _ucLogView.Log(args.Content, args.LogLevel);
           
            });
        }

        private void btnMinimized_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void listBoxMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ucViewContent.Content = null;
            if (listBoxMain.SelectedIndex == 0)
            {
                btnExecute.Visibility = Visibility.Visible;
                btnStop.Visibility = Visibility.Visible;

                ucViewContent.Content = null;
                ucViewContent.Content = ucAutoRun;
            }
            if (listBoxMain.SelectedIndex == 1)
            {
                btnExecute.Visibility = Visibility.Visible;
                btnStop.Visibility = Visibility.Visible;

                ucViewContent.Content = null;
                ucViewContent.Content = ucProgram;
            }
            if (listBoxMain.SelectedIndex == 2)
            {
                btnExecute.Visibility = Visibility.Collapsed;
                btnStop.Visibility = Visibility.Collapsed;

                ucViewContent.Content = null;
                ucViewContent.Content = ucMaintain;
            }
            if (listBoxMain.SelectedIndex == 3)
            {
                btnExecute.Visibility = Visibility.Collapsed;
                btnStop.Visibility = Visibility.Collapsed;

                ucViewContent.Content = null;
                ucViewContent.Content = ucFactory;
            }

        }     
        public void ShowControls()
        {
            
        }
        public static void ShowProgressView()
        {
           
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            Logger.Log("执行", EmLogLevel.INFO);
            DialogSnack.View("执行",EmLogLevel.INFO);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Logger.Log("停机", EmLogLevel.INFO);;
            DialogSnack.View("停机", EmLogLevel.INFO);
        }
    }

}
