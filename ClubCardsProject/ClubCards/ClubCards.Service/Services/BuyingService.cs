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
           var data = _buyingService.GetAllDB();
            if (data == null || (data.FindIndex(b => b.Id == id)) == -1)
                return null;
            return _buyingService.GetByIdDB(id);
        }

        public bool AddBuying(BuyingEntity buying)
        {
            var data = _buyingService.GetAllDB();
            if (data == null||(data.Find(b => b.Id == buying.Id) != null))//אם ה id כבר קיים במערכת
                return false;
            return _buyingService.AddDB(buying);
        }

        public bool UpdateBuying(int id, BuyingEntity buying)
        {
            var data = _buyingService.GetAllDB();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            return _buyingService.UpdateDB(id, buying);
        }

        public bool DeleteBuying(int id)
        {
            var data= _buyingService.GetAllDB();
            if (data==null||(data.FindIndex(b=>b.Id == id)==-1))
                return false;
            return _buyingService.DeleteDB(id); 
        }


    }
}
