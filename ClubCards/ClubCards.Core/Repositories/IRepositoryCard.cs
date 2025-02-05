using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Repositories
{
    public interface IRepositoryCard:IRepositoryGeneric<CardEntity>
    {
        public IEnumerable<CardEntity> GetAllDB();
        bool UpdateDB(int numCard, CardEntity cardEntity);
    }
}
