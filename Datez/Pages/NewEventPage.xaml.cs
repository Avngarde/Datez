using Datez.ViewModels;

namespace Datez.Pages;

public partial class NewEventPage : ContentPage
{
	public NewEventPage(NewEventPageViewModel pageViewModel)
	{
		InitializeComponent();
		BindingContext = pageViewModel;
	}
}