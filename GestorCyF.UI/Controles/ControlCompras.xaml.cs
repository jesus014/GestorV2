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
    /// Lógica de interacción para ControlCompras.xaml
    /// </summary>
    public partial class ControlCompras : UserControl, IRepositorioContenedor
    {
        IGenericCompras manager;
        IProductoManger managerProductos;
        IProveedoresManager managerProveedores;
        DataGrid dtg;
        public ControlCompras()
        {
            InitializeComponent();
            manager = FabricManager.Compras(@"C:\GestorCyF");
            managerProductos = FabricManager.Productos(@"C:\GestorCyF");
            managerProveedores = FabricManager.Proveedores(@"C:\GestorCyF");
            dtg = new DataGrid();
            CargarDatosIniciales();
            pkrFechaCompra.SelectedDate = DateTime.Now;
            
        }

        private void cmbProveedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            cmbProducto.ItemsSource = null;
            cmbProducto.ItemsSource = managerProductos.Listar;
            cmbProveedor.ItemsSource = managerProveedores.Listar;
        }

        public void CargarTabla()
        {
            dtg.ItemsSource = manager.Listar;
        }

        public void Editar()
        {
            Compras elemento = dtg.SelectedItem as Compras;
            txbCantidad.Text = elemento.cantidad;
            txbPrecioCompra.Text = elemento.precioCompra;
            cmbProducto.Text= elemento.producto.nombre;
            cmbProveedor.Text = elemento.proveedor.empresa;
            pkrFechaCompra.SelectedDate = elemento.FechaHora;
        }

        public bool Eliminar()
        {
            Compras elemento = dtg.SelectedItem as Compras;
            return manager.Eliminar(elemento.Id, false);
        }

        public bool Guardar()
        {
            return manager.Agregar(new Compras()
            {
                FechaHora = DateTime.Now,
                fechaCompra = pkrFechaCompra.SelectedDate.Value,
                precioCompra = txbPrecioCompra.Text,
                producto = cmbProducto.SelectedItem as Productos,
                proveedor = cmbProveedor.SelectedItem as Proveedores,
                cantidad = txbCantidad.Text,
                totalCompra = (double.Parse(txbPrecioCompra.Text) * int.Parse(txbCantidad.Text)).ToString(),
                
            }, false);
            
        }

        public bool ActualizarStock(Productos productos, string text)
        {
            productos.FechaHora = productos.FechaHora;
            productos.nombre = productos.nombre;
            productos.descripcion = productos.descripcion;
            productos.folio_producto = productos.folio_producto;
            productos.imagen = productos.imagen;
            productos.marca = productos.marca;
            productos.precio = productos.precio;
            productos.stock_actual = productos.stock_actual+ int.Parse(text);
            productos.stock_minimo = productos.stock_minimo;
            return managerProductos.Modificar(productos, false);
        }

        public void LimpiarCampos()
        {
            pkrFechaCompra.SelectedDate = DateTime.Now;
            txbPrecioCompra.Clear();
            cmbProducto.SelectedItem = null;
            cmbProveedor.SelectedItem = null;
            txbCantidad.Clear();
        }

        public bool Modificado()
        {
            Compras elemento = dtg.SelectedItem as Compras;
            elemento.FechaHora = DateTime.Now;
            elemento.cantidad = txbCantidad.Text;
            elemento.fechaCompra = pkrFechaCompra.SelectedDate.Value;
            elemento.producto = cmbProducto.SelectedItem as Productos;
            elemento.precioCompra = txbPrecioCompra.Text;
            elemento.proveedor = cmbProducto.SelectedItem as Proveedores;
            elemento.totalCompra = (double.Parse(txbPrecioCompra.Text) * int.Parse(txbCantidad.Text)).ToString();
            return manager.Modificar(elemento, false);

        }
    }
}
