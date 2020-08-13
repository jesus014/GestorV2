using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.BIZ
{
    public class ServiciosManager : GenericManager<Servicios>, IServicioManager
    {
        public ServiciosManager(IGenericRepository<Servicios> genericRepository) : base(genericRepository)
        {

        }
    }
}
