using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Abstract;
using Portfolio.Business.Concrete;
using Portfolio.Business.DTOs.Auth;
using Portfolio.Business.DTOs.Project;
using Portfolio.Entity.Concrete;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Route("admin")]
    public class AdminsController : BaseAdminController
    {
        private readonly IAuthService _authService;
        private readonly IPasswordHasher<Portfolio.Entity.Concrete.Admin> _passwordHasher;
        public AdminsController(IAuthService authService, IPasswordHasher<Portfolio.Entity.Concrete.Admin> passwordHasher)
        {
            _authService = authService;
            _passwordHasher = passwordHasher;
        }

        [HttpGet("admins")]
        public async Task<IActionResult> IndexAsync()
        {
           var admins = await _authService.TGetAdminNames();

            return View(admins);
        }

        [HttpGet("admins/add")]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost("admins/add")]
        public async Task<IActionResult> AddAdmin(AddAdminDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var admin = new Portfolio.Entity.Concrete.Admin
            {
                NameSurname = dto.NameSurname,
                Username = dto.Username
            };

            admin.PasswordHash = _passwordHasher.HashPassword(admin, dto.Password);

            await _authService.TInsertAsync(admin);

            return RedirectToAction("Index", "Admins");
        }

        [HttpPost("admins/delete")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _authService.TGetByIdAsync(id);

            await _authService.TDeleteAsync(admin);

            return RedirectToAction("Index", "Admins");
        }
    }
}
