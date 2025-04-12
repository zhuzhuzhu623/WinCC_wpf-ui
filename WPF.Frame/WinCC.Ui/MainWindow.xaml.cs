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
using WinCC.Ui.Views.CameraView;
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
        
        public MainWindow()
        {
            Wpf.Ui.Appearance.SystemThemeWatcher.Watch(this);

            InitializeComponent();

            NavigationItems = new List<NavigationViewItem>();
            NavigationItems.Add(new NavigationViewItem()
            {
                Content = "运行",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                Width = 105,
                Height = 70,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0, 10, 0, 0)
            });
            NavigationItems.Add(new NavigationViewItem()
            {
                Content = "编程",
                Icon = new SymbolIcon { Symbol = SymbolRegular.BranchCompare24 },
                Width = 105,
                Height = 70,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0, 10, 0, 0)
            });
            NavigationItems.Add(new NavigationViewItem()
            {
                Content = "设备",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PositionForward24 },
                Width = 105,
                Height = 70,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0, 10, 0, 0)
            });
            RootNavigation.MenuItemsSource = NavigationItems;
        }

        public List<NavigationViewItem> NavigationItems { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
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
    }
}
