using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class CardService:ICardService
    {
        private IRepositoryCard _cardRepository;
        private IRepositoryManager _repositoryManager;
        public CardService(IRepositoryCard cardRepository, IRepositoryManager repositoryManager)
        {
            _cardRepository = cardRepository;
            _repositoryManager = repositoryManager;
        }

        public List<CardEntity> GetCards()
        {
            return _cardRepository.GetAllDB();
        }

        public CardEntity GetCardByID(int id)
        {
            //var data = _cardService.GetAllDB();
            //if (data == null || (data.FindIndex(c => c.Id == id) == -1))
            //    return null;
            return _cardRepository.GetByIdDB(id);
        }

        public bool AddCard(CardEntity cardObj)
        {
            CardEntity card = _cardRepository.GetByIdDB((int)cardObj.NumCard);
            if (card == null)
            {
                _cardRepository.AddDB(cardObj);
                _repositoryManager.save();
                return true;
            }
            return false;
        }


        public bool UpdateCard(uint numCard, CardEntity cardObj)
        {
            CardEntity card = _cardRepository.GetByIdDB((int)numCard);
            if (card != null)
            {
                _cardRepository.UpdateDB((int)numCard, cardObj);
                _repositoryManager.save() ;
                return true;
            }
            return false;
        }

        public bool DeleteCard(uint numCard)
        {  
            CardEntity card= _cardRepository.GetByIdDB((int)numCard);
            if (card !=null)
            {
                _cardRepository.DeleteDB((int)numCard);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}

