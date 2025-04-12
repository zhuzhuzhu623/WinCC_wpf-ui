using CommonModels.SystemEntities;
using CommonModels.SystemEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinCC.Bll.BllService;

namespace WinCC.FormDialog
{
    /// <summary>
    /// formCameraData.xaml 的交互逻辑
    /// </summary>
    public partial class formCameraData : Window
    {
        public bool Add = false;
        public CameraData CameraData { get; set; } 
        public formCameraData()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;
        }
        public formCameraData(CameraData cameraData)
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;

            CameraData = cameraData;    
        }

        private void txtCameraWidth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private bool IsTextAllowed(string text)
        {
            return Regex.IsMatch(text, "^[0-9]*$");
        }

        private void txtCameraHeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            CameraData.Name = txtCameraName.Text;
            CameraData.SerialNumber = txtCameraserName.Text;
            if(txtCameraWidth.Text == "")
            {
                DialogSnack.View("相机宽度未设置",EmLogLevel.ERROR);
                return ;
            }
            if (txtCameraHeight.Text == "")
            {
                DialogSnack.View("相机高度未设置", EmLogLevel.ERROR);
                return;
            }
            CameraData.Width = int.Parse(txtCameraWidth.Text);
            CameraData.Height = int.Parse(txtCameraHeight.Text);

            this.DialogResult = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Add)
                CameraData = new CameraData();

            txtCameraName.Text = CameraData.Name;
            txtCameraserName.Text = CameraData.SerialNumber;
            txtCameraWidth.Text = CameraData.Width.ToString();
            txtCameraHeight.Text = CameraData.Height.ToString();
        }
    }
}
