using System;
using Transport1.Droid.Model;
using Xamarin.Forms;

namespace Transport1
{
    public class QuadPage : ContentPage
    {
        readonly Button result;
        readonly Label answerX;
        readonly Label answerX2;
        readonly Label exception;
        readonly Entry quady;
        public QuadPage(){
            Title = "Квадратное уравнение";
            result = new Button
            {
                Text = "Посчитать"
            };
            result.Clicked += GetAnswer;
                Button backButton = new Button
                {
                    Text = "Назад",
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.End
                };
                backButton.Clicked += BackButton_Click;
            exception = new Label
            {
                Text = "Ошибка в вводе уравнения",
                IsVisible = false
            };
            quady = new Entry
            {
                Placeholder = "2x^2+x+5=0"
            };
            answerX = new Label
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            answerX2 = new Label
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Content = new StackLayout
            {
                Children = { quady, result, exception,answerX,answerX2, backButton }
            };
        }
            private async void BackButton_Click(object sender, EventArgs e)
            {
                await Navigation.PopModalAsync();
            }
        private void GetAnswer(object sender, EventArgs e)
        { 
            string var = quady.Text;
            if (var == null) return;
            CheckQuad checkQuad = new CheckQuad();
          int isOk = checkQuad.Parser(var);
            switch(isOk) {
                case -1:
                    answerX.IsVisible = false;
                    answerX2.IsVisible = false;
                    exception.IsVisible = true;
                    break;
                case 0:
                    answerX.IsVisible = false;
                    answerX2.IsVisible = false;
                    exception.Text = "Дискриминант меньше нуля";
                    exception.IsVisible = true;
                    break;
                case 1:
                    exception.IsVisible = false;
                    answerX2.IsVisible = false;
                    answerX.Text = "x="+checkQuad.x.ToString();
                    answerX.IsVisible = true;
                    break;
                case 2:
                    exception.IsVisible = false;
                    answerX.IsVisible = false;
                    answerX2.Text = "x1=" + checkQuad.x1.ToString() + "\n" +
                        "x2=" + checkQuad.x2.ToString();
                    answerX2.IsVisible = true;
                    break;
            }
        }
    }
}