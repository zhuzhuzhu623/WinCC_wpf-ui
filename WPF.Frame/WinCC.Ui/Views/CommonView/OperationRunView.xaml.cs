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

namespace WinCC.Ui.Views.CommonView
{
    /// <summary>
    /// OperationRunView.xaml 的交互逻辑
    /// </summary>
    public partial class OperationRunView : UserControl
    {
        public static OperationRunView _Instance = null;
        private static readonly object _lockObj = new object();
        public OperationRunView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取窗体实例
        /// </summary>
        /// <returns></returns>
        public static OperationRunView GetWindow()
        {
            if (_Instance == null)
            {
                lock (_lockObj)
                {
                    if (_Instance == null)
                    {
                        _Instance = new OperationRunView();
                    }
                }
            }
            return _Instance;
        }
        private void BtnNewPro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
