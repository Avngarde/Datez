using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Datez.Pages;

namespace Datez.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty] private string _testText = "Test";

    [RelayCommand]
    public async Task OpenAddNewEvent()
    {
        var newEventPage = _serviceProvider.GetRequiredService<NewEventPage>();
        await Application.Current.MainPage.Navigation.PushAsync
        (
            newEventPage
        );
    }

    public MainPageViewModel(IServiceProvider serviceProvider) 
    { 
        _serviceProvider = serviceProvider;
    }
}
