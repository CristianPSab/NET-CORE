using ApiRest.Abstractions;
using System;
using System.Collections.Generic;

namespace ApiRest.Repository
{
    public interface IRepository<T> : ICrud<T>
    {
    }

    public class Repository<T> : IRepository<T>
    {
      

        public void Delete(int id)
        {
          
        }

        public IList<T> GetAll()
        {
            return null;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
