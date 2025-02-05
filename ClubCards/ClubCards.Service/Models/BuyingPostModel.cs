using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClubCards.Api.Models
{
    public class BuyingPostModel
    {
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
