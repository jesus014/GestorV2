using GestorCyF.BIZ;
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
    /// Lógica de interacción para ControlServicios.xaml
    /// </summary>
    public partial class ControlServicios : UserControl, IRepositorioContenedor
    {
        IServicioManager manager;
        
        DataGrid dtg;
        public ControlServicios()
        {
            InitializeComponent();
            manager = FabricManager.Servicios(@"C:\GestorCyF");
            dtg = new DataGrid();
            CargarDatosIniciales();
        }
        public string Error => manager.Error;

        public DataGrid AsignarDataGrid { set => dtg = value; }

        public void Cancelar()
        {
            LimpiarCampos();
        }

        public void CargarDatosIniciales()
        {
            LimpiarCampos();
            CargarTabla();
        }

        public void CargarTabla()
        {
            dtg.ItemsSource = manager.Listar;
        }

        public void Editar()
        {
            Servicios elemento = dtg.SelectedItem as Servicios;
            txbNombreServicio.Text = elemento.nombre;
            txbFolio.Text = elemento.folio_servicio;
            txbDescripcion.Text = elemento.descripcion;
            txbPrecio.Text = elemento.precio;
        }

        public bool Eliminar()
        {
            Servicios elemento = dtg.SelectedItem as Servicios;
            return manager.Eliminar(elemento.Id, false);
        }

        public bool Guardar()
        {
            return manager.Agregar(new Servicios()
            {
                FechaHora = DateTime.Now,
                nombre = txbNombreServicio.Text,
                folio_servicio= txbFolio.Text,
                descripcion = txbDescripcion.Text,
                precio = txbPrecio.Text,
            }, false);
        }
        public void LimpiarCampos()
        {
            txbFolio.Clear();
            txbNombreServicio.Clear();
            txbPrecio.Clear();
            txbDescripcion.Clear();
        }

        public bool Modificado()
        {
            Servicios elemento = dtg.SelectedItem as Servicios;
            elemento.FechaHora = DateTime.Now;
            elemento.nombre = txbNombreServicio.Text;
            elemento.folio_servicio = txbFolio.Text;
            elemento.precio = txbPrecio.Text;
            elemento.descripcion = txbDescripcion.Text;
            return manager.Modificar(elemento, false);
        }
    }
}
