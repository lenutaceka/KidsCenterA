using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.ViewModels
{
    public class CourseMembershipViewModel
    {
        public int MembershipID { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Course Name")]
        public int CourseCategoryId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Child First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Child Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public DateTime EndDate { get; set; }

    }
}