using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

using maui.Services;
using maui.Models;

namespace maui.ViewModels;

public partial class MainPageVM : BaseVM
{
    IDataService _dataService;
    public ObservableCollection<Property> Properties {get;} = new();
    public String UpperTitle { get; set; }

    [ObservableProperty]
    bool isRefreshing=true;

    [ObservableProperty]
    Property selectedProperty;


    public MainPageVM(IDataService dataService)
    {
        UpperTitle = "All properties";
        this._dataService = dataService;
    }

    [RelayCommand]
    public async Task GetPropertiesAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var properties = await _dataService.GetAllPropAsync();

            if(Properties.Count != 0)
                Properties.Clear();

            foreach (var property in properties)
                Properties.Add(property);
        }
        catch (System.Exception ex)
        {
            Debug.WriteLine($"Unable to get properties: {ex.Message}");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }


    [RelayCommand]
    async Task AddPropClicked()
	{
		await Shell.Current.GoToAsync("AddPropertyPage");
	}


    [RelayCommand]
    async Task NavigateToDetail()
	{
        if (selectedProperty == null)
            return;

		var navigationParamater = new Dictionary<string, object>
		{
			{"Property", selectedProperty}
		};

		await Shell.Current.GoToAsync(nameof(PropertyViewPage), true, navigationParamater);
	}
}