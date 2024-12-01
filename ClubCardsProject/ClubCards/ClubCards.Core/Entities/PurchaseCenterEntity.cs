namespace ClubCardsProject.Entities
{
    public class PurchaseCenterEntity
    {
        public uint Id { get; set; }
        public string NamePurchasePoint { get; set; }//שם מוקד רכישה
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Quantity { get; set; }
        public PurchaseCenterEntity() { }

        public PurchaseCenterEntity(uint id, string namePurchasePoint, string address, string city, string phone, string email, int quantity)
        {
            Id = id;
            NamePurchasePoint = namePurchasePoint;
            Address = address;
            City = city;
            Phone = phone;
            Email = email;
            Quantity = quantity;
        }
    }
}
