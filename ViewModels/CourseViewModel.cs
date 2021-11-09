using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Trainer First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Trainer Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Course Name")]
        public string CourseCategoryName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Age group")]
        public string AgeCategoryName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [DisplayName("Course Price")]
        public int CoursePrice { get; set; }
    }

}