using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class StoreRepository : IRepository<StoreEntity>
    {
        private readonly DataContext _dataContext;
        public StoreRepository (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<StoreEntity> GetAllDB()
        {
            return _dataContext.StoresList.ToList();
        }
        public StoreEntity GetByIdDB(int id)
        {
            return _dataContext.StoresList.Where(b => b.Id == id).FirstOrDefault();
        }
        public int IsExist(uint numStore)
        {
            return _dataContext.StoresList.ToList().FindIndex(s => s.NumStore == numStore);
        }
        public bool AddDB(StoreEntity storeEntity)
        {
            try
            {
                 _dataContext.StoresList.Add(storeEntity);
                 _dataContext.SaveChanges();
                 return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int numStoreIndex, StoreEntity storeEntity)
        {
            try
            {
                //int index = IsExist(numStore);
                if (storeEntity.Id != 0)
                    _dataContext.StoresList.ToList()[numStoreIndex].Id = storeEntity.Id;

                if (!string.IsNullOrEmpty(storeEntity.Name))
                    _dataContext.StoresList.ToList()[numStoreIndex].Name = storeEntity.Name;

                if (!string.IsNullOrEmpty(storeEntity.Address))
                    _dataContext.StoresList.ToList()[numStoreIndex].Address = storeEntity.Address;

                if (!string.IsNullOrEmpty(storeEntity.City))
                     _dataContext.StoresList.ToList()[numStoreIndex].City = storeEntity.City;

                if (!string.IsNullOrEmpty(storeEntity.Phone))
                     _dataContext.StoresList.ToList()[numStoreIndex].Phone = storeEntity.Phone;

                if (!string.IsNullOrEmpty(storeEntity.Email))
                     _dataContext.StoresList.ToList()[numStoreIndex].Email = storeEntity.Email;

                if (!string.IsNullOrEmpty(storeEntity.Manager))
                     _dataContext.StoresList.ToList()[numStoreIndex].Manager = storeEntity.Manager;

                _dataContext.SaveChanges(); 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int numStoreIndexDelete)
        {
            try
            {
               // StoreEntity store = _dataContext.StoresList.ToList().Find(b => b.NumStore == numStore);
                //_dataContext.StoresList.Remove(store);
                _dataContext.StoresList.Remove(_dataContext.StoresList.ToList()[numStoreIndexDelete]);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
