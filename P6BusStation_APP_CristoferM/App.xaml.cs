using P6BusStation_APP_CristoferM.Views;

namespace P6BusStation_APP_CristoferM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
