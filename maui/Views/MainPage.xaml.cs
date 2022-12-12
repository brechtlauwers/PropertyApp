namespace maui;
using maui.Services;
using maui.Models;
using maui.ViewModels;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageVM viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as MainPageVM).GetPropertiesAsync();
	}
}

