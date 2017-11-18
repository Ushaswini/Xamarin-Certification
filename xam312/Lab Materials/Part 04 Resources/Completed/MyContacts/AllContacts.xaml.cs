using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MyContacts
{
    public partial class AllContacts : ContentPage
    {
        bool isEditing;
        public AllContacts()
        {
            InitializeComponent();
            BindingContext = new ObservableCollection<Grouping<string,Person>>(
                SimpsonFactory.Characters
                .OrderBy(c => c.Name)
                .GroupBy(c => c.Name[0].ToString(), c => c)
                .Select(g => new Grouping<string,Person>(g.Key, g)));
        }

        void OnEdit(object sender, EventArgs e)
        {
            isEditing = !isEditing;
            ((ToolbarItem)sender).Text = isEditing ? "End Edit" : "Edit";
        }

        async void OnDelete(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Person person = (Person)item.BindingContext;
            await DeletePersonAsync(person);
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!isEditing)
            {
                Person tappedPerson = (Person) e.Item;
                await this.Navigation.PushAsync(new ContactDetails(tappedPerson));
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (isEditing)
            {
                Person person = (Person)e.SelectedItem;
                if (await DeletePersonAsync(person))
                {
                    OnEdit(editButton, EventArgs.Empty);
                }
            }
        }

        async Task<bool> DeletePersonAsync(Person person)
        {
            if (person != null)
            {
                if (await this.DisplayAlert("Confirm", "Are you sure you want to delete " + person.Name, "Yes", "No") == true)
                {
                    SimpsonFactory.Characters.Remove(person);

                    // Now remove from our grouped collection.
                    string firstLetter = person.Name[0].ToString();
                    var bc = BindingContext as IList<Grouping<string,Person>>;
                    var collection = bc.First(g => g.Key == firstLetter);
                    collection.Remove(person);

                    // No more entries with that letter? Kill that whole section!
                    if (!collection.Any())
                        bc.Remove(collection);

                    return true;
                }
            }
            return false;
        }

        bool reverse;

        void OnRefreshing(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            List<Person> reversedData = ((reverse) 
                ? SimpsonFactory.Characters.OrderBy(p => p.Name)
                : SimpsonFactory.Characters.OrderByDescending(p => p.Name)).ToList();
            reverse = !reverse;
            
            SimpsonFactory.Characters.Clear();
            foreach (var item in reversedData)
                SimpsonFactory.Characters.Add(item);

            lv.IsRefreshing = false;
        }        
    }
}
