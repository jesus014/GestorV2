using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.BIZ
{
    public class ClientesManager:GenericManager<Clientes>, IClienteManager
    {
        public ClientesManager(IGenericRepository<Clientes> genericRepository) : base(genericRepository)
        {
                
        }

    }
}
