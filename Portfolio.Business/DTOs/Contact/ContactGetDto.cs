using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.Contact
{
    public class ContactGetDto
    {
        public bool OpenToWork { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string MapLocation { get; set; }
        public string MapImageUrl { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
