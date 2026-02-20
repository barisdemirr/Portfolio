using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.Project
{
    public class ProjectAddAdminDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TechStack { get; set; }
        public string ImageUrl { get; set; }
        public bool IsGithubActive { get; set; }
        public string? GithubLink { get; set; }
        public bool IsDeployed { get; set; }
        public string? DeployLink { get; set; }
    }
}
