using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GestorCyF.UI
{
    public interface IRepositorioContenedor
    {
        string Error { get; }

        bool Guardar();

        bool Modificado();

        void Editar();

        bool Eliminar();

        void Cancelar();

        void LimpiarCampos();

        DataGrid AsignarDataGrid { set; }

        void CargarTabla();

        void CargarDatosIniciales();

    }
}
