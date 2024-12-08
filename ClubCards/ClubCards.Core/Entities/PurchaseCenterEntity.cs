using System.ComponentModel.DataAnnotations;

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
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public PurchaseCenterEntity() { }

        public PurchaseCenterEntity(int id,uint numPurchaseCenter, string namePurchasePoint, string address, string city, string phone, string email, int quantity)
        {
            Id = id;
            NumPurchaseCenter = numPurchaseCenter;
            NamePurchasePoint = namePurchasePoint;
            Address = address;
            City = city;
            Phone = phone;
            Email = email;
            Quantity = quantity;
        }
    }
}
