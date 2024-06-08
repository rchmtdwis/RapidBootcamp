using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidBootcamp.WebApplication.DAL
{
    public interface ICrud<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}