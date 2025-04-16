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
using WinCC.Ui.Views.CameraView;
using WinCC.Ui.Views.CommonView;
using Wpf.Ui.Controls;

namespace WinCC.Ui.Views.Pages
{
    /// <summary>
    /// ProgramPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProgramPage : Page
    {
        public ProgramPage()
        {
            InitializeComponent();

           
        }
      
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UcOperationRun.Content = OperationRunView.GetWindow();
            UcCameraDisplay.Content = CameraDisplayView.GetWindow();
            UcNavigationView.Content = NavigationImageView.GetWindow();
            UcLogView.Content = LogView.GetWindow();
        }

        private void BtnNewPro_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
