using Microsoft.AspNetCore.Mvc;
using static ClubCardsProject.Entities.BuyingEntity;
using System.Linq;
using ClubCardsProject.Entities;

namespace ClubCardsProject.Services
{
    public class BuyingService
    {
       static List<BuyingEntity> _buyings;

        public List<BuyingEntity> GetBuyings()
        {
            if (_buyings == null)
                return null;
            return _buyings;
        }

        public BuyingEntity GetBuyingById(int id)
        {
            if (_buyings == null || (_buyings.FindIndex(b=>b.Id==id))==-1)
                return null;
            return _buyings.Find(buying => buying.Id == id);
        }

        public bool PostBuying(BuyingEntity buying)
        {
            if (_buyings == null)
                _buyings = new List<BuyingEntity>();
            if (_buyings.Find(b=>b.Id==buying.Id)!=null)
                return false;
            _buyings.Add(buying);
            return true;
        }

        public bool PutBuying(int id, BuyingEntity buying)
        {
            if (_buyings == null || (_buyings.FindIndex(b => b.Id == id) == -1))
                return false;
            int index = _buyings.FindIndex(buying => buying.Id == id);
            _buyings[index] = buying;
            return true;
        }

        public bool DeleteBuying(int id)
        {
            if (_buyings == null || (_buyings.FindIndex(b => b.Id == id)) == -1)
                return false;
            _buyings.Remove(_buyings.Find(store => store.Id == id));
            return true;
        }

        
    }
}
