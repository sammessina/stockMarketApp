using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WeatherApp.Resources;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace WeatherApp {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage() {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e) {
            GetQuote();
        }


        private async void GetQuote() {
            string url = "http://download.finance.yahoo.com/d/quotes.csv?s=MSFT&f=sl1d1t1c1ohgv&e=.csv";

            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            string data = await client.GetStringAsync(uri);

            string[] datas = data.Split(new[] { ',' });
            string delta = datas[4];
            //1 is amount
            //4 is +/-
            StockBlock.Text = datas[1];
            DeltaBlock.Text = delta;
            if (delta[0] == '-') {
                DeltaBlock.Foreground = new SolidColorBrush(Colors.Red);
            }
            else {
                DeltaBlock.Foreground = new SolidColorBrush(Colors.Green);
            }


        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem)

    }


}