using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class CardRepository : IRepository<CardEntity>
    {
        private readonly DataContext _dataContext;
        public CardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<CardEntity> GetAllDB()
        {
            return _dataContext.CardsList.ToList();
        }
        public CardEntity GetByIdDB(int id)
        {
            return _dataContext.CardsList.Where(b => b.Id == id).FirstOrDefault();
        }
        public int IsExist(uint numCard)
        {
            return _dataContext.CardsList.ToList().FindIndex(c => c.NumCard == numCard);
        }
        public bool AddDB(CardEntity cardEntity)
        {
            try
            {
                 _dataContext.CardsList.Add(cardEntity);
                 _dataContext.SaveChanges();
                 return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int numCardIndex, CardEntity cardEntity)
        {
            try
            {
                //int index = IsExist(numCard);
                    //בעיקרון אי אפשר לשנות ID
               if (cardEntity.Id != 0)
                   _dataContext.BuyingsList.ToList()[numCardIndex].Id = cardEntity.Id;

               if (cardEntity.NumCard != 0)
                   _dataContext.CardsList.ToList()[numCardIndex].NumCard = cardEntity.NumCard;

               if (cardEntity.IdCustomer != 0)
                   _dataContext.CardsList.ToList()[numCardIndex].IdCustomer = cardEntity.IdCustomer;

               if (DateTime.Compare(cardEntity.DateOfPurchase, DateTime.Now) != 0)
                   _dataContext.CardsList.ToList()[numCardIndex].DateOfPurchase = cardEntity.DateOfPurchase;

               if (DateTime.Compare(cardEntity.CardValidity, DateTime.Now) != 0)
                    _dataContext.CardsList.ToList()[numCardIndex].CardValidity = cardEntity.CardValidity;

               if (string.IsNullOrEmpty(cardEntity.PurchaseCenter))
                    _dataContext.CardsList.ToList()[numCardIndex].PurchaseCenter = cardEntity.PurchaseCenter;

               if (cardEntity.Sum != 0)
                    _dataContext.CardsList.ToList()[numCardIndex].Sum = cardEntity.Sum;

                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int numCardIndexDelete)
        {
            try
            {
               // CardEntity card = _dataContext.CardsList.ToList().Find(b => b.NumCard == numCard);
               // _dataContext.CardsList.Remove(card);
                _dataContext.CardsList.Remove(_dataContext.CardsList.ToList()[numCardIndexDelete]);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
