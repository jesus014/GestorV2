using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Text;
using GestorCyF.COMMON.Entidades;

namespace GestorCyF.COMMON.Interfaces
{
    public interface IGenericRepository<T> where T : BaseDTO
    {
        string Error { get; set; }
        bool Resultado { get; }
        bool Create(T entidad, bool local);
        List<T> Read { get; }
        bool Update(T entidadModificada, bool local);
        bool Delete(ObjectId id, bool local);
        bool LocalCreate(T entidad);
        bool LocalUpdate(T entidad);
        bool LocalDelete(MongoDB.Bson.ObjectId entidad);
        List<T> LocalRead();
    }
}
