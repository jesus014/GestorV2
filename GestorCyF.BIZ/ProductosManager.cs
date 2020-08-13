using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.BIZ
{
    public class ProductosManager : GenericManager<Productos>, IProductoManger
    {
        public ProductosManager(IGenericRepository<Productos> genericRepository) : base(genericRepository)
        {

        }
    }
}
