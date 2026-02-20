using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.Projects
{
    public class ProjectsGetDto
    {
        public string SurTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GithubUrl { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
