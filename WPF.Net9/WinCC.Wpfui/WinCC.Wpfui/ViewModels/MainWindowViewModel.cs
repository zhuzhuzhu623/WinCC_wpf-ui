// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace WinCC.Wpfui.ViewModels;

public partial class MainWindowViewModel : ViewModel
{
    private bool _isInitialized = false;

    [ObservableProperty]
    private string _applicationTitle = string.Empty;

    [ObservableProperty]
    private ObservableCollection<object> _navigationItems = [];

    [ObservableProperty]
    private ObservableCollection<object> _navigationFooter = [];

    [ObservableProperty]
    private ObservableCollection<MenuItem> _trayMenuItems = [];

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE0060:Remove unused parameter",
        Justification = "Demo"
    )]
    public MainWindowViewModel(INavigationService navigationService)
    {
        if (!_isInitialized)
        {
            InitializeViewModel();
        }
    }

    private void InitializeViewModel()
    {
        // ApplicationTitle = "WPF UI - MVVM Demo";

        NavigationItems =
        [
            new NavigationViewItem()
            {
                Content = "Auto",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },   Width = 105, Height=70,HorizontalAlignment = HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.DashboardPage),    Margin = new Thickness(0 ,10 ,0 ,0)
            },
            new NavigationViewItem()
            {
                Content = "Edit",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },   Width = 105,Height=70,HorizontalAlignment = HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),    Margin = new Thickness(0 ,10 ,0 ,0)
            },
              new NavigationViewItem()
            {
                Content = "Param",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PositionForward24 },   Width = 105,Height=70,HorizontalAlignment = HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0 ,10 ,0 ,0)
            },  
            new NavigationViewItem()
            {
                Content = "Device",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PositionForward24 },   Width = 105,Height=70,HorizontalAlignment = HorizontalAlignment.Center,
                TargetPageType = typeof(Views.Pages.ProgramPage),
                Margin = new Thickness(0 ,10 ,0 ,0)
            },
        ];

        NavigationFooter =
        [
            new NavigationViewItem()
            {
                Content = "Help",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                Width = 100,HorizontalAlignment = HorizontalAlignment.Left,
               TargetPageType = typeof(Views.Pages.SettingsPage),
            },
        ];

        TrayMenuItems = [new() { Header = "Home", Tag = "tray_home" }];

        _isInitialized = true;
    }
}
