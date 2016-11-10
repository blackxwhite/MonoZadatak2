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
using PagedList;

namespace Mono_Zadatak2.Controllers
{
    public class VehicleMakesController : Controller
    {
        public VehicleService vehicleService;

        public VehicleMakesController()
        {
            this.vehicleService = VehicleService.GetInstance;
        }

        // GET: VehicleMakes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "Abrv_desc" : "Abrv";
            ViewBag.CurrentFilter = searchString;
            var vehicles = vehicleService.SearchSortVehicleMake(sortOrder, currentFilter, searchString, page);
            
            return View(vehicles);
        }

        // GET: VehicleMakes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewVehicleMake vehicleMake = vehicleService.FindVehicleMake(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleMakeId,VehicleMakeName,VehicleMakeAbrv")] ViewVehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                vehicleService.CreateVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewVehicleMake vehicleMake = vehicleService.FindVehicleMake(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleMakeId,VehicleMakeName,VehicleMakeAbrv")] ViewVehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                vehicleService.EditVehicleMake(vehicleMake);
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewVehicleMake vehicleMake = vehicleService.FindVehicleMake(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            vehicleService.DeleteVehicleMake(id);
            return RedirectToAction("Index");
        }
    }
}
