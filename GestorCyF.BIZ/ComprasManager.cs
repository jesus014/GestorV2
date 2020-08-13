using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.BIZ
{
    public class ComprasManager : GenericManager<Compras>, IGenericCompras
    {
        public ComprasManager(IGenericRepository<Compras> genericRepository) : base(genericRepository)
        {
                
        }
    }
}
