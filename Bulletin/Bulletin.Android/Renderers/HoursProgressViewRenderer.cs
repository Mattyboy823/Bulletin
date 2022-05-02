﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bulletin.Droid.Renderers;
using Bulletin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(HoursProgressView), typeof(HoursProgressViewRenderer))]
namespace Bulletin.Droid.Renderers
{
    public class HoursProgressViewRenderer : ViewRenderer
    {
        private HoursProgressView viewA;

        public HoursProgressViewRenderer (Context context) : base(context)
        {
            SetWillNotDraw(false);
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            viewA = Element as HoursProgressView;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            var paint = new Paint();
            paint.Color = viewA.BarColor.ToAndroid();
            paint.StrokeWidth = Context.ToPixels(5);
            canvas.DrawLine(0, canvas.Height / 2, canvas.Width, canvas.Height / 2, paint);

            var currentProgressWidth = (viewA.Current - viewA.Min) / (viewA.Max - viewA.Min);
            paint.Color =  viewA.FillColor.ToAndroid();
            canvas.DrawLine(0, canvas.Height / 2, (float)(canvas.Width * currentProgressWidth), canvas.Height / 2, paint );
        }
    }
}