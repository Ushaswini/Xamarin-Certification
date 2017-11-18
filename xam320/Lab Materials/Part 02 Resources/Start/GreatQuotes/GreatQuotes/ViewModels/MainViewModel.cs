using GreatQuotes.Data;
using GreatQuotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        QuoteViewModel _selectedQuote;

        public QuoteViewModel SelectedQuote
        {
            get { return _selectedQuote; }
            set
            {
                SetPropertyValue(ref _selectedQuote, value);
            }
        }
        public IList<QuoteViewModel> Quotes { get; private set; }

        public MainViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>(QuoteManager.Load().Select(q => new QuoteViewModel(q)));
        }

    }
}
