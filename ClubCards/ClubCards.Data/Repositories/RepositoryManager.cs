using ClubCards.Core.Repositories;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly DataContext _context;
        public IRepositoryGeneric<BuyingEntity> Buyings { get; }

        public IRepositoryGeneric<CardEntity> Cards { get; }

        public IRepositoryGeneric<CustomerEntity> Customers { get; }

        public IRepositoryGeneric<PurchaseCenterEntity> PurchaseCenters { get; }

        public IRepositoryGeneric<StoreEntity> Stores { get; }

        public RepositoryManager(DataContext context, IRepositoryGeneric<BuyingEntity> buyings, IRepositoryGeneric<CardEntity> cards, IRepositoryGeneric<CustomerEntity> customers, IRepositoryGeneric<PurchaseCenterEntity> purchaseCenters, IRepositoryGeneric<StoreEntity> stores)
        {
            _context = context;
            Buyings = buyings;
            Cards = cards;
            Customers = customers;
            PurchaseCenters = purchaseCenters;
            Stores = stores;
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
