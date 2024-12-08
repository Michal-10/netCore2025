using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClubCardsProject.Entities
{
    public class CardEntity
    {
        //מזהה לפי מספר כרטיס

        [Key]
        public int Id { get; set; }
        [Required]
        //public uint Id { get; set; }
        public uint NumCard { get; set; }// מספר כרטיס
        [Required]
        public uint IdCustomer { get; set; }//מזהה לקוח
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public string PurchaseCenter { get; set; } //מוקד רכישה
        [Precision(18, 4)]
        public decimal Sum { get; set; }// סכום
        

        public CardEntity() { }

        public CardEntity(int id, uint numCard, DateTime dateOfPurchase, DateTime cardValidity, string purchaseCenter, decimal sum, uint idCustomer)
        {
            Id= id; 
            NumCard = numCard;
            DateOfPurchase = dateOfPurchase;
            CardValidity = cardValidity;
            PurchaseCenter = purchaseCenter;
            Sum = sum;
            IdCustomer = idCustomer;
        }
    }
}
