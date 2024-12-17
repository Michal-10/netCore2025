using System.Linq;
using ClubCardsProject.Entities;
using ClubCards.Core.Services;
using ClubCards.Core.Repositories;

namespace ClubCardsProject.Services
{
    public class BuyingService:IBuyingService
    {
        private IRepositoryBuying _buyingRepository;
        private IRepositoryManager _repositoryManager;
        public BuyingService(IRepositoryBuying buyingRepository, IRepositoryManager repositorymanager)
        {
            _buyingRepository = buyingRepository;
            _repositoryManager = repositorymanager;
        }

        public List<BuyingEntity> GetBuyings()
        {
            return _buyingRepository.GetAllDB();
        }

        public BuyingEntity GetBuyingById(int id)
        {
            return _buyingRepository.GetByIdDB(id);
        }

        public bool AddBuying(BuyingEntity buyingObj)
        {
            BuyingEntity buying = _buyingRepository.GetByIdDB((int)buyingObj.NumBuying);
            if (buying == null)
            {
                _buyingRepository.AddDB(buyingObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdateBuying(uint numBuying, BuyingEntity buyingObj)
        {
            BuyingEntity buying = _buyingRepository.GetByIdDB((int)numBuying);
            if (buying != null)
            //return _buyingRepository.UpdateDB(index, buying);
            {
                _buyingRepository.UpdateDB((int)numBuying, buyingObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeleteBuying(uint numBuying)
        {
            BuyingEntity buying  = _buyingRepository.GetByIdDB((int)numBuying);
            if (buying != null)
            {
                _buyingRepository.DeleteDB((int)numBuying);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}
