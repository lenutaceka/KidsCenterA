using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using KidsCenterA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenterA.Repository
{
    public class CourseRepository
    {
        private KidsCenterAModelsDataContext dbContext;

        public CourseRepository()
        {
            dbContext = new KidsCenterAModelsDataContext();
        }

        public CourseRepository(KidsCenterAModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Models.CourseViewModel> GetAllCourses()
        {
            List<Models.CourseViewModel> courseList = new List<Models.CourseViewModel>();
            foreach (Course dbCourse in dbContext.Courses)
            {
                courseList.Add(MapDbObjectToModel(dbCourse));
            }
            return courseList;
        }



        public List<ViewModels.CourseViewModel> GetAllCoursesVM()
        {
            List<ViewModels.CourseViewModel> courseViewModels = new List<ViewModels.CourseViewModel>();
            List<Models.CourseViewModel> courseList = GetAllCourses();
            for (var i = 0; i < courseList.Count; i++)
            {
                courseViewModels.Add(new ViewModels.CourseViewModel());
                courseViewModels[i].CourseId = courseList[i].CourseId;
                courseViewModels[i].FirstName = dbContext.Trainers.FirstOrDefault(x => x.TrainerId == courseList[i].TrainerId).FirstName;
                courseViewModels[i].LastName = dbContext.Trainers.FirstOrDefault(x => x.TrainerId == courseList[i].TrainerId).LastName;
                courseViewModels[i].CourseCategoryName = dbContext.CourseCategories.FirstOrDefault(x => x.CourseCategoryId == courseList[i].CourseCategoryId).CourseCategoryName;
                courseViewModels[i].AgeCategoryName = dbContext.AgeCategories.FirstOrDefault(x => x.AgeCategoryId == courseList[i].AgeCategoryId).AgeCategoryName;
                courseViewModels[i].CoursePrice = courseList[i].CoursePrice;
            }
            return courseViewModels;
        }

        public Models.CourseViewModel GetCourseById(int id)
        {
            return MapDbObjectToModel(dbContext.Courses.FirstOrDefault(x => x.CourseId == id));
        }

        public void InsertCourse(Models.CourseViewModel courseModel)
        {
            dbContext.Courses.InsertOnSubmit(MapModelToDbObject(courseModel));
            dbContext.SubmitChanges();
        }

        public void UpdateCourse(Models.CourseViewModel courseModel)
        {
            Course course = dbContext.Courses.FirstOrDefault(x => x.CourseId == courseModel.CourseId);
            if (course != null)
            {
                course.CourseId = courseModel.CourseId;
                course.TrainerId = courseModel.TrainerId;
                course.CourseCategoryId = courseModel.CourseCategoryId;
                course.AgeCategoryId = courseModel.AgeCategoryId;
                course.CoursePrice = courseModel.CoursePrice;
                dbContext.SubmitChanges();
            }
        }


        public void DeleteCourse(int id)
        {
            Course course = dbContext.Courses.FirstOrDefault(x => x.CourseId == id);
            if (course != null)
            {
                dbContext.Courses.DeleteOnSubmit(course);
                dbContext.SubmitChanges();
            }
        }

        public Course MapModelToDbObject(Models.CourseViewModel courseModel)
        {
            Course dbCourse = new Course();
            if (courseModel != null)
            {
                dbCourse.CourseId = courseModel.CourseId;
                dbCourse.TrainerId = courseModel.TrainerId;
                dbCourse.CourseCategoryId = courseModel.CourseCategoryId;
                dbCourse.AgeCategoryId = courseModel.AgeCategoryId;
                dbCourse.CoursePrice = courseModel.CoursePrice;

                return dbCourse;
            }
            return null;
        }

        public Models.CourseViewModel MapDbObjectToModel(Course dbCourse)
        {
            Models.CourseViewModel courseModel = new Models.CourseViewModel();
            if (dbCourse != null)
            {
                courseModel.CourseId = dbCourse.CourseId;
                courseModel.TrainerId = dbCourse.TrainerId;
                courseModel.CourseCategoryId = dbCourse.CourseCategoryId;
                courseModel.AgeCategoryId = dbCourse.AgeCategoryId;
                courseModel.CoursePrice = dbCourse.CoursePrice;

                return courseModel;
            }
            return null;
        }

    }
}