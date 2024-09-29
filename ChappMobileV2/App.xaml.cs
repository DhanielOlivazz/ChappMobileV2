using ChappMobileV2.Vistas;

namespace ChappMobileV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LogIn();
        }
    }
}
