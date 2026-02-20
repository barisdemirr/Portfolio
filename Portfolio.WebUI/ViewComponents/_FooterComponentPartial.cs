using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.SocialMedia;

namespace Portfolio.WebUI.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        public _FooterComponentPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var valueList = await _socialMediaService.TGetAllAsync();

            List<SocialGetDto> values = valueList.Select(v => new SocialGetDto
            {
                AccountUrl = v.AccountUrl,
                LogoUrl = v.LogoUrl
            }).ToList();

            return View(values);
        }
    }
}
