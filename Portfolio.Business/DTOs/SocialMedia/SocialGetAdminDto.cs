using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.SocialMedia
{
    public class SocialGetAdminDto
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; }
        public string AccountUrl { get; set; }
    }
}
