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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestorCyF.UI
{
    /// <summary>
    /// Lógica de interacción para LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
            txbNombre.Text = "Leticia";
            txbContrasenia.Password = "administrador";
        }
        string Usuario = "Leticia";
        string Contraseña = "administrador";
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txbContrasenia.Password == Contraseña && txbNombre.Text == Usuario)
            {
                MainWindow InicioSesion = new MainWindow();
                InicioSesion.Show();
                this.Close();
            }
            else
            {

                MessageBox.Show("Error, Usuario y/o Contraseña Incorrectos", this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
