using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Datez.Db;
using Datez.Helpers.Models;
using Datez.Messages;
using Datez.Models;
using Datez.Pages;
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
        private readonly IDatabase<Note> _noteDb;

        [ObservableProperty] private string _eventName;
        [ObservableProperty] private string? _timeLeft;
        [ObservableProperty] private string? _eventColor;
        [ObservableProperty] private List<Note> _notes;

        //Dynamic UI values
        [ObservableProperty] private GridLength _eventTimeHeight;
        [ObservableProperty] private GridLength _eventNotesHeight;
        [ObservableProperty] private GridLength _notesAddButtonHeight;
        [ObservableProperty] private GridLength _notesViewHeight;


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

        [RelayCommand]
        public async Task OpenEditEvent()
        {
            var ev = await _eventDb.Get(Event.Id);
            if (ev is not null)
            {
                var editEventPage = _serviceProvider.GetRequiredService<EditEventPage>();
                editEventPage.PassEvent(ev);
                await Application.Current.MainPage.Navigation.PushAsync(editEventPage);
            }
        }

        [RelayCommand]
        public async Task AddNote()
        {
            string noteContent = await Application.Current.MainPage.DisplayPromptAsync("Add Note", "Note Content:", maxLength: 50, keyboard: Keyboard.Text);
            if (noteContent != null && noteContent.Length > 0)
            {
                Note note = new()
                {
                    Content = noteContent,
                    EventId = Event.Id
                };

                await _noteDb.Add(note);
                await LoadNotes();
                SetGridHeights();
            }
        }

        [RelayCommand]
        public async Task DeleteNote(Note note)
        {
            await _noteDb.Delete(note);
            await LoadNotes();
            SetGridHeights();
        }

        public EventPageViewModel(IDatabase<Event> eventDatabase, IDatabase<Note> notesDatabase, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _eventDb = eventDatabase;
            _noteDb = notesDatabase;
        }

        public async Task LoadEvent()
        {
            if (Event != null)
            {
                await LoadNotes();
                TimeLeft = Event.TimeDifferenceString;
                EventName = Event.Name;
                EventColor = Event.ProgressBarColor;

                SetGridHeights();
            }
        }

        private async Task LoadNotes()
        {
            var notes = await _noteDb.GetAll();
            var eventNotes = notes.Where(ev => ev.EventId == Event.Id);
            Notes = eventNotes.ToList();
        }

        private void SetGridHeights()
        {
            if (Notes.Count > 0)
            {
                EventTimeHeight = new GridLength(60, GridUnitType.Star);
                EventNotesHeight = new GridLength(50, GridUnitType.Star);
                NotesAddButtonHeight = new GridLength(20, GridUnitType.Star);
                NotesViewHeight = new GridLength(80, GridUnitType.Star);
            }
            else
            {
                EventTimeHeight = new GridLength(60, GridUnitType.Star);
                EventNotesHeight = new GridLength(10, GridUnitType.Star);
                NotesAddButtonHeight = new GridLength(100, GridUnitType.Star);
                NotesViewHeight = new GridLength(0, GridUnitType.Star);
            }
        }
    }
}
