using ClubCards.Core.DTOs;
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

        public IEnumerable<PurchaseCenterDTO> GetPurchaseCenters();
        public PurchaseCenterDTO GetPurchaseCenterByID(int id);
        public bool AddPurchaseCenter(PurchaseCenterDTO purchaseCenter);
        public bool UpdatePurchaseCenter(uint id, PurchaseCenterDTO purchaseCenter);
        public bool DeletePurchaseCentere(uint id);
    }
}
