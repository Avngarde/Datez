using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Datez.Db;
using Datez.Models;

namespace Datez.ViewModels;

public partial class NewEventPageViewModel : ObservableObject
{
    private readonly IDatabase<Event> _eventDb;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty] private string? _eventName;
    [ObservableProperty] private DateTime _eventDate;
    [ObservableProperty] private DateTime _minimalDate = DateTime.Now;

    [RelayCommand]
    public async Task AddEvent()
    {
        TimeSpan originalDateDifference = EventDate - DateTime.Now;
        Event ev = new()
        {
            Name = EventName,
            CreateDate = DateTime.Now,
            EventDate = EventDate,
            OriginalDaysDifference = originalDateDifference.Days
        };

        await _eventDb.Add(ev);
    }

    public NewEventPageViewModel(IDatabase<Event> eventDatabase, IServiceProvider serviceProvider)
    {
        _eventDb = eventDatabase;
        _serviceProvider = serviceProvider;
    }
}
