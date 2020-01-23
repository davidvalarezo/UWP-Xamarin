using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Ejercicio3
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        enum operaciones { desconocida, suma, resta, multiplicacion, division};
        static operaciones oper = operaciones.desconocida;
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void bnOperacionClick(object sender, RoutedEventArgs e)
        {
            oper = oper + 1;
            if (oper > operaciones.division)
            {
                oper = operaciones.suma;
            }
            string[] textBoton = { "#", "+", "-", "*", "/" };
            btnOperacion.Content = textBoton[(int)oper];

        }

        private async void bCalculadora(object sender, RoutedEventArgs e)
        {
            double op1 = 0.0, op2 = 0.0, resultado = 0.0;
            try
            {
                op1 = double.Parse(Op1.Text);
                op2 = double.Parse(Op2.Text);
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog("Error en la conversion" + ex.Message);
                await dialog.ShowAsync();
                return;
            }
            if (oper != operaciones.desconocida)
            {
                try
                {
                    resultado = EjecutaCalculo(op1,op2, oper);
                    tb_resultado.Text = resultado.ToString();
                }
                catch (Exception ex)
                {
                    var dialog = new MessageDialog("Error en la conversion" + ex.Message);
                    await dialog.ShowAsync();
                    return;
                }

            }
            
        }

        private double EjecutaCalculo(double op1, double op2, operaciones oper)
        {
            double resul = 0.0;

            try
            {
                switch (oper)
                {
                    case operaciones.suma:
                        resul = op1 + op2;
                        break;
                    case operaciones.resta:
                        resul = op1 - op2;
                        break;
                    case operaciones.multiplicacion:
                        resul = op1 * op2;
                        break;
                    case operaciones.division:
                        resul = op1 / op2;
                        break;
                }

                
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog("Error en la conversion" + ex.Message);
             
                //return resul;
            }
            return resul;

        }

        private void limpiarPantalla(object sender, RoutedEventArgs e)
        {
            tb_resultado.Text = "";
            Op1.Text = "";
            Op2.Text = "";

        }

        private void bnDOperacionClick(object sender, RoutedEventArgs e)
        {
            var option = ((MenuFlyoutItem)sender).Tag.ToString();

            switch (option)
            {
                case "1":
                    oper = operaciones.suma;
                    break;
                case "2":
                    oper = operaciones.resta;
                    break;
                case "3":
                    oper = operaciones.multiplicacion;
                    break;
                case "4":
                    oper = operaciones.division;
                    break;
            }

            string[] textBoton = { "#", "+", "-", "*", "/" };
            btnOperacion.Content = textBoton[(int)oper];

        }
    }
}
