using AutoMapper;
using ClubCards.Core.DTOs;
using ClubCards.Core.Repositories;
using ClubCards.Core.Services;
using ClubCardsProject.Entities;
using System.Linq;

namespace ClubCardsProject.Services
{
    public class CardService:ICardService
    {
        private IRepositoryManager _repositoryManager;
        readonly IMapper _mapper;
        public CardService( IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<CardDTO> GetCards()
        {
            var cards = _repositoryManager.Cards.GetAllDB();
            return _mapper.Map<IEnumerable<CardDTO>>(cards);
        }

        public CardDTO? GetCardByID(int id)
        {
            return _mapper.Map<CardDTO>(_repositoryManager.Cards.GetByIdDB(id));
        }

        public bool AddCard(CardDTO cardObj)
        {
            var card = _repositoryManager.Cards.GetByIdDB((int)cardObj.NumCard);
            if (card == null)
            {
                var cardEntity  = _mapper.Map<CardEntity>(card);
                _repositoryManager.Cards.AddDB(cardEntity);
                _repositoryManager.save();
                return true;
            }
            return false;
        }


        public bool UpdateCard(uint numCard, CardDTO cardObj)
        {
            var card = _repositoryManager.Cards.GetByIdDB((int)numCard);
            if (card != null)
            {
                var cardEntity = _mapper.Map<CardEntity>(cardObj);
                _repositoryManager.Cards.UpdateDB((int)numCard, cardEntity);
                _repositoryManager.save() ;
                return true;
            }
            return false;
        }

        public bool DeleteCard(uint numCard)
        {  
            CardEntity? card = _repositoryManager.Cards.GetByIdDB((int)numCard);
            if (card !=null)
            {
                _repositoryManager.Cards.DeleteDB((int)numCard);
                _repositoryManager.save();
                return true;
            }
            return false;
        }
    }
}

