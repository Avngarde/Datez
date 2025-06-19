using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Datez.Pages;

namespace Datez.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] private string _testText = "Test";

    [RelayCommand]
    public async Task OpenAddNewEvent()
    {
        await Application.Current.MainPage.Navigation.PushAsync
        (
            new NewEventPage()
        );
    }
}
