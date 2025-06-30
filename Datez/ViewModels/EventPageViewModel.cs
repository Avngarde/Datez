using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Datez.Db;
using Datez.Helpers.Models;
using Datez.Messages;
using Datez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datez.ViewModels
{
    public partial class EventPageViewModel : ObservableObject
    {
        public EventUIModel? Event { get; set; }
        private readonly IServiceProvider _serviceProvider;
        private readonly IDatabase<Event> _eventDb;

        [ObservableProperty] private string _eventName;
        [ObservableProperty] private string? _timeLeft;
        [ObservableProperty] private string? _eventColor;


        [RelayCommand]
        public async Task DeleteEvent()
        {
            var ev = await _eventDb.Get(Event.Id);
            int result = await _eventDb.Delete(ev);
            if (result > 0)
            {
                WeakReferenceMessenger.Default.Send(new RefreshEventsMessage());
                await Application.Current.MainPage.Navigation.PopAsync(true);
            }
        }

        public EventPageViewModel(IDatabase<Event> eventDatabase, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _eventDb = eventDatabase;
        }

        public void LoadEvent()
        {
            if (Event != null)
            {
                TimeLeft = Event.TimeDifferenceString;
                EventName = Event.Name;
                EventColor = Event.ProgressBarColor;
            }
        }
    }
}
