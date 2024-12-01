using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCardsProject.Entities;

namespace ClubCardsProject.Services
{
    public class CustomerService:ICustomerService
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
            if (data == null||(data.FindIndex(c=>c.Id==id)==-1))
                return null;
            return _customerService.GetByIdDB(id);
        }

        public bool AddCustomer(CustomerEntity customer)
        {
            var data = _customerService.GetAllDB();
            if (data == null||(data.Find(b => b.Id == customer.Id) != null))//אם ה id כבר קיים במערכת
                return false;
            if (!ValidationCheck.IsEmailValid(customer.Email) && !ValidationCheck.IsTzValid(customer.Tz))
                return false;
            return _customerService.AddDB(customer);

        }

        public bool UpdateCustomer(int id, CustomerEntity customer)
        {
            var data= _customerService.GetAllDB();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            return _customerService.UpdateDB(id, customer);
        }

        public bool DeleteCustomer(int id)
        {
            var data= _customerService.GetAllDB();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            return _customerService.DeleteDB(id);
        }

     
    }
}
