using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using KidsCenterA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidsCenterA.Repository
{
    public class CourseMembershipRepository
    {
        private KidsCenterAModelsDataContext dbContext;

        public CourseMembershipRepository()
        {
            dbContext = new KidsCenterAModelsDataContext();
        }

        public CourseMembershipRepository(KidsCenterAModelsDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public List<Models.CourseMembershipViewModel> GetAllMemberships()
        {
            List<Models.CourseMembershipViewModel> CourseMembershipList = new List<Models.CourseMembershipViewModel>();
            foreach (CourseMembership dbCourseMembership in dbContext.CourseMemberships)
            {
                CourseMembershipList.Add(MapDbObjectToModel(dbCourseMembership));
            }
            return CourseMembershipList;
        }

        public List<ViewModels.CourseMembershipViewModel> GetAllMembershipsVM()
        {
            List<ViewModels.CourseMembershipViewModel> courseMembershipVM = new List<ViewModels.CourseMembershipViewModel>();
            List<Models.CourseMembershipViewModel> courseMembership = GetAllMemberships();

            for (var i = 0; i < courseMembership.Count; i++)
            {
                courseMembershipVM.Add(new ViewModels.CourseMembershipViewModel());
                courseMembershipVM[i].MembershipID = courseMembership[i].MembershipId;
                courseMembershipVM[i].CourseCategoryId = dbContext.Courses.FirstOrDefault(x => x.CourseId == courseMembership[i].CourseId).CourseCategoryId;
                courseMembershipVM[i].FirstName = dbContext.Childrens.FirstOrDefault(x => x.ChildId == courseMembership[i].ChildId).FirstName;
                courseMembershipVM[i].LastName = dbContext.Childrens.FirstOrDefault(x => x.ChildId == courseMembership[i].ChildId).LastName;
                courseMembershipVM[i].Email = dbContext.Childrens.FirstOrDefault(x => x.ChildId == courseMembership[i].ChildId).Email;
                courseMembershipVM[i].StartDate = courseMembership[i].StartDate;
                courseMembershipVM[i].EndDate = courseMembership[i].EndDate;
            }
            return courseMembershipVM;
        }

        public Models.CourseMembershipViewModel GetMembershipByID(int id)
        {
            return MapDbObjectToModel(dbContext.CourseMemberships.FirstOrDefault(x => x.MembershipId == id));
        }

        public void InsertMembership(Models.CourseMembershipViewModel courseMembershipModel)
        {
            dbContext.CourseMemberships.InsertOnSubmit(MapModelToDbObject(courseMembershipModel));
            dbContext.SubmitChanges();
        }


        public void UpdateMembership(Models.CourseMembershipViewModel courseMembershipModel)
        {
            CourseMembership courseMembership = dbContext.CourseMemberships.FirstOrDefault(x => x.MembershipId == courseMembershipModel.MembershipId);
            if (courseMembership != null)
            {
                courseMembership.MembershipId = courseMembershipModel.MembershipId;
                courseMembership.CourseId = courseMembershipModel.CourseId;
                courseMembership.ChildId = courseMembershipModel.ChildId;
                courseMembership.StartDate = courseMembershipModel.StartDate;
                courseMembership.EndDate = courseMembershipModel.EndDate;
                dbContext.SubmitChanges();
            }
        }


        public void DeleteMembership(int id)
        {
            CourseMembership courseMembership = dbContext.CourseMemberships.FirstOrDefault(x => x.MembershipId == id);
            if (courseMembership != null)
            {
                dbContext.CourseMemberships.DeleteOnSubmit(courseMembership);
                dbContext.SubmitChanges();
            }
        }

        private Models.CourseMembershipViewModel MapDbObjectToModel(CourseMembership dbCourseMembership)
        {
            Models.CourseMembershipViewModel courseMembershipModel = new Models.CourseMembershipViewModel();
            if (dbCourseMembership != null)
            {
                courseMembershipModel.MembershipId = dbCourseMembership.MembershipId;
                courseMembershipModel.CourseId = dbCourseMembership.CourseId;
                courseMembershipModel.ChildId = dbCourseMembership.ChildId;
                courseMembershipModel.StartDate = dbCourseMembership.StartDate;
                courseMembershipModel.EndDate = dbCourseMembership.EndDate;

                return courseMembershipModel;
            }
            return null;
        }

        private CourseMembership MapModelToDbObject(Models.CourseMembershipViewModel courseMembershipModel)
        {
            CourseMembership dbCourseMembership = new CourseMembership();
            if (courseMembershipModel != null)
            {
                dbCourseMembership.MembershipId = courseMembershipModel.MembershipId;
                dbCourseMembership.CourseId = courseMembershipModel.CourseId;
                dbCourseMembership.ChildId = courseMembershipModel.ChildId;
                dbCourseMembership.StartDate = courseMembershipModel.StartDate;
                dbCourseMembership.EndDate = courseMembershipModel.EndDate;

                return dbCourseMembership;
            }
            return null;
        }
    }
}