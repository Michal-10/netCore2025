using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data
{
    public interface IRepository<T>
    {
        public List<T> GetAllDB();
        public bool AddDB(T buyingEntity);
        public bool UpdateDB(int id, T obj);
        public bool DeleteDB(int id);
        public T GetByIdDB(int id);
    }
}
