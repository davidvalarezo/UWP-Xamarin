using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Ejercicio4
{
    class ColorChanger
    {
        public delegate void changeColorDelegate(Color c);
        public static event changeColorDelegate ChangeColor;

        static public void onChanceColor(Color c)
        {
            if (ChangeColor  != null) // it has subscriptores
            {
                ChangeColor(c); // call the event
            }
        }

    }
    
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static String forma = "Rectangle";
        public static String acessKey;
        public static int key = 5;
        
        public MainPage()
        {
            this.InitializeComponent();
            ColorChanger.ChangeColor += changeColorRectangulo;
            ColorChanger.ChangeColor += changeColorEclipse;

            rectangle1.Tapped += rectangulo_tappe;

        }

        private void changeColorRectangulo(Color c)
        {
            foreach(Object o in miCanvas.Children)
                if (o is Rectangle)
                {
                    Rectangle rec = o as Rectangle;
                    rec.Fill = new SolidColorBrush(c);
                }
        }

        private void changeColorEclipse(Color c)
        {
            foreach (Object o in miCanvas.Children)
                if (o is Ellipse)
                {
                    Ellipse e = o as Ellipse;
                    e.Fill = new SolidColorBrush(c);
                }
        }

        private void rectangulo_tappe(object sender, TappedRoutedEventArgs e)
        {
            Rectangle r = sender as Rectangle;
            if (r != null)
            {
                SolidColorBrush color = r.Fill as SolidColorBrush;
                ColorChanger.onChanceColor(color.Color);


            }
        }

        private void miCanvas_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (forma.Equals("Rectangle"))
            {
                Rectangle r = new Rectangle();
                r.Width = 50;
                r.Height = 50;
                r.Margin = new Thickness(e.GetPosition(miCanvas).X - (r.Width / 2) , e.GetPosition(miCanvas).Y - (r.Height / 2), 0, 0);
                r.Fill = new SolidColorBrush(Colors.Yellow);
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.AccessKey = "" + key;
                r.CanDrag = true;
                r.DragStarting += rect_DragStarting;
                miCanvas.Children.Add(r);
            }
            else
            {
                Ellipse r = new Ellipse();
                r.Width = 50;
                r.Height = 50;
                r.Margin = new Thickness(e.GetPosition(miCanvas).X - (r.Width/2) , e.GetPosition(miCanvas).Y - (r.Height/2), 0, 0);
                r.Fill = new SolidColorBrush(Colors.Blue);
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.AccessKey = "" + key;
                r.CanDrag = true;
                r.DragStarting += rect_DragStarting;
                miCanvas.Children.Add(r);
            }

            key++;

        }

        private void isForma(object sender, TappedRoutedEventArgs e)
        {          
            if (sender is Ellipse)
            {
                forma = "Ellipse";
            }
            else{
                forma = "Rectangle";
            }
        }


        private void Canvas_DragOver(object sender, DragEventArgs e)
        {
            //To specifies which operations are allowed    
            e.AcceptedOperation = DataPackageOperation.Move;

            // To display the data which is dragged   
            //e.DragUIOverride.Caption = "drop here to view image";
            e.DragUIOverride.IsGlyphVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsCaptionVisible = true;
        }

        private void miCanvas_Drop(object sender, DragEventArgs e)
        {

            foreach (Object o in miCanvas.Children)
            {
                if (o is Rectangle)
                {
                    Rectangle rec = o as Rectangle;
                    if (acessKey.Equals(rec.AccessKey))
                    {
                        rec.Margin = new Thickness(e.GetPosition(miCanvas).X - (rec.Width/2), e.GetPosition(miCanvas).Y - (rec.Height/2), 0, 0);
                    }
                }
                else if (o is Ellipse)
                {
                    Ellipse ellip = o as Ellipse;
                    if (acessKey.Equals(ellip.AccessKey))
                    {
                        ellip.Margin = new Thickness(e.GetPosition(miCanvas).X - (ellip.Width/2), e.GetPosition(miCanvas).Y - (ellip.Height/2), 0, 0);
                    }
                }


            }
                //e.AcceptedOperation = DataPackageOperation.Move;
                //e.AllowedOperations = DataPackageOperation.Move;
        }

        private void rect_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            args.AllowedOperations = DataPackageOperation.Move;
            acessKey = sender.AccessKey; 
               
        }
    }
}
