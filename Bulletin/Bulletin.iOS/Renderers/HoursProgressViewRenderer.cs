using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Bulletin.Views;
using CoreAnimation;
using Bulletin.iOS.Renderers;

[assembly:ExportRenderer(typeof(HoursProgressView), typeof(HoursProgressViewRenderer))]
namespace Bulletin.iOS.Renderers
{
    public class HoursProgressViewRenderer : ViewRenderer
    {
        private CAShapeLayer backgroundLayer1;
        private CAShapeLayer foregroundLayer1;

        public HoursProgressViewRenderer()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                e.NewElement.SizeChanged += NewElement_SizeChanged;
            }
            if (e.OldElement != null)
            {
                e.OldElement.SizeChanged -= NewElement_SizeChanged;
            }
        }
        private void NewElement_SizeChanged(object sender, EventArgs e)
        {
            if(backgroundLayer1 != null)
            {
                backgroundLayer1.RemoveFromSuperLayer();
            }
            if (foregroundLayer1 != null)
            {
                foregroundLayer1.RemoveFromSuperLayer();
            }
            var view = Element as HoursProgressView;
            var backgroundPath = new UIBezierPath();
            backgroundPath.MoveTo(new CoreGraphics.CGPoint(0, view.Height / 2));
            backgroundPath.AddLineTo(new CoreGraphics.CGPoint(view.Width, view.Height / 2));
            backgroundPath.LineWidth = 5;
            backgroundLayer1 = new CAShapeLayer();
            backgroundLayer1.Path = backgroundPath.CGPath;
            backgroundLayer1.StrokeColor = view.BarColor.ToCGColor();
            Layer.AddSublayer(backgroundLayer1);

            var currentPRogressWidth = (view.Current - view.Min) / (view.Max - view.Min);
            var foregroundPath = new UIBezierPath();
            foregroundPath.MoveTo(new CoreGraphics.CGPoint(0, view.Height / 2));
            foregroundPath.AddLineTo(new CoreGraphics.CGPoint(view.Width * currentPRogressWidth, view.Height / 2));

            foregroundLayer1 = new CAShapeLayer();
            foregroundPath.LineWidth = 5;
            foregroundLayer1.Path = foregroundPath.CGPath;
            foregroundLayer1.StrokeColor = view.BarColor.ToCGColor();
            
            Layer.AddSublayer(foregroundLayer1);
        }
    }
}