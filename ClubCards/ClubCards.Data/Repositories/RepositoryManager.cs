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
        public IRepositoryBuying Buyings { get; }

        public IRepositoryCard Cards { get; }

        public IRepositoryCustomer Customers { get; }

        public IRepositoryPurchaseCenter PurchaseCenters { get; }

        public IRepositoryStore Stores { get; }
        public RepositoryManager(DataContext context, IRepositoryBuying buyings, IRepositoryCard cards, IRepositoryCustomer customers, IRepositoryPurchaseCenter purchaseCenters, IRepositoryStore stores)
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
