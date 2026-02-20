using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Project;
using Portfolio.Business.DTOs.Skill;
using Portfolio.Entity.Concrete;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Route("admin/[controller]")]
    public class SkillController : BaseAdminController
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _skillService.TGetAllAsync();

            List<SkillGetAdminDto> dtoList = values.Select(v => new SkillGetAdminDto
            {
                SkillId = v.SkillId,
                Name = v.Name,
                ProgressValue = v.ProgressValue,
                ShowOnHero = v.ShowOnHero
            }).ToList();

            return View(dtoList);
        }

        [HttpGet("add")]
        public IActionResult AddSkill()
        {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSkill(SkillAddAdminDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            Skill skill = new Skill
            {
                Name = dto.Name,
                ProgressValue = dto.ProgressValue,
                Description = dto.Description,
                ShowOnHero = dto.ShowOnHero
            };

            await _skillService.TInsertAsync(skill);

            return RedirectToAction("Index", "Skill");
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditSkill(int id)
        {
            var project = await _skillService.TGetByIdAsync(id);

            SkillUpdateAdminDto dto = new SkillUpdateAdminDto
            {
                SkillId = id,
                Name = project.Name,
                Description = project.Description,
                ProgressValue = project.ProgressValue,
                ShowOnHero = project.ShowOnHero, 
                UpdatedAt = project.UpdatedAt
            };

            return View(dto);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditSkill(int id, SkillUpdateAdminDto dto)
        {
            var skill = await _skillService.TGetByIdAsync(id);

            skill.Name = dto.Name;
            skill.Description = dto.Description;
            skill.ShowOnHero = dto.ShowOnHero;
            skill.ProgressValue = dto.ProgressValue;

            await _skillService.TUpdateAsync(skill);

            return RedirectToAction("Index", "Skill");
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            Skill skill = await _skillService.TGetByIdAsync(id);

            await _skillService.TDeleteAsync(skill);

            return RedirectToAction("Index", "Skill");
        }
    }
}
