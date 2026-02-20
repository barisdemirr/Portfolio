using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.Skill
{
    public class SkillGetAdminDto
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int ProgressValue { get; set; }
        public bool ShowOnHero { get; set; }
    }
}
