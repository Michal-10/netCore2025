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
    public class CustomerRepository : RepositoryGeneric<CustomerEntity>, IRepositoryCustomer
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        //public List<CustomerEntity> GetAllDB()
        //{
        //    return _dataContext.CustomersList.ToList();
        //}

        public bool UpdateDB(int idCustomer, CustomerEntity customerEntity)
        {
            //try
            //{
            CustomerEntity customer = GetByIdDB(idCustomer);

            if (customerEntity.Tz != null && !string.IsNullOrEmpty(customerEntity.Tz))
                customer.Tz = customerEntity.Tz;

            if (customerEntity.FirstName != null && !string.IsNullOrEmpty(customerEntity.FirstName))
                customer.FirstName = customerEntity.FirstName;

            if (customerEntity.LastName != null && !string.IsNullOrEmpty(customerEntity.LastName))
                customer.LastName = customerEntity.LastName;

            if (!string.IsNullOrEmpty(customerEntity.Phone))
                customer.Phone = customerEntity.Phone;

            if (customerEntity.Email != null && !string.IsNullOrEmpty(customerEntity.Email))
                customer.Email = customerEntity.Email;

            if (DateTime.Compare(customerEntity.DateOfBirth, DateTime.Now) != 0)
                customer.DateOfBirth = customerEntity.DateOfBirth;

            if (customerEntity.DateOfJoin != null && DateTime.Compare(customerEntity.DateOfJoin, DateTime.Now) != 0)
                customer.DateOfJoin = customerEntity.DateOfJoin;
 
            return true;
        }
    }
}
