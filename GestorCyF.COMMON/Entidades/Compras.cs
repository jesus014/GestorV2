using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Entidades
{
    public class Compras : BaseDTO
    {
        public string cantidad { get; set; }
        public Productos producto { get; set; }
        public Proveedores proveedor { get; set; }
        public DateTime fechaCompra { get; set; }
        public string precioCompra { get; set; }
        public string totalCompra { get; set; }
    }
}
