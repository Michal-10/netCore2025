using System.Text.Json;

namespace ClubCardsProject.Entities
{
    public class DataContextCustomerFake : IDataContextCustomer
    {
        //public List<CardEntity> Cards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<CustomerEntity> LoadData()
        {
            List<CustomerEntity> list = new List<CustomerEntity>();
            list.Add( new CustomerEntity(1, "215112608", "a", "b", "054", "d@g.c", new DateTime(10, 10, 10), new DateTime(11, 11, 11)));
            list.Add( new CustomerEntity(2, "215112608", "a", "b", "054", "d@g.c", new DateTime(20, 10, 20), new DateTime(22,10,22)));
            return list;
        }

        public bool SaveData(List<CustomerEntity> list) 
        {
            return true;
        }
    }
}
