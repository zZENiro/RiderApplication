using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApplication.scenarios.LoginScenario.Controls
{
    public delegate void MyButtonEventHandler(object sender, MyButtonEventArgs args);
    
    public class MyButtonEventArgs
    {

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyButton
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            "Text",
            typeof(string),
            typeof(MyButton),
            default(string));


        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            "StartColor",
            typeof(Color),
            typeof(MyButton),
            Color.Black
            );

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            "EndColor",
            typeof(Color),
            typeof(MyButton),
            Color.Black
            );

        public event MyButtonEventHandler ButtonClicked;

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public MyButton()
        {
            InitializeComponent();

        }

        void Handle_Pressed(object sender, System.EventArgs e)
        {
            this.FadeTo(0.7, 100);
        }

        void Handle_Released(object sender, System.EventArgs e)
        {
            this.FadeTo(1, 200);
            ButtonClicked?.Invoke(this, new MyButtonEventArgs());
        }
    }
}