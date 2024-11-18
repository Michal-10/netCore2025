using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClubCardsProject.Services
{
    public class PurchaseCenterService
    {

        public List<PurchaseCenterEntity> GetPurchaseCenters()
        {
            if (DataContextManager.Data.PurchaseCentersList == null)
                return null;
            return DataContextManager.Data.PurchaseCentersList;
        }

        public PurchaseCenterEntity GetPurchaseCenterByID(int id)
        {
            if (DataContextManager.Data.PurchaseCentersList == null || (DataContextManager.Data.PurchaseCentersList.FindIndex(p=>p.Id==id)==-1))
                return null;
            return DataContextManager.Data.PurchaseCentersList.Find(p => p.Id == id);
        }

        public bool AddPurchaseCenter(PurchaseCenterEntity purchaseCenter)
        {
            if (DataContextManager.Data.PurchaseCentersList == null)
                DataContextManager.Data.PurchaseCentersList = new List<PurchaseCenterEntity>();
            else if (DataContextManager.Data.PurchaseCentersList.Find(b => b.Id == purchaseCenter.Id) != null)//אם ה id כבר קיים במערכת
                 return false;
            if (!ValidationCheckGeneric.IsEmailValid(purchaseCenter.Email))
                return false;
            DataContextManager.Data.PurchaseCentersList.Add(purchaseCenter);
            return true;
        }

        public bool UpdatePurchaseCenter(int id, PurchaseCenterEntity purchaseCenter)
        {
            if (DataContextManager.Data.PurchaseCentersList == null || (DataContextManager.Data.PurchaseCentersList.Find(p => p.Id == id) == null))
                return false;
            int index = DataContextManager.Data.PurchaseCentersList.FindIndex(p => p.Id == id);
            DataContextManager.Data.PurchaseCentersList[index] = purchaseCenter;
            return true;
        }

        public bool DeletePurchaseCentere(int id)
        {
            if (DataContextManager.Data.PurchaseCentersList == null || (DataContextManager.Data.PurchaseCentersList.FindIndex(p => p.Id == id) == -1))
                return false;
            DataContextManager.Data.PurchaseCentersList.Remove(DataContextManager.Data.PurchaseCentersList.Find(p => p.Id == id));
            return true;
        }
    }
}
