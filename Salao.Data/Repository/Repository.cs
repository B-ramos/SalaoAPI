using Microsoft.EntityFrameworkCore;
using Salao.Data.Context;
using Salao.Domain.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Salao.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected readonly SalaoContext _context;
        private DbSet<T> dataset;

        public Repository(SalaoContext context)
        {
            _context = context;
            dataset = context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(int id)
        {
            return dataset.FirstOrDefault(x => x.Id.Equals(id));
        }

        public T Create(T entity)
        {
            dataset.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public T Update(T entity, T newEntity)
        { 
            _context.Entry(entity).CurrentValues.SetValues(newEntity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        { 
            dataset.Remove(entity);
            _context.SaveChanges();
        }
    }
}
