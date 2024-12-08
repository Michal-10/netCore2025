using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Services
{
    public interface IStoreService
    {
        public List<StoreEntity> GetStores();
        public StoreEntity GetStoreById(int id);
        public bool AddStore(StoreEntity store);
        public bool UpdateStore(uint id, StoreEntity store);
        public bool DeleteStore(uint id);
    }
}
