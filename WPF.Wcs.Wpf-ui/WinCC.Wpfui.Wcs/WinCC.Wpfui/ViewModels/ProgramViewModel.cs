// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommonModels.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using WinCC.Bll;
using WinCC.Wpfui.DialogViews;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace WinCC.Wpfui.ViewModels;

public partial class ProgramViewModel(ISnackbarService snackbarService, ILogger<ProgramViewModel> logger, IBllLocation bllLocation, IContentDialogService contentDialogService) : ViewModel
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

    [ObservableProperty]
    private List<Location> _locations;

    [ObservableProperty]
    private List<Location> _currentLocations;

    public override async void OnNavigatedTo()
    {
        var result = await  bllLocation.GetLocation();
        if (result.Success)
            Locations = result.Data;

        GetSkipPageAmount();
    }

    [RelayCommand]
    private async void Select()
    {
        //snackbarService.Show( "Don't Blame Yourself.", "No Witcher's Ever Died In His Bed.", ControlAppearance.Success,   new SymbolIcon(SymbolRegular.Fluent24),  TimeSpan.FromSeconds(SnackbarTimeout));

        //var uiMessageBox = new Wpf.Ui.Controls.MessageBox
        //{
        //    Title = "WPF UI Message Box",
        //    Content =
        //       "Never gonna give you up, never gonna let you down Never gonna run around and desert you Never gonna make you cry, never gonna say goodbye",
        //   // Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#488DFD")),
        //};

        //_ = await uiMessageBox.ShowDialogAsync();

        var resultLo = await bllLocation.GetLocation();
        if (resultLo.Success)
            Locations = resultLo.Data;
        else
            snackbarService.Show("库位", "查询失败", ControlAppearance.Danger, new SymbolIcon(SymbolRegular.Fluent24), TimeSpan.FromSeconds(SnackbarTimeout));
        SkipPageList();

    }

    [RelayCommand]
    private async void Create()
    {
        //ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
        //    new SimpleContentDialogCreateOptions()
        //    {
        //        Title = "Save your work?",
        //        Content = "",
        //        PrimaryButtonText = "Save",
        //        SecondaryButtonText = "Don't Save",
        //        CloseButtonText = "Cancel",
        //    }
        //);

        var result = new DialogLocation(contentDialogService.GetDialogHost());
        _ = await result.ShowAsync();

        var resultData = result.CreateLocationData;

        if (resultData == null) return;

         var resultCre =   await bllLocation.CreateLocation(resultData);
        if (!resultCre.Success)
        {
            return;
        }

        var resultLo = await bllLocation.GetLocation();
        if (resultLo.Success)
            Locations = resultLo.Data;

        snackbarService.Show("成功", "生成库位成功", ControlAppearance.Success, new SymbolIcon(SymbolRegular.Fluent24), TimeSpan.FromSeconds(SnackbarTimeout));
    }

    [RelayCommand]
    private async void Modify()
    {

    }


    #region 页面跳转

    private int PageCount = 16;

    [ObservableProperty]
    private double? _skipPageNumber = 1;

    [ObservableProperty]
    private int _skipPageAmount = 1;

    [RelayCommand]
    private async void NextPage()
    {
        if (SkipPageNumber >= SkipPageAmount) return;
        SkipPageNumber = SkipPageNumber + 1;
        SkipPageList();
    }

    [RelayCommand]
    private async void PreviousPage()
    {
        if (SkipPageNumber <= 1) return;
        SkipPageNumber = SkipPageNumber - 1;
        SkipPageList();
    }

    [RelayCommand]
    private async void SkipPage()
    {
        SkipPageList();
    }

    private void GetSkipPageAmount()
    {
        SkipPageAmount = (Locations.Count / PageCount) + 1;
    }
    private void SkipPageList()
    {
        if(SkipPageNumber == null)
        {
            SkipPageNumber = 1;return;
        }
        if (Locations == null) return;

            CurrentLocations = null;
            int currentPage = (int)SkipPageNumber;
            CurrentLocations = Locations.Skip((currentPage - 1)  * PageCount).Take( PageCount).ToList();
        
       
    }


    #endregion
    private void SetLogContent(LogContent logContent)
    {
        //if (LogContents == null)
        //    LogContents = new ObservableCollection<LogContent>();
        //if (LogContents.Count > 500)
        //    LogContents.Remove(LogContents[0]);
        //LogContents.Add(logContent);
        //SelectedLogIndex = LogContents.Count - 1;

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

