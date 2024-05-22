using OTD.Core.DTOs;
using OTD.Core.Entities;
using OTD.Core.Models;
using OTD.Repository.Abstract;
using OTD.Business.Abstract;
using OTD.Business.Helper;

namespace OTD.Business.Concrete
{
    public class VehicleBusiness : BaseBusiness
    {
        private readonly IVehicleRepository _repository;

        public VehicleBusiness(IVehicleRepository vehicleRepository)
        {
            _repository = vehicleRepository;
        }

        public ResponseViewModel Add(VehicleDto dto)
        {
            var vehicle = new Vehicle()
            {
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                Year = dto.Year,
                Color = dto.Color,
                Horsepower = dto.Horsepower
            };

            _repository.Add(vehicle);
            var success = _repository.SaveChanges();
            if(success == false)
                return GenerateResponse<ResponseViewModel>(success, ResponseCode.CreatedFailure, null);

            return GenerateResponse(success, ResponseCode.CreatedSuccess, dto);
        }

        public ResponseViewModel Update(VehicleDto dto)
        {
            var vehicle = _repository.Get(x => x.VehicleId == dto.VehicleId && x.DeleteFlag == false);

            if (vehicle == null)
                return GenerateResponse<ResponseViewModel>(false, ResponseCode.NotFound, null);

            vehicle.Manufacturer = dto.Manufacturer;
            vehicle.Model = dto.Model;
            vehicle.Year = dto.Year;
            vehicle.Color = dto.Color;
            vehicle.Horsepower = dto.Horsepower;
            vehicle.ModifiedOn = DateTime.Now;

            _repository.Update(vehicle);
            var success = _repository.SaveChanges();
            if (success == false)
                return GenerateResponse<ResponseViewModel>(success, ResponseCode.CreatedFailure, null);

            return GenerateResponse(success, ResponseCode.UpdatedSuccess, dto);
        }

        public ResponseViewModel Delete(VehicleDto dto)
        {
            var vehicle = _repository.Get(x => x.VehicleId == dto.VehicleId && x.DeleteFlag == false);

            if (vehicle == null)
                return GenerateResponse(false, ResponseCode.NotFound, dto);

            vehicle.DeleteFlag = true;

            _repository.Update(vehicle);
            var success = _repository.SaveChanges();
            if (success == false)
                return GenerateResponse<ResponseViewModel>(success, ResponseCode.DeletedFailure, null);

            return GenerateResponse(success, ResponseCode.DeletedSuccess, dto);
        }

        public ResponseViewModel Get(Guid vehicleId)
        {
            var vehicle = _repository.Get(x => x.VehicleId == vehicleId && x.DeleteFlag == false);

            if (vehicle == null)
                return GenerateResponse<ResponseViewModel>(false, ResponseCode.NotFound, null);

            return GenerateResponse(true, ResponseCode.Success, vehicle);
        }

        public ResponseViewModel List()
        {
            var response = new ResponseViewModel();

            var vehicles = _repository.GetList(x => x.DeleteFlag == false);

            if (vehicles == null)
                return GenerateResponse<ResponseViewModel>(false, ResponseCode.NotFound, null);

            return GenerateResponse(true, ResponseCode.Success, vehicles);
        }
    }
}
