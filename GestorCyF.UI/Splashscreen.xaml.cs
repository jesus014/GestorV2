using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestorCyF.UI
{
    /// <summary>
    /// Lógica de interacción para Splashscreen.xaml
    /// </summary>
    public partial class Splashscreen : Window
    {
        public Splashscreen()
        {
            InitializeComponent();
            Cargando();
            pbBarraProgreso.ValueChanged += pbBarraProgreso_EvaluarProgreso;
        }
        private void pbBarraProgreso_EvaluarProgreso(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pbBarraProgreso.Value == 100)
            {
                LogIn InicioSesion = new LogIn();
                InicioSesion.Show();
                this.Close();
            }
        }

        private void Cargando()
        {
            Duration duracion = new Duration(TimeSpan.FromSeconds(20));
            DoubleAnimation animation = new DoubleAnimation(200.0, duracion);
            pbBarraProgreso.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, animation);
        }
    }
}
