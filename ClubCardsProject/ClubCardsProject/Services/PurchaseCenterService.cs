using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClubCardsProject.Services
{
    public class PurchaseCenterService
    {
        static List<PurchaseCenterEntity> _purchaseCenters;

        public List<PurchaseCenterEntity> GetPurchaseCenters()
        {
            if (_purchaseCenters == null)
                return null;
            return _purchaseCenters;
        }

        public PurchaseCenterEntity GetPurchaseCenterByID(int id)
        {
            if (_purchaseCenters == null || (_purchaseCenters.FindIndex(p=>p.Id==id)==-1))
                return null;
            return _purchaseCenters.Find(p => p.Id == id);
        }

        public bool PostPurchaseCenter(PurchaseCenterEntity purchaseCenter)
        {
            if (_purchaseCenters == null)
                _purchaseCenters = new List<PurchaseCenterEntity>();
            if (_purchaseCenters.Find(b => b.Id == purchaseCenter.Id) != null)
                return false;
            _purchaseCenters.Add(purchaseCenter);
            return true;
        }

        public bool PutPurchaseCenter(int id, PurchaseCenterEntity purchaseCenter)
        {
            if (_purchaseCenters == null || (_purchaseCenters.Find(p => p.Id == id) == null))
                return false;
            int index = _purchaseCenters.FindIndex(p => p.Id == id);
            _purchaseCenters[index] = purchaseCenter;
            return true;
        }

        public bool DeletePurchaseCentere(int id)
        {
            if (_purchaseCenters == null || (_purchaseCenters.FindIndex(p => p.Id == id) == -1))
                return false;
            _purchaseCenters.Remove(_purchaseCenters.Find(p => p.Id == id));
            return true;
        }
    }
}
