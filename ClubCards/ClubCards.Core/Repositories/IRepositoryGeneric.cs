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
         IEnumerable<T> GetDB();
         T? GetByIdDB(int id);
         bool AddDB(T buyingEntity);
         bool DeleteDB(int id);

    }
}
