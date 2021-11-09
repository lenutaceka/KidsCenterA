using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenterA.Repository
{
    public class AgeCategoryRepository
    {
        private KidsCenterAModelsDataContext dbContext;

        public AgeCategoryRepository()
        {
            dbContext = new KidsCenterAModelsDataContext();
        }

        public AgeCategoryRepository(KidsCenterAModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<AgeCategoryModel> GetAllCategories()
        {
            List<AgeCategoryModel> AgeCategoryList = new List<AgeCategoryModel>();
            foreach (AgeCategory dbAgeCategory in dbContext.AgeCategories)
            {
                AgeCategoryList.Add(MapDbObjectToModel(dbAgeCategory));
            }
            return AgeCategoryList;
        }


        public AgeCategoryModel GetAgeCategoryById(int id)
        {
            return MapDbObjectToModel(dbContext.AgeCategories.FirstOrDefault(x => x.AgeCategoryId == id));
        }

        public void InsertAgeCategory(AgeCategoryModel ageCategoryModel)
        {
            dbContext.AgeCategories.InsertOnSubmit(MapModelToDbObject(ageCategoryModel));
            dbContext.SubmitChanges();
        }

        public void UpdateAgeCategory(AgeCategoryModel ageCategoryModel)
        {
            AgeCategory ageCategory = dbContext.AgeCategories.FirstOrDefault(x => x.AgeCategoryId == ageCategoryModel.AgeCategoryId);
            if (ageCategory != null)
            {
                ageCategory.AgeCategoryId = ageCategoryModel.AgeCategoryId;
                ageCategory.AgeCategoryName = ageCategoryModel.AgeCategoryName;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteAgeCategory(int id)
        {
            AgeCategory ageCategory = dbContext.AgeCategories.FirstOrDefault(x => x.AgeCategoryId == id);
            if (ageCategory != null)
            {
                dbContext.AgeCategories.DeleteOnSubmit(ageCategory);
                dbContext.SubmitChanges();
            }
        }

        private AgeCategoryModel MapDbObjectToModel(AgeCategory dbAgeCategory)
        {
            AgeCategoryModel ageCategoryModel = new AgeCategoryModel();
            if (dbAgeCategory != null)
            {
                ageCategoryModel.AgeCategoryId = dbAgeCategory.AgeCategoryId;
                ageCategoryModel.AgeCategoryName = dbAgeCategory.AgeCategoryName;

                return ageCategoryModel;
            }
            return null;
        }


        private AgeCategory MapModelToDbObject(AgeCategoryModel ageCategoryModel)
        {
            AgeCategory dbAgeCategory = new AgeCategory();
            if (ageCategoryModel != null)
            {
                dbAgeCategory.AgeCategoryId = ageCategoryModel.AgeCategoryId;
                dbAgeCategory.AgeCategoryName = ageCategoryModel.AgeCategoryName;

                return dbAgeCategory;
            }
            return null;
        }
    }
}