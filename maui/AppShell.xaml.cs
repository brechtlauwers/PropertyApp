namespace maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PropertyViewPage), typeof(PropertyViewPage));
		Routing.RegisterRoute(nameof(AddPropertyPage), typeof(AddPropertyPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}
