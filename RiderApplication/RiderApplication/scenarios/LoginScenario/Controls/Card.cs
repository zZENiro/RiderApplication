﻿using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace RiderApplication.scenarios.LoginScenario.Controls
{
    public class Card : Frame
    {
        public static readonly BindableProperty ElevationProperty = BindableProperty.Create(
            nameof(Elevation),
            typeof(int),
            typeof(Card),
            4,
            propertyChanged: (control, _, __) => ((Card)control).UpdateElevation());

        public int Elevation
        {
            get => (int)GetValue(ElevationProperty);
            set => SetValue(ElevationProperty, value);
        }

        public Card() => (HasShadow, Padding, BackgroundColor) = (true, new Thickness(12, 6), Color.Transparent);

        private void UpdateElevation()
        {
            On<iOS>()
                .SetIsShadowEnabled(true)
                .SetShadowColor(Color.Black)
                .SetShadowOffset(new Size(0, 4))
                .SetShadowOpacity(0.8)
                .SetShadowRadius(Elevation / 1.3)
                .UseBlurEffect(BlurEffectStyle.ExtraLight)
                .SetIsShadowEnabled(true);


            On<Android>()
                .SetElevation(Elevation);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == StyleProperty.PropertyName)
            {
                if (Style.Setters.Any(s => s.Property == PaddingProperty))
                {
                    Padding = (Thickness)Style.Setters.First(s => s.Property == PaddingProperty).Value;
                }
            }
        }
    }
}
