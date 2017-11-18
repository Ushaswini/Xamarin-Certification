using System;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Util;

namespace XamPaint
{
	public class PaintView : View
	{
        Path drawPath;

        Paint drawPaint;

		public PaintView(Context context) 									 : base(context, null, 0)         { Init(); }
		public PaintView(Context context, IAttributeSet attrs)               : base(context, attrs)           { Init(); }
		public PaintView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { Init(); }

		void Init()
		{
            drawPaint = new Paint { Color = Color.Aqua, StrokeWidth = 5f };
            drawPath = new Path();
            drawPaint.SetStyle(Paint.Style.Stroke);
		}

		public void Clear()
		{
            drawPath.Reset();
            Invalidate();
		}

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawPath(drawPath, drawPaint);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            var X = e.GetX();
            var Y = e.GetY();

            switch (e.ActionMasked)
            {
                case MotionEventActions.Down:
                    drawPath.MoveTo(X, Y);
                    break;
                case MotionEventActions.Move:
                    drawPath.LineTo(X, Y);
                    Invalidate();
                    break;
                case MotionEventActions.Up:
                    break;
                default:
                    return false;
                  
            }
            return true;
        }
	}
}