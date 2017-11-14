using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace X_NetworkCheck
{
    public partial class X_NetworkCheckPage : ContentPage
    {
        public X_NetworkCheckPage()
        {
            //Add the Nuget package Xam.Plugin.Connectivity  
            InitializeComponent();
            checkConnectivity(CrossConnectivity.Current.IsConnected);
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }



        async void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            await DisplayAlert("HandleConnectivityChanged","Changed","Ok");
            checkConnectivity(e.IsConnected);
        }

        public void checkConnectivity(bool sw){
            if (sw)
            {
                if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
                {
                    var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                    webStatusLabel.Text = connectionType.ToString();
                }
            }
            else
            {
                webStatusLabel.Text = "Offline";
            }
        }
    }
}
