using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubCards.Core.DTOs
{
    public class StoreDTO
    {
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
    }
}
