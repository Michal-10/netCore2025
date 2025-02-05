using System.ComponentModel.DataAnnotations;

namespace ClubCards.Api.Models
{
    public class CustomerPostModel
    {
        public uint IdCustomer { get; set; }
        public string Tz { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 8)]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
    }
}
