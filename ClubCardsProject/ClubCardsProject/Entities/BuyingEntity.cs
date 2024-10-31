namespace ClubCardsProject.Entities
{
    public  enum PaymentMethodTypes { CASH, CREDITCARD, CHECK }
        
    public class BuyingEntity
        {
            public int Id { get; set; }
            public int IdCustomer { get; set; }
            public int IdCard { get; set; }
            public int IdPurchaseCenter { get; set; }
            public DateTime Date { get; set; }
            public Double Sum { get; set; }
            public PaymentMethodTypes PaymentMethod { get; set; }

            public BuyingEntity()
            {
            }

            public BuyingEntity(int id, int idCustomer, int idCard, int idStore, DateTime date, double sum, PaymentMethodTypes paymentMethod)
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

