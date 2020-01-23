using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Ejercicio1
{
    public class Page1 : ContentPage
    {
        public Page1()
        {

            Label etiqueta = new Label
            { Text = "Felicidades, nueva página desde código!" };
            etiqueta.VerticalOptions = LayoutOptions.CenterAndExpand;
            Content = etiqueta;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Padding = new Thickness(10,30,10,10);
                    etiqueta.Text += " en IOS";
                    break;
                case Device.Android:
                    Padding = new Thickness(20, 100, 10, 20);
                    etiqueta.Text += " en Android";
                    break;
                case Device.UWP:
                    Padding = new Thickness(50, 0, 100, 0);
                    etiqueta.Text += " en UWP";
                    break;
            }
            /*Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };*/
        }
    }
}