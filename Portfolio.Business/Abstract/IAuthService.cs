using Portfolio.Business.DTOs.Auth;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Abstract
{
    public interface IAuthService : IGenericService<Admin>
    {
        Task<Admin> LoginAsync(LoginDto dto);
        Task<List<GetAdminsDto>> TGetAdminNames();
    }
}
