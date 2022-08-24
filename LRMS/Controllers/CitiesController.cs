using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("Add")]
        public IActionResult Add(City city)
        {
            var result = _cityService.Add(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoAdd")]
        public IActionResult DtoAdd(CityAddDto cityAdd)
        {
            var result = _cityService.DtoAdd(cityAdd);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _cityService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(int id)
        {
            var result = _cityService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(City city)
        {
            var result = _cityService.Update(city);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoUpdate")]
        public IActionResult DtoUpdate(CityUpdateDto updateDto)
        {
            var result = _cityService.DtoUpdate(updateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _cityService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetById")]
        public IActionResult DtoGetById(int id)
        {
            var result = _cityService.DtoGetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _cityService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByName")]
        public IActionResult DtoGetAllByName(string name)
        {
            var result = _cityService.DtoGetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<City, bool>>? filter = null)
        {
            var result = _cityService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByFilter")]
        public IActionResult DtoGetAllByFilter(Expression<Func<City, bool>>? filter = null)
        {
            var result = _cityService.DtoGetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _cityService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllBySecret")]
        public IActionResult DtoGetAllBySecret()
        {
            var result = _cityService.DtoGetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAll")]
        public IActionResult DtoGetAll()
        {
            var result = _cityService.DtoGetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
