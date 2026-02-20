using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Skill;

namespace Portfolio.WebUI.ViewComponents
{
    public class _HeroComponentPartial : ViewComponent
    {
        private readonly IHeroSectionService _heroSectionService;
        private readonly ISkillService _skillService;

        public _HeroComponentPartial(IHeroSectionService heroSectionService, ISkillService skillService)
        {
            _heroSectionService = heroSectionService;
            _skillService = skillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _heroSectionService.TGetAllAsync();
            var section = values[0];

            List<SkillGetDtoHero> skills = await _skillService.TGetSkillsOnHero();

            var model = (section, skills);

            return View(model);
        }
    }
}
