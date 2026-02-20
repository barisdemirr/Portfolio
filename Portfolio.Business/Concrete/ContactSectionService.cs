using Portfolio.Business.Abstract;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class ContactSectionService : GenericService<ContactSection>, IContactSectionService
    {
        public ContactSectionService(IGenericDal<ContactSection> genericDal) : base(genericDal)
        {
        }
    }
}
