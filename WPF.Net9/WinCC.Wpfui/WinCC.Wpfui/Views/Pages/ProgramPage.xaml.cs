using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using WinCC.Wpfui.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Abstractions.Controls;

namespace WinCC.Wpfui.Views.Pages
{
    /// <summary>
    /// ProgramPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProgramPage : INavigableView<WinCC.Wpfui.ViewModels.ProgramViewModel>
    {
        public WinCC.Wpfui.ViewModels.ProgramViewModel ViewModel { get; }

        public ProgramPage(WinCC.Wpfui.ViewModels.ProgramViewModel viewModel, ISnackbarService snackbarService)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();

            ViewModel.LogContents.CollectionChanged += Items_CollectionChanged;
        }

        private void Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                // 获取最后一个添加的项
                if (e.NewItems != null)
                {
                    var newItem = e.NewItems[0];

                    // 滚动到最后一个添加的项
                    LogList.ScrollIntoView(newItem);
                }
            }
        }
    }
}
