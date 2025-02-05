using ClubCardsProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.DTOs
{
    public class CardDTO
    {
        public int Id { get; set; }
        [Required]
        public uint NumCard { get; set; }// מספר כרטיס

        public int CustomerId { get; set; }//מזהה לקוח

        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public int PurchaseCenterId { get; set; } //מוקד רכישה

        [Precision(18, 4)]
        public decimal Sum { get; set; }// סכום

    }
}
