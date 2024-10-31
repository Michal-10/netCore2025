using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClubCardsProject.Services
{
    public class CustomerService
    {
        static List<CustomerEntity> _customers;

        public List<CustomerEntity> GetCustomers()
        {
            if (_customers == null)
                return null;
            return _customers;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            if (_customers == null || (_customers.FindIndex(c=>c.Id==id)==-1))
                return null;
            return _customers.Find(c => c.Id == id);
        }
        public bool PostCustomer(CustomerEntity customer)
        {
            if (_customers == null)
                _customers = new List<CustomerEntity>();
            if (_customers.Find(b => b.Id == customer.Id) != null)
                return false;
            _customers.Add(customer);
            return true;
        }

        public bool PutCustomer(int id, CustomerEntity customer)
        {
            if (_customers == null || (_customers.Find(c => c.Id == id) == null))
                return false;
            int index = _customers.FindIndex(c => c.Id == id);
            _customers[index] = customer;
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            if (_customers == null || (_customers.Find(c => c.Id == id) == null))
                return false;
            _customers.Remove(_customers.Find(c => c.Id == id));
            return true;
        }
    }
}
