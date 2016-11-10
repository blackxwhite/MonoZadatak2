using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project.Service.Models;

namespace Project.Service.DAL
{
    public class VehicleInitializer : DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var vehicleMake = new List<VehicleMake>
            {
                new VehicleMake {VehicleMakeName = "BMW", VehicleMakeAbrv = "bmw" },
                new VehicleMake {VehicleMakeName = "Ford", VehicleMakeAbrv = "ford" },
                new VehicleMake {VehicleMakeName = "Volkswagen", VehicleMakeAbrv = "vw" }
            };
            vehicleMake.ForEach(v => context.VehicleMakes.Add(v));
            context.SaveChanges();

            var vehicleModel = new List<VehicleModel>
            {
                //new VehicleModel {VehicleModelName = "X6", VehicleMakeId = 1, VehicleModelAbrv = "x6" },
                //new VehicleModel {VehicleModelName = "M5", VehicleMakeId = 2, VehicleModelAbrv = "m5" }
            };
            vehicleModel.ForEach(v => context.VehicleModels.Add(v));
            context.SaveChanges();
        }
    }
}
