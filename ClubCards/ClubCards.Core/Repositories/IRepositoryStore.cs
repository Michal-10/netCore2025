using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Repositories
{
    public interface IRepositoryStore:IRepositoryGeneric<StoreEntity>
    {
        public IEnumerable<StoreEntity> GetAllDB();
        bool UpdateDB(int numStore, StoreEntity storeEntity);
    }
}
