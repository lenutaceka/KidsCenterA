using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidsCenterA.Models
{
    public class ChildrenModel
    {
        public int ChildId { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 100 chars)")]
        [DisplayName("Child First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 100 chars)")]
        [DisplayName("Child Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        public int Age { get; set; }

        [StringLength(250, ErrorMessage = "String too long (max 100 chars)")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max 100 chars)")]
        public string Email { get; set; }
    }
}