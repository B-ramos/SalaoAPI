using Microsoft.EntityFrameworkCore;
using Salao.Data.Context;
using Salao.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public T Update(T entity)
        {
            var result = FindById(entity.Id);
            if (result == null)
                return null;

            _context.Entry(result).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(int id)
        {
            var entity = FindById(id);

            if (entity == null)
                return;

            dataset.Remove(entity);
            _context.SaveChanges();
        }
    }
}
