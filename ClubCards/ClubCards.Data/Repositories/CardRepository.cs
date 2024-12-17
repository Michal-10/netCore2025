using ClubCards.Core.Repositories;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class CardRepository : RepositoryGeneric<CardEntity>, IRepositoryCard
    {
        public CardRepository(DataContext context) : base(context)
        {
        }

        override public List<CardEntity> GetAllDB()
        {
            return _dbSet.ToList();//.Include(c=>c.PurchaseCenterId).Include(c=>c.CustomerId).ToList();
        }

        public bool UpdateDB(int numCard, CardEntity cardEntity)
        {
            CardEntity card = GetByIdDB(numCard);

            if (cardEntity.CustomerId > 0 && _dbSet.Find(cardEntity.CustomerId) != null)
                card.CustomerId = cardEntity.CustomerId;

            if (cardEntity.PurchaseCenterId > 0 && _dbSet.Find(cardEntity.PurchaseCenterId) != null)
                card.PurchaseCenterId = cardEntity.PurchaseCenterId;

            if (cardEntity.NumCard != card.NumCard)
                card.NumCard = cardEntity.NumCard;

            if (cardEntity.CustomerId != card.CustomerId)
                card.CustomerId = cardEntity.CustomerId;

            if (DateTime.Compare(cardEntity.DateOfPurchase, DateTime.Now) != 0)
                card.DateOfPurchase = cardEntity.DateOfPurchase;

            if (DateTime.Compare(cardEntity.CardValidity, DateTime.Now) != 0)
                card.CardValidity = cardEntity.CardValidity;

            if (cardEntity.PurchaseCenterId != card.PurchaseCenterId)
                card.PurchaseCenterId = cardEntity.PurchaseCenterId;

            if (cardEntity.Sum != 0 && cardEntity.Sum != card.Sum)
                card.Sum = cardEntity.Sum;

            return true;
        }

    }
}
