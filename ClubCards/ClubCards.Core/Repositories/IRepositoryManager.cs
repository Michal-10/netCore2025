
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Repositories
{
    public interface IRepositoryManager
    {
        IRepositoryGeneric<BuyingEntity> Buyings { get; }
        IRepositoryGeneric<CardEntity> Cards { get; }
        IRepositoryGeneric<CustomerEntity> Customers { get; }
        IRepositoryGeneric<PurchaseCenterEntity> PurchaseCenters { get; }
        IRepositoryGeneric<StoreEntity> Stores { get; }
        void save();
    }
}
