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
            return _dataContext.CustomersList.ToList();
        }
        public CustomerEntity GetByIdDB(int id)
        {
            return _dataContext.CustomersList.Where(b => b.Id == id).FirstOrDefault();
        }
        public int IsExist(uint idCustomer)
        {
            return _dataContext.CustomersList.ToList().FindIndex(c => c.Id == idCustomer);

        }
        
        public bool AddDB(CustomerEntity customerEntity)
        {
            try
            {
                 _dataContext.CustomersList.Add(customerEntity);
                 _dataContext.SaveChanges();
                 return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int idCustomerIndex, CustomerEntity customerEntity)
        {
            try
            {
                //int index = IsExist(numCustomerIndex);
                if (customerEntity.Id != 0)
                     _dataContext.CustomersList.ToList()[idCustomerIndex].Id = customerEntity.Id;

                if (!string.IsNullOrEmpty(customerEntity.Tz))
                     _dataContext.CustomersList.ToList()[idCustomerIndex].Tz = customerEntity.Tz;

                if (!string.IsNullOrEmpty(customerEntity.FirstName))
                     _dataContext.CustomersList.ToList()[idCustomerIndex].FirstName = customerEntity.FirstName;

                if (!string.IsNullOrEmpty(customerEntity.LastName))
                     _dataContext.CustomersList.ToList()[idCustomerIndex].LastName = customerEntity.LastName;

                if (!string.IsNullOrEmpty(customerEntity.Phone))
                     _dataContext.CustomersList.ToList()[idCustomerIndex].Phone = customerEntity.Phone;

                if (!string.IsNullOrEmpty(customerEntity.Email))
                     _dataContext.CustomersList.ToList()[idCustomerIndex].Email = customerEntity.Email;

                if (DateTime.Compare(customerEntity.DateOfBirth, DateTime.Now) != 0)
                     _dataContext.CustomersList.ToList()[idCustomerIndex].DateOfBirth = customerEntity.DateOfBirth;

                if (DateTime.Compare(customerEntity.DateOfJoin, DateTime.Now) != 0)
                     _dataContext.CustomersList.ToList()[idCustomerIndex].DateOfJoin = customerEntity.DateOfJoin;

                _dataContext.SaveChanges(); 
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int idCustomerIndexDelete)
        {
            try
            {
                //CustomerEntity customer = _dataContext.CustomersList.ToList().Find(b => b.IdCustomer == idCustomer);
                //_dataContext.CustomersList.Remove(customer);
                _dataContext.CustomersList.Remove(_dataContext.CustomersList.ToList()[idCustomerIndexDelete]);
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
