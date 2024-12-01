
using Newtonsoft.Json;

using ClubCardsProject.Entities;
using System.Text.Json;

namespace ClubCardsProject.Data
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
            //string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
            //string jsonString = File.ReadAllText(path);
            //DataContext data = JsonConvert.DeserializeObject<DataContext>(jsonString);

            string path = Path.Combine(AppContext.BaseDirectory,"Data", "data.json");
            string jsonString = File.ReadAllText(path);
            DataStructure? data = System.Text.Json.JsonSerializer.Deserialize<DataStructure>(jsonString);
            BuyingsList = data.BuyingsList;
            CardsList = data.CardsList;
            CustomersList = data.CustomersList;
            PurchaseCentersList = data.PurchaseCentersList;
            StoresList = data.StoresList;
        }
        public void SaveChange()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
            var data = new
            {
                BuyingsList = this.BuyingsList,
                CardsList = this.CardsList,
                CustomersList = this.CustomersList,
                PurchaseCentersList = this.PurchaseCentersList,
                StoresList = this.StoresList
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(path, jsonString);
        }
    }
    public class DataStructure
    {
        public List<BuyingEntity> BuyingsList { get; set; }
        public List<CardEntity> CardsList { get; set; }
        public List<CustomerEntity> CustomersList { get; set; }
        public List<PurchaseCenterEntity> PurchaseCentersList { get; set; }
        public List<StoreEntity> StoresList { get; set; }
    }
}
