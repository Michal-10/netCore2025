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
            int index = _cardService.IsExist(card.NumCard);
            if (index == -1)
            {
                return _cardService.AddDB(card);
            }
            return false;
        }


        public bool UpdateCard(uint numCard, CardEntity card)
        {
            int index = _cardService.IsExist(numCard);
            if (index != -1)
            {
                return _cardService.UpdateDB(index, card);
            }
            return false;
        }

        public bool DeleteCard(uint numCard)
        {  
            int index= _cardService.IsExist(numCard);
            if (index != -1)
            {
                return _cardService.DeleteDB(index);
            }
            return false;
        }
    }
}

