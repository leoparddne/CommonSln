using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.IRepository
{
    public interface IRepositoryBase<T>
    {
        void Add(T obj);
        void Del(T obj);
        void DelRange(IEnumerable<T> list);
        void Update(T obj);
        void UpdateRange(IEnumerable<T> list);
        T Get(Func<T, bool> lambda);
        IEnumerable<T> GetList();
        IEnumerable<T> GetList(Func<T, bool> lambda);
    }
}
