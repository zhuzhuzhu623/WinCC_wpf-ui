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
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui;

namespace WinCC.Wpfui.Views.Pages
{
    /// <summary>
    /// TaskRecordPage.xaml 的交互逻辑
    /// </summary>
    public partial class TaskRecordPage : INavigableView<WinCC.Wpfui.ViewModels.TaskRecordViewModel>
    {
        public WinCC.Wpfui.ViewModels.TaskRecordViewModel ViewModel { get; }

        public TaskRecordPage(WinCC.Wpfui.ViewModels.TaskRecordViewModel viewModel, ISnackbarService snackbarService)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();


        }

    }
}
