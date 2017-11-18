using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using RotationGesture;

namespace AndroidGestures
{
    [Activity(Label = "AndroidGestures", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, 
                                GestureDetector.IOnGestureListener,
                                ScaleGestureDetector.IOnScaleGestureListener,
                                RotationGesture.IOnRotationGestureListener
    {
        private GestureDetector gestureDetector;
        private ScaleGestureDetector scaleGestureDetector;
        private RotationGestureDetector rotationGestureDetector;

        private ImageView xamLogo;
        private float deltaX, deltaY,currentScale = 1.0f;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            xamLogo = FindViewById<ImageView>(Resource.Id.xamLogo);
            gestureDetector = new GestureDetector(this, this);
            scaleGestureDetector = new ScaleGestureDetector(this, this);
            rotationGestureDetector = new RotationGestureDetector(this);
        }

        public bool OnDown(MotionEvent e)
        {
            return false;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            return false;
        }

        public void OnLongPress(MotionEvent e)
        {
           
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            deltaX -= distanceX;
            deltaY -= distanceY;

            xamLogo.TranslationX = deltaX;
            xamLogo.TranslationY = deltaY;
            return true;
        }

        public void OnShowPress(MotionEvent e)
        {
           
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }

      

        public override bool OnTouchEvent(MotionEvent e)
        {
            gestureDetector.OnTouchEvent(e);
            scaleGestureDetector.OnTouchEvent(e);
            rotationGestureDetector.OnTouch(e);
            return true;
        }

        public bool OnScale(ScaleGestureDetector detector)
        {
            this.currentScale *= detector.ScaleFactor;
            xamLogo.ScaleX = currentScale;
            xamLogo.ScaleY = currentScale;
            return true;
        }

        public bool OnScaleBegin(ScaleGestureDetector detector)
        {
            return true;
        }

        public void OnScaleEnd(ScaleGestureDetector detector)
        {
            
        }

        public void OnRotate(float angle)
        {
            xamLogo.Rotation = angle;
        }
    }
}

