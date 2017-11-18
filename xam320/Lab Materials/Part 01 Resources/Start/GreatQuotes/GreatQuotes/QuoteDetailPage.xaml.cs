using Xamarin.Forms;
using GreatQuotes.Data;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{    
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage(GreatQuoteViewModel model)
        {
            BindingContext = model;
            InitializeComponent ();
        }
    }
}

