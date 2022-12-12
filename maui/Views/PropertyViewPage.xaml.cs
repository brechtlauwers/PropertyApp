namespace maui;
using maui.Services;
using maui.Models;
using maui.ViewModels;

public partial class PropertyViewPage : ContentPage
{
    public PropertyViewPage(PropertyDetailVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}