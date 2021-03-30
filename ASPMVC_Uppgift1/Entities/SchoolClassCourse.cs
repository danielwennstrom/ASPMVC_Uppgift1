using System;
using System.Collections.Generic;

#nullable disable

namespace ASPMVC_Uppgift1.Entities
{
    public partial class SchoolClassCourse
    {
        public Guid SchoolClassId { get; set; }
        public Guid SchoolCourseId { get; set; }
        public string TeacherId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual SchoolClass SchoolCourse { get; set; }
    }
}
