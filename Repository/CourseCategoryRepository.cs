using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenterA.Repository
{
    public class CourseCategoryRepository
    {
        private KidsCenterAModelsDataContext dbContext;

        public CourseCategoryRepository()
        {
            dbContext = new KidsCenterAModelsDataContext();
        }

        public CourseCategoryRepository(KidsCenterAModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<CourseCategoryModel> GetAllCourseCategories()
        {
            List<CourseCategoryModel> courseCategoryList = new List<CourseCategoryModel>();
            foreach (CourseCategory dbCourseCategory in dbContext.CourseCategories)
            {
                courseCategoryList.Add(MapDbObjectToModel(dbCourseCategory));
            }
            return courseCategoryList;
        }

        public CourseCategoryModel GetCourseCategoryById(int id)
        {
            return MapDbObjectToModel(dbContext.CourseCategories.FirstOrDefault(x => x.CourseCategoryId == id));
        }

        public void InsertCourseCategory(CourseCategoryModel courseCategoryModel)
        {
            dbContext.CourseCategories.InsertOnSubmit(MapModelToDbObject(courseCategoryModel));
            dbContext.SubmitChanges();
        }

        public void UpdateCourseCategory(CourseCategoryModel courseCategoryModel)
        {
            CourseCategory courseCategory = dbContext.CourseCategories.FirstOrDefault(x => x.CourseCategoryId == courseCategoryModel.CourseCategoryId);
            if (courseCategory != null)
            {
                courseCategory.CourseCategoryId = courseCategoryModel.CourseCategoryId;
                courseCategory.CourseCategoryName = courseCategoryModel.CourseCategoryName;

                dbContext.SubmitChanges();
            }
        }

        public void DeleteCourseCategory(int id)
        {
            CourseCategory courseCategory = dbContext.CourseCategories.FirstOrDefault(x => x.CourseCategoryId == id);
            if (courseCategory != null)
            {
                dbContext.CourseCategories.DeleteOnSubmit(courseCategory);
                dbContext.SubmitChanges();
            }
        }

        private CourseCategory MapModelToDbObject(CourseCategoryModel courseCategoryModel)
        {
            CourseCategory dbCourseCategory = new CourseCategory();
            if (courseCategoryModel != null)
            {
                dbCourseCategory.CourseCategoryId = courseCategoryModel.CourseCategoryId;
                dbCourseCategory.CourseCategoryName = courseCategoryModel.CourseCategoryName;

                return dbCourseCategory;
            }
            return null;
        }

        private CourseCategoryModel MapDbObjectToModel(CourseCategory dbCourseCategory)
        {
            CourseCategoryModel courseCategoryModel = new CourseCategoryModel();
            if (dbCourseCategory != null)
            {
                courseCategoryModel.CourseCategoryId = dbCourseCategory.CourseCategoryId;
                courseCategoryModel.CourseCategoryName = dbCourseCategory.CourseCategoryName;

                return courseCategoryModel;
            }
            return null;
        }
    }
}