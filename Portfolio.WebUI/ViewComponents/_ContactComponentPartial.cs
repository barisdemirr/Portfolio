using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.Concrete;
using System.Threading.Tasks;

namespace Portfolio.WebUI.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {   
        private readonly IContactSectionService _contactSectionService;
        public _ContactComponentPartial(IContactSectionService contactSectionService)
        {
            _contactSectionService = contactSectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactSectionService.TGetAllAsync();
            var value = values[0];

            return View(value);
        }
    }
}
