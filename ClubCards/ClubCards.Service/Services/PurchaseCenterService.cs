using AutoMapper;
using ClubCards.Core.DTOs;
using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using System;

namespace ClubCardsProject.Services
{
    public class PurchaseCenterService:IPurchaseCenterService
    {
        private IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;

        public PurchaseCenterService( IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;  
            _mapper = mapper;
        }
        public IEnumerable<PurchaseCenterDTO> GetPurchaseCenters()
        {
            var purchaseCenters = _repositoryManager.PurchaseCenters.GetAllDB();
            return _mapper.Map<IEnumerable<PurchaseCenterDTO>>(purchaseCenters);
        }

        public PurchaseCenterDTO? GetPurchaseCenterByID(int id)
        {
            return _mapper.Map<PurchaseCenterDTO>(_repositoryManager.PurchaseCenters.GetByIdDB(id));
        }

        public bool AddPurchaseCenter(PurchaseCenterDTO purchaseCenterObj)
        {
            var purchaseCenter = _repositoryManager.PurchaseCenters.GetByIdDB((int)purchaseCenterObj.NumPurchaseCenter);
            if (purchaseCenter ==null && purchaseCenterObj.Email.IsEmailValid() )
            {
                var purchaseCenterEntity = _mapper.Map<PurchaseCenterEntity>(purchaseCenterObj);
                _repositoryManager.PurchaseCenters.AddDB(purchaseCenterEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdatePurchaseCenter(uint numPurchaseCenter, PurchaseCenterDTO purchaseCenterObj)
        {
            var purchaseCenter = _repositoryManager.PurchaseCenters.GetByIdDB((int)numPurchaseCenter);
            if (purchaseCenter != null)
            {
                var purchaseCenterEntity = _mapper.Map<PurchaseCenterEntity>(purchaseCenterObj);
                _repositoryManager.PurchaseCenters.UpdateDB((int)numPurchaseCenter, purchaseCenterEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeletePurchaseCentere(uint numPurchaseCenter)
        {
            PurchaseCenterEntity? purchaseCenter = _repositoryManager.PurchaseCenters.GetByIdDB((int)numPurchaseCenter);
            if (purchaseCenter != null)
            {
                _repositoryManager.PurchaseCenters.DeleteDB((int)numPurchaseCenter);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}
