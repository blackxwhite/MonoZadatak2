using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.ViewModels
{
    public class ViewVehicleMake
    {
        public Guid VehicleMakeId { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleMakeAbrv { get; set; }

        public ICollection<ViewVehicleModel> VehicleModel;
    }
}
