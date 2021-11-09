using KidsCenterA.Models;
using KidsCenterA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenterA.Controllers
{
    public class TrainerController : Controller
    {
        TrainerRepository trainerRepository = new TrainerRepository();

        // GET: Trainer
        [Authorize(Roles = "User, Admin")]
        public ActionResult Index()
        {
            List<TrainerModel> Trainers = trainerRepository.GetAllTrainers();
            return View("Index", Trainers);
        }

        // GET: Trainer/Details/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Details(int id)
        {
            TrainerModel trainerModel = trainerRepository.GetTrainerById(id);
            return View("TrainerDetails", trainerModel);
        }

        // GET: Trainer/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateTrainer");
        }

        // POST: Trainer/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TrainerModel trainerModel = new TrainerModel();
                UpdateModel(trainerModel);
                trainerRepository.InsertTrainer(trainerModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateTrainer");
            }
        }

        // GET: Trainer/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            TrainerModel trainerModel = trainerRepository.GetTrainerById(id);
            return View("EditTrainer", trainerModel);
        }

        // POST: Trainer/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                TrainerModel trainerModel = new TrainerModel();
                UpdateModel(trainerModel);
                trainerRepository.UpdateTrainer(trainerModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditTrainer");
            }
        }

        // GET: Trainer/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            TrainerModel trainerModel = trainerRepository.GetTrainerById(id);
            return View("DeleteTrainer", trainerModel);
        }

        // POST: Trainer/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                trainerRepository.DeleteTrainer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteTrainer");
            }
        }
    }
}