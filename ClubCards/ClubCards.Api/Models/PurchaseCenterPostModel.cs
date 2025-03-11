using System.ComponentModel.DataAnnotations;

namespace ClubCards.Api.Models
{
    public class PurchaseCenterPostModel
    {
        public uint NumPurchaseCenter { get; set; }//מספר מוקד
        public string NamePurchasePoint { get; set; }//שם מוקד רכישה
        public string Address { get; set; }
        public string City { get; set; }

        [StringLength(10, MinimumLength = 8)]
        public string Phone { get; set; }
        public string? Email { get; set; }
        public int Quantity { get; set; }
    }
}
