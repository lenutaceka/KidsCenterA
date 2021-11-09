using System;
using System.Collections.Generic;
using KidsCenterA.Models;
using System.Linq;
using System.Web;

namespace KidsCenterA.ViewModels
{
    public class CreateCourseMembershipViewModel
    {
        public Models.CourseMembershipViewModel CourseMembership { get; set; }
        
        public List<CourseCategoryModel> courseCategories { get; set; }


        public List<ChildrenModel> KidsList { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CreateCourseMembershipViewModel()
        {
            this.CourseMembership = new Models.CourseMembershipViewModel();
        }
    }
}