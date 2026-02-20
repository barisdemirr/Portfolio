using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Route("admin")]
    public class DashboardController : BaseAdminController
    {
        private readonly IProjectService _projectService;
        private readonly ISocialMediaService _socialService;
        private readonly ISkillService _skillService;
        public DashboardController(IProjectService projectService, ISocialMediaService socialMediaService, ISkillService skillService)
        {
            _projectService = projectService;
            _socialService = socialMediaService;
            _skillService = skillService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var projectNumber = await _projectService.TCountAsync();
            var skillNumber = await _skillService.TCountAsync();
            var socialNumber = await _socialService.TCountAsync();

            var model = (projectNumber, skillNumber, socialNumber);

            return View(model);
        }
    }
}
