using Xamarin.Forms;
using GreatQuotes.Data;
using System.Linq;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var model = new GreatQuoteViewModel(QuoteManager.Load().First());
            MainPage = new NavigationPage(new QuoteDetailPage(model));
        }
    }
}

