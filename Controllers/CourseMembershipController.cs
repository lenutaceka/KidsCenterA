using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using KidsCenterA.Repository;
using KidsCenterA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenterA.Controllers
{
    public class CourseMembershipController : Controller
    {
        CourseMembershipRepository courseMembershipRepository = new CourseMembershipRepository();
        CourseCategoryRepository courseCategoryRepository = new CourseCategoryRepository();
        ChildrenRepository childrenRepository = new ChildrenRepository();

        // GET: CourseMembership
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            List<ViewModels.CourseMembershipViewModel> courseMembershipLists = courseMembershipRepository.GetAllMembershipsVM();
            return View("Index", courseMembershipLists);
        }

        // GET: CourseMembership/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int id)
        {
            Models.CourseMembershipViewModel courseMembershipModel = courseMembershipRepository.GetMembershipByID(id);
            return View("Details", courseMembershipModel);
        }

        // GET: CourseMembership/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            var courseMembership = new CourseMembership();
            CreateCourseMembershipViewModel createCourseMembershipVM = new CreateCourseMembershipViewModel();
            createCourseMembershipVM.courseCategories = courseCategoryRepository.GetAllCourseCategories();
            createCourseMembershipVM.KidsList = childrenRepository.GetAllChildren();
            createCourseMembershipVM.StartDate = courseMembership.StartDate;
            createCourseMembershipVM.EndDate = courseMembership.EndDate;
            return View(createCourseMembershipVM);
        }

        // POST: CourseMembership/Create
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
               
                var courseMembership = new CourseMembership();
                CreateCourseMembershipViewModel createCourseMembershipVM = new CreateCourseMembershipViewModel();
                createCourseMembershipVM.courseCategories = courseCategoryRepository.GetAllCourseCategories();
                createCourseMembershipVM.KidsList = childrenRepository.GetAllChildren();
                UpdateModel(createCourseMembershipVM);
                courseMembershipRepository.InsertMembership(createCourseMembershipVM.CourseMembership);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("Create");
            }
        }

        // GET: CourseMembership/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Models.CourseMembershipViewModel courseMembershipModel = courseMembershipRepository.GetMembershipByID(id);
            return View("Edit", courseMembershipModel);
        }

        // POST: CourseMembership/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.CourseMembershipViewModel courseMembershipModel = new Models.CourseMembershipViewModel();
                UpdateModel(courseMembershipModel);
                courseMembershipRepository.UpdateMembership(courseMembershipModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: CourseMembership/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Models.CourseMembershipViewModel courseMembershipModel = courseMembershipRepository.GetMembershipByID(id);
            return View("Delete", courseMembershipModel);
        }

        // POST: CourseMembership/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                courseMembershipRepository.DeleteMembership(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
