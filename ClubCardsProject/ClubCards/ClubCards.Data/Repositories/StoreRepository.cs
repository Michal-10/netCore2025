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
            return _dataContext.StoresList;
        }
        public StoreEntity GetByIdDB(int id)
        {
            return _dataContext.StoresList.Where(b => b.Id == id).FirstOrDefault();
        }
        public bool AddDB(StoreEntity storeEntity)
        {
            try
            {
                _dataContext.StoresList.Add(storeEntity);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int id, StoreEntity storeEntity)
        {
            try
            {
                int index = _dataContext.StoresList.FindIndex(b => b.Id == id);
                _dataContext.StoresList[index] = storeEntity;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int id)
        {
            try
            {
                StoreEntity store = _dataContext.StoresList.Find(b => b.Id == id);
                _dataContext.StoresList.Remove(store);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
