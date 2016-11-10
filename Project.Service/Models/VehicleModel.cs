using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Models
{
    public class VehicleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelAbrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
