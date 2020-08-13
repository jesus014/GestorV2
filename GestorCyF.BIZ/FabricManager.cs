using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using GestorCyF.COMMON.Validadores;
using GestorCyF.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.BIZ
{
    public static class FabricManager
    {
        public static ClientesManager Clientes (string pathDB)
        {
            return new ClientesManager(new GenericRepository<Clientes>(new ClientesValidator(), pathDB));
        }
        public static ProductosManager Productos(string pathDB)
        {
            return new ProductosManager(new GenericRepository<Productos>(new ProductosValidator(), pathDB));
        }
        public static ProveedoresManager Proveedores(string pathDB)
        {
            return new ProveedoresManager(new GenericRepository<Proveedores>(new ProveedoresValidator(), pathDB));
        }
        public static ComprasManager Compras(string pathDB)
        {
            return new ComprasManager(new GenericRepository<Compras>(new ComprasValidator(), pathDB));
        }
        public static ServiciosManager Servicios(string pathDB)
        {
            return new ServiciosManager(new GenericRepository<Servicios>(new ServiciosValidator(), pathDB));
        }
        public static VentasManager Ventas(string pathDB)
        {
            return new VentasManager(new GenericRepository<Ventas>(new VentasValidator(), pathDB));
        }

    }
}
