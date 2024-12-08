using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCardsProject.Entities;
using System;

namespace ClubCardsProject.Services
{
    public class PurchaseCenterService:IPurchaseCenterService
    {
        private readonly IRepository<PurchaseCenterEntity> _purchaseCenterService;
        public PurchaseCenterService(IRepository<PurchaseCenterEntity> purchaseCenterService)
        {
            _purchaseCenterService = purchaseCenterService;
        }
        public List<PurchaseCenterEntity> GetPurchaseCenters()
        {
           return _purchaseCenterService.GetAllDB();
        }

        public PurchaseCenterEntity GetPurchaseCenterByID(int id)
        {
            var data=_purchaseCenterService.GetAllDB();
            if (data == null || (data.FindIndex(p=>p.Id==id)==-1))
                return null;
            return _purchaseCenterService.GetByIdDB(id);
        }

        public bool AddPurchaseCenter(PurchaseCenterEntity purchaseCenter)
        {
            int index = _purchaseCenterService.IsExist(purchaseCenter.NumPurchaseCenter);
            if (index == -1 && ValidationCheck.IsEmailValid(purchaseCenter.Email) )
            {
                return _purchaseCenterService.AddDB(purchaseCenter);
            }
            return false;
        }

        public bool UpdatePurchaseCenter(uint numPurchaseCenter, PurchaseCenterEntity purchaseCenter)
        {
            int index = _purchaseCenterService.IsExist(numPurchaseCenter);
            if (index != -1)
            {
                return _purchaseCenterService.UpdateDB(index, purchaseCenter);
            }
            return false;
        }

        public bool DeletePurchaseCentere(uint numPurchaseCenter)
        {
            int index = _purchaseCenterService.IsExist(numPurchaseCenter);
            if (index != -1)
            {
                return _purchaseCenterService.DeleteDB(index);
            }
            return false;
        }
    }
}
