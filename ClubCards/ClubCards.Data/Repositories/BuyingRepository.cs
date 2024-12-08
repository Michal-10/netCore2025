using ClubCards.Core.Services;
using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClubCards.Data.Repositories
{
    public class BuyingRepository: IRepository<BuyingEntity>
    {
        private readonly DataContext _dataContext;
        public BuyingRepository(DataContext dataContext)
        {
            _dataContext = dataContext ;
        }
        public  List<BuyingEntity> GetAllDB()
        {
            return _dataContext.BuyingsList.ToList();
        }
        public BuyingEntity GetByIdDB(int id)
        {
            return _dataContext.BuyingsList.Where(b => b.Id == id).FirstOrDefault();
        }
        public int IsExist(uint numBuying)
        {
            return _dataContext.BuyingsList.ToList().FindIndex(b => b.NumBuying == numBuying);
        }

        public bool AddDB(BuyingEntity buyingEntity)
        {
            try
            {
                 _dataContext.BuyingsList.Add(buyingEntity);
                 _dataContext.SaveChanges();
                 return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateDB(int numBuyingIndex, BuyingEntity buyingEntity)
        {
            try
            {
                //int index = IsExist(numBuying);
                    //בעיקרון אי אפשר לשנות ID
                if (buyingEntity.Id != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].Id = buyingEntity.Id;

                if (buyingEntity.NumBuying != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].NumBuying = buyingEntity.NumBuying;

                if (buyingEntity.IdCustomer != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].IdCustomer = buyingEntity.IdCustomer;

                if (buyingEntity.IdCard != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].IdCard = buyingEntity.IdCard;

                if (buyingEntity.IdPurchaseCenter != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].IdPurchaseCenter = buyingEntity.IdPurchaseCenter;

                if (DateTime.Compare(buyingEntity.Date, DateTime.Now) != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].Date = buyingEntity.Date;

                if (buyingEntity.Sum != 0)
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].Sum = buyingEntity.Sum;

                if (!string.IsNullOrEmpty(buyingEntity.PaymentMethod))
                     _dataContext.BuyingsList.ToList()[numBuyingIndex].PaymentMethod = buyingEntity.PaymentMethod;

                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDB(int numBuyingIndexDelete)
        {
            try
            {
                // BuyingEntity buying = _dataContext.BuyingsList.ToList().Find(b => b.NumBuying == numBuying);
                // _dataContext.BuyingsList.Remove(buying);
                _dataContext.BuyingsList.Remove(_dataContext.BuyingsList.ToList()[numBuyingIndexDelete]);
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
