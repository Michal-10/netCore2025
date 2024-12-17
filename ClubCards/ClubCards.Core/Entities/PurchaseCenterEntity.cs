using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCardsProject.Entities
{
    public class PurchaseCenterEntity
    {
        //מזהה לפי מספר מוקד
        [Key]
        public int Id { get; set; }
        [Required]
        public uint NumPurchaseCenter { get; set; }//מספר מוקד
        public string NamePurchasePoint { get; set; }//שם מוקד רכישה
        public string Address { get; set; }
        public string City { get; set; }

        [StringLength(10, MinimumLength = 8)]
        public string Phone { get; set; }
        public string? Email { get; set; }
        public int Quantity { get; set; }
        public List<CardEntity> CardsList { get; set; }
    }
}
