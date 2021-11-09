using KidsCenterA.Models;
using KidsCenterA.Models.DbObjects;
using KidsCenterA.Repository;
using KidsCenterA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseViewModel = KidsCenterA.Models.CourseViewModel;

namespace KidsCenterA.Controllers
{
    public class CourseController : Controller
    {
        public CourseRepository courseRepository = new CourseRepository();
        public AgeCategoryRepository ageCategoryRepository = new AgeCategoryRepository();
        public CourseCategoryRepository courseCategoryRepository = new CourseCategoryRepository();
        public TrainerRepository trainerRepository = new TrainerRepository();

        // GET: Course
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            List<ViewModels.CourseViewModel> coursesList = courseRepository.GetAllCoursesVM();
            return View("Index", coursesList);
        }

        // GET: Course/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int id)
        {
            CourseViewModel courseVM = courseRepository.GetCourseById(id);
            return View("Details", courseVM);
        }

        // GET: Course/Create
        [Authorize(Roles = "User, Admin")]
        public ActionResult Create()
        {
            var course = new Course();
            CreateCourseViewModel createCourseVM = new CreateCourseViewModel();
            createCourseVM.TrainersList = trainerRepository.GetAllTrainers();
            createCourseVM.AgeCategories = ageCategoryRepository.GetAllCategories();
            createCourseVM.CourseCategories = courseCategoryRepository.GetAllCourseCategories();
            createCourseVM.CoursePrice = course.CoursePrice;
            return View(createCourseVM);
        }

        // POST: Course/Create
        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                
                CreateCourseViewModel createCourseVM = new CreateCourseViewModel();
                createCourseVM.TrainersList = trainerRepository.GetAllTrainers();
                createCourseVM.AgeCategories = ageCategoryRepository.GetAllCategories();
                createCourseVM.CourseCategories = courseCategoryRepository.GetAllCourseCategories();
                UpdateModel(createCourseVM);
                courseRepository.InsertCourse(createCourseVM.Course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Course/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            Models.CourseViewModel courseModel = courseRepository.GetCourseById(id);
            return View("Edit", courseModel);
        }

        // POST: Course/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.CourseViewModel courseModel = new Models.CourseViewModel();
                UpdateModel(courseModel);
                courseRepository.UpdateCourse(courseModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Models.CourseViewModel courseModel = courseRepository.GetCourseById(id);
            return View("Delete", courseModel);
        }

        // POST: Course/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                courseRepository.DeleteCourse(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
