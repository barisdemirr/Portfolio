using Portfolio.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.Concrete
{
    public class Admin : BaseEntity
    {
        public int AdminId { get; set; }
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
