namespace maui;
using maui.Services;
using maui.Models;
using maui.ViewModels;

public partial class AddPropertyPage : ContentPage
{
    public AddPropertyPage(AddPropertyVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}