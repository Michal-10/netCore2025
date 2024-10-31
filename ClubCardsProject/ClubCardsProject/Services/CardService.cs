using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class CardService
    {
        static List<CardEntity> _cards;

        public List<CardEntity> GetCards()
        {
            if (_cards == null)
                return null;
            return _cards;
        }

        public CardEntity GetCardByID(int id)
        {
            if (_cards == null || (_cards.FindIndex(c=>c.Id==id)==-1))
                return null;
            return _cards.Find(card => card.Id == id);
        }

        public bool PostCard(CardEntity card)
        {
            if (_cards == null)
                _cards = new List<CardEntity>();
            if (_cards.Find(c => c.Id == card.Id) != null)
                return false;
            _cards.Add(card);
            return true;
        }


      

        public bool PutCard(int id, CardEntity card)
        {
            if (_cards == null || (_cards.Find(c => c.Id == id) == null))
                return false;
            int index = _cards.FindIndex(c => c.Id == id);
            _cards[index] = card;
            return true;
        }

        public bool DeleteCard(int id)
        {
            if (_cards == null || (_cards.FindIndex(c => c.Id == id) == -1))
                return false;
            _cards.Remove(_cards.Find(card => card.Id == id));
            return true;
        }
    }
}
