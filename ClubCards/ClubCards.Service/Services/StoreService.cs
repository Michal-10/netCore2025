using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace ClubCardsProject.Services
{
    public class StoreService:IStoreService
    {
        private IRepositoryStore _storeRepository;
        private IRepositoryManager _repositoryManager;
        public StoreService(IRepositoryStore storeRepository, IRepositoryManager repositoryManager)
        {
            _storeRepository = storeRepository;
            _repositoryManager = repositoryManager;
        }
        public List<StoreEntity> GetStores()
        { 
            return _storeRepository.GetAllDB();
        }

        public StoreEntity GetStoreById(int id)
        {
            //    var data = _storeService.GetAllDB();
            //    if (data == null || (data.Find(s=>s.Id==id)==null))
            //        return null;
            return _storeRepository.GetByIdDB(id);
        }

        public bool AddStore(StoreEntity storeObj)
        {
            StoreEntity store = _storeRepository.GetByIdDB((int)storeObj.NumStore);
            if (store == null && ValidationCheck.IsEmailValid(storeObj.Email))
            {
                _storeRepository.AddDB(storeObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdateStore(uint numStore, StoreEntity storeObj)
        {
            StoreEntity store = _storeRepository.GetByIdDB((int)numStore);
            if (store != null)
            {
                _storeRepository.UpdateDB((int)numStore, storeObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeleteStore(uint numStore)
        {
            StoreEntity store= _storeRepository.GetByIdDB((int)numStore);
            if (store != null)
            {
                _storeRepository.DeleteDB((int)numStore);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

       
    }
}
