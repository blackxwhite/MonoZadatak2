using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Service.DAL;
using Project.Service.Models;
using Project.Service.ViewModels;

namespace Mono_Zadatak2.Controllers
{
    public class VehicleModelsController : Controller
    {
        private VehicleService vehicleservice;

        public VehicleModelsController()
        {
            vehicleservice = VehicleService.GetInstance;
        }

        // GET: VehicleModels
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "Model_desc" : "Model";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "Abrv:desc" : "Abrv";
            ViewBag.CurrentFilter = searchString;
            var vehicles = vehicleservice.SearchSortVehicleModel(sortOrder, currentFilter, searchString, page);

            return View(vehicles);
        }

        // GET: VehicleModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewVehicleModel vehicleModel = vehicleservice.FindVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            ViewBag.VehicleMakeId = vehicleservice.getAll();
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleModelId,VehicleMakeId,VehicleModelName,VehicleModelAbrv")] ViewVehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                //vehicleModel.VehicleMakeId = 4;
                vehicleservice.CreateVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }

            ViewBag.VehicleMakeId = vehicleservice.getAll().ToList();
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewVehicleModel vehicleModel = vehicleservice.FindVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleMakeId = vehicleservice.getAll();
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleModelId,VehicleMakeId,VehicleModelName,VehicleModelAbrv")] ViewVehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                vehicleservice.EditVehicleModel(vehicleModel);
                return RedirectToAction("Index");
            }
            ViewBag.VehicleMakeId = vehicleservice.getAll();
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewVehicleModel vehicleModel = vehicleservice.FindVehicleModel(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vehicleservice.DeleteVehicleModel(id);
            return RedirectToAction("Index");
        }
    }
}
