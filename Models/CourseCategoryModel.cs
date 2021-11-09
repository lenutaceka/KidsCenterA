using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.Models
{
    public class CourseCategoryModel
    {
        public int CourseCategoryId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        [DisplayName("Course Name")]
        public string CourseCategoryName { get; set; }
    }
}