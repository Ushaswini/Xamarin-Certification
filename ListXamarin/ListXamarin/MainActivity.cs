using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ListXamarin
{
    [Activity(Label = "ListXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView listview;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            listview = FindViewById<ListView>(Resource.Id.listView);

            listview.Adapter = new InstructorAdapter(InstructorData.Instructors);

            //listview.Adapter = new ArrayAdapter<Instructor>(this, Android.Resource.Layout.SimpleListItem1, InstructorData.Instructors);

            listview.ItemClick += Listview_ItemClick;
            listview.FastScrollEnabled = true;
        }

        private void Listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = InstructorData.Instructors[e.Position];

            var intent = new Intent(this, typeof(InstructorDetailsActivity));
            intent.PutExtra("position", e.Position);
            StartActivity(intent);

            //var dailog = new AlertDialog.Builder(this);
            //dailog.SetMessage(instructor.Name);
            //dailog.SetNeutralButton("OK",delegate { });

            //dailog.Show();
        }
    }
}

