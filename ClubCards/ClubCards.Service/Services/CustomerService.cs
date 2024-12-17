using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
//using ClubCards.Data;
using ClubCardsProject.Entities;

namespace ClubCardsProject.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepositoryCustomer _customerRepository;
        private IRepositoryManager _repositoryManager;
        public CustomerService(IRepositoryCustomer customerRepository, IRepositoryManager repositoryManager)
        {
            _customerRepository = customerRepository;
            _repositoryManager = repositoryManager;
        }

        public List<CustomerEntity> GetCustomers()
        {
            return _customerRepository.GetAllDB();
        }

        public CustomerEntity GetCustomerById(int id)
        {
            //var data = _customerService.GetAllDB();
            //if (data == null || (data.FindIndex(c => c.Id == id) == -1))
            //    return null;
            return _customerRepository.GetByIdDB(id);
        }

        public bool AddCustomer(CustomerEntity customerObj)
        {
            CustomerEntity customer = _customerRepository.GetByIdDB((int)customerObj.Id);
            
            if (customer == null && ValidationCheck.IsEmailValid(customerObj.Email) && ValidationCheck.IsTzValid(customerObj.Tz))
            {
                _customerRepository.AddDB(customerObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(uint idCustomer, CustomerEntity customerObj)
        {
            CustomerEntity customer = _customerRepository.GetByIdDB((int)idCustomer);
            if (customer != null)
            {
                _customerRepository.UpdateDB((int)idCustomer, customerObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(uint idCustomer)
        {
            CustomerEntity customer = _customerRepository.GetByIdDB((int)idCustomer);
            if (customer != null)
            {
                _customerRepository.DeleteDB((int)idCustomer);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}

