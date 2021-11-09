using KidsCenterA.Models;
using KidsCenterA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenterA.Controllers
{
    public class CourseCategoryController : Controller
    {
        CourseCategoryRepository courseCategoryRepository = new CourseCategoryRepository();

        // GET: CourseCategory
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<CourseCategoryModel> courseCategories = courseCategoryRepository.GetAllCourseCategories();
            return View("Index", courseCategories);
        }

        // GET: CourseCategory/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            CourseCategoryModel courseCategoryModel = courseCategoryRepository.GetCourseCategoryById(id);
            return View("Details", courseCategoryModel);
        }

        // GET: CourseCategory/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateCourseCategory");
        }

        // POST: CourseCategory/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CourseCategoryModel courseCategoryModel = new CourseCategoryModel();
                UpdateModel(courseCategoryModel);

                if (User.Identity.IsAuthenticated)
                {
                    courseCategoryModel.CourseCategoryName = User.Identity.Name + ":" + courseCategoryModel.CourseCategoryName;
                }

                courseCategoryRepository.InsertCourseCategory(courseCategoryModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCourseCategory");
            }
        }

        // GET: CourseCategory/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            CourseCategoryModel courseCategoryModel = courseCategoryRepository.GetCourseCategoryById(id);
            return View("EditCourseCategory", courseCategoryModel);
        }

        // POST: CourseCategory/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                CourseCategoryModel courseCategoryModel = new CourseCategoryModel();
                UpdateModel(courseCategoryModel);
                courseCategoryRepository.UpdateCourseCategory(courseCategoryModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCourseCategory");
            }
        }

        // GET: CourseCategory/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            CourseCategoryModel courseCategoryModel = courseCategoryRepository.GetCourseCategoryById(id);
            return View("DeleteCourseCategory", courseCategoryModel);
        }

        // POST: CourseCategory/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                courseCategoryRepository.DeleteCourseCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCourseCategory");
            }
        }
    }
}
