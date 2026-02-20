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
    public class ProjectsSectionDal : GenericRepository<ProjectsSection>, IProjectsSectionDal
    {
        public ProjectsSectionDal(PortfolioDbContext context) : base(context)
        {
        }
    }
}
