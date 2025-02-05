using System.ComponentModel.DataAnnotations;

namespace ClubCards.Api.Models
{
    public class StorePostModel
    {
        public uint NumStore { get; set; }//מספר חנות
        [MaxLength(100)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [StringLength(10, MinimumLength = 8)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Manager { get; set; }
    }
}
