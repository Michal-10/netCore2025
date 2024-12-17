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
        
        [StringLength(10, MinimumLength = 8)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Manager { get; set; }
        public List<BuyingEntity> ListBuying { get; set; }
        
    }
}
