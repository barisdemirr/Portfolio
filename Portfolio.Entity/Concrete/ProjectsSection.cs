using Portfolio.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Entity.Concrete
{
    public class ProjectsSection : BaseEntity
    {
        public int ProjectsSectionId { get; set; }
        public string SurTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
    }
}
