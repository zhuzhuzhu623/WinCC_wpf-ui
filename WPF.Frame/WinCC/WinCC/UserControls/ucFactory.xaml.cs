using Cognex.VisionPro.Exceptions;
using CommonModels;
using CommonModels.Entities;
using CommonModels.SystemEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WinCC.Bll;
using WinCC.FormDialog;

namespace WinCC.UserControls
{
    /// <summary>
    /// ucFactory.xaml 的交互逻辑
    /// </summary>
    public partial class ucFactory : UserControl
    {
        public ucFactory()
        {
            InitializeComponent();
        }
        List<MenuOperation> MenuOperations;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MenuOperations = new List<MenuOperation>();
            MenuOperation menu = new MenuOperation();
            menu.MenuName = "原厂配置";
            menu.Id = 0;
            MenuOperations.Add(menu);
            menu = new MenuOperation();
            menu.MenuName = "原厂参数";
            menu.Id = 1;
            MenuOperations.Add(menu);
            listMeun.ItemsSource = MenuOperations;
          
            InitSystemSetting();
        }

        private void InitSystemSetting()
        {
          
            gridCameraList.ItemsSource = null;
            gridCameraList.Items.Refresh(); 
            gridCameraList.ItemsSource = AppSession.SystemSetting.CameraDatas;

            AppSession.SaveSystemSetting();
        }

        private void listMeun_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabPageMeun.SelectedIndex = listMeun.SelectedIndex;
        }

        private void btnCameraAdd_Click(object sender, RoutedEventArgs e)
        {
            formCameraData formCameraData = new formCameraData();
            formCameraData.Add = true;
            var resultDialog = (bool)formCameraData.ShowDialog();
            if (!resultDialog) return;
            AppSession.SystemSetting.CameraDatas.Add(formCameraData.CameraData);

            InitSystemSetting();

        }

        private void btnCameraDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var resultIndex = gridCameraList.SelectedIndex;
                AppSession.SystemSetting.CameraDatas.RemoveAt(resultIndex);

            
                InitSystemSetting();
            }
            catch
            {

            }
            
        }
    }
}
