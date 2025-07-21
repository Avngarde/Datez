using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Datez.Db;
using Datez.Models;

namespace Datez.ViewModels;

public partial class EditEventPageViewModel : ObservableObject
{
    private readonly IDatabase<Event> _eventDb;
    private readonly IServiceProvider _serviceProvider;
    public Event Event;

    [ObservableProperty] private string? _eventName;
    [ObservableProperty] private DateTime _eventDate;
    [ObservableProperty] private DateTime _minimalDate = DateTime.Now;
    [ObservableProperty] private string? _eventColor;

    [RelayCommand]
    public async Task EditEvent()
    {
        Event.EventDate = EventDate;
        Event.Name = EventName;
        Event.ProgressBarColor = EventColor;

        await _eventDb.Edit(Event);

        //WeakReferenceMessenger.Default.Send(new RefreshEventsMessage());
        await Application.Current.MainPage.Navigation.PopAsync(true);
    }

    [RelayCommand]
    public void SelectColor(string color)
    {
        EventColor = color;
    }

    public EditEventPageViewModel(IDatabase<Event> eventDatabase, IServiceProvider serviceProvider)
    {
        _eventDb = eventDatabase;
        _serviceProvider = serviceProvider;
    }
}
