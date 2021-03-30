using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ASPMVC_Uppgift1.Entities
{
    public partial class SchoolClassStudent
    {
        [Required]
        public string StudentId { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public Guid SchoolClassId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
    }
}
