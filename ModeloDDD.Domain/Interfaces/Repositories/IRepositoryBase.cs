﻿using System.Collections.Generic;

namespace ModeloDDD.Domain.Interfaces.Repositories
{
    //CRUD basico do repository base
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
