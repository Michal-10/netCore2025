using AutoMapper;
using ClubCards.Core.DTOs;
using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
//using ClubCards.Data;
using ClubCardsProject.Entities;

namespace ClubCardsProject.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;

        public CustomerService( IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            var customers = _repositoryManager.Customers.GetDB();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _mapper.Map<CustomerDTO>(_repositoryManager.Customers.GetByIdDB(id));
        }

        public bool AddCustomer(CustomerDTO customerObj)
        {
            var customer = _repositoryManager.Customers.GetByIdDB((int)customerObj.Id);
            
            if (customer == null && customerObj.Email.IsEmailValid() && customerObj.Tz.IsTzValid())
            {
                var customerEntity = _mapper.Map<CustomerEntity>(customer);
                _repositoryManager.Customers.AddDB(customerEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool UpdateCustomer(uint idCustomer, CustomerDTO customerObj)
        {
            var customer = _repositoryManager.Customers.GetByIdDB((int)idCustomer);
            if (customer != null)
            {
                var customerEntity = _mapper.Map<CustomerEntity>(customerObj);
                _repositoryManager.Customers.UpdateDB((int)idCustomer, customerEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(uint idCustomer)
        {
            CustomerEntity customer = _repositoryManager.Customers.GetByIdDB((int)idCustomer);
            if (customer != null)
            {
                _repositoryManager.Customers.DeleteDB((int)idCustomer);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}

