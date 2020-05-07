using System;
using Transport1.Droid.Model;
using Xamarin.Forms;

namespace Transport1
{
    public class HistoryPage : ContentPage
    {
        readonly Label integral;
        readonly Button Answer;
        readonly Label dx;
        readonly Entry step;
        readonly Label exception;
        readonly Entry func;
        readonly Entry a;
        readonly Entry b;
        readonly Label result;
        public HistoryPage()
        {
            Title = "Интеграл";
            Button backButton = new Button
            {
                Text = "Назад",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End
            };
            exception = new Label
            {
                Text = "Ошибка в вводе Интеграла",
                IsVisible = false
            };
            integral = new Label
            {
                Text = "∫",
                FontSize = 25
            };
            Answer = new Button
            {
                Text = "Решить"
            }; Answer.Clicked += Get_Answer;
            dx = new Label
            {
                Text = "dx"
            };
            func = new Entry
            {
                Placeholder = "функция"
            };
            a = new Entry
            {
                Placeholder = "верхняя граница"
            };
            b = new Entry
            {
                Placeholder = "нижняя граница"
            };
            step = new Entry
            {
                Placeholder = "0.01"
            };
            result = new Label
            {

            };


            backButton.Clicked += BackButton_Click;
            Content = new StackLayout
            {
                 
               Children = { integral, a, b, step,exception, func, dx, result, Answer, backButton }
            };
        }

        private async void Get_Answer(object sender, EventArgs e)
        {
            exception.Text = "Ошибка в вводе Интеграла";
            string function = func.Text;
            if (!double.TryParse(step.Text, out double tav))
            {
                exception.IsVisible = true;
                return;
            }
            if (!double.TryParse(a.Text, out double a1))
            {
                exception.IsVisible = true;
                return;
            }
            if (!double.TryParse(b.Text, out double b1))
            {
                exception.IsVisible = true;
                return;
            }
            if (a1 < b1)
            {
                exception.Text = "Нижняя граница была больше верхней";
                exception.IsVisible = true;
                result.IsVisible = false;
                return;
            }
            
            Integral it = new Integral();
           double res = await it.Answer(function,tav,b1,a1);
            if (res == -1)
            {
                result.IsVisible = false;
                exception.IsVisible = true;
                return;
            }
            if (double.IsNaN(res))
            {
                result.IsVisible = false;
                exception.IsVisible = true;
                exception.Text = "не получилось :((";
                return;
            }
            exception.IsVisible = false;
            result.Text = $"{res}";
            result.IsVisible = true;
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
    
}