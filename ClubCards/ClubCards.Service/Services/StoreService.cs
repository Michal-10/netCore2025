using AutoMapper;
using ClubCards.Core.DTOs;
using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace ClubCardsProject.Services
{
    public class StoreService:IStoreService
    {
        private IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;
        public StoreService( IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public IEnumerable<StoreDTO> GetStores()
        {
            var stores = _repositoryManager.Stores.GetAllDB();
            return _mapper.Map<IEnumerable<StoreDTO>>(stores);
        }

        public StoreDTO? GetStoreById(int id)
        {
            return _mapper.Map<StoreDTO>(_repositoryManager.Stores.GetByIdDB(id));
        }

        public bool AddStore(StoreDTO storeObj)
        {
            var store = _repositoryManager.Stores.GetByIdDB((int)storeObj.NumStore);
            if (store == null && storeObj.Email.IsEmailValid())
            {
                var storeEntity = _mapper.Map<StoreEntity>(store);
                _repositoryManager.Stores.AddDB(storeEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdateStore(uint numStore, StoreDTO storeObj)
        {
            var store = _repositoryManager.Stores.GetByIdDB((int)numStore);
            if (store != null)
            {
                var storeEntity = _mapper.Map<StoreEntity>(storeObj);
                _repositoryManager.Stores.UpdateDB((int)numStore, storeEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeleteStore(uint numStore)
        {
            StoreEntity? store = _repositoryManager.Stores.GetByIdDB((int)numStore);
            if (store != null)
            {
                _repositoryManager.Stores.DeleteDB((int)numStore);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

       
    }
}
