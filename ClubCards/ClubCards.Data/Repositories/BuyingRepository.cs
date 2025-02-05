using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClubCards.Data.Repositories
{
    public class BuyingRepository : RepositoryGeneric<BuyingEntity>, IRepositoryBuying
    {
        public BuyingRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<BuyingEntity> GetAllDB()
        {
            return _dbSet.Include(c => c.Card).Include(b=>b.Store);
        }

        public bool UpdateDB(int numBuying, BuyingEntity buyingEntity)
        {
            BuyingEntity buying = GetByIdDB(numBuying);    

            if (buyingEntity.CardId >= 0 && _dbSet.Find(buyingEntity.CardId) != null)
                buying.CardId = buyingEntity.CardId;

            if (buyingEntity.StoreId >= 0 && _dbSet.Find(buyingEntity.StoreId) != null)
                buying.StoreId = buyingEntity.StoreId;

            if (buyingEntity.NumBuying != buying.NumBuying)
                buying.NumBuying = buyingEntity.NumBuying;

            if (DateTime.Compare(buyingEntity.Date, DateTime.Now) != 0)
                buying.Date = buyingEntity.Date;

            if (buyingEntity.Sum != 0 && buyingEntity.Sum != buying.Sum)
                buying.Sum = buyingEntity.Sum;

            if (buyingEntity.PaymentMethod != buying.PaymentMethod)
                buying.PaymentMethod = buyingEntity.PaymentMethod;

            return true;
        }

    }
}
