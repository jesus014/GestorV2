using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Entidades
{
    public class Ventas : BaseDTO
    {
        public List<ElementosLIsta> ElementosLista { get; set; }
        public DateTime fechaVenta { get; set; }
        public Clientes cliente { get; set; }
        public string totalVenta { get; set; }
        public string folio { get; set; }
    }
}
