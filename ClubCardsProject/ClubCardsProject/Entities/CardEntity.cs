namespace ClubCardsProject.Entities
{
    public class CardEntity
    {
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public string PurchaseCenter { get; set; } //מוקד רכישה
        public Double Sum { get; set; }// סכום
        public int IdCustomer { get; set; }//מזהה לקוח
        public string ColorCard { get; set; }// צבע כרטיס

        public CardEntity()
        {
        }

        public CardEntity(int id, DateTime dateOfPurchase, DateTime cardValidity, string purchaseCenter, double sum, int idCustomer, string colorCard)
        {
            this.Id = id;
            DateOfPurchase = dateOfPurchase;
            CardValidity = cardValidity;
            PurchaseCenter = purchaseCenter;
            Sum = sum;
            IdCustomer = idCustomer;
            ColorCard = colorCard;
        }
    }
}
