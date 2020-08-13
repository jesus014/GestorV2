using GestorCyF.COMMON.Entidades;
using GestorCyF.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GestorCyF.BIZ
{
    public class GenericManager<T> : IGenericManager<T> where T : BaseDTO
    {
        IGenericRepository<T> repository;

        public GenericManager(IGenericRepository<T> repo)
        {
            repository = repo;
        }
        public string Error { get => repository.Error; set { } }

        public List<T> Listar => repository.Read;

        public bool Agregar(T entidad, bool local) => repository.Create(entidad, local);

        public bool AgregarLocal(T entidad)
        {
            return repository.LocalCreate(entidad);
        }

        public T BuscarPorId(ObjectId id) => repository.Read.Where(p => p.Id == id).SingleOrDefault();

        public bool Eliminar(ObjectId id, bool local) => repository.Delete(id, local);

        public List<T> ListarLocal() => repository.LocalRead();

        public bool Modificar(T entidad, bool local) => repository.Update(entidad, local);
    }
}
