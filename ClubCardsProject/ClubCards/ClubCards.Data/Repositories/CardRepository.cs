using ClubCardsProject.Data;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Data.Repositories
{
    public class CardRepository : IRepository<CardEntity>
    {
        private readonly DataContext _dataContext;
        public CardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<CardEntity> GetAllDB()
        {
            return _dataContext.CardsList;
        }
        public CardEntity GetByIdDB(int id)
        {
            return _dataContext.CardsList.Where(b => b.Id == id).FirstOrDefault();
        }
        public bool AddDB(CardEntity CardEntity)
        {
            try
            {
                _dataContext.CardsList.Add(CardEntity);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDB(int id, CardEntity cardEntity)
        {
            try
            {
                int index = _dataContext.CardsList.FindIndex(b => b.Id == id);
                _dataContext.CardsList[index] = cardEntity;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteDB(int id)
        {
            try
            {
                CardEntity card = _dataContext.CardsList.Find(b => b.Id == id);
                _dataContext.CardsList.Remove(card);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}
