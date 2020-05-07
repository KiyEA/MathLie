using System;
using Transport1.Droid.Model;
using Xamarin.Forms;

namespace Transport1.Droid.View
{
    public class Determinant : ContentPage
    {

        readonly Entry N;
        double[][] a;
        double[][] b;
        int i = 0;
        int j = 0;
        int mass;
        readonly Label exception;
        readonly Entry AIJ;
        readonly Button answer;
        readonly Button Accept;
        readonly Label result;
        public Determinant()
        {
            exception = new Label
            {
                Text = "Ошибка в вводе",
                IsVisible = false
            };
            Button backButton = new Button
            {
                Text = "Назад",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End
            }; backButton.Clicked += BackButton_Click;
            N = new Entry
            {
                Placeholder = "N"
            };
            Accept = new Button
            {
                IsVisible = false,
                Text = "Ок"
            }; Accept.Clicked += Accept_Clicked;
            AIJ = new Entry
            {
                IsVisible = false,
                Placeholder = "Aij"
            };
            answer = new Button
            {
                Text = "Принять"
            }; answer.Clicked += Answer_Clicked;
            result = new Label
            {
                IsVisible = false,
                FontSize = 22
            };
            Content = new StackLayout
            {

                Children = { N, AIJ,Accept, answer,result,exception, backButton }
            };

        }

        private void Accept_Clicked(object sender, EventArgs e)
        {
            try
            {
                double.TryParse(AIJ.Text, out a[i][j]);
                j++;
                if (j == mass)
                {
                    j = 0;
                    i++;
                    if (i == mass)
                    {
                        AIJ.IsVisible = false;
                        Accept.IsVisible = false;
                        Det Determinant = new Det();
                        result.Text = "Определитель =" + Determinant.GetDet(a, b, mass).ToString();
                        result.IsVisible = true;
                    }
                }
                AIJ.Text = null;
                AIJ.Placeholder = "A" + $"{i}" + $"{j}";
            }
            catch(Exception ex)
            {
                Except();
            }
        }

        private void Except()
        {
            N.IsVisible = false;
            AIJ.IsVisible = false;
            Accept.IsVisible = false;
            answer.IsVisible = false;
            result.IsVisible = false;
            exception.IsVisible = true;
        }

        private void Answer_Clicked(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            AIJ.IsVisible = true;
            answer.IsVisible = false;
            N.IsVisible = false;
            AIJ.Placeholder = "A" + $"{i}" + $"{j}";
            Accept.IsVisible = true;
            int.TryParse(N.Text, out mass);
            if (mass == 0) Except();
            a = new double[mass][];
            b = new double[1][];
            b[0] = new double[mass];
            for (i=0; i < mass; i++) a[i] = new double[mass];

        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}