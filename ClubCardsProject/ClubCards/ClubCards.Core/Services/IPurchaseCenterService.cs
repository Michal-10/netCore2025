using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Services
{
    public interface IPurchaseCenterService
    {

        public List<PurchaseCenterEntity> GetPurchaseCenters();
        public PurchaseCenterEntity GetPurchaseCenterByID(int id);
        public bool AddPurchaseCenter(PurchaseCenterEntity purchaseCenter);
        public bool UpdatePurchaseCenter(int id, PurchaseCenterEntity purchaseCenter);
        public bool DeletePurchaseCentere(int id);
    }
}
