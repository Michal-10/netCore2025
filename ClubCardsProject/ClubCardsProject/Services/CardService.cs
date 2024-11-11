using ClubCardsProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class CardService
    {
        //static List<CardEntity> _cards;

        public List<CardEntity> GetCards()
        {
            if (DataContextManager.Data.CardsList == null)
                return null;
            //return _cards;
            return DataContextManager.Data.CardsList;
        }

        public CardEntity GetCardByID(int id)
        {
            //if (_cards == null || (_cards.FindIndex(c=>c.Id==id)==-1))
            //    return null;
            //return _cards.Find(card => card.Id == id);
            if (DataContextManager.Data.CardsList == null || (DataContextManager.Data.CardsList.FindIndex(c => c.Id == id) == -1))
                return null;
            return DataContextManager.Data.CardsList.Find(card => card.Id == id);
        }

        public bool AddCard(CardEntity card)
        {
            //if (_cards == null)
            //    _cards = new List<CardEntity>();
            //else if (_cards.Find(c => c.Id == card.Id) != null)//אם ה id כבר קיים במערכת
            //     return false;
            //_cards.Add(card);
            //return true;
            if (DataContextManager.Data.CardsList == null)
                DataContextManager.Data.CardsList = new List<CardEntity>();
            else if (DataContextManager.Data.CardsList.Find(c => c.Id == card.Id) != null)//אם ה id כבר קיים במערכת
                return false;
            DataContextManager.Data.CardsList.Add(card);
            return true;
        }


        public bool UpdateCard(int id, CardEntity card)
        {
            //if (_cards == null || (_cards.Find(c => c.Id == id) == null))
            //    return false;
            //int index = _cards.FindIndex(c => c.Id == id);
            //_cards[index] = card;
            //return true;
            if (DataContextManager.Data.CardsList == null || (DataContextManager.Data.CardsList.Find(c => c.Id == id) == null))
                return false;
            int index = DataContextManager.Data.CardsList.FindIndex(c => c.Id == id);
            DataContextManager.Data.CardsList[index] = card;
            return true;
        }

        public bool DeleteCard(int id)
        {
            //if (_cards == null || (_cards.FindIndex(c => c.Id == id) == -1))
            //    return false;
            //_cards.Remove(_cards.Find(card => card.Id == id));
            //return true;
            if (DataContextManager.Data.CardsList == null || (DataContextManager.Data.CardsList.FindIndex(c => c.Id == id) == -1))
                return false;
            DataContextManager.Data.CardsList.Remove(DataContextManager.Data.CardsList.Find(card => card.Id == id));
            return true;
        }
    }
}
