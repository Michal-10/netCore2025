using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Repositories
{
    public interface IRepositoryGeneric<T>
    {
         List<T> GetAllDB();
         T? GetByIdDB(int id);
        //public T IsExist(int numUniq);
         bool AddDB(T buyingEntity);
         bool DeleteDB(int id);

    }
}
