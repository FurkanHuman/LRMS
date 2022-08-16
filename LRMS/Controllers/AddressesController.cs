using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Address address)
        {
            var result = _addressService.Add(address);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _addressService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _addressService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Address address)
        {
            var result = _addressService.Update(address);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _addressService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetByName(string name)
        {
            var result = _addressService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByPostalCode")]
        public IActionResult GetAllByPostalCode(string postalCode)
        {
            var result = _addressService.GetAllByPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCityId")]
        public IActionResult GetAllByCityId(int cityId)
        {
            var result = _addressService.GetAllByCityId(cityId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByGeoLocation")]
        public IActionResult GetAllByGeoLocation(string geoLocation)
        {
            var result = _addressService.GetAllByGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySearchString")]
        public IActionResult GetAllBySearchString(string searchString)
        {
            var result = _addressService.GetAllBySearchString(searchString);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Address, bool>>? filter = null)
        {
            var result = _addressService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _addressService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _addressService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAll")]
        public IActionResult DtoGetAll()
        {
            var result = _addressService.GetAlladdressDtos();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
