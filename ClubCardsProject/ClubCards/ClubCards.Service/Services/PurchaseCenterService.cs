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
            var data = _purchaseCenterService.GetAllDB();
            if (data == null || (data.FindIndex(p => p.Id == purchaseCenter.Id) != -1))
                return false;
            if (!ValidationCheck.IsEmailValid(purchaseCenter.Email))
                return false;
           return _purchaseCenterService.AddDB(purchaseCenter);
        }

        public bool UpdatePurchaseCenter(int id, PurchaseCenterEntity purchaseCenter)
        {
            var data = _purchaseCenterService.GetAllDB();
            if (data == null || (data.FindIndex(p => p.Id == id) == -1))
                return false;
            return _purchaseCenterService.UpdateDB(id,purchaseCenter);
        }

        public bool DeletePurchaseCentere(int id)
        {
            var data = _purchaseCenterService.GetAllDB();
            if (data == null || (data.FindIndex(p => p.Id == id) == -1))
                return false;
            return _purchaseCenterService.DeleteDB(id);
        }
    }
}
