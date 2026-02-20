using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.Auth
{
    public class AddAdminDto
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
