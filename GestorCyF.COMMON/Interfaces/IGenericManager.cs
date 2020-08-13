using GestorCyF.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorCyF.COMMON.Interfaces
{
    public interface IGenericManager<T> where T : BaseDTO
    {
        string Error { get; set; }
        bool Agregar(T entidad, bool local);
        List<T> Listar { get; }
        bool Eliminar(ObjectId id, bool local);
        bool Modificar(T entidad, bool local);
        bool AgregarLocal(T entidad);
        T BuscarPorId(ObjectId id);
        List<T> ListarLocal();
    }
}
