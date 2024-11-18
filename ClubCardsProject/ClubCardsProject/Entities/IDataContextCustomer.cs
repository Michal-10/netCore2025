namespace ClubCardsProject.Entities
{
    public interface IDataContextCustomer
    {
        //public List<CardEntity> Cards { get; set; }
        //public List<CardEntity> LoadData();
        //public bool SaveData(List<CardEntity> path);

        public List<CustomerEntity> LoadData();
        public bool SaveData(List<CustomerEntity> path);
    }
}
