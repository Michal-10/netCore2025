using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCardsProject.Entities
{
    public class CardEntity
    {
        //מזהה לפי מספר כרטיס

        [Key]
        public int Id { get; set; }
        [Required]
        public uint NumCard { get; set; }// מספר כרטיס
        
        public int CustomerId { get; set; }//מזהה לקוח
        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }

        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public int PurchaseCenterId { get; set; } //מוקד רכישה
        //[ForeignKey(nameof(IdPurchaseCenter))]
        public PurchaseCenterEntity PurchaseCenter { get; set; }

        [Precision(18, 4)]
        public decimal Sum { get; set; }// סכום

        public List<BuyingEntity> Buyings { get; set; }
        
    }
}
