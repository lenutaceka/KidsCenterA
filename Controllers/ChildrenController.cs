using KidsCenterA.Models;
using KidsCenterA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidsCenterA.Controllers
{
    public class ChildrenController : Controller
    {
        ChildrenRepository childrenRepository = new ChildrenRepository();

        // GET: Children
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<ChildrenModel> childrens = childrenRepository.GetAllChildren();
            return View("Index", childrens);
        }

        // GET: Children/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            ChildrenModel childrenModel = childrenRepository.GetChildrenById(id);
            return View("Details", childrenModel);
        }

        // GET: Children/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateChildren");
        }

        // POST: Children/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ChildrenModel childrenModel = new ChildrenModel();
                UpdateModel(childrenModel);
                childrenRepository.InsertChildren(childrenModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateChildren");
            }
        }

        // GET: Children/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ChildrenModel childrenModel = childrenRepository.GetChildrenById(id);
            return View("EditChildren", childrenModel);
        }

        // POST: Children/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ChildrenModel childrenModel = new ChildrenModel();
                UpdateModel(childrenModel);
                childrenRepository.UpdateChildren(childrenModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditChildren");
            }
        }

        // GET: Children/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ChildrenModel childrenModel = childrenRepository.GetChildrenById(id);
            return View("Delete", childrenModel);
        }

        // POST: Children/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                childrenRepository.DeleteChildren(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
