using FluentValidation;
using FluentValidation.Results;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using System.Linq;
using GestorCyF.COMMON.Interfaces;
using GestorCyF.COMMON.Entidades;

namespace GestorCyF.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDTO
    {
        string dbName;
        string tableName;
        private MongoClient client;
        private IMongoDatabase db;
        private AbstractValidator<T> Validator;
        public string Error { get; set; }
        public bool Resultado { get; private set; }
        private ValidationResult validationResult;

        public GenericRepository(AbstractValidator<T> validator, string pathDB)
        {
            dbName = pathDB + @"\gestorGyF.db";
            client = new MongoClient(new MongoUrl("mongodb+srv://AlainJordan:jordan07@cluster0-c5roo.mongodb.net/test?retryWrites=true&w=majority"));
            db = client.GetDatabase("Cluster0");
            
            tableName = typeof(T).Name;
      
            Validator = validator;
            Resultado = false;
            Error = "";

        }

        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Read => Collection().AsQueryable().ToList();

        public bool Create(T entidad, bool local)
        {
            entidad.Id = MongoDB.Bson.ObjectId.GenerateNewId();
            entidad.FechaHora = DateTime.Now;
            validationResult = Validator.Validate(entidad);
            if (validationResult.IsValid)
            {
                try
                {
                    Collection().InsertOne(entidad);
                    if (local)
                    {
                        Resultado = LocalCreate(entidad);
                    }
                    else
                    {
                        Resultado = true;
                    }
                    Error = null;
                }
                catch (Exception)
                {
                    Error = "No se pudo crear " + typeof(T).Name;
                    Resultado = false;
                }
            }
            else
            {
                Resultado = false;
                ObtenerError(validationResult.Errors);
            }
            return Resultado;
        }

        public bool Delete(MongoDB.Bson.ObjectId id, bool local)
        {
            try
            {
                if (local)
                {
                    Resultado = LocalDelete(id);
                }
                else
                {
                    Resultado = Collection().DeleteOne(e => e.Id == id).DeletedCount == 1;
                }
                Error = null;
            }
            catch (Exception)
            {
                Resultado = false;
                Error = "No se pudo eliminar " + typeof(T).Name;
            }
            return Resultado;
        }

        public bool Update(T entidadModificada, bool local)
        {
            validationResult = Validator.Validate(entidadModificada);
            if (validationResult.IsValid)
            {
                try
                {
                    if (local)
                    {
                        Resultado = LocalUpdate(entidadModificada);
                    }
                    else
                    {
                        Resultado = Collection().ReplaceOne(p => p.Id == entidadModificada.Id, entidadModificada).ModifiedCount == 1;
                    }
                    Error = null;
                }
                catch (Exception)
                {
                    Error = "No se pudo modificar " + typeof(T).Name;
                    Resultado = false;
                }
            }
            else
            {
                Resultado = false;
                ObtenerError(validationResult.Errors);
            }
            return Resultado;
        }
        private void ObtenerError(IList<ValidationFailure> errors)
        {
            Error = typeof(T).Name + " Invalido/a";
            foreach (var error in errors)
            {
                Error += "\n" + error.ErrorMessage;
            }
        }

        public bool LocalCreate(T entidad)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var collection = db.GetCollection<T>(tableName);
                    collection.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                Error = "Error al cargar local";
                return false;
            }
        }

        public bool LocalUpdate(T entidad)
        {
            try
            {
                using (var db = new LiteDatabase(dbName))
                {
                    var collection = db.GetCollection<T>(tableName);
                    collection.Update(entidad);
                }
                return true;
            }
            catch (Exception)
            {
                Error = "Error al modificar local";
                return false;
            }
        }

        public bool LocalDelete(MongoDB.Bson.ObjectId id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(dbName))
                {
                    var collection = db.GetCollection<T>(tableName);
                    r = collection.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {
                Error = "Error de eliminar local";
                return false;
            }
        }

        public List<T> LocalRead()
        {
            List<T> data = new List<T>();
            using (var db = new LiteDatabase(dbName))
            {
                data = db.GetCollection<T>(tableName).FindAll().ToList();
            }
            return data;
        }
    }
}
