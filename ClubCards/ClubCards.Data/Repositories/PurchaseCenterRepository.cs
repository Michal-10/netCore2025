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
    public class PurchaseCenterRepository : RepositoryGeneric<PurchaseCenterEntity>, IRepositoryPurchaseCenter
    {
        public PurchaseCenterRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<PurchaseCenterEntity> GetAllDB()
        {
            return _dbSet.Include(c=>c.CardsList);
        }

        public bool UpdateDB(int numPurchaseCenter, PurchaseCenterEntity purchaseCenterEntity)
        {
            PurchaseCenterEntity purchaseCenter = GetByIdDB(numPurchaseCenter);

            if (purchaseCenterEntity.NumPurchaseCenter != 0 && purchaseCenterEntity.NumPurchaseCenter != purchaseCenter.NumPurchaseCenter)
                purchaseCenter.NumPurchaseCenter = purchaseCenterEntity.NumPurchaseCenter;

            if (purchaseCenterEntity.NamePurchasePoint != null && !string.IsNullOrEmpty(purchaseCenterEntity.NamePurchasePoint))
                purchaseCenter.NamePurchasePoint = purchaseCenterEntity.NamePurchasePoint;

            if (!string.IsNullOrEmpty(purchaseCenterEntity.Address))
                purchaseCenter.Address = purchaseCenterEntity.Address;

            if (purchaseCenterEntity.City != null && !string.IsNullOrEmpty(purchaseCenterEntity.City))
                purchaseCenter.City = purchaseCenterEntity.City;

            if (!string.IsNullOrEmpty(purchaseCenterEntity.Phone))
                purchaseCenter.Phone = purchaseCenterEntity.Phone;

            if (!string.IsNullOrEmpty(purchaseCenterEntity.Email))
                purchaseCenter.Email = purchaseCenterEntity.Email;

            if (purchaseCenterEntity.Quantity != 0 && purchaseCenterEntity.Quantity != purchaseCenter.Quantity)
                purchaseCenter.Quantity = purchaseCenterEntity.Quantity;

            return true;
        }
    }
}
