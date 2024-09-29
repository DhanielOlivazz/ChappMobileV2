using ChappMobileV2.Menus;
namespace ChappMobileV2.Vistas;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}
    public void OnRegisterClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Menu();
    }
    public void OnLogInTapped(object sender, EventArgs e)
    {
        Application.Current.MainPage = new LogIn();
    }
}