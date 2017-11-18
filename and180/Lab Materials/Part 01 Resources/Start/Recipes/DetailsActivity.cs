using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace Recipes
{
	[Activity(Label = "DetailsActivity")]
	public class DetailsActivity : AppCompatActivity
	{
		Recipe recipe;
		ArrayAdapter adapter;
        Android.Support.V7.Widget.Toolbar toolbar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Details);

			//
			// Retrieve the recipe to be displayed on this page
			//
			int index = Intent.GetIntExtra("RecipeIndex", -1);
			recipe = RecipeData.Recipes[index];

            //
            // Show the recipe name
            //
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = recipe.Name;
            base.SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_arrow_back_white_24dp);

            //toolbar.Title = recipe.Name;
            //toolbar.InflateMenu(Resource.Menu.actions);
            //toolbar.MenuItemClick += Actions_MenuItemClick;

			//
			// Show the list of ingredients
			//
			var list = FindViewById<ListView>(Resource.Id.ingredientsListView);
			list.Adapter = adapter = new ArrayAdapter<Ingredient>(this, Android.Resource.Layout.SimpleListItem1, recipe.Ingredients);

		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.MenuInflater.Inflate(Resource.Menu.actions, menu);
            SetFavoriteDrawable(false);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;
                case Resource.Id.addToFavorites:
                    recipe.IsFavorite = !recipe.IsFavorite;
                    SetFavoriteDrawable(recipe.IsFavorite);        
                    break;
                case Resource.Id.about:
                    StartActivity(typeof(AboutActivity));
                    break;
                case Resource.Id.oneServing:
                    SetServings(1);
                    item.SetChecked(true);
                    break;
                case Resource.Id.twoServings:
                    SetServings(2);
                    item.SetChecked(true);
                    break;
                case Resource.Id.fourServings:
                    SetServings(4);
                    item.SetChecked(true);
                    break;
            }

            return true;
        }

        private void Actions_MenuItemClick(object sender, Android.Support.V7.Widget.Toolbar.MenuItemClickEventArgs e)
        {
            switch (e.Item.ItemId)
            {
                case Resource.Id.addToFavorites:
                    recipe.IsFavorite = !recipe.IsFavorite;
                    SetFavoriteDrawable(recipe.IsFavorite);
                    break;
                case Resource.Id.about:
                    StartActivity(typeof(AboutActivity));
                    break;
                case Resource.Id.oneServing:
                    SetServings(1);
                    e.Item.SetChecked(true);
                    break;
                case Resource.Id.twoServings:
                    SetServings(2);
                    e.Item.SetChecked(true);
                    break;
                case Resource.Id.fourServings:
                    SetServings(4);
                    e.Item.SetChecked(true);
                    break;

            }
        }
       
       
		void SetFavoriteDrawable(bool isFavorite)
		{
            if (isFavorite)
                toolbar.Menu.FindItem(Resource.Id.addToFavorites).SetIcon(Resource.Drawable.ic_favorite_white_24dp); // filled in 'heart' image
            else
                toolbar.Menu.FindItem(Resource.Id.addToFavorites).SetIcon(Resource.Drawable.ic_favorite_border_white_24dp);

        }
		
		void SetServings(int numServings)
		{
			recipe.NumServings = numServings;

			adapter.NotifyDataSetChanged();
		}
	}
}