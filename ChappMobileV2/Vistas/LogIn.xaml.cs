using ChappMobileV2.Menus;
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
    private void OnLogInClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Menu();
    }
}