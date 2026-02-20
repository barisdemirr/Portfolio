using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Portfolio.Business.Abstract;
using Portfolio.Business.Concrete;
using Portfolio.Business.DTOs.Project;
using Portfolio.Entity.Concrete;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Route("admin")]
    public class ProjectController : BaseAdminController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("project")]
        public async Task<IActionResult> Index()
        {   
            var values = await _projectService.TGetAllAsync();

            List<ProjectGetAdminDto> dtoList = values.Select(v => new ProjectGetAdminDto
            {
                ProjectId = v.ProjectId,
                Title = v.Title,
                Description = v.Description,
                TechStack = v.TechStack
            }).ToList();

            return View(dtoList);
        }

        [HttpGet("project/add")]
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost("project/add")]
        public async Task<IActionResult> AddProject(ProjectAddAdminDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            Project project = new Project
            {
                Title = dto.Title,
                Description = dto.Description,
                TechStack = dto.TechStack,
                ImageUrl = dto.ImageUrl,
                IsGithubActive = dto.IsGithubActive,
                GithubLink = dto.GithubLink,
                IsDeployed = dto.IsDeployed,
                DeployLink = dto.DeployLink,
            };

            await _projectService.TInsertAsync(project);

            return RedirectToAction("Index", "Project");
        }


        [HttpGet("project/edit")]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _projectService.TGetByIdAsync(id);

            ProjectUpdateAdminDto dto = new ProjectUpdateAdminDto
            {
                ProjectId = id,
                Title = project.Title,
                Description = project.Description,
                TechStack = project.TechStack,
                ImageUrl = project.ImageUrl,
                IsGithubActive = project.IsGithubActive,
                GithubLink = project.GithubLink,
                IsDeployed = project.IsDeployed,
                DeployLink = project.DeployLink,
                UpdatedAt = project.UpdatedAt
            };

            return View(dto);
        }

        [HttpPost("project/edit")]
        public async Task<IActionResult> EditProject(int id, ProjectUpdateAdminDto dto)
        {
            var project = await _projectService.TGetByIdAsync(id);

            project.Title = dto.Title;
            project.Description = dto.Description;
            project.TechStack = dto.TechStack;
            project.ImageUrl = dto.ImageUrl;
            project.IsGithubActive = dto.IsGithubActive;
            project.GithubLink = dto.GithubLink;
            project.IsDeployed = dto.IsDeployed;
            project.DeployLink = dto.DeployLink;

            await _projectService.TUpdateAsync(project);

            return RedirectToAction("Index", "Project");
        }

        [HttpPost("project/delete")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            Project project = await _projectService.TGetByIdAsync(id);

            await _projectService.TDeleteAsync(project);

            return RedirectToAction("Index", "Project");
        }
    }
}
