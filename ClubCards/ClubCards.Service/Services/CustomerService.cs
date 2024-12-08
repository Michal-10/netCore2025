using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCardsProject.Entities;

namespace ClubCardsProject.Services
{
    public class CustomerService : ICustomerService
    {
        readonly IRepository<CustomerEntity> _customerService;
        public CustomerService(IRepository<CustomerEntity> customerService)
        {
            _customerService = customerService;
        }

        public List<CustomerEntity> GetCustomers()
        {
            return _customerService.GetAllDB();
        }

        public CustomerEntity GetCustomerById(int id)
        {
            var data = _customerService.GetAllDB();
            if (data == null || (data.FindIndex(c => c.Id == id) == -1))
                return null;
            return _customerService.GetByIdDB(id);
        }

        public bool AddCustomer(CustomerEntity customer)
        {
            int index = _customerService.IsExist((uint)customer.Id);
            if (index == -1 && ValidationCheck.IsEmailValid(customer.Email) && ValidationCheck.IsTzValid(customer.Tz))
            {
                return _customerService.AddDB(customer);
            }
            return false;
        }

        public bool UpdateCustomer(uint idCustomer, CustomerEntity customer)
        {
            int index = _customerService.IsExist(idCustomer);
            if (index != -1)
            {
                return _customerService.UpdateDB(index, customer);
            }
            return false;
        }

        public bool DeleteCustomer(uint idCustomer)
        {
            int index = _customerService.IsExist(idCustomer);
            if ( index!= -1)
            {
                return _customerService.DeleteDB(index);
            }
            return false;
        }
    }
}

