using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Skill;
using Portfolio.Business.DTOs.SocialMedia;
using Portfolio.Entity.Concrete;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Route("admin/[controller]")]
    public class SocialMediaController : BaseAdminController
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _socialMediaService.TGetAllAsync();

            List<SocialGetAdminDto> dtoList = values.Select(v => new SocialGetAdminDto
            {
                SocialMediaId = v.SocialMediaId,
                Name = v.Name,
                AccountUrl = v.AccountUrl
            }).ToList();

            return View(dtoList);
        }

        [HttpGet("add")]
        public IActionResult AddSocial()
        {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSocial(SocialAddAdminDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            SocialMedia social = new SocialMedia
            {
                Name = dto.Name,
                AccountUrl = dto.AccountUrl,
                LogoUrl = dto.LogoUrl
            };

            await _socialMediaService.TInsertAsync(social);

            return RedirectToAction("Index", "SocialMedia");
        }


        [HttpGet("edit")]
        public async Task<IActionResult> EditSocial(int id)
        {
            var social = await _socialMediaService.TGetByIdAsync(id);

            SocialUpdateAdminDto dto = new SocialUpdateAdminDto
            {
                SocialMediaId = social.SocialMediaId,
                Name = social.Name,
                AccountUrl = social.AccountUrl,
                LogoUrl = social.LogoUrl
            };

            return View(dto);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditSocial(int id, SocialUpdateAdminDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var social = await _socialMediaService.TGetByIdAsync(id);

            social.Name = dto.Name;
            social.LogoUrl = dto.LogoUrl;
            social.AccountUrl = dto.AccountUrl;

            await _socialMediaService.TUpdateAsync(social);

            return RedirectToAction("Index", "SocialMedia");
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteSocial(int id)
        {
            SocialMedia social = await _socialMediaService.TGetByIdAsync(id);

            await _socialMediaService.TDeleteAsync(social);

            return RedirectToAction("Index", "SocialMedia");
        }
    }
}
