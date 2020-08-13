using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorCyF.UI.Controles
{
    /// <summary>
    /// Lógica de interacción para ControlVentas.xaml
    /// </summary>
    public partial class ControlVentas : UserControl, IRepositorioContenedor
    {
        IVentasManager managerVentas;
        IProductoManger managerProductos;
        IServicioManager managerServicios;
        DataGrid dtg;
        public ControlVentas()
        {
            InitializeComponent();
          
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNuevoServivio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
