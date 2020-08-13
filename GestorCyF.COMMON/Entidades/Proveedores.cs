using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Entidades
{
    public class Proveedores: BaseDTO
    {
        public string folio_proveedor { get; set; }
        public string empresa { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return string.Format("{0}",empresa);
        }

    }
}
