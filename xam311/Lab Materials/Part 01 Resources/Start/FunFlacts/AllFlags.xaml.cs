using FlagData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunFlacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllFlags : ContentPage
    {
        //bool isEditing;
        //ToolbarItem cancelEditButton;
        public AllFlags()
        {
            InitializeComponent();
            //cancelEditButton = (ToolbarItem)Resources[nameof(cancelEditButton)];
            BindingContext = DependencyService.Get<FunFlactsViewModel>();
            flagsList.ItemTapped += FlagsList_ItemTapped;
        }

        private async void FlagsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await this.Navigation.PushAsync(new FlagDetailsPage());

            
            //DependencyService.Get<FunFlactsViewModel>().CurrentFlag = (Flag)e.Item;

        }

        //private void OnEdit(object sender, EventArgs e)
        //{
        //    var tbItem = sender as ToolbarItem;
        //    isEditing = (tbItem == editButton);

        //    ToolbarItems.Remove(tbItem);
        //    ToolbarItems.Add(isEditing ? cancelEditButton : editButton);
            
        //}

        //private async void flagsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (isEditing)
        //    {
        //        var flag = (Flag)e.SelectedItem;
        //        if (flag != null && await this.DisplayAlert("Confirm",
        //        $"Are you sure you want to delete {flag.Country}?", "Yes", "No"))
        //        {
        //            DependencyService.Get<FunFlactsViewModel>()
        //                .Flags.Remove(flag);
        //        }
        //        OnEdit(cancelEditButton, EventArgs.Empty);

        //    }
        //}

        private async void OnRefreshing(object sender, EventArgs e)
        {
            try
            {
                var collection = DependencyService.Get<FunFlactsViewModel>().Flags;
                int i = collection.Count - 1, j = 0;
                while (i > j)
                {
                    var temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;
                    i--; j++;
                    await System.Threading.Tasks.Task.Delay(200); // make it take some time.
                }
            }
            finally
            {
                // Turn off the refresh.
                ((ListView)sender).IsRefreshing = false;
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Flag flag = (Flag)item.BindingContext;
            if (flag != null && await this.DisplayAlert("Confirm",
                $"Are you sure you want to delete {flag.Country}?", "Yes", "No"))
            {
                DependencyService.Get<FunFlactsViewModel>()
                    .Flags.Remove(flag);
            }

        }
    }

}