namespace ClubCardsProject.Entities
{
    //public  enum PaymentMethodTypes { CASH=1, CREDIT_CARD, CHECK }
        
    public class BuyingEntity
        {
            public uint Id { get; set; }
            public uint IdCustomer { get; set; }
            public uint IdCard { get; set; }
            public uint IdPurchaseCenter { get; set; }
            public DateTime Date { get; set; }
            public decimal Sum { get; set; }
            //public PaymentMethodTypes PaymentMethod { get; set; }
            public string PaymentMethod { get; set; }

            public BuyingEntity() { }

            //public BuyingEntity(uint id, uint idCustomer, uint idCard, uint idStore, DateTime date, double sum, PaymentMethodTypes paymentMethod)
            public BuyingEntity(uint id, uint idCustomer, uint idCard, uint idStore, DateTime date, decimal sum, string paymentMethod)
            {
                Id = id;
                IdCustomer = idCustomer;
                IdCard = idCard;
                IdPurchaseCenter = idStore;
                Date = date;
                Sum = sum;
                PaymentMethod = paymentMethod;
            }
        }
    }

