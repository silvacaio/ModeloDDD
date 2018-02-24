using ModeloDDD.Domain.Interfaces.Repositories;
using ModeloDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModeloDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ModeloDDDContext _context = new ModeloDDDContext();

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

        public TEntity GetById(int id) => _context.Set<TEntity>().Find(id);

        public void Remove(TEntity obj) => _context.Set<TEntity>().Remove(obj);

        public void Update(TEntity obj) => _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
