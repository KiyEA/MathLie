using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.ComponentModel;
using Transport1.Droid.View;
using Xamarin.Forms;

namespace Transport1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly Label connectionStateLbl;
        readonly Button toCommonPageBtn;
        readonly Label CopyRight;
        readonly Button toDevivatePage;
        readonly Button toHistoryPageBtn;
        readonly Button toDeterminantPageBtn;
        public MainPage()
        {
            CopyRight = new Label
            {
                Text = "© Kiy Eduard",
                HorizontalOptions = LayoutOptions.End

            };
            Title = "Главная";
            toCommonPageBtn = new Button
            {
                Text="Квадратное уравнение",

            }; toCommonPageBtn.Clicked += ToCommonPage;
            toDevivatePage = new Button
            {
                Text = "Производная"
            };toDevivatePage.Clicked += ToDevivatePage;
                toHistoryPageBtn = new Button
                {
                    Text = "Интеграл"
                };
                toHistoryPageBtn.Clicked += ToHistoryPage;
                connectionStateLbl = new Label
                {
                    Text = "Подключение отсутствует",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                };
            toDeterminantPageBtn = new Button
            {
                Text = "Посчитать определитель"
            };toDeterminantPageBtn.Clicked += ToDetPage;
            Content = new StackLayout
            {
                Children = { connectionStateLbl, toCommonPageBtn, toHistoryPageBtn,  toDeterminantPageBtn,toDevivatePage, CopyRight }
            };

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private async void ToDetPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Determinant());
        }

        private async void ToHistoryPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HistoryPage());
        }
        private async void ToCommonPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QuadPage());
        }
        private async void ToDevivatePage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new DevivatePage());
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
            toHistoryPageBtn.IsVisible = CrossConnectivity.Current.IsConnected;
            toDeterminantPageBtn.IsVisible = CrossConnectivity.Current.IsConnected;

        }
    }

}