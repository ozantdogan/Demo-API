using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTD.Business.Concrete;
using OTD.Core.DTOs;
using OTD.Core.Models;
using OTD.Repository.Abstract;

namespace OTD.UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleBusiness _vehicleBusiness;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleBusiness = new VehicleBusiness(vehicleRepository);
        }

        [HttpGet("List")]
        [Authorize]
        public async Task<ActionResult<ResponseViewModel>> List()
        {
            var response = await _vehicleBusiness.List();
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("Get")]
        [Authorize]
        public async Task<ActionResult<ResponseViewModel>> GetHero(Guid id)
        {
            var response = await _vehicleBusiness.Get(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseViewModel>> AddHero(VehicleDto dto)
        {
            var response = await _vehicleBusiness.Add(dto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ResponseViewModel>> UpdateHero(VehicleDto dto)
        {
            var response = await _vehicleBusiness.Update(dto);
            if(!response.Success)
                return BadRequest(response);
            
            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseViewModel>> DeleteHero(VehicleDto dto)
        {
            var response = await _vehicleBusiness.Delete(dto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
