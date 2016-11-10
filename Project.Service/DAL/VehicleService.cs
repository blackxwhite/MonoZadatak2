using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project.Service.ViewModels;
using Project.Service.Models;
using PagedList;
using Project.Service.Interface;

namespace Project.Service.DAL
{
    public class VehicleService : VehicleInterface
    {
        private static VehicleService VehicleServices;
        private readonly VehicleContext Db;
        IPagedList VehiclesList;
        int pageSize = 3;

        private VehicleService()
        {
            Db = new VehicleContext();
        }

        public static VehicleService GetInstance
        {
            get
            {
                if(VehicleServices == null)
                {
                    VehicleServices = new VehicleService();
                }
                return VehicleServices;
            }
        }

        public void CreateVehicleMake(ViewVehicleMake vehicleMake)
        {
            Db.VehicleMakes.Add(Mapper.Map<VehicleMake>(vehicleMake));
            Db.SaveChanges();
        }

        public void CreateVehicleModel(ViewVehicleModel vehicleModel)
        {
            Db.VehicleModels.Add(Mapper.Map<VehicleModel>(vehicleModel));
            Db.SaveChanges();
        }

        public ViewVehicleMake FindVehicleMake(Guid? id)
        {
            return Mapper.Map<VehicleMake, ViewVehicleMake>(Db.VehicleMakes.Find(id));
        }

        public ViewVehicleModel FindVehicleModel(Guid? id)
        {
            return Mapper.Map<VehicleModel, ViewVehicleModel>(Db.VehicleModels.Find(id));
        }

        public void EditVehicleMake(ViewVehicleMake viewVehicleMake)
        {
            VehicleMake vehicleMakes = Db.VehicleMakes.Find(viewVehicleMake.VehicleMakeId);
            Mapper.Map(viewVehicleMake, vehicleMakes);
            Db.SaveChanges();
        }

        public void EditVehicleModel(ViewVehicleModel viewVehicleModel)
        {
            VehicleModel vehicleModels = Db.VehicleModels.Find(viewVehicleModel.VehicleModelId);
            Mapper.Map(viewVehicleModel, vehicleModels);
            Db.SaveChanges();
        }

        public void DeleteVehicleMake(Guid? id)
        {
            VehicleMake vehicleMakes = Db.VehicleMakes.Find(id);
            Db.VehicleMakes.Remove(vehicleMakes);
            Db.SaveChanges();
        }

        public void DeleteVehicleModel(Guid? id)
        {
            VehicleModel vehicleModels = Db.VehicleModels.Find(id);
            Db.VehicleModels.Remove(vehicleModels);
            Db.SaveChanges();
        }

        public IPagedList SearchSortVehicleMake(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = (page ?? 1);
            var vehicles = Db.VehicleMakes.AsQueryable();

            if(searchString != null)
            {
                page = 1;
                vehicles = Db.VehicleMakes.Where(x => x.VehicleMakeName.Contains(searchString));
            }
            else
            {
                searchString = currentFilter;
                vehicles = Db.VehicleMakes.AsQueryable();

            }
            switch (sortOrder)
            {
                case "Name":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleMake>>(vehicles.OrderBy(x => x.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Name_desc":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleMake>>(vehicles.OrderByDescending(x => x.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv:":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleMake>>(vehicles.OrderBy(x => x.VehicleMakeAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv_desc:":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleMake>>(vehicles.OrderByDescending(x => x.VehicleMakeAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                default:
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleMake>>(vehicles.OrderBy(x => x.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
            }
            return VehiclesList;
        }

        public IPagedList SearchSortVehicleModel(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = (page ?? 1);
            var vehicles = Db.VehicleModels.AsQueryable();
            
            if(searchString != null)
            {
                page = 1;
                vehicles = Db.VehicleModels.Where(x => x.VehicleMake.VehicleMakeName.Contains(searchString) || x.VehicleModelName.Contains(searchString));
            }
            else
            {
                searchString = currentFilter;
                vehicles = Db.VehicleModels.AsQueryable();
            }

            switch(sortOrder)
            {
                case "Name":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderBy(x => x.VehicleMake.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Name_desc":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderByDescending(x => x.VehicleMake.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Model":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderBy(x => x.VehicleModelName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Model_desc":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderByDescending(x => x.VehicleModelName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderBy(x => x.VehicleModelAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv_desc":
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderByDescending(x => x.VehicleModelAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                default:
                    VehiclesList = Mapper.Map<IEnumerable<ViewVehicleModel>>(vehicles.OrderBy(x => x.VehicleModelName)).ToPagedList(pageNumber, pageSize);
                    break;
            }
            return VehiclesList;
        }

        public static void ConfigMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleModel, ViewVehicleModel>().ReverseMap();
                cfg.CreateMap<VehicleMake, ViewVehicleMake>().ReverseMap();
            });
        }

        public List<VehicleMake> getAll()
        {
            return Db.VehicleMakes.ToList();
        }
    }
}
