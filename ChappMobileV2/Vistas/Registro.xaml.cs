using ChappMobileV2.Controllers;
using ChappMobileV2.Menus;
using ChappMobileV2.ModelsAPI;
using ChappMobileV2.ModelsAPI.DTOs;
using System.Globalization;
namespace ChappMobileV2.Vistas;

public partial class Registro : ContentPage
{
    public Registro()
	{
		InitializeComponent();
	}
    public async void OnRegisterClicked(object sender, EventArgs e)
    {
        var user = new DTO_User()
        {
            name = UsernameEntry.Text,
            email = emailEntry.Text,
            password = PasswordEntry.Text,
        };

        AuthController auth = new AuthController();

        var messages = await auth.Register(user);

        if (messages[0] == "Registro Exitoso")
        {
            DisplayAlert("Registro", "Usuario registrado con éxito", "OK");
            Application.Current.MainPage = new LogIn();
        }
        else
        {
            DisplayAlert(messages[0], messages[1], "OK");
        }
    }
    public void OnLogInTapped(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LogIn();
    }
}