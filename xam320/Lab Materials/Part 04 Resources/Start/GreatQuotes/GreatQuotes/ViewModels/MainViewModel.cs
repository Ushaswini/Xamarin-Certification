using System.Collections.Generic;
using System.Collections.ObjectModel;
using GreatQuotes.Data;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using XamarinUniversity.Infrastructure;
using XamarinUniversity.Interfaces;
using System.Windows.Input;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        public IList<QuoteViewModel> Quotes { get; private set; }

        public ICommand AddQuote { get; private set; }

        public ICommand DeleteQuote { get; private set; }

        public ICommand EditQuote { get; private set; }

        public ICommand ShowQuoteDetail { get; private set; }

        QuoteViewModel selectedQuote;
        public QuoteViewModel SelectedQuote {
            get {
                return selectedQuote;
            }
            set {
                SetPropertyValue(ref selectedQuote, value);
            }
        }

        public MainViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>(QuoteManager.Load()
                            .Select(q => new QuoteViewModel(q)));

            SelectedQuote = Quotes.FirstOrDefault();
            AddQuote = new Command(async() => await OnAddQuote());
            DeleteQuote = new Command<QuoteViewModel>(async vm => await OnDeleteQuote(vm));
            EditQuote = new Command<QuoteViewModel>(async vm => await OnEditQuote(vm));
            ShowQuoteDetail = new Command<QuoteViewModel>(async vm => await OnShowQuoteDetails(vm));
        }

        public async Task OnAddQuote()
        {
            var newQuote = new QuoteViewModel();
            Quotes.Add(newQuote);
            SelectedQuote = newQuote;

            if (!DependencyService.Get<INavigationService>().CanGoBack)
            {
                await DependencyService.Get<INavigationService>()
                                   .NavigateAsync(AppPages.Edit, newQuote);
            }
        }

        public async Task OnEditQuote(QuoteViewModel quote)
        {
            SelectedQuote = quote;
            await DependencyService.Get<INavigationService>()
                .NavigateAsync(AppPages.Edit, quote);
        }

        public async Task OnDeleteQuote(QuoteViewModel quote)
        {
            bool result = await DependencyService.Get<IMessageVisualizerService>()
                .ShowMessage("Are you sure?", 
                    "Are you sure you want to delete this quote from " + quote.Author + "?",
                    "Yes", "No");

            if (result == true) {
                int pos = Quotes.IndexOf(quote);
                Quotes.Remove(quote);
                if (SelectedQuote == quote) {
                    if (pos > Quotes.Count - 1)
                        pos = Quotes.Count - 1;
                    SelectedQuote = Quotes[pos];
                }
            }
        }

        public async Task OnShowQuoteDetails(QuoteViewModel quote)
        {
            SelectedQuote = quote;
            await DependencyService.Get<INavigationService>().NavigateAsync(AppPages.Detail, quote);
        }
    }
}

