using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.Models
{
    public class AgeCategoryModel
    {
        public int AgeCategoryId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(100, ErrorMessage = "String too long (max 100 chars)")]
        [DisplayName("Age Group")]
        public string AgeCategoryName { get; set; }
    }
}