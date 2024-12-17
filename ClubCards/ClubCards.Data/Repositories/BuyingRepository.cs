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

        override public List<BuyingEntity> GetAllDB()
        {
            return _dbSet.ToList();//Include(b=>b.CardId).Include(b=>b.StoreId).ToList();
        }

        public bool UpdateDB(int numBuying, BuyingEntity buyingEntity)
        {
            BuyingEntity buying = GetByIdDB(numBuying);                 //int index = IsExist(numBuying);

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
