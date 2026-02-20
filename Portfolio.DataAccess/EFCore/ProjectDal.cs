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
    public class ProjectDal : GenericRepository<Project>, IProjectDal
    {
        public ProjectDal(PortfolioDbContext context) : base(context)
        {
        }

        public async Task<List<Project>> GetAllDescAsync()
        {
            return await _context.Projects.OrderByDescending(x => x.ProjectId).ToListAsync();
        }
    }
}
