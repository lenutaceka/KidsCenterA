using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.Models
{
    public class CourseMembershipViewModel
    {
        public int MembershipId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int ChildId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime EndDate { get; set; }
    }
}