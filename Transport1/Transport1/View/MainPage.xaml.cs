using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Transport1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly Label connectionStateLbl;
        readonly Button toCommonPageBtn;
        readonly Button toModalPageBtn;
        readonly Button toHistoryPageBtn;
        public MainPage()
        {



             
                Title = "Главная";
                toCommonPageBtn = new Button
                {

                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End
                };
                toCommonPageBtn.Clicked += ToCommonPage;
                toHistoryPageBtn = new Button
                {
                    Text = "История поездок"
                };
                toHistoryPageBtn.Clicked += ToHistoryPage;
            toModalPageBtn = new Button
            {
                Text = "Подключенные карты",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End
            };
            toModalPageBtn.Clicked += ToModalPage;

                connectionStateLbl = new Label
                {
                    Text = "Подключение отсутствует",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };
            Content = new StackLayout
            {
                Children = { connectionStateLbl, toCommonPageBtn, toModalPageBtn }
            };

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }
        private async void ToHistoryPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
        private async void ToModalPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ModalPage());
        }
        private async void ToCommonPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommonPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckConnection();
        }
        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckConnection();
        }
        private void CheckConnection()
        {
            connectionStateLbl.IsVisible = !CrossConnectivity.Current.IsConnected;
            toCommonPageBtn.IsVisible = CrossConnectivity.Current.IsConnected;
            toModalPageBtn.IsVisible = CrossConnectivity.Current.IsConnected;
            toHistoryPageBtn.IsVisible = CrossConnectivity.Current.IsConnected;

        }
    }

}