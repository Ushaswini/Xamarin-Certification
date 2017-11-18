using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Provider;
using Android.Graphics;
using RayHotDog.Droid.Utility;

namespace RayHotDog.Droid
{
    [Activity(Label = "TakePictureActivity")]
    public class TakePictureActivity : Activity
    {
        private Button takePictureButton;
        private ImageView rayPictureImageView;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            //create a sub -directory in default place where picture are to be stored

            imageDirectory=new File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures),"RayHotDogs");

            if(!imageDirectory.Exists())
            {
                imageDirectory.Mkdir();
            }

            // Create your application here
        }

        private void FindViews()
        {
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            rayPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, string.Format("PhotoWithRay_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(resultCode== Result.Ok && requestCode == 0)
            {
                int width = rayPictureImageView.Width;
                int heigth = rayPictureImageView.Height;
                imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, heigth);

                if(imageBitmap != null)
                {
                    rayPictureImageView.SetImageBitmap(imageBitmap);
                    imageBitmap = null;
                }

                //required to avoid any memory leaks
                GC.Collect();
            }
        }
    }
}