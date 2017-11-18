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

using Android.Graphics.Drawables;
using System.IO;
using Java.Lang;

namespace ListXamarin
{
    class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {

        List<Instructor> instructors;
        Java.Lang.Object[] sectionHeaders;
        Dictionary<int, int> positionForSectionMap;
        Dictionary<int, int> sectionForPositionMap;

        public InstructorAdapter(List<Instructor> instructors)
        {
            this.instructors = instructors;
            this.sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(instructors);
            this.positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(instructors);
            this.sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(instructors);
        }

        public override Instructor this[int position]
        {
            get
            {
                return instructors[position];
            }
        }

        public override int Count
        {
            get
            {
                return instructors.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return positionForSectionMap[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView;

            if(view == null)
            {
                var inflater = LayoutInflater.From(parent.Context);
                view = inflater.Inflate(Resource.Layout.InstructorRow, parent, false);

                var p = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var n = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var s = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

                view.Tag = new ViewHolder { Photo = p, Name = n, Specialty = s };          



            }

            var holder = (ViewHolder)view.Tag;
            

            holder.Name.Text = instructors[position].Name;
            holder.Specialty.Text = instructors[position].Specialty;

            //Stream stream = parent.Context.Assets.Open(instructors[position].ImageUrl);
            //Drawable drawable = Drawable.CreateFromStream(stream,null);
            holder.Photo.SetImageDrawable(ImageAssetManager.Get(parent.Context,instructors[position].ImageUrl));

            return view;

        }
    }
}