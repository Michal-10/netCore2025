using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCardsProject.Entities;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

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
            int index = _storeService.IsExist(store.NumStore);
            if (index == -1 && ValidationCheck.IsEmailValid(store.Email))
            {
                return _storeService.AddDB(store);
            }
            return false;
        }

        public bool UpdateStore(uint numStore, StoreEntity store)
        {
            int index = _storeService.IsExist(numStore);
            if (index != -1)
            {
                return _storeService.UpdateDB(index, store);
            }
            return false;
        }

        public bool DeleteStore(uint numStore)
        {
            int index= _storeService.IsExist(numStore);
            if (index != -1)
            {
                return _storeService.DeleteDB(index);
            }
            return false;
        }

       
    }
}
