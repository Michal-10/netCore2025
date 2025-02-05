using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.DTOs
{
    public class BuyingDTO
    {
        public int Id { get; set; }
        [Required]
        public uint NumBuying { get; set; }//מספר קניה

        public int CardId { get; set; }
        public int StoreId { get; set; }

        public DateTime Date { get; set; }

        [Precision(18, 4)]
        public decimal Sum { get; set; }

        public int PaymentMethod { get; set; }
    }
}
