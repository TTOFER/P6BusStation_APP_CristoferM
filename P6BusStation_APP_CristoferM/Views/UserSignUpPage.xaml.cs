using P6BusStation_APP_CristoferM.ViewModels;
using P6BusStation_APP_CristoferM.Models;

namespace P6BusStation_APP_CristoferM.Views;

public partial class UserSignUpPage : ContentPage
{
    //definir objeto ViewModel
    UserViewModel? vm;

    public UserSignUpPage()
	{
		InitializeComponent();

        BindingContext = vm = new UserViewModel();

        LoadUserRoleList();
    }

    private async void LoadUserRoleList()
    {
        LstUserRoles.ItemsSource = await vm.VmGetUserRolesAsync();
    }

    private async void BtnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
        //TODO: validacion para los campos que son requisito

        var answer = await DisplayAlert("Confirmation Required", "Adding new User. Are you sure?", "Yes", "No");

        if (answer)
        {
            //extraer objeto tipo UserRole de la lista
            UserRole SelectedUserRole = LstUserRoles.SelectedItem as UserRole;

            bool R = await vm.VmAddUser(SelectedUserRole.UserRoleId,
                                          TxtEmail.Text.Trim(),
                                          TxtName.Text.Trim(),
                                          TxtPhone.Text.Trim(),
                                          TxtPassword.Text.Trim(),
                                          TxtAddress.Text.Trim() 
                                          );

            if (R)
            {
                await DisplayAlert(";)", "User added!!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Error: ", "OK");
            }

        }
    }
}