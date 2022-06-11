using Business.Abstract;
using Entities.Concrete.Infos;
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
        public IActionResult Add(string cityName)
        {
            City city = new() { CityName = cityName };
            var result = _cityService.Add(city);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _cityService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(int id)
        {
            var result = _cityService.ShadowDelete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(int id, string cityName)
        {
            City city = new() { Id = id, CityName = cityName };
            var result = _cityService.Update(city);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _cityService.GetByNames(name);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetByFilterLists")]
        public IActionResult GetByFilterLists(Expression<Func<City, bool>>? filter = null)
        {
            var result = _cityService.GetByFilterLists(filter);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _cityService.GetAllBySecrets();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _cityService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
