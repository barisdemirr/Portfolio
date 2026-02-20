using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.DTOs.About
{
    public class AboutGetDto
    {
        public string SurTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public string CvUrl { get; set; }
        public string EducationDepartment { get; set; }
        public string EducationCollege { get; set; }
        public string EducationDate { get; set; }
        public string EducationDescription { get; set; }
        public string TechTitle { get; set; }
        public string TechDescription { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
