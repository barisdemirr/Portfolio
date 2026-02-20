using Portfolio.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.Concrete
{
    public class Skill : BaseEntity
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int ProgressValue { get; set; }
        public string Description { get; set; }
        public bool ShowOnHero { get; set; }
    }
}
