using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Services
{
    public interface ICustomerService
    {
        public List<CustomerEntity> GetCustomers();
        public CustomerEntity GetCustomerById(int id);
        public bool AddCustomer(CustomerEntity customer);
        public bool UpdateCustomer(uint id, CustomerEntity customer);
        public bool DeleteCustomer(uint id);

    }
}
