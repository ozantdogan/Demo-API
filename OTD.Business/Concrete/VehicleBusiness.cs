using OTD.Core.DTOs;
using OTD.Core.Entities;
using OTD.Core.Models;
using OTD.Repository.Abstract;

namespace OTD.Business.Concrete
{
    public class VehicleBusiness
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleBusiness(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public ResponseViewModel Add(VehicleDto dto)
        {
            var response = new ResponseViewModel();

            var vehicle = new Vehicle()
            {
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                Horsepower = dto.Horsepower
            };

            _vehicleRepository.Add(vehicle);
            var success = _vehicleRepository.SaveChanges();

            response.Success = success;
            response.Data = vehicle;
            response.Message = "Done";

            return response;
        }

        public ResponseViewModel Update(VehicleDto dto)
        {
            var response = new ResponseViewModel();

            var vehicle = _vehicleRepository.Get(x => x.VehicleId == dto.VehicleId && x.DeleteFlag == false);

            if (vehicle == null)
            {
                response.Message = "Cannot access the vehicle.";
                response.Success = false;
            }

            vehicle.Manufacturer = dto.Manufacturer;
            vehicle.Model = dto.Model;
            vehicle.Year = dto.Year;
            vehicle.Color = dto.Color;
            vehicle.Horsepower = dto.Horsepower;

            _vehicleRepository.Update(vehicle);
            var success = _vehicleRepository.SaveChanges();

            response.Success = success;
            response.Message = "Vehicle has been changed";
            response.Data = vehicle;

            return response;
        }

        public ResponseViewModel Delete(VehicleDto dto)
        {
            var response = new ResponseViewModel();

            var vehicle = _vehicleRepository.Get(x => x.VehicleId == dto.VehicleId && x.DeleteFlag == false);

            if (vehicle == null)
            {
                response.Message = "Cannot access the vehicle.";
                response.Success = false;
            }

            vehicle.DeleteFlag = true;
            _vehicleRepository.Update(vehicle);
            var success = _vehicleRepository.SaveChanges();

            response.Success = success;
            response.Message = "Vehicle has been deleted.";
            response.Data = vehicle;

            return response;
        }

        public ResponseViewModel Get(Guid vehicleId)
        {
            var response = new ResponseViewModel();

            var vehicle = _vehicleRepository.Get(x => x.VehicleId == vehicleId && x.DeleteFlag == false);

            if (vehicle == null)
            {
                response.Message = "Cannot access the vehicle.";
                response.Success = false;

                return response;
            }
            response.Message = "Vehicle has been summoned";
            response.Data = vehicle;

            return response;
        }

        public ResponseViewModel List()
        {
            var response = new ResponseViewModel();

            var vehicles = _vehicleRepository.GetList(x => x.DeleteFlag == false);

            if (vehicles == null)
            {
                response.Message = "Cannot access the vehicle.";
                response.Success = false;

                return response;
            }

            response.Message = "Vehicle has been summoned";
            response.Data = vehicles;

            return response;
        }

    }
}
