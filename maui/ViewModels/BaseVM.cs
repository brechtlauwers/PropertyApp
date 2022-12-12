using CommunityToolkit.Mvvm.ComponentModel;


namespace maui.ViewModels;

public partial class BaseVM : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;    

    public bool IsNotBusy => !IsBusy;
}
