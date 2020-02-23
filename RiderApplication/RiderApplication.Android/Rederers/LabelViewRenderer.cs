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
using RiderApplication.Droid.Rederers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Android;

[assembly: ExportRenderer(typeof(Label), typeof(LabelViewRenderer))]

namespace RiderApplication.Droid.Rederers
{
    [Obsolete]
    public class LabelViewRenderer : LabelRenderer
    {
        public LabelViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                SetOutlineSpotShadowColor(Android.Graphics.Color.Argb(255, 30, 39, 70));
                SetOutlineAmbientShadowColor(Android.Graphics.Color.Argb(255, 30, 39, 70));
            }
        }
    }
}