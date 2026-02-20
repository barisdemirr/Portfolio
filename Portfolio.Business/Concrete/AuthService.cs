using Microsoft.AspNetCore.Identity;
using Portfolio.Business.Abstract;
using Portfolio.Business.DTOs.Auth;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class AuthService : GenericService<Admin>, IAuthService
    {
        private readonly IAuthDal _authDal;
        private readonly IPasswordHasher<Admin> _passwordHasher;
        public AuthService(IAuthDal authDal, IPasswordHasher<Admin> passwordHasher) : base(authDal)
        {
            _authDal = authDal;
            _passwordHasher = passwordHasher;
        }

        public async Task<Admin> LoginAsync(LoginDto dto)
        {
            var user = await _authDal.GetByUsernameAsync(dto.Username);

            if (user == null) return null;

            var res = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (res != PasswordVerificationResult.Success) return null;

            return user;
        }

        public async Task<List<GetAdminsDto>> TGetAdminNames()
        {
            var admins = await TGetAllAsync();

            var adminDtos = admins.Select(a => new GetAdminsDto
            {
                AdminId = a.AdminId,
                NameSurname = a.NameSurname
            }).ToList();

            return (adminDtos);
        }
    }
}
