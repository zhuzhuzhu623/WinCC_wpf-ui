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
using Wpf.Ui.Controls;

namespace WinCC.Wpfui.DialogViews
{
    /// <summary>
    /// DialogLocationEdit.xaml 的交互逻辑
    /// </summary>
    public partial class DialogLocationEdit : ContentDialog
    {
        public DialogLocationEdit(ContentPresenter? contentPresenter)
       : base(contentPresenter)
        {
            InitializeComponent();
        }

        protected override void OnButtonClick(ContentDialogButton button)
        {
          
        }

    }
}
