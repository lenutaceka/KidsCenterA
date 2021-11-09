using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int CourseCategoryId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int AgeCategoryId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int CoursePrice { get; set; }
    }
}