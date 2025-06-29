using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Datez.Db;
using Datez.Pages;
using Datez.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using Datez.Helpers.Models;
using Datez.Helpers;
using CommunityToolkit.Mvvm.Messaging;
using Datez.Messages;

namespace Datez.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IDatabase<Event> _eventDb;

    [ObservableProperty] private bool _isLoading = true;
    [ObservableProperty] private ObservableCollection<EventUIModel> _events = new();

    [RelayCommand]
    public async Task OpenAddNewEvent()
    {
        var newEventPage = _serviceProvider.GetRequiredService<NewEventPage>();
        await Application.Current.MainPage.Navigation.PushAsync
        (
            newEventPage
        );
    }

    [RelayCommand]
    public async Task OpenEvent(EventUIModel ev)
    {
        var eventPage = _serviceProvider.GetRequiredService<EventPage>();
        await Application.Current.MainPage.Navigation.PushAsync
        (
            eventPage
        );
    }

    public MainPageViewModel(IDatabase<Event> eventDatabase, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _eventDb = eventDatabase;

        WeakReferenceMessenger.Default.Register<RefreshEventsMessage>(this, async (r, m) =>
        {
            await LoadEvents();
        });
    }
    
    public async Task LoadEvents()
    {
        Events.Clear();
        var eventsDb = await _eventDb.GetAll();
        foreach(Event ev in eventsDb.ToArray())
        {
            TimeDiff timeDifference = TimeDifference.Calculate(ev.EventDate, DateTime.Now);
            Events.Add(
                new EventUIModel()
                {
                    Id = ev.Id,
                    Name = ev.Name,
                    EventDate = ev.EventDate,
                    TimeDifferenceString = CreateTimeDifferenceString(timeDifference),
                    TimeDifferenceProgress = TimeDifference.CalculateTimeProgress(timeDifference.Days, ev.OriginalDaysDifference),
                    ProgressBarColor = ev.ProgressBarColor
                }
            );
        }

        IsLoading = false;
    }

    private string CreateTimeDifferenceString(TimeDiff diff)
    {
        string timeDiff = "";

        if (diff.Days <= 0 && diff.Months <= 0 && diff.Years <= 0)
            return "Event Due";

        if (diff.Days > 0)
            timeDiff += $"{diff.Days} Days";

        if (diff.Months > 0)
            timeDiff += $", {diff.Months} Months";

        if (diff.Years > 0)
            timeDiff += $", {diff.Years} Years";

        return timeDiff;
    }
}
