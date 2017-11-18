using GreatQuotes.Data;
using GreatQuotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatQuotes.ViewModels
{
   
   public class GreatQuoteViewModel : SimpleViewModel
    {
        GreatQuote _quote;

        public GreatQuoteViewModel(GreatQuote quote)
        {
            this._quote = quote;
        }

        public String FirstName
        {
            get
            {
                return _quote.FirstName;
            }
            set
            {
                if(_quote.FirstName != value)
                {
                    _quote.FirstName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("Author");
                }
            }
        }

        public String LastName
        {
            get
            {
                return _quote.LastName;
            }
            set
            {
                if (_quote.LastName != value)
                {
                    _quote.LastName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(() => Author);
                }
            }
        }


        public String QuoteText
        {
            get
            {
                return _quote.QuoteText;
            }
            set
            {
                if (_quote.QuoteText != value)
                {
                    _quote.QuoteText = value;
                    RaisePropertyChanged();
                }
            }
        }
        public Gender Gender
        {
            get
            {
                return _quote.Gender;
            }
            set
            {
                if (_quote.Gender != value)
                {
                    _quote.Gender = value;
                    RaisePropertyChanged();
                }
            }
        }

        public String Author
        {
            get
            {
               return _quote.FirstName + " " + _quote.LastName; 
            }
            
        }

    }
}
