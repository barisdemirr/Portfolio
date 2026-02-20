using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Skill;
using System.Threading.Tasks;

namespace Portfolio.WebUI.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {   
        private readonly IAboutSectionService _aboutSectionService;
        private readonly ISkillService _skillService;
        public _AboutComponentPartial(IAboutSectionService aboutSectionService, ISkillService skillService)
        {
            _aboutSectionService = aboutSectionService;
            _skillService = skillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutSectionService.TGetAllAsync();
            var section = values[0];

            var skillList = await _skillService.TGetAllAsync();
            List<SkillGetDto> skills = skillList.Select(s => new SkillGetDto
            {
                Name = s.Name,
                Description = s.Description,
                ProgressValue = s.ProgressValue
            }).ToList();

            var model = (section, skills);

            return View(model);
        }
    }
}
