using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.ViewModels
{
    public class ViewVehicleModel
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelAbrv { get; set; }
        public virtual ViewVehicleMake VehicleMake { get; set; }
    }
}
