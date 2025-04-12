// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommonModels.Entitis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace WinCC.Wpfui.ViewModels;

public partial class ProgramViewModel(ISnackbarService snackbarService, ILogger<ProgramViewModel> logger) : ViewModel
{
    [ObservableProperty]
    private int _selectedLogIndex =0;
    [ObservableProperty]
    private ObservableCollection<LogContent> _logContents = new ObservableCollection<LogContent>();
    private ControlAppearance _snackbarAppearance = ControlAppearance.Secondary;
    [ObservableProperty]
    private List<MenuOperation> _menuOperations = new List<MenuOperation>();

    [ObservableProperty]
    private int _snackbarTimeout = 2;


    public override void OnNavigatedTo()
    {
        MenuOperations.Add(new MenuOperation() { MenuName = "基础参数"});
        MenuOperations.Add(new MenuOperation() { MenuName = "视觉/打标" });
        MenuOperations.Add(new MenuOperation() { MenuName = "坏板检测" });
    }

    [RelayCommand]
    private async void Autorun()
    {

        SetLogContent(new LogContent() { Content = "123", LogLevel = "ssss" });

        snackbarService.Show( "Don't Blame Yourself.", "No Witcher's Ever Died In His Bed.", ControlAppearance.Success,   new SymbolIcon(SymbolRegular.Fluent24),  TimeSpan.FromSeconds(SnackbarTimeout));

        var uiMessageBox = new Wpf.Ui.Controls.MessageBox
        {
            Title = "WPF UI Message Box",
            Content =
               "Never gonna give you up, never gonna let you down Never gonna run around and desert you Never gonna make you cry, never gonna say goodbye",
           // Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#488DFD")),
        };

        _ = await uiMessageBox.ShowDialogAsync();

    }

    private void SetLogContent(LogContent logContent)
    {
        if (LogContents == null)
            LogContents = new ObservableCollection<LogContent>();
        if (LogContents.Count > 500)
            LogContents.Remove(LogContents[0]);
        LogContents.Add(logContent);
        SelectedLogIndex = LogContents.Count - 1;

        logger.LogWarning("123");
    }

    private void UpdateSnackbarAppearance(int appearanceIndex)
    {
        _snackbarAppearance = appearanceIndex switch
        {
            1 => ControlAppearance.Secondary,
            2 => ControlAppearance.Info,
            3 => ControlAppearance.Success,
            4 => ControlAppearance.Caution,
            5 => ControlAppearance.Danger,
            6 => ControlAppearance.Light,
            7 => ControlAppearance.Dark,
            8 => ControlAppearance.Transparent,
            _ => ControlAppearance.Primary,
        };
    }
}
