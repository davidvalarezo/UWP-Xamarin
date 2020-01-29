using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace E5_Animacion
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void rectangle_tapped(object sender, TappedRoutedEventArgs e)
        {
            Animation.Begin();
        }

        private void image_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            image.Opacity = 0.3;
        }

        private void image_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            posicion.TranslateX = e.Delta.Translation.X;
            posicion.TranslateY = e.Delta.Translation.Y;
        }

        private void image_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            image.Opacity = 1;
        }
    }
}
