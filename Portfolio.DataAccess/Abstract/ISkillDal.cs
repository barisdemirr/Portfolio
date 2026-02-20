using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.Abstract
{
    public interface ISkillDal : IGenericDal<Skill>
    {
        Task<List<Skill>> GetSkillsOnHeroAsync();
    }
}
