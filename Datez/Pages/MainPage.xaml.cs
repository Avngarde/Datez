using Datez.ViewModels;

namespace Datez.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel pageViewModel)
	{
		InitializeComponent();
		BindingContext = pageViewModel;

		Loaded += async (_, _) => await pageViewModel.LoadEvents();
	}
}

