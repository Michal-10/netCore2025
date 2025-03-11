using ClubCards.Core.DTOs;
using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Services
{
    public interface IBuyingService
    {
        public IEnumerable<BuyingDTO> GetBuyings();
        public BuyingDTO GetBuyingById(int id);
        public bool AddBuying(BuyingDTO buying);
        public bool UpdateBuying(uint id, BuyingDTO buying);
        public bool DeleteBuying(uint id);
    }
}
