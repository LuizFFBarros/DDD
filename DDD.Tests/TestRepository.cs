using DDD.Domain.Entities;
using DDD.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Tests
{
    public class TestRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        private SqlInMemory context = new SqlInMemory();
        new public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        new public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        new public void Delete(int id)
        {
            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        new public IList<T> Select()
        {
            return context.Set<T>().ToList();
        }

        new public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }

    }
}
