using ClubCards.Core.DTOs;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Services
{
    public interface ICardService
    {
        public IEnumerable<CardDTO> GetCards();
        public CardDTO GetCardByID(int id);
        public bool AddCard(CardDTO card);
        public bool UpdateCard(uint id, CardDTO card);
        public bool DeleteCard(uint id);

    }
}
