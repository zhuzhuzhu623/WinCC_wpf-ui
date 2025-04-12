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
using WinCC.Bll.Entities;
using Wpf.Ui.Controls;

namespace WinCC.Wpfui.DialogViews
{
    /// <summary>
    /// DialogLocation.xaml 的交互逻辑
    /// </summary>
    public partial class DialogLocation : ContentDialog
    {
        public CreateLocationData CreateLocationData { get; set; }
        public DialogLocation(ContentPresenter? contentPresenter)
     : base(contentPresenter)
        {
            InitializeComponent();

            CreateLocationData = new CreateLocationData();  
        }

        protected override void OnButtonClick(ContentDialogButton button)
        {
            CreateLocationData.Row = (int)txtRow.Value;
            CreateLocationData.Column = (int)txtCol.Value;
            CreateLocationData.Layer = (int)txtLayer.Value;
            base.OnButtonClick(button);
            return;
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            txtRow.Value = CreateLocationData.Row;
            txtCol.Value = CreateLocationData.Column;
            txtLayer.Value = CreateLocationData.Layer;
        }
    }
}
