using Portfolio.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.Concrete
{
    public class HeroSection : BaseEntity
    {
        public int HeroSectionId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Role { get; set; }
        public string SubRole { get; set; }
        public string Description { get; set; }
    }
}
