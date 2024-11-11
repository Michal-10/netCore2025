using Microsoft.AspNetCore.Mvc;
using static ClubCardsProject.Entities.BuyingEntity;
using System.Linq;
using ClubCardsProject.Entities;

namespace ClubCardsProject.Services
{
    public class BuyingService
    {
        //static List<BuyingEntity> _buyings;
        //static DataContext _buyings;
        //DataContextManager  _buyings;
        public List<BuyingEntity> GetBuyings()
        {
            if (DataContextManager.Data.BuyingsList == null)
            //if (_buyings == null)
                return null;
            //return _buyings.BuyingsList;
            return DataContextManager.Data.BuyingsList;
        }

        public BuyingEntity GetBuyingById(int id)
        {
            //if (_buyings == null || (_buyings.BuyingsList.FindIndex(b=>b.Id==id))==-1)
            //    return null;
            //return _buyings.BuyingsList.Find(buying => buying.Id == id);
            if (DataContextManager.Data.BuyingsList == null || (DataContextManager.Data.BuyingsList.FindIndex(b => b.Id == id)) == -1)
                return null;
            return DataContextManager.Data.BuyingsList.Find(buying => buying.Id == id);

        }

        public bool AddBuying(BuyingEntity buying)
        {
            //if (_buyings == null)
            ////if (_buyings.BuyingsList == null)
            //    //_buyings.BuyingsList = new List<BuyingEntity>();
            //    _buyings=new DataContext();
            //else if (_buyings.BuyingsList.Find(b=>b.Id==buying.Id)!=null)//אם ה id כבר קיים במערכת
            //     return false;
            //_buyings.BuyingsList.Add(buying);
            //return true;
            if (DataContextManager.Data.BuyingsList == null)
                DataContextManager.Data.BuyingsList = new List<BuyingEntity>();
            else if (DataContextManager.Data.BuyingsList.Find(b => b.Id == buying.Id) != null)//אם ה id כבר קיים במערכת
                return false;
            DataContextManager.Data.BuyingsList.Add(buying);
            return true;
        }

        public bool UpdateBuying(int id, BuyingEntity buying)
        {
            //if (_buyings.BuyingsList == null || (_buyings.BuyingsList.FindIndex(b => b.Id == id) == -1))
            //    return false;
            //int index = _buyings.BuyingsList.FindIndex(buying => buying.Id == id);
            //_buyings.BuyingsList[index] = buying;
            //return true;
            if (DataContextManager.Data.BuyingsList == null || (DataContextManager.Data.BuyingsList.FindIndex(b => b.Id == id) == -1))
                return false;
            int index = DataContextManager.Data.BuyingsList.FindIndex(buying => buying.Id == id);
            DataContextManager.Data.BuyingsList[index] = buying;
            return true;
        }

        public bool DeleteBuying(int id)
        {
            //if (_buyings.BuyingsList == null || (_buyings.BuyingsList.FindIndex(b => b.Id == id)) == -1)
            //    return false;
            //_buyings.BuyingsList.Remove(_buyings.BuyingsList.Find(store => store.Id == id));
            //return true;
            if (DataContextManager.Data.BuyingsList == null || (DataContextManager.Data.BuyingsList.FindIndex(b => b.Id == id)) == -1)
                return false;
            DataContextManager.Data.BuyingsList.Remove(DataContextManager.Data.BuyingsList.Find(store => store.Id == id));
            return true;
        }

        
    }
}
