using GreatQuotes.ViewModels;
using Xamarin.Forms;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public static MainViewModel model { get; private set; }
        public App()
        {
            InitializeComponent();
            

            MainPage = new NavigationPage(new QuoteListPage());
        }
        static App()
        {
            model = new MainViewModel();
        }
    }
}

