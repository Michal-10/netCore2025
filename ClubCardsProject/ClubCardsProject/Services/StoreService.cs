using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class StoreService
    {
        static DataContext _stores;

        public List<StoreEntity> GetStores()
        {
            if (_stores == null)
            {
                return null;
            }
            return _stores.StoresList;
        }

        public StoreEntity GetStoreById(int id)
        {
            if (_stores == null || (_stores.StoresList.Find(s=>s.Id==id)==null))
                return null;
            return _stores.StoresList.Find(store => store.Id == id);
        }

        public bool AddStore(StoreEntity store)
        {
            if (_stores.StoresList == null)
                _stores=new DataContext();
            else if (_stores.StoresList.Find(b => b.Id == store.Id) != null)//אם ה id כבר קיים במערכת
                 return false;
            if (!ValidationCheckGeneric.IsEmailValid(store.Email) )
                return false;
            _stores.StoresList.Add(store);
            return true;
        }

        public bool UpdateStore(int id, StoreEntity store)
        {
            if (_stores.StoresList == null || (_stores.StoresList.Find(s => s.Id == id) == null))
                return false;
            int index = _stores.StoresList.FindIndex(store => store.Id == id);
            _stores.StoresList[index] = store;
            return true;
        }

        public bool DeleteStore(int id)
        {
            if (_stores.StoresList == null || (_stores.StoresList.Find(s => s.Id == id) == null))
                return false;
            _stores.StoresList.Remove(_stores.StoresList.Find(store => store.Id == id));
            return true;
        }
    }
}
