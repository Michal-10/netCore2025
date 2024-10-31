namespace ClubCardsProject.Entities
{
    public class StoreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Manager { get; set; }
        public StoreEntity() { }

        public StoreEntity(int id, string name, string address, string city, string phone, string email, string manager)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Phone = phone;
            Email = email;
            Manager = manager;
        }
    }
}
