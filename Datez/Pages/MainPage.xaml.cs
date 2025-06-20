using Datez.ViewModels;

namespace Datez.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel pageViewModel)
	{
		InitializeComponent();
		BindingContext = pageViewModel;
	}
}

