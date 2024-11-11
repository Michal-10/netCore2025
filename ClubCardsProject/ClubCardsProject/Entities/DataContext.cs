namespace ClubCardsProject.Entities
{
    public class DataContext
    {
        public List<BuyingEntity> BuyingsList { get; set; }
        public List<CardEntity> CardsList { get; set; }
        public List<CustomerEntity> CustomersList { get; set; }
        public List<PurchaseCenterEntity> PurchaseCentersList { get; set; }
        public List<StoreEntity> StoresList { get; set; }

        public DataContext()
        {
            //BuyingsList = new  List<BuyingEntity>();
            //CardsList = new List<CardEntity>();
            CustomersList = new List<CustomerEntity>() { new CustomerEntity(1, "215112608", "a", "b", "054", "d@g.c", new DateTime(10, 10, 10), new DateTime(11, 11, 11)) };
            //PurchaseCentersList = new List<PurchaseCenterEntity>();
            //StoresList = new List<StoreEntity>();
        }

        //public DataContext(List<BuyingEntity> buyingsList, List<CardEntity> cardsList, List<CustomerEntity> customersList, List<PurchaseCenterEntity> purchaseCentersList, List<StoreEntity> storesList)
        //{
        //    BuyingsList = buyingsList;
        //    CardsList = cardsList;
        //    CustomersList = customersList;
        //    PurchaseCentersList = purchaseCentersList;
        //    StoresList = storesList;
        //}
    }
}
