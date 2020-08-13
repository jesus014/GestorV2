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

namespace GestorCyF.UI
{
    public enum Accion
    {
        Nuevo,
        Editar
    }
    /// <summary>
    /// Lógica de interacción para Contenedor.xaml
    /// </summary>
    public partial class Contenedor : UserControl
    {
        IRepositorioContenedor control;
        Accion accion;
        public Contenedor(Control control)
        {
            InitializeComponent();
            HabilitarBotones(false);
            skpContenedor.IsEnabled = false;
            this.control = control as IRepositorioContenedor;
            this.control.LimpiarCampos();
            this.control.AsignarDataGrid = dtg;
            ActualizarTabla();
            this.control.CargarDatosIniciales();
        }

        public void ActualizarTabla()
        {
            dtg.ItemsSource = null;
            control.CargarTabla();
        }

        public void HabilitarBotones(bool v)
        {
            btnCancelar.IsEnabled = v;
            btnEditar.IsEnabled = !v;
            btnEliminar.IsEnabled = !v;
            btnGuardar.IsEnabled = v;
            btnNuevo.IsEnabled = !v;
        }

        public void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HabilitarBotones(true);
                accion = Accion.Nuevo;
                skpContenedor.IsEnabled = true;
                control.LimpiarCampos();
                ActualizarTabla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "GestorCyF", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtg.SelectedItem != null)
                {
                    control.LimpiarCampos();
                    accion = Accion.Editar;
                    control.Editar();
                    HabilitarBotones(true);
                    skpContenedor.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Asegurate de seleccionar un elemento antes de Editar", "GestorCyF", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dtg.SelectedItem != null)
                {
                    if (MessageBox.Show("¿Realmente deseas Eliminar este elemento?", "GestorCyF", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.Yes)
                    {
                        control.Eliminar();
                        control.CargarTabla();
                        MessageBox.Show("Elemento Eliminado con éxito", Title.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Asegurate de seleccionar un elemento antes de Eliminar", "Administrador", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (accion == Accion.Nuevo)
                {
                    if (control.Guardar())
                    {
                        ActualizarTabla();
                        HabilitarBotones(false);
                        control.LimpiarCampos();
                        MessageBox.Show("Elemento creado con éxito", Title.Content.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(control.Error, "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    if (control.Modificado())
                    {
                        ActualizarTabla();
                        HabilitarBotones(false);
                        control.LimpiarCampos();
                        MessageBox.Show("Elemento modificado con éxito", "Administrador", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(control.Error, "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotones(false);
            control.LimpiarCampos();
            skpContenedor.IsEnabled = false;
        }

        public void dtg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dtg.SelectedItem != null)
                {
                    accion = Accion.Editar;
                    HabilitarBotones(true);
                    control.Editar();
                    skpContenedor.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Administrador", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
