using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Repositories
{
    public interface IRepositoryPurchaseCenter:IRepositoryGeneric<PurchaseCenterEntity>
    {
        public IEnumerable<PurchaseCenterEntity> GetAllDB();
        bool UpdateDB(int numPurchaseCenter, PurchaseCenterEntity purchaseCenterEntity);
    }
}
