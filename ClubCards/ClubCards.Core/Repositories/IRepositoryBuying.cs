﻿using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.Repositories
{
    public interface  IRepositoryBuying:IRepositoryGeneric<BuyingEntity>
    {
        public IEnumerable<BuyingEntity> GetAllDB();
        bool UpdateDB(int numBuying, BuyingEntity buyingEntity);

    }
}
