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
    /// Lógica de interacción para ControlProveedores.xaml
    /// </summary>
    public partial class ControlProveedores : UserControl, IRepositorioContenedor
    {
        IProveedoresManager manager;
        DataGrid dtg;
        public ControlProveedores()
        {
            InitializeComponent();
            manager = FabricManager.Proveedores(@"C:\GestorCyF");
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
            Proveedores proveedores = dtg.SelectedItem as Proveedores;
            txbEmail.Text = proveedores.email;
            txbEmpresa.Text = proveedores.empresa;
            txbFolio.Text = proveedores.folio_proveedor;
            txbTelefono1.Text = proveedores.telefono1.ToString();
            txbTelefono2.Text = proveedores.telefono2.ToString();
            
        }
        public bool Eliminar()
        {
            Proveedores proveedores = dtg.SelectedItem as Proveedores;
            return manager.Eliminar(proveedores.Id, false);
        }

        public bool Guardar()
        {
            return manager.Agregar(new Proveedores()
            {
                FechaHora = DateTime.Now,
                empresa = txbEmpresa.Text,
                folio_proveedor = txbFolio.Text,
               telefono1= txbTelefono1.Text,
                telefono2 = txbTelefono2.Text,
                email = txbEmail.Text,
            }, false);

        }
        public void LimpiarCampos()
        {
            txbTelefono1.Clear();
            txbTelefono2.Clear();
            txbEmpresa.Clear();
            txbEmail.Clear();
           txbFolio.Clear();
            
        }

        public bool Modificado()
        {
            Proveedores proveedores = dtg.SelectedItem as Proveedores;
            proveedores.FechaHora = DateTime.Now;
            proveedores.email = txbEmail.Text;
            proveedores.empresa= txbEmpresa.Text;
            proveedores.folio_proveedor = txbFolio.Text;
            proveedores.telefono1 = (txbTelefono1.Text);
            proveedores.telefono2 = (txbTelefono2.Text); ;
            return manager.Modificar(proveedores, false);
        }
    }
}
