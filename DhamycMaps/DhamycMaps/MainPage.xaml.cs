using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace DhamycMaps
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void GetLocationButton_Clicked(object sender, EventArgs e)
        {
            isBusy.IsRunning = true;
            isBusy.IsVisible = true;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(10000);
                //var map = new Map(
                //             MapSpan.FromCenterAndRadius(
                //               new Position(position.Latitude, position.Longitude),
                //               Distance.FromMiles(0.3)
                //             )
                //)
                //{
                //    IsShowingUser = true,
                //    HeightRequest = 100,
                //    WidthRequest = 960,
                //    VerticalOptions = LayoutOptions.FillAndExpand
                //};
                //var positionPin = new Position(position.Latitude, position.Longitude);
                //var pin = new Pin
                //{
                //    Type = PinType.Place,
                //    Position = positionPin,
                //    Label = "Estas Aquí",
                //    Address = "CORREEEEE!!!"
                //};
                //map.Pins.Add(pin);

                //isBusy.IsRunning = false;
                //isBusy.IsVisible = false;

                var stack = new StackLayout { Spacing = 0, Margin=20 };

                stack.Children.Add(new Label { Text = "Dhamyc Community!", TextColor = Color.Accent, HorizontalTextAlignment=TextAlignment.Center, FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), FontAttributes = FontAttributes.Bold });
                stack.Children.Add(new Label { Text = $"Longitud: {position.Latitude.ToString()}" , HorizontalTextAlignment=TextAlignment.Center});
                stack.Children.Add(new Label { Text = $"Longitud: {position.Longitude.ToString()}", HorizontalTextAlignment = TextAlignment.Center });
                //stack.Children.Add(map);
                //Content = stack;

            }
            catch (Exception ex)
            {
                string msge = ex.Message;
            }
            

            
        }
    }
}
