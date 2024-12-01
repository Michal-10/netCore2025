using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class CustomerRepository : IRepository<CustomerEntity>
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<CustomerEntity> GetAllDB()
        {
            return _dataContext.CustomersList;
        }
        public CustomerEntity GetByIdDB(int id)
        {
            return _dataContext.CustomersList.Where(b => b.Id == id).FirstOrDefault();
        }
        public bool AddDB(CustomerEntity CustomerEntity)
        {
            try
            {
                _dataContext.CustomersList.Add(CustomerEntity);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int id, CustomerEntity CustomerEntity)
        {
            try
            {
                int index = _dataContext.CustomersList.FindIndex(b => b.Id == id);
                _dataContext.CustomersList[index] = CustomerEntity;
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
                CustomerEntity customer = _dataContext.CustomersList.Find(b => b.Id == id);
                _dataContext.CustomersList.Remove(customer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
