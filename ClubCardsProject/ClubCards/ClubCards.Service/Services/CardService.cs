using ClubCards.Core.Services;
using ClubCards.Data;
using ClubCardsProject.Entities;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class CardService:ICardService
    {
        private IRepository<CardEntity> _cardService;
        public CardService(IRepository<CardEntity> cardService)
        {
            _cardService = cardService;
        }

        public List<CardEntity> GetCards()
        {
            return _cardService.GetAllDB();
        }

        public CardEntity GetCardByID(int id)
        {
            var data = _cardService.GetAllDB();
            if (data == null || (data.FindIndex(c => c.Id == id) == -1))
                return null;
            return _cardService.GetByIdDB(id);
        }

        public bool AddCard(CardEntity card)
        {
            var data = _cardService.GetAllDB();
            if (data == null || (data.Find(b => b.Id == card.Id) != null))//אם ה id כבר קיים במערכת
                return false;
            return _cardService.AddDB(card);
        }


        public bool UpdateCard(int id, CardEntity card)
        {
            var data = _cardService.GetAllDB();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            return _cardService.UpdateDB(id, card);
        }

        public bool DeleteCard(int id)
        {
            var data= _cardService.GetAllDB();
            if (data == null || (data.Find(c => c.Id == id) == null))
                return false;
            return _cardService.DeleteDB(id);   
        }
    }
}
