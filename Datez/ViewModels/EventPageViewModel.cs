using CommunityToolkit.Mvvm.ComponentModel;

using Datez.Helpers.Models;

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
        [ObservableProperty] private string _eventName;
        [ObservableProperty] private string? _timeLeft;
        [ObservableProperty] private string? _eventColor;

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
