namespace maui.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using maui.Models;
using maui.Services;

[QueryProperty(nameof(Property), "Property")]
public partial class PropertyDetailVM : BaseVM
{
    IDataService _dataService;

    public PropertyDetailVM(IDataService dataService)
    {
        this._dataService = dataService;
    }

    [ObservableProperty]
    Property property;

    [RelayCommand]
    async Task DeleteButton()
    {
        await _dataService.DeletePropAsync(property.Id);
        await App.Current.MainPage.Navigation.PopAsync();
    }
}