using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Ejercicio1
{
    public class Page2 : ContentPage
    {
        public Page2()
        {
           /* Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };*/
        }

        private bool OnTimerTick()
        {
            DateTime dt = DateTime.Now;
            return true;
        }
    }
}