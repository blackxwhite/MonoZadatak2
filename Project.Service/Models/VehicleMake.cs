using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
    public class VehicleMake
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid VehicleMakeId { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleMakeAbrv { get; set; }

        public ICollection<VehicleModel> VehicleModel;
    }
}
