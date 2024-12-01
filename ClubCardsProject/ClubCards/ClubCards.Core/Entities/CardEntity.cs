namespace ClubCardsProject.Entities
{
    public class CardEntity
    {
        public uint Id { get; set; }
        public DateTime DateOfPurchase { get; set; } //תאריך רכישה
        public DateTime CardValidity { get; set; } //תוקף כרטיס
        public string PurchaseCenter { get; set; } //מוקד רכישה
        public decimal Sum { get; set; }// סכום
        public uint IdCustomer { get; set; }//מזהה לקוח
        public string ColorCard { get; set; }// צבע כרטיס

        public CardEntity() { }

        public CardEntity(uint id, DateTime dateOfPurchase, DateTime cardValidity, string purchaseCenter, decimal sum, uint idCustomer, string colorCard)
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
