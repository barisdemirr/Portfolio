using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Context;
using Portfolio.DataAccess.Repositories;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.EFCore
{
    public class ContactSectionDal : GenericRepository<ContactSection>, IContactSectionDal
    {
        public ContactSectionDal(PortfolioDbContext context) : base(context)
        {
        }
    }
}
