using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RiderApplication.Droid.Rederers;
using RiderApplication.scenarios.LoginScenario.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientView), typeof(GradientViewRenderer))]
namespace RiderApplication.Droid.Rederers
{
    public class GradientViewRenderer : VisualElementRenderer<GradientView>
    {
        public GradientViewRenderer(Context context) : base(context)
        {
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            var box = Element;

            var gradient = new LinearGradient(0, 0,
                                              box.Direction == GradientDirection.Horizontal ? Width : 0,
                                              box.Direction == GradientDirection.Vertical ? Height : 0,
                                              box.StartColor.ToAndroid(),
                                              box.EndColor.ToAndroid(),
                                              Shader.TileMode.Mirror);

            var paint = new Paint()
            {
                Dither = true,
            };

            paint.SetShader(gradient);
            canvas.DrawPaint(paint);

            base.DispatchDraw(canvas);
        }
    }
}