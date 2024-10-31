using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class StoreService
    {
        static List<StoreEntity> _storeEntityes;

        public List<StoreEntity> GetStores()
        {
            if (_storeEntityes == null)
            {
                return null;
            }
            return _storeEntityes;
        }

        public StoreEntity GetStoreById(int id)
        {
            if (_storeEntityes == null || (_storeEntityes.Find(s=>s.Id==id)==null))
                return null;
            return _storeEntityes.Find(store => store.Id == id);
        }

        public bool PostStore(StoreEntity store)
        {
            if (_storeEntityes == null)
                _storeEntityes = new List<StoreEntity>();
            if (_storeEntityes.Find(b => b.Id == store.Id) != null)
                return false;
            _storeEntityes.Add(store);
            return true;
        }

        public bool PutStore(int id, StoreEntity store)
        {
            if (_storeEntityes == null || (_storeEntityes.Find(s => s.Id == id) == null))
                return false;
            int index = _storeEntityes.FindIndex(store => store.Id == id);
            _storeEntityes[index] = store;
            return true;
        }

        public bool DeleteStore(int id)
        {
            if (_storeEntityes == null || (_storeEntityes.Find(s => s.Id == id) == null))
                return false;
            _storeEntityes.Remove(_storeEntityes.Find(store => store.Id == id));
            return true;
        }
    }
}
