﻿using Xamarin.Forms;
using GreatQuotes.ViewModels;

namespace GreatQuotes
{    
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage()
        {
            BindingContext = App.model.SelectedQuote;
            InitializeComponent ();
        }
    }
}

