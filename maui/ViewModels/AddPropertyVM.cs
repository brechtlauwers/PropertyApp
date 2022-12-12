namespace maui.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

using Plugin.ValidationRules;

using maui.Models;
using maui.Services;
using maui.Validations;

public partial class AddPropertyVM : BaseVM
{
    IDataService _dataService;

    [ObservableProperty]
    Property prop;

    ValidationUnit _unit1;

    public Validatable<string> Title { get; set; }
    public Validatable<string> Address { get; set; }
    public Validatable<string> Description { get; set; }
    public Validatable<string> Price { get; set; }
    public Validatable<string> Owner { get; set; }
    public Validatable<string> Surface { get; set; }
    public Validatable<string> Bedrooms { get; set; }
    public Validatable<string> PicturePath { get; set; }


    public AddPropertyVM(IDataService dataService)
    {
        this._dataService = dataService;
        Prop = new();

        Title = new();
        Address = new();
        Description = new();
        Price = new();
        Owner = new();
        Surface = new();
        Bedrooms = new();
        PicturePath = new();

        _unit1 = new ValidationUnit(Title, Address, Description, Price, Owner, Surface, Bedrooms, PicturePath);

        AddValidations();
    }

    private void AddValidations()
    {
        Title.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "A title is required."});
        Address.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "An address is required"});
        Description.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "A description is required"});
        Price.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "a price is required"});
        Owner.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "an owner is required"});
        Surface.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "a surface is required"});
        Bedrooms.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "amount of bedrooms are required"});
        PicturePath.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "a picture is required"});
    }


    [RelayCommand]
    public async void SelectImage()
    {
        FileResult result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image",
            FileTypes = FilePickerFileType.Images
        });

        if(result != null)
        {
            var stream = await result.OpenReadAsync();
            // The picture loader did not work...
            //PicturePath = ImageSource.FromStream(() => stream);
            PicturePath.Value = "specialhouse.jpg";
        }

        return;
    }

    public bool Validate()
    {
        return _unit1.Validate();
    }

    [RelayCommand]
    public async void ConfirmButton()
    {
        var isValid = this.Validate();

        Prop.Title = "testese";

        if(isValid)
        {
            Prop.Title = this.Title.Value;
            Prop.Address = this.Address.Value;
            Prop.Description = this.Description.Value;
            Prop.Price = double.Parse(this.Price.Value);
            Prop.Owner = this.Owner.Value;
            Prop.Surface = int.Parse(this.Surface.Value);
            Prop.Bedrooms = int.Parse(this.Bedrooms.Value);
            Prop.Picture = this.PicturePath.Value;

            await _dataService.AddPropAsync(Prop);

            await App.Current.MainPage.DisplayAlert(":)", "Property added successfully!", "OK");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert(":(", "This form is not valid", "OK");
        }
    }
}
