using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Entidades
{
    public class Clientes : BaseDTO
    {
        public string nombre { get; set; }
        public string apellidop { get; set; }
        public string apellidom { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        
    }
}
