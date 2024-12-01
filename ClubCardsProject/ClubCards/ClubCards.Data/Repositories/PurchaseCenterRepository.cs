using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class PurchaseCenterRepository:IRepository<PurchaseCenterEntity>
    {
        private readonly DataContext _dataContext;
        public PurchaseCenterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<PurchaseCenterEntity> GetAllDB()
        {
            return _dataContext.PurchaseCentersList;
        }
        public PurchaseCenterEntity? GetByIdDB(int id)
        {
            return _dataContext.PurchaseCentersList.Where(b => b.Id == id).FirstOrDefault();
        }
        public bool AddDB(PurchaseCenterEntity purchaseCenterEntity)
        {
            try
            {
                _dataContext.PurchaseCentersList.Add(purchaseCenterEntity);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int id, PurchaseCenterEntity purchaseCenterEntity)
        {
            try
            {
                int index = _dataContext.PurchaseCentersList.FindIndex(b => b.Id == id);
                _dataContext.PurchaseCentersList[index] = purchaseCenterEntity;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int id)
        {
            try
            {
                PurchaseCenterEntity customer = _dataContext.PurchaseCentersList.Find(b => b.Id == id);
                _dataContext.PurchaseCentersList.Remove(customer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
