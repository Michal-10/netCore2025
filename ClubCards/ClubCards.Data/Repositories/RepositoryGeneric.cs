using ClubCards.Core.Repositories;
using ClubCardsProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class RepositoryGeneric<T>:IRepositoryGeneric<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        public RepositoryGeneric(DataContext context)
        {
            _dbSet = context.Set<T>();
        }
        virtual public IEnumerable<T> GetDB()
        {
            return _dbSet;
        }

        public T? GetByIdDB(int id)
        {
            return _dbSet.Find(id);
        }

        public bool AddDB(T buyingEntity)
        {
            _dbSet.Add(buyingEntity);
            return true;
        }

        //public bool UpdateDB(int id, T obj)
        //{
        //    _dbSet.Update(obj);
        //    return true;
        //}

        public bool DeleteDB(int id)
        {
            _dbSet.Remove(GetByIdDB(id));
            //_dbSet.SaveChanges();
            return true;
        }
    }
}
