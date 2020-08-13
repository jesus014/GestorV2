using GestorCyF.BIZ;
using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para ControlProductos.xaml
    /// </summary>
    public partial class ControlProductos : UserControl, IRepositorioContenedor
    {
        IProductoManger manager;
        DataGrid dtg;
        public ControlProductos()
        {
            InitializeComponent();
            manager = FabricManager.Productos(@"C:\GestorCyF");
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
            Productos producto = dtg.SelectedItem as Productos;
            txbNombre.Text = producto.nombre;
            txbDescripcion.Text = producto.descripcion;
            txbFolio.Text = producto.folio_producto;
            txbMarca.Text = producto.marca;
            txbPrecio.Text = producto.precio.ToString();
            txbStockActual.Text = producto.stock_actual.ToString();
            txbStockMinimo.Text = producto.stock_minimo.ToString();

            imgImagen.Source = ByteToImage(producto.imagen);
        }
        public bool Eliminar()
        {
            Productos producto = dtg.SelectedItem as Productos;
            return manager.Eliminar(producto.Id, false);
        }
        public bool Guardar()
        {
            return manager.Agregar(new Productos()
            {
                FechaHora = DateTime.Now,
                nombre = txbNombre.Text,
                descripcion= txbDescripcion.Text,
                folio_producto = txbFolio.Text,
                marca = txbMarca.Text,
                precio = double.Parse( txbPrecio.Text),
                imagen=ImageToByte(imgImagen.Source),
                stock_actual=int.Parse( txbStockActual.Text),
                stock_minimo= int.Parse(txbStockMinimo.Text),
            }, false);
        }
        public void LimpiarCampos()
        {
            txbDescripcion.Clear();
            txbNombre.Clear();
            txbFolio.Clear();
            txbMarca.Clear();
            txbPrecio.Clear();
            txbStockActual.Clear();
            txbStockMinimo.Clear();
            imgImagen.Source = null;
        }
        public bool Modificado()
        {
            Productos productos = dtg.SelectedItem as Productos;
            productos.FechaHora = DateTime.Now;
            productos.nombre = txbNombre.Text;
            productos.descripcion = txbDescripcion.Text;
            productos.folio_producto = txbFolio.Text;
            productos.imagen = ImageToByte(imgImagen.Source);
            productos.marca = txbMarca.Text;
            productos.precio = double.Parse(txbPrecio.Text);
            productos.stock_actual = int.Parse(txbStockActual.Text);
            productos.stock_minimo = int.Parse(txbStockMinimo.Text);
            return manager.Modificar(productos, false);
        }
        private ImageSource ByteToImage(byte[] imagenData)
        {
            if (imagenData==null)
            {
                return null;
            }
            else
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imagenData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                ImageSource imgSrc = biImg as ImageSource;
                return imgSrc;
            }
        }
        private byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memStream);
                return memStream.ToArray();
            }
            else
            {
                return null;
            }
        }

        private void BtnElegirImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Selecione una imagen";
            dialogo.Filter = "Archivos de imagen|*.jpg; *.png";
            if (dialogo.ShowDialog().Value)
            {
                imgImagen.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }
    }
}
