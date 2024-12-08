using System.ComponentModel.DataAnnotations;

namespace ClubCardsProject.Entities
{
    public class StoreEntity
    {
        //מזהה לפי מספר חנות
        [Key]
        public int Id { get; set; }
        [Required]
        public uint NumStore { get; set; }//מספר חנות
        [MaxLength(100)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Manager { get; set; }
        public StoreEntity() { }

        public StoreEntity(int id,uint numStore, string name, string address, string city, string phone, string email, string manager)
        {
            Id= id;
            NumStore = numStore;
            Name = name;
            Address = address;
            City = city;
            Phone = phone;
            Email = email;
            Manager = manager;
        }
    }
}
