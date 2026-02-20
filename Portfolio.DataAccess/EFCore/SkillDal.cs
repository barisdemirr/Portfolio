using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Context;
using Portfolio.DataAccess.Repositories;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.EFCore
{
    public class SkillDal : GenericRepository<Skill>, ISkillDal
    {
        public SkillDal(PortfolioDbContext context) : base(context)
        {
        }

        public async Task<List<Skill>> GetSkillsOnHeroAsync()
        {
            return await _context.Skills.Where(s => s.ShowOnHero).ToListAsync();
        }
    }
}
