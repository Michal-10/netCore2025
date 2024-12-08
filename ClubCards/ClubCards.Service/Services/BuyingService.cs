using System.Linq;
using ClubCardsProject.Entities;
using ClubCards.Data;
using ClubCards.Core.Services;

namespace ClubCardsProject.Services
{
    public class BuyingService:IBuyingService
    {
        private IRepository<BuyingEntity> _buyingService;
        public BuyingService(IRepository<BuyingEntity> buyingService)
        {
            _buyingService = buyingService;
        }

        public List<BuyingEntity> GetBuyings()
        {
            return _buyingService.GetAllDB();
        }

        public BuyingEntity GetBuyingById(int id)
        {
            return _buyingService.GetByIdDB(id);
        }

        public bool AddBuying(BuyingEntity buying)
        {
            int index = _buyingService.IsExist(buying.NumBuying);
            if (index == -1 )
            {
                return _buyingService.AddDB(buying);
            }
            return false;
        }

        public bool UpdateBuying(uint numBuying, BuyingEntity buying)
        {
            int index = _buyingService.IsExist(numBuying);
            if (index != -1)
                return _buyingService.UpdateDB(index, buying);
            return false;
        }

        public bool DeleteBuying(uint numBuying)
        {
            int index = _buyingService.IsExist(numBuying);
            if (index != -1)
            {
                return _buyingService.DeleteDB(index);
            }
            return false;
        }
    }
}
