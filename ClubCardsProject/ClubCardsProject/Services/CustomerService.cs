using ClubCardsProject.Entities;


namespace ClubCardsProject.Services
{
    public class CustomerService
    {
        readonly IDataContextCustomer _customerService;
        public CustomerService(IDataContextCustomer customerService)
        {
            _customerService = customerService;
        }

        public List<CustomerEntity> GetCustomers()
        {
            var data=_customerService.LoadData();
            if (data==null)
                return null;
            //return data.Select(c => c.Id).ToList();
            return data;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            var data = _customerService.LoadData();
            if (data == null||(data.FindIndex(c=>c.Id==id)==-1))
                return null;
           return data.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool AddCustomer(CustomerEntity customer)
        {
            var data = _customerService.LoadData();
            if (data == null)
                return false;
            else  if (data.Find(b => b.Id == customer.Id) != null)//אם ה id כבר קיים במערכת
                return false;
            if (!ValidationCheckGeneric.IsEmailValid(customer.Email) && !ValidationCheckGeneric.IsTzValid(customer.Tz))
                return false;
            data.Add(customer);
            return _customerService.SaveData(data);
        }

        public bool UpdateCustomer(int id, CustomerEntity customer)
        {
            var data= _customerService.LoadData();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            int index = data.FindIndex(c => c.Id == id);
            data[index] = customer;
             _customerService.SaveData(data);
            return true;
        }

        public bool DeleteCustomer(int id)
        {
            var data= _customerService.LoadData();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            data.Remove(data.Find(c => c.Id == id));
            return  _customerService.SaveData(data);
        }

    }
}
