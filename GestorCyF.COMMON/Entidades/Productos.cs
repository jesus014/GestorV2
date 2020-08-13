using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Entidades
{
    public class Productos : BaseDTO
    {
        public string folio_producto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string marca { get; set; }
        public string descripcion { get; set; }
        public int stock_minimo { get; set; }
        public int stock_actual { get; set; }
        public byte[] imagen { get; set; }


        public override string ToString()
        {
            return string.Format("{0} ({1})", nombre, marca);
        }
    }
}
