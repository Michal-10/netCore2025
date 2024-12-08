using System.ComponentModel.DataAnnotations;

namespace ClubCardsProject.Entities
{
    public class CustomerEntity
    {
        //[Key]
        //public int Index { get; set; }
        //[Required]
        [Key]
        public int Id { get; set; }
        public uint IdCustomer { get; set; }
        public string Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public CustomerEntity() { }

        public CustomerEntity(int id,string tz, string firstName, string lastName, string phone, string email, DateTime dateOfBirth, DateTime dateOfJoin)
        {
            Id = id;
            Tz = tz;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            DateOfBirth = dateOfBirth;
            DateOfJoin = dateOfJoin;
        }
        
    }
}
