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
    /// Lógica de interacción para ControlClientes.xaml
    /// </summary>
    public partial class ControlClientes : UserControl, IRepositorioContenedor
    {
        IClienteManager manager;
        DataGrid dtg;
        public ControlClientes()
        {
            InitializeComponent();
            manager = FabricManager.Clientes(@"C:\GestorCyF");
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
            Clientes cliente = dtg.SelectedItem as Clientes;
            txbNombre.Text = cliente.nombre;
            txbApellidoM.Text = cliente.apellidom;
            txbApellidoP.Text = cliente.apellidop;
            txbTelefono.Text = cliente.telefono.ToString();
            txbEmail.Text = cliente.email;
        }

        public bool Eliminar()
        {
            Clientes clientes = dtg.SelectedItem as Clientes;
            return manager.Eliminar(clientes.Id, false);
        }

        public bool Guardar()
        {
            return manager.Agregar(new Clientes()
            {
                FechaHora = DateTime.Now,
                nombre = txbNombre.Text,
                apellidop = txbApellidoP.Text,
                apellidom = txbApellidoM.Text,
                telefono = txbTelefono.Text,
                email =txbEmail.Text,
            }, false);
        }

        public void LimpiarCampos()
        {
            txbTelefono.Clear();
            txbNombre.Clear();
            txbEmail.Clear();
            txbApellidoM.Clear();
            txbApellidoP.Clear();
        }

        public bool Modificado()
        {
            Clientes clientes = dtg.SelectedItem as Clientes;
            clientes.FechaHora = DateTime.Now;
            clientes.nombre = txbNombre.Text;
            clientes.apellidom = txbApellidoM.Text;
            clientes.apellidop = txbApellidoP.Text;
            clientes.telefono = (txbTelefono.Text);
            clientes.email = txbEmail.Text;
            return manager.Modificar(clientes, false);
        }
    }
}
