using Newtonsoft.Json;
using P6BusStation_APP_CristoferM.Models;
using P6BusStation_APP_CristoferM.ViewModels;
using System.Text;

namespace P6BusStation_APP_CristoferM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}


    private void SwShowPassword_Toggled(object sender, ToggledEventArgs e)
    {
        TxtPassword.IsPassword = true;

        if (SwShowPassword.IsToggled)
        {
            TxtPassword.IsPassword = false;
        }
    }

    private async void BtnSignUp_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UserSignUpPage());
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        string username = TxtUserName.Text;
        string password = TxtPassword.Text;

        var isValidUser = await ValidateUserAsync(username, password);

        if (isValidUser)
        {
            await DisplayAlert("Inicio de sesión", "Inicio de sesión exitoso", "OK");
            // Navegar a PreguntaPage
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }

    private async Task<bool> ValidateUserAsync(string email, string password)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("http://192.168.100.9:45455/api/");
            var loginRequest = new
            {
                Email = email,
                Password = password
            };

            var jsonContent = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Users/ValidateUser", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(jsonResponse);

                return true;
            }

            return false;
        }
    }
}