using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsPractice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            mainListView.ItemsSource = new List<Person>
            {
                new Person{Name="Name1",Age=10},
                new Person{Name="Name2",Age=11},
                new Person{Name="Name3",Age=12},
                new Person{Name="Name4",Age=13},
                new Person{Name="Name5",Age=14}

            };
        }
    }
}