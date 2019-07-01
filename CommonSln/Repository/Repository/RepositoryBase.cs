using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> dbSet;
        protected readonly CommonContext context;
        public RepositoryBase(CommonContext context)
        {
            this.context = context;
            dbSet=context.Set<T>();
        }

        public void Add(T obj)
        {
            dbSet.Add(obj);
        }

        public void Del(T obj)
        {
            dbSet.Remove(obj);
        }

        public void DelRange(IEnumerable<T> list)
        {
            dbSet.RemoveRange(list);
        }

        public T Get(Func<T, bool> lambda)
        {
            return  dbSet.Find(lambda);
        }

        public IEnumerable<T> GetList()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetList(Func<T, bool> lambda)
        {
            return dbSet.Where(lambda);
        }

        public void Update(T obj)
        {
            dbSet.Update(obj);
        }

        public void UpdateRange(IEnumerable<T> list)
        {
            dbSet.UpdateRange(list);
        }
    }
}
