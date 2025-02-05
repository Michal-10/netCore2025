using ClubCardsProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.DTOs
{
    public class PurchaseCenterDTO
    {
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
    }
}
