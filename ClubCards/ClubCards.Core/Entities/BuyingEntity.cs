using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCardsProject.Entities
{
    public enum PaymentMethodTypes { CASH=1, CREDIT_CARD, CHECK }
        
    public class BuyingEntity
    {
        //יחודי לפי מספר הזמנה

        [Key]
        public int Id { get; set; }
        [Required]
        public uint NumBuying { get; set; }//מספר קניה
       
        public int CardId { get; set; }
        public CardEntity Card { get; set; }
        public int StoreId { get;set; }
        //[ForeignKey(nameof(IdStore))]
        public StoreEntity Store { get; set; }

        public DateTime Date { get; set; }

        [Precision(18, 4)]
        public decimal Sum { get; set; }

        public int PaymentMethod { get; set; }

        }
    }

