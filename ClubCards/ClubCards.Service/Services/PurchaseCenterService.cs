using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using System;

namespace ClubCardsProject.Services
{
    public class PurchaseCenterService:IPurchaseCenterService
    {
        private IRepositoryPurchaseCenter _prchaseCenterRepository;
        private IRepositoryManager _repositoryManager;
        public PurchaseCenterService(IRepositoryPurchaseCenter prchaseCenterRepository, IRepositoryManager repositoryManager)
        {
            _prchaseCenterRepository = prchaseCenterRepository;
            _repositoryManager = repositoryManager;  
        }
        public List<PurchaseCenterEntity> GetPurchaseCenters()
        {
           return _prchaseCenterRepository.GetAllDB();
        }

        public PurchaseCenterEntity GetPurchaseCenterByID(int id)
        {
            //var data=_purchaseCenterService.GetAllDB();
            //if (data == null || (data.FindIndex(p=>p.Id==id)==-1))
            //    return null;
            return _prchaseCenterRepository.GetByIdDB(id);
        }

        public bool AddPurchaseCenter(PurchaseCenterEntity purchaseCenterObj)
        {
            PurchaseCenterEntity purchaseCenter = _prchaseCenterRepository.GetByIdDB((int)purchaseCenterObj.NumPurchaseCenter);
            if (purchaseCenter ==null && ValidationCheck.IsEmailValid(purchaseCenterObj.Email) )
            {
                _prchaseCenterRepository.AddDB(purchaseCenterObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdatePurchaseCenter(uint numPurchaseCenter, PurchaseCenterEntity purchaseCenterObj)
        {
            PurchaseCenterEntity purchaseCenter = _prchaseCenterRepository.GetByIdDB((int)numPurchaseCenter);
            if (purchaseCenter != null)
            {
                _prchaseCenterRepository.UpdateDB((int)numPurchaseCenter, purchaseCenterObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeletePurchaseCentere(uint numPurchaseCenter)
        {
            PurchaseCenterEntity purchaseCenter = _prchaseCenterRepository.GetByIdDB((int)numPurchaseCenter);
            if (purchaseCenter != null)
            {
                _prchaseCenterRepository.DeleteDB((int)numPurchaseCenter);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}
