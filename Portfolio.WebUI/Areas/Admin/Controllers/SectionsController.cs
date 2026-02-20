using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.About;
using Portfolio.Business.DTOs.Contact;
using Portfolio.Business.DTOs.Hero;
using Portfolio.Business.DTOs.Projects;
using System.Text.Json;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Route("admin/[action]")]
    public class SectionsController : BaseAdminController
    {
        private readonly IHeroSectionService _heroSectionService;
        private readonly IAboutSectionService _aboutSectionService;
        private readonly IProjectsSectionService _projectsSectionService;
        private readonly IContactSectionService _contactSectionService;

        public SectionsController(IHeroSectionService heroSectionService, IAboutSectionService aboutSectionService, IProjectsSectionService projectsSectionService, IContactSectionService contactSectionService)
        {
            _heroSectionService = heroSectionService;
            _aboutSectionService = aboutSectionService;
            _projectsSectionService = projectsSectionService;
            _contactSectionService = contactSectionService;
        }


        //----- HERO -----

        [HttpGet]
        public async Task<IActionResult> Hero()
        {   
            var values = await _heroSectionService.TGetAllAsync();
            var value = values[0];

            HeroGetDto dto = new HeroGetDto
            {
                Title = value.Title,
                SubTitle = value.SubTitle,
                Role = value.Role,
                SubRole = value.SubRole,
                Description = value.Description,
                UpdatedAt = value.UpdatedAt
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Hero(HeroUpdateDto dto)
        {
            
            var values = await _heroSectionService.TGetAllAsync();
            var value = values[0];

            value.Title = dto.Title;
            value.SubTitle = dto.SubTitle;
            value.Role = dto.Role;
            value.SubRole = dto.SubRole;
            value.Description = dto.Description;

            await _heroSectionService.TUpdateAsync(value);

            return RedirectToAction("Hero", "Sections");
        }


        //----- ABOUT -----

        [HttpGet]
        public async Task<IActionResult> AboutAsync()
        {
            var values = await _aboutSectionService.TGetAllAsync();
            var value = values[0];

            AboutGetDto dto = new AboutGetDto
            {
                SurTitle = value.SurTitle,
                Title = value.Title,
                Description = value.Description,
                SubDescription = value.SubDescription,
                CvUrl = value.CvUrl,
                EducationCollege = value.EducationCollege,
                EducationDate = value.EducationDate,
                EducationDepartment = value.EducationDepartment,
                EducationDescription = value.EducationDescription,
                TechDescription = value.TechDescription,
                TechTitle = value.TechTitle,
                UpdatedAt = value.UpdatedAt
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> About(AboutUpdateDto dto)
        {

            var values = await _aboutSectionService.TGetAllAsync();
            var value = values[0];

            value.SurTitle = dto.SurTitle;
            value.Title = dto.Title;
            value.Description = dto.Description;
            value.SubDescription = dto.SubDescription;
            value.CvUrl = dto.CvUrl;
            value.EducationCollege = dto.EducationCollege;
            value.EducationDate = dto.EducationDate;
            value.EducationDepartment = dto.EducationDepartment;
            value.EducationDescription = dto.EducationDescription;
            value.TechDescription = dto.TechDescription;
            value.TechTitle = dto.TechTitle;

            await _aboutSectionService.TUpdateAsync(value);

            return RedirectToAction("About", "Sections");
        }


        //----- PROJECTS -----

        [HttpGet]
        public async Task<IActionResult> Projects()
        {
            var values = await _projectsSectionService.TGetAllAsync();
            var value = values[0];

            ProjectsGetDto dto = new ProjectsGetDto
            {
                SurTitle = value.SurTitle,
                Title = value.Title,
                Description = value.Description,
                GithubUrl = value.GithubUrl,
                UpdatedAt = value.UpdatedAt
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Projects(ProjectsUpdateDto dto)
        {

            var values = await _projectsSectionService.TGetAllAsync();
            var value = values[0];

            value.SurTitle = dto.SurTitle;
            value.Title = dto.Title;
            value.Description = dto.Description;
            value.GithubUrl = dto.GithubUrl;

            await _projectsSectionService.TUpdateAsync(value);

            return RedirectToAction("Projects", "Sections");
        }


        //----- CONTACT -----

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var values = await _contactSectionService.TGetAllAsync();
            var value = values[0];

            ContactGetDto dto = new ContactGetDto
            {
                OpenToWork = value.OpenToWork,
                Title = value.Title,
                Description= value.Description,
                Email = value.Email,
                Phone = value.Phone,
                Location = value.Location,
                MapImageUrl = value.MapImageUrl,
                MapLocation = value.MapLocation,
                UpdatedAt= value.UpdatedAt
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactUpdateDto dto)
        {

            var values = await _contactSectionService.TGetAllAsync();
            var value = values[0];

            value.OpenToWork = dto.OpenToWork;
            value.Title = dto.Title;
            value.Description = dto.Description;
            value.Email = dto.Email;
            value.Phone = dto.Phone;
            value.Location = dto.Location;
            value.MapImageUrl = dto.MapImageUrl;
            value.MapLocation = dto.MapLocation;

            await _contactSectionService.TUpdateAsync(value);

            return RedirectToAction("Contact", "Sections");
        }
    }
}
