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
        public List<CardEntity> GetCards();
        public CardEntity GetCardByID(int id);
        public bool AddCard(CardEntity card);
        public bool UpdateCard(int id, CardEntity card);
        public bool DeleteCard(int id);

    }
}
