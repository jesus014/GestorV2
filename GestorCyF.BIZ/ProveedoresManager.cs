using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.BIZ
{
    public class ProveedoresManager : GenericManager<Proveedores>, IProveedoresManager
    {
        public ProveedoresManager(IGenericRepository<Proveedores> genericRepository) : base(genericRepository)
        {

        }
    }
}
