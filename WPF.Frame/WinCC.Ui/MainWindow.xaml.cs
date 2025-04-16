using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinCC.Bll.BllService;
using WinCC.Ui.Views.CameraView;
using WinCC.Ui.Views.CommonView;
using Wpf.Ui;
using Wpf.Ui.Abstractions;
using Wpf.Ui.Controls;

namespace WinCC.Ui
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : INavigationWindow
    {
        LogView _LogView;
        public MainWindow()
        {
            Wpf.Ui.Appearance.SystemThemeWatcher.Watch(this);

            InitializeComponent();

            NavigationItems = new List<NavigationViewItem>();
            NavigationItems.Add(new NavigationViewItem()
            {
                Content = "运行",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                Width = 95,
                Height = 80,
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0, 0, 0, 0),
             
            });
            NavigationItems.Add(new NavigationViewItem()
            {
                Content = "编程",
                Icon = new SymbolIcon { Symbol = SymbolRegular.BranchCompare24 },
                Width = 95,
                Height = 80,
                FontSize = 24,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0, 0, 0, 0),
            });
            NavigationItems.Add(new NavigationViewItem()
            {
                Content = "设备",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PositionForward24 },
                Width = 95,
                Height = 80,
                FontSize = 24,
                HorizontalAlignment= System.Windows.HorizontalAlignment.Center, 
                TargetPageType = typeof(Views.Pages.MaintainPage),
                Margin = new Thickness(0, 0, 0, 0),
            });
            RootNavigation.MenuItemsSource = NavigationItems;
        
            _LogView = LogView.GetWindow();

        }

        public List<NavigationViewItem> NavigationItems { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Logger.LogWrite += Logger_LogWrite;
            
            Navigate(NavigationItems[0].TargetPageType);

        }

        private void Logger_LogWrite(object sender, LogEventArgs args)
        {
            Dispatcher.Invoke(() =>
            {
                _LogView.Log(args.Content, args.LogLevel);

            });
        }

        public INavigationView GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(INavigationViewPageProvider navigationViewPageProvider) =>
            RootNavigation.SetPageProviderService(navigationViewPageProvider);

        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            System.Windows.Application.Current.Shutdown();
        }

        INavigationView INavigationWindow.GetNavigation()
        {
            throw new NotImplementedException();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            // 调整窗口大小以避开任务栏
            //Rect screenWorkingArea = SystemParameters.WorkArea;
            //this.Left = screenWorkingArea.Left;
            //this.Top = screenWorkingArea.Top;
            //this.Width = screenWorkingArea.Width;
            //this.Height = screenWorkingArea.Height;
        }
    }
}
