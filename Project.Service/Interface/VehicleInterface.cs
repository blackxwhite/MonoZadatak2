using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.ViewModels;
using PagedList;
using Project.Service.Models;

namespace Project.Service.Interface
{
    public interface VehicleInterface
    {
        void CreateVehicleMake(ViewVehicleMake VehicleMake);
        void CreateVehicleModel(ViewVehicleModel VehicleModel);
        ViewVehicleMake FindVehicleMake(Guid? id);
        ViewVehicleModel FindVehicleModel(Guid? id);
        void EditVehicleMake(ViewVehicleMake VehicleMake);
        void EditVehicleModel(ViewVehicleModel VehicleModel);
        void DeleteVehicleMake(Guid? id);
        void DeleteVehicleModel(Guid? id);
        IPagedList SearchSortVehicleMake(string sortOrder, string currentFilter, string searchString, int? page);
        IPagedList SearchSortVehicleModel(string sortOrder, string currentFilter, string searchString, int? page);
        List<VehicleMake> getAll();
    }
}
