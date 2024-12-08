using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class PurchaseCenterRepository:IRepository<PurchaseCenterEntity>
    {
        private readonly DataContext _dataContext;
        public PurchaseCenterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<PurchaseCenterEntity> GetAllDB()
        {
            return _dataContext.PurchaseCentersList.ToList();
        }
        public PurchaseCenterEntity? GetByIdDB(int id)
        {
            return _dataContext.PurchaseCentersList.Where(b => b.Id == id).FirstOrDefault();
        }
        public int IsExist(uint numPurchaseCenter)
        {
            return _dataContext.PurchaseCentersList.ToList().FindIndex(p => p.NumPurchaseCenter == numPurchaseCenter);
        }
        public bool AddDB(PurchaseCenterEntity purchaseCenterEntity)
        {
            try
            {
                 _dataContext.PurchaseCentersList.Add(purchaseCenterEntity);
                 _dataContext.SaveChanges();
                 return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int numPurchaseCenterIndex, PurchaseCenterEntity purchaseCenterEntity)
        {
            try
            {
                //int index = IsExist(numPurchaseCenter);
                if (purchaseCenterEntity.Id != 0)
                    _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].Id = purchaseCenterEntity.Id;

                if (purchaseCenterEntity.NumPurchaseCenter != 0)
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].NumPurchaseCenter = purchaseCenterEntity.NumPurchaseCenter;

                if (!string.IsNullOrEmpty(purchaseCenterEntity.NamePurchasePoint))
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].NamePurchasePoint = purchaseCenterEntity.NamePurchasePoint;

                if (!string.IsNullOrEmpty(purchaseCenterEntity.Address))
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].Address = purchaseCenterEntity.Address;

                if (!string.IsNullOrEmpty(purchaseCenterEntity.City))
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].City = purchaseCenterEntity.City;

                if (!string.IsNullOrEmpty(purchaseCenterEntity.Phone))
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].Phone = purchaseCenterEntity.Phone;

                if (!string.IsNullOrEmpty(purchaseCenterEntity.Email))
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].Email = purchaseCenterEntity.Email;

                if (purchaseCenterEntity.Quantity != 0)
                     _dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndex].Quantity = purchaseCenterEntity.Quantity;

                _dataContext.SaveChanges(); 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int numPurchaseCenterIndexDelete)
        {
            try
            {
                //PurchaseCenterEntity customer = _dataContext.PurchaseCentersList.ToList().Find(b => b.NumPurchaseCenter == numPurchaseCenter);
                //_dataContext.PurchaseCentersList.Remove(customer);
                _dataContext.PurchaseCentersList.Remove(_dataContext.PurchaseCentersList.ToList()[numPurchaseCenterIndexDelete]);
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
