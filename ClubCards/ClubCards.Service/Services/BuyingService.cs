using System.Linq;
using ClubCardsProject.Entities;
using ClubCards.Core.Services;
using ClubCards.Core.Repositories;
using AutoMapper;
using ClubCards.Core.DTOs;

namespace ClubCardsProject.Services
{
    public class BuyingService:IBuyingService
    {
        private IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;

        public BuyingService( IRepositoryManager repositorymanager,IMapper mapper)
        {
            _repositoryManager = repositorymanager;
            _mapper = mapper;
        }

        public IEnumerable<BuyingDTO> GetBuyings()
        {
            var buyings = _repositoryManager.Buyings.GetAllDB();
            return _mapper.Map<IEnumerable<BuyingDTO>>(buyings);
        }

        public BuyingDTO? GetBuyingById(int id)
        {
            return _mapper.Map<BuyingDTO>(_repositoryManager.Buyings.GetByIdDB(id));
        }

        public bool AddBuying(BuyingDTO buyingObj)
        {
            var buying = _repositoryManager.Buyings.GetByIdDB((int)buyingObj.NumBuying);
            if (buying == null)
            {
                var buyingEntity = _mapper.Map<BuyingEntity>(buyingObj);
                _repositoryManager.Buyings.AddDB(buyingEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdateBuying(uint numBuying, BuyingDTO buyingObj)
        {
            var buying = _repositoryManager.Buyings.GetByIdDB((int)numBuying);
            if (buying != null)
            {
                var buyingEntity = _mapper.Map<BuyingEntity>(buying);
                _repositoryManager.Buyings.UpdateDB((int)numBuying, buyingEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeleteBuying(uint numBuying)
        {
            BuyingEntity? buying = _repositoryManager.Buyings.GetByIdDB((int)numBuying);
            if (buying != null)
            { 
                _repositoryManager.Buyings.DeleteDB((int)numBuying);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}
