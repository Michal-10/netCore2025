using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCards.Api.Models
{
    public class CardPostModel
    {
        public uint NumCard { get; set; }// מספר כרטיס
        public int CustomerId { get; set; }//מזהה לקוח
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public int PurchaseCenterId { get; set; } //מוקד רכישה
        [Precision(18, 4)]
        public decimal Sum { get; set; }// סכום
    }
}
