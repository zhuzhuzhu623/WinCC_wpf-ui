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

namespace WinCC.UserControls
{
    /// <summary>
    /// ucMaintain.xaml 的交互逻辑
    /// </summary>
    public partial class ucMaintain : UserControl
    {
        public ucMaintain()
        {
            InitializeComponent();
        }
        List<MenuOperation> MenuOperations;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MenuOperations = new List<MenuOperation>();
            MenuOperation menu = new MenuOperation();
            menu.MenuName = "相机校准";
            menu.Id = 0;
            MenuOperations.Add(menu);
            menu = new MenuOperation();
            menu.MenuName = "M0M1";
            menu.Id = 1;
            MenuOperations.Add(menu);
            menu = new MenuOperation();
            menu.MenuName = "基本参数";
            menu.Id = 2;
            MenuOperations.Add(menu);
            listMeun.ItemsSource= MenuOperations;
        }

        private void listMeun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabPageMeun.SelectedIndex = listMeun.SelectedIndex;
        }
    }
}
