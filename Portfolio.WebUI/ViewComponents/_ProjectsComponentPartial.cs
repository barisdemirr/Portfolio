using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Project;
using System.Threading.Tasks;

namespace Portfolio.WebUI.ViewComponents
{
    public class _ProjectsComponentPartial : ViewComponent
    {   
        private readonly IProjectsSectionService _projectsSectionService;
        private readonly IProjectService _projectService;
        public _ProjectsComponentPartial(IProjectsSectionService projectsSectionService, IProjectService projectService)
        {
            _projectsSectionService = projectsSectionService;
            _projectService = projectService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var projectsSections = await _projectsSectionService.TGetAllAsync();
            var projectsSection = projectsSections[0];

            var projects = await _projectService.TGetAllDescAsync();

            var model = (projectsSection, projects);
            return View(model);
        }
    }
}
