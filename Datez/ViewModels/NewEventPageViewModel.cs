using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Datez.Db;
using Datez.Helpers.Models;
using Datez.Messages;
using Datez.Models;

namespace Datez.ViewModels;

public partial class NewEventPageViewModel : ObservableObject
{
    private readonly IDatabase<Event> _eventDb;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty] private string? _eventName;
    [ObservableProperty] private DateTime _eventDate;
    [ObservableProperty] private DateTime _minimalDate = DateTime.Now;
    [ObservableProperty] private string? _eventColor;

    [RelayCommand]
    public async Task AddEvent()
    {
        TimeSpan originalDateDifference = EventDate - DateTime.Now;
        Event ev = new()
        {
            Name = EventName,
            CreateDate = DateTime.Now,
            EventDate = EventDate,
            OriginalDaysDifference = originalDateDifference.Days,
            ProgressBarColor = EventColor
        };

        await _eventDb.Add(ev);

        WeakReferenceMessenger.Default.Send(new RefreshEventsMessage());
        await Application.Current.MainPage.Navigation.PopAsync(true);
    }

    [RelayCommand]
    public void SelectColor(string color)
    {
        EventColor = color;
    }

    public NewEventPageViewModel(IDatabase<Event> eventDatabase, IServiceProvider serviceProvider)
    {
        _eventDb = eventDatabase;
        _serviceProvider = serviceProvider;
    }
}
