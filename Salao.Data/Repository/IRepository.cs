using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> FindAll();
        T FindById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
