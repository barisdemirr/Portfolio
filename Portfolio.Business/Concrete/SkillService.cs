using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Skill;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        private readonly ISkillDal _skillDal;
        public SkillService(ISkillDal skillDal) : base(skillDal)
        {
            _skillDal = skillDal;
        }

        public async Task<List<SkillGetDtoHero>> TGetSkillsOnHero()
        {
            var skills = await _skillDal.GetSkillsOnHeroAsync();

            return skills.Select(s => new SkillGetDtoHero
            {
                Name = s.Name
            }).ToList();
        }
    }
}
