using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Datez.Db;
using Datez.Pages;
using Datez.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;

namespace Datez.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IDatabase<Event> _eventDb;

    [ObservableProperty] private ObservableCollection<Event> _events = new();

    [RelayCommand]
    public async Task OpenAddNewEvent()
    {
        var newEventPage = _serviceProvider.GetRequiredService<NewEventPage>();
        await Application.Current.MainPage.Navigation.PushAsync
        (
            newEventPage
        );
    }

    public MainPageViewModel(IDatabase<Event> eventDatabase, IServiceProvider serviceProvider) 
    { 
        _serviceProvider = serviceProvider;
        _eventDb = eventDatabase;
    }
    
    public async Task LoadEvents()
    {
        Events.Clear();
        var eventsDb = await _eventDb.GetAll();
        Events = eventsDb.ToObservableCollection<Event>();
    }
}
