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
    public class HeroSectionService : GenericService<HeroSection>, IHeroSectionService
    {
        public HeroSectionService(IGenericDal<HeroSection> genericDal) : base(genericDal)
        {
        }
    }
}
