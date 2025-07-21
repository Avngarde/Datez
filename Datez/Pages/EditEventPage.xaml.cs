using Datez.Models;
using Datez.ViewModels;

namespace Datez.Pages;

public partial class EditEventPage : ContentPage
{
	public EditEventPage(EditEventPageViewModel editEventPageViewModel)
	{
		InitializeComponent();
		BindingContext = editEventPageViewModel;
	}

	public void PassEvent(Event ev)
	{
		if (BindingContext is EditEventPageViewModel vm)
        {
			vm.Event = ev;

			vm.EventName = ev.Name;
			vm.EventDate = ev.EventDate;
			vm.MinimalDate = ev.EventDate;
			vm.EventColor = ev.ProgressBarColor;
        }
	}
}