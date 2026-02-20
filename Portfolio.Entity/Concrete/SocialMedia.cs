using Portfolio.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.Concrete
{
    public class SocialMedia: BaseEntity
    {
        public int SocialMediaId { get; set; }
        public string LogoUrl { get; set; }
        public string Name { get; set; }
        public string AccountUrl { get; set; }
    }
}
