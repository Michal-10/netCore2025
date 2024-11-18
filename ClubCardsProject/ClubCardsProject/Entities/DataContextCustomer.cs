using ClubCardsProject.Controllers;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Text.Json;

namespace ClubCardsProject.Entities
{
    public class DataContextCustomer : IDataContextCustomer
    {
        //List<CustomerEntity> _customerEntities;

        //public DataContextCustomer()
        //{
        //    using (var reader = new StreamReader("data.csv")) 
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        _customerEntities = csv.GetRecords<CardEntity>().ToList();
        //    }
        //}

        public List<CustomerEntity> LoadData()
        {
            //try
            //{
            //    string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.csv");
            //    string jsonString = File.ReadAllText(path);
            //    var AllCoins = JsonSerializer.Deserialize<List<CustomerEntity>>(jsonString);// typeof(DataCoins)); ;
            //    if (AllCoins == null) { return null; }

            //    return AllCoins;
            //}
            //catch
            //{
            //    return null;
            //}
           
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                string jsonString = File.ReadAllText(path);
                var AllCustomer = JsonSerializer.Deserialize<List<CustomerEntity>>(jsonString);// typeof(CustomerEntity)); ;
                if (AllCustomer == null) { return null; }
                return AllCustomer;
            }
            catch
            {
                return null;
            }
        }

        public bool SaveData(List<CustomerEntity> data)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");
                string jsonString = JsonSerializer.Serialize<List<CustomerEntity>>(data);
                File. WriteAllText(path,jsonString);
                return true;
            }
            catch { return false; }
        }

        
    }
}
