using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using RiderApplication.Droid.Rederers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Shell), typeof(MyShellRenderer))]
namespace RiderApplication.Droid.Rederers
{
    class MyShellRenderer : ShellRenderer
    {
        public MyShellRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementSet(Shell element)
        {
            base.OnElementSet(element);
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            var renderer = base.CreateShellItemRenderer(shellItem);

            return renderer;
        }

        protected override IShellFlyoutRenderer CreateShellFlyoutRenderer()
        {
            var flyout = base.CreateShellFlyoutRenderer();

            return flyout;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var flyout = base.CreateShellFlyoutContentRenderer();

            GradientDrawable gradient = new GradientDrawable(
                GradientDrawable.Orientation.BottomTop,
                new Int32[] {
                    ((Color)App.LookupColor(Xamarin.Forms.Color.FromHex("#8EDDDD"))).ToAndroid(),
                    ((Color)App.LookupColor(Xamarin.Forms.Color.FromHex("#B1A5FF"))).ToAndroid()
                }
            );

            var cl = ((CoordinatorLayout)flyout.AndroidView);
            cl.SetBackground(gradient);

            var g = (AppBarLayout)cl.GetChildAt(0);
            g.SetBackgroundColor(Color.Transparent.ToAndroid());
            g.OutlineProvider = null;

            var header = g.GetChildAt(0);
            header.SetBackgroundColor(Color.Transparent.ToAndroid());

            return flyout;
        }
    }
}