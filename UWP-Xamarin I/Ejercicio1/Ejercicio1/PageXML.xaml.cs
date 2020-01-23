using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageXML : ContentPage
    {
        private int seg = 0, min = 0, hora = 0;
        private int segT = 0, minT = 0, horaT = 0;
        DateTime dtTemporizador = DateTime.Now;
        public PageXML()
        {
            InitializeComponent();
            horaT = 23 - dtTemporizador.Hour;
            minT = 59 - dtTemporizador.Minute;
            segT = 59 - dtTemporizador.Second;
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            Device.StartTimer(TimeSpan.FromSeconds(1), OnCronometro);
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTemporizador);
        }

        private bool OnTimerTick()
        {
            DateTime dt = DateTime.Now;
            tiempo.Text = dt.ToString("T");
            fecha.Text = dt.ToString("D");
            return true;
        }

        public void ButtonPlay(object sender, EventArgs e)
        {
            if (play.Text.Equals("Play")) { play.Text = "Pause"; }
            else{ play.Text = "Play"; }
        }

        public void ButtonStop(object sender, EventArgs e)
        {
            cronometro.Text = "00:00:00";
            play.Text = "Play";
            seg = 0; min = 0; hora = 0;
        }

        private bool OnCronometro()
        {
            if (play.Text.Equals("Pause"))
            {
                if (seg < 59)
                {
                    seg++;
                }
                else
                {
                    seg = 0;
                    if (min<59)
                    {
                        min++;
                    }
                    else
                    {
                        min = 0;
                        if (hora < 23)
                        {
                            hora++;
                        }
                        else { hora = 0; }
                    }
                }
            }
            cronometro.Text = FormatoCronometro(hora)+":"+FormatoCronometro(min)+":"+FormatoCronometro(seg);
            return true;
        }

        private String FormatoCronometro(int s)
        {
            if (s < 10) { return "0" + s; }
            else return "" + s;
        }

        private bool OnTemporizador()
        {
            //int seg = 0, min = 0, hora = 0;
            if (segT>1)
            {
                segT--;
            }
            else 
            { 
                segT = 59;
                if (minT>1)
                {
                    minT--;

                }
                else
                {
                    minT = 59;
                    if (horaT > 1)
                    {
                        horaT--;
                    }
                    else { horaT = 23; }
                }
            }
           
            tiempoDesc.Text = FormatoCronometro(horaT) + ":" + FormatoCronometro(minT) + ":" + FormatoCronometro(segT);
            return true;
        }
    }
}