using System;
using Xamarin.Forms;

#if __ANDROID__
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Support.Design.Widget;
#endif

namespace XFDraw
{
    public partial class MainPage : ContentPage
    {
        bool IsCanvasDirty
        {
            get { return isCanvasDirty; }
            set
            {
                isCanvasDirty = value;

                if (clearCommand != null)
                    clearCommand.ChangeCanExecute();
            }
        }
        bool isCanvasDirty;

        Command clearCommand;
        public MainPage()
        {
            InitializeComponent();

            

            sketchView.SketchUpdated += OnSketchUpdate;

            clearCommand = new Command(OnClearClicked, () => { return isCanvasDirty; });

            var trash = new ToolbarItem()
            {
                Text = "Clear",
                Icon = "trash.png",
                Command=clearCommand,
            };
            trash.Clicked += (o, s) => OnClearClicked();

            ToolbarItems.Add(trash);

#if __ANDROID__

            var actionButton = new FloatingActionButton(Forms.Context);
            actionButton.SetImageResource(XFDraw.Droid.Resource.Drawable.pencil);
            actionButton.Click += (s, e) =>
            {
                OnColorClicked();
                actionButton.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(sketchView.InkColor.ToAndroid());
            };

            var actionButtonFrame = new FrameLayout(Forms.Context);
            actionButtonFrame.SetClipToPadding(false);
            actionButtonFrame.SetPadding(0, 0, 50, 50);
            actionButtonFrame.AddView(actionButton);

            var actionButtonFrameView = actionButtonFrame.ToView();
            actionButtonFrameView.HorizontalOptions = LayoutOptions.End;
            actionButtonFrameView.VerticalOptions = LayoutOptions.End;

            mainLayout.Children.Add(actionButtonFrameView);

#else
            ToolbarItems.Add(new ToolbarItem("New Color", "pencil.png", OnColorClicked));
#endif
        }

        void OnClearClicked()
        {
            sketchView.Clear();
            IsCanvasDirty = false;
        }

        void OnSketchUpdate(object sender, EventArgs e)
        {
            IsCanvasDirty = true;
        }

        void OnColorClicked()
        {
            sketchView.InkColor = GetRandomColor();
        }

        Random rand = new Random();
        Color GetRandomColor()
        {
            return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
        }
    }
}