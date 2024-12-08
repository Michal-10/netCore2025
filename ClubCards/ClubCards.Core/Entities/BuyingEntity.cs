using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubCardsProject.Entities
{
    //public  enum PaymentMethodTypes { CASH=1, CREDIT_CARD, CHECK }
        
    public class BuyingEntity
    {
        //יחודי לפי מספר הזמנה

        [Key]
        public int Id { get; set; }
        [Required]
        public uint NumBuying { get; set; }//מספר קניה
        [Required] 
        public uint IdCustomer { get; set; }
        [Required] 
        public uint IdCard { get; set; }
        [Required] 
        public uint IdPurchaseCenter { get; set; }
        public DateTime Date { get; set; }

        //[Column(TypeName = "decimal(18,4)")]
        [Precision(18, 4)]
        public decimal Sum { get; set; }

        //public PaymentMethodTypes PaymentMethod { get; set; }
        public string PaymentMethod { get; set; }

            public BuyingEntity() { }

            //public BuyingEntity(uint id, uint idCustomer, uint idCard, uint idStore, DateTime date, double sum, PaymentMethodTypes paymentMethod)
            public BuyingEntity(int id,uint numBuying ,uint idCustomer, uint idCard, uint idStore, DateTime date, decimal sum, string paymentMethod)
            {
                Id = id;
                NumBuying = numBuying;
                IdCustomer = idCustomer;
                IdCard = idCard;
                IdPurchaseCenter = idStore;
                Date = date;
                Sum = sum;
                PaymentMethod = paymentMethod;
            }
        }
    }

