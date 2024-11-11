using ClubCardsProject.Entities;


namespace ClubCardsProject.Services
{
    public class CustomerService
    {
        //static List<CustomerEntity> _customers;
        //static DataContext _customers;
        //ValidationCheckGeneric<CustomerEntity> valid;
        ValidationCheckGeneric valid;

        public List<CustomerEntity> GetCustomers()
        {
            //if (_customers==null)
            //{
            //    return null;
            //}
            //return _customers.CustomersList;
            if (DataContextManager.Data.CustomersList == null)
            {
                return null;
            }
            return DataContextManager.Data.CustomersList;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            //if (_customers == null || (_customers.CustomersList.FindIndex(c=>c.Id==id)==-1))
            //    return null;
            //return _customers.CustomersList.Find(c => c.Id == id);
            if (DataContextManager.Data.CustomersList == null || (DataContextManager.Data.CustomersList.FindIndex(c => c.Id == id) == -1))
                return null;
            return DataContextManager.Data.CustomersList.Find(c => c.Id == id);

        }

        public bool AddCustomer(CustomerEntity customer)
        {
            //if (_customers.CustomersList == null)
            //    //_customers = new List<CustomerEntity>();
            //    _customers= new DataContext();
            //else if (_customers.CustomersList.Find(b => b.Id == customer.Id) != null)//אם ה id כבר קיים במערכת
            //     return false;
            ////valid=new ValidationCheckGeneric<CustomerEntity>();
            //valid=new ValidationCheckGeneric();
            //if (!valid.IsEmailValid(customer.Email)&&!valid.IsTzValid(customer.Tz))
            //    return false;
            //_customers.CustomersList.Add(customer);
            //return true;
            if (DataContextManager.Data.CustomersList == null)
                //_customers = new List<CustomerEntity>();
                DataContextManager.Data.CustomersList = new List<CustomerEntity>();
            else if (DataContextManager.Data.CustomersList.Find(b => b.Id == customer.Id) != null)//אם ה id כבר קיים במערכת
                return false;
            //valid=new ValidationCheckGeneric<CustomerEntity>();
            valid = new ValidationCheckGeneric();
            if (!valid.IsEmailValid(customer.Email) && !valid.IsTzValid(customer.Tz))
                return false;
            DataContextManager.Data.CustomersList.Add(customer);
            return true;
        }

        public bool UpdateCustomer(int id, CustomerEntity customer)
        {
            //    if (_customers.CustomersList == null || (_customers.CustomersList.Find(c => c.Id == id) == null))
            //        return false;
            //    int index = _customers.CustomersList.FindIndex(c => c.Id == id);
            //    _customers.CustomersList[index] = customer;
            //    return true;
            if (DataContextManager.Data.CustomersList == null || (DataContextManager.Data.CustomersList.Find(c => c.Id == id) == null))
                return false;
            int index = DataContextManager.Data.CustomersList.FindIndex(c => c.Id == id);
            DataContextManager.Data.CustomersList[index] = customer;
            return true;

        }

        public bool DeleteCustomer(int id)
        {
            //    if (_customers == null || (_customers.CustomersList.Find(c => c.Id == id) == null))
            //        return false;
            //    _customers.CustomersList.Remove(_customers.CustomersList.Find(c => c.Id == id));
            //    return true;

            if (DataContextManager.Data.CustomersList == null || (DataContextManager.Data.CustomersList.Find(c => c.Id == id) == null))
                return false;
            DataContextManager.Data.CustomersList.Remove(DataContextManager.Data.CustomersList.Find(c => c.Id == id));
            return true;
        }
    }
}
