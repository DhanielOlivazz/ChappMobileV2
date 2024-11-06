using ChappMobileV2.Menus;
using ChappMobileV2.ModelsAPI.DTOs;
using ChappMobileV2.Controllers;
namespace ChappMobileV2.Vistas;


public partial class LogIn : ContentPage
{
    public LogIn()
    {
        InitializeComponent();
    }
    private void OnRegisterTapped(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Registro();
    }
    private async void OnLogInClicked(object sender, EventArgs e)
    {
        var user = new DTO_User()
        {
            email = EmailEntry.Text,
            password = PasswordEntry.Text,
        };
        AuthController auth = new AuthController();

        var messages = await auth.Login(user);

        if (messages[1] == "Inicio de sesion exitoso")
        {
            DisplayAlert(messages[0], messages[1], "OK");

            Application.Current.MainPage = new Menu();
        }
        else
        {
            DisplayAlert(messages[0], messages[1], "OK");
        }
        
    }
}