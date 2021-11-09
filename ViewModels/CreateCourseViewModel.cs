using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KidsCenterA.ViewModels
{
    public class CreateCourseViewModel
    {
        public Models.CourseViewModel Course { get; set; }

        public List<TrainerModel> TrainersList { get; set; }

        public List<AgeCategoryModel> AgeCategories { get; set; }
        public List<CourseCategoryModel> CourseCategories { get; set; }

        public int CoursePrice { get; set; }

        public CreateCourseViewModel()
        {
            this.Course = new Models.CourseViewModel();
        }
    }
}