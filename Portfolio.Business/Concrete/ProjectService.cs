using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Project;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class ProjectService : GenericService<Project>, IProjectService
    {
        private readonly IProjectDal _projectDal;
        public ProjectService(IProjectDal projectDal) : base(projectDal)
        {
            _projectDal = projectDal;
        }

        public async Task<List<ProjectGetDto>> TGetAllDescAsync()
        {
            var values = await _projectDal.GetAllDescAsync();

            return values.Select(v => new ProjectGetDto
            {
                Title = v.Title,
                Description = v.Description,
                TechStack = v.TechStack,
                ImageUrl = v.ImageUrl,
                IsDeployed = v.IsDeployed,
                IsGithubActive = v.IsGithubActive,
                GithubLink = v.GithubLink,
                DeployLink = v.DeployLink
            }).ToList();
        }
    }
}
