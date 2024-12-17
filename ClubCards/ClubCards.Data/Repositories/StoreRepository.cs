using ClubCards.Core.Repositories;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class StoreRepository : RepositoryGeneric<StoreEntity>, IRepositoryStore
    {
        public StoreRepository(DataContext context) : base(context)
        {
        }

        public List<StoreEntity> GetAllDB()
        {
            return _dbSet.ToList();//.Include(s=>s.ListBuying).ToList();
        }

        public bool UpdateDB(int numStore, StoreEntity storeEntity)
        {
            StoreEntity store = GetByIdDB(numStore);

            if (storeEntity.Name != null && !string.IsNullOrEmpty(storeEntity.Name))
                store.Name = storeEntity.Name;

            if (storeEntity.Name != null && !string.IsNullOrEmpty(storeEntity.Address))
                store.Address = storeEntity.Address;

            if (storeEntity.City != null && !string.IsNullOrEmpty(storeEntity.City))
                store.City = storeEntity.City;

            if (!string.IsNullOrEmpty(storeEntity.Phone))
                store.Phone = storeEntity.Phone;

            if (!string.IsNullOrEmpty(storeEntity.Email))
                store.Email = storeEntity.Email;

            if (storeEntity.Manager != null && !string.IsNullOrEmpty(storeEntity.Manager))
                store.Manager = storeEntity.Manager;

            return true;
        }

    }
}
