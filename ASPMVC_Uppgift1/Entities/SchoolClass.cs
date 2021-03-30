using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ASPMVC_Uppgift1.Entities
{
    public partial class SchoolClass
    {
        public SchoolClass()
        {
            SchoolClassCourseSchoolClasses = new HashSet<SchoolClassCourse>();
            SchoolClassCourseSchoolCourses = new HashSet<SchoolClassCourse>();
            SchoolClassStudents = new HashSet<SchoolClassStudent>();
        }

        public Guid Id { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public string TeacherId { get; set; }
        public DateTime Created { get; set; }

        public SchoolClass(DateTime created)
        {
            Created = DateTime.Now;
        }

        public virtual ICollection<SchoolClassCourse> SchoolClassCourseSchoolClasses { get; set; }
        public virtual ICollection<SchoolClassCourse> SchoolClassCourseSchoolCourses { get; set; }
        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
    }
}
