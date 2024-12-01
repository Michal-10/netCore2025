using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCardsProject.Entities;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class StoreService:IStoreService
    {
        readonly IRepository<StoreEntity> _storeService;
        public StoreService(IRepository<StoreEntity> storeService)
        {
            _storeService = storeService;
        }
        public List<StoreEntity> GetStores()
        { 
            return _storeService.GetAllDB();
        }

        public StoreEntity GetStoreById(int id)
        {
            var data = _storeService.GetAllDB();
            if (data == null || (data.Find(s=>s.Id==id)==null))
                return null;
            return _storeService.GetByIdDB(id);
        }

        public bool AddStore(StoreEntity store)
        {
            var data=_storeService.GetAllDB();
            if (data == null||(data.Find(b => b.Id == store.Id) != null))//אם ה id כבר קיים במערכת
                 return false;
            if (!ValidationCheck.IsEmailValid(store.Email) )
                return false;
            return _storeService.AddDB(store);
        }

        public bool UpdateStore(int id, StoreEntity store)
        {
            var data=_storeService.GetAllDB();
            if (data == null || (data.Find(s => s.Id == id) == null))
                return false;
            return _storeService.UpdateDB(id,store);
        }

        public bool DeleteStore(int id)
        {
            var data=_storeService.GetAllDB();
            if (data == null || (data.Find(s => s.Id == id) == null))
                return false;
            return _storeService.DeleteDB(id);
        }
    }
}
