using ClubCards.Core.DTOs;
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
        public IEnumerable<CustomerDTO> GetCustomers();
        public CustomerDTO GetCustomerById(int id);
        public bool AddCustomer(CustomerEntity customer);
        public bool UpdateCustomer(uint id, CustomerEntity customer);
        public bool DeleteCustomer(uint id);

    }
}
