using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.Skill
{
    public class SkillUpdateAdminDto
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProgressValue { get; set; }
        public bool ShowOnHero { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

