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

namespace ET53_CommandBar
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            miRec.Opacity = 0;
            miTexto.Text = "Rectangulo Transparente";
        }

        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            miRec.Opacity = 0.5;
            miTexto.Text = "Rectangulo Semitransparente";
        }

        private void AppBarButton_Click_2(object sender, RoutedEventArgs e)
        {
            miRec.Opacity = 1;
            miTexto.Text = "Opaco";
        }



        private void AppBarButton_Click_3(object sender, RoutedEventArgs e)
        {
            miRec.Opacity = 0;
            miTexto.Text = "Rectangulo Transparente";
        }

        private void AppBarButton_Click_4(object sender, RoutedEventArgs e)
        {
            miRec.Opacity = 0.5;
            miTexto.Text = "Rectangulo Semitransparente";
        }

        private void AppBarButton_Click_5(object sender, RoutedEventArgs e)
        {
            miRec.Opacity = 1;
            miTexto.Text = "Opaco";
        }

        private void videoPlay(object sender, RoutedEventArgs e)
        {
            video.Play();
        }

        private void videoStop(object sender, RoutedEventArgs e)
        {
            video.Stop();
        }
        private void videoPause(object sender, RoutedEventArgs e)
        {
            video.Pause();
        }


        private void videoVolumen(object sender, RangeBaseValueChangedEventArgs e)
        {
            video.Volume = (volumenSlider.Value / 100);
        }
    }
}
