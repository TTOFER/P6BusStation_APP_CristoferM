using P6BusStation_APP_CristoferM.ViewModels;

namespace P6BusStation_APP_CristoferM.Views;

public partial class HomePage : ContentPage
{
	HomeViewModel? vm;
	public HomePage()
	{
		InitializeComponent();

		BindingContext = vm = new HomeViewModel();

		LoadDestinationList();
	}

    private async void LoadDestinationList()
    {
        LstOriginDestiantion.ItemsSource = await vm.VmGetDestinationsAsync();

        LstFinalDestiantion.ItemsSource = await vm.VmGetDestinationsAsync();
    }
}