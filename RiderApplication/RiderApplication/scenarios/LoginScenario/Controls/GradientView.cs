using System;
using Xamarin.Forms;

namespace RiderApplication.scenarios.LoginScenario.Controls
{
    public enum GradientDirection
    {
        Vertical,
        Horizontal
    }

    public class GradientView : View
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            "StartColor",
            typeof(Color),
            typeof(GradientView),
            default(Color));

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            "EndColor",
            typeof(Color),
            typeof(GradientView),
            default(Color));

        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }

        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        public static readonly BindableProperty DirectionProperty = BindableProperty.Create("Direction", typeof(GradientDirection), typeof(GradientView), default(GradientDirection));

        public GradientDirection Direction
        {
            get => (GradientDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }
    }
}
