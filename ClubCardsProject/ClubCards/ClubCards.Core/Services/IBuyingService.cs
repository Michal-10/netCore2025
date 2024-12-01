using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Services
{
    public interface IBuyingService
    {
        public List<BuyingEntity> GetBuyings();
        public BuyingEntity GetBuyingById(int id);
        public bool AddBuying(BuyingEntity buying);
        public bool UpdateBuying(int id, BuyingEntity buying);
        public bool DeleteBuying(int id);
    }
}
