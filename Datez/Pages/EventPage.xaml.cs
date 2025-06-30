using Datez.Helpers.Models;
using Datez.ViewModels;

namespace Datez.Pages;

public partial class EventPage : ContentPage
{
	public EventPage(EventPageViewModel eventPageViewModel)
	{
		InitializeComponent();
		BindingContext = eventPageViewModel;

		Loaded += (_, _) => eventPageViewModel.LoadEvent();
    }

    public void PassEvent(EventUIModel ev)
    {
        if (BindingContext is EventPageViewModel vm)
        {
            vm.Event = ev;
        }
    }
}