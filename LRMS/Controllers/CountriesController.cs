using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Country country)
        {
            var result = _countryService.Add(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoAdd")]
        public IActionResult DtoAdd(CountryAddDto addDto)
        {
            var result = _countryService.DtoAdd(addDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            var result = _countryService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(int id)
        {
            var result = _countryService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Country country)
        {
            var result = _countryService.Update(country);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoUpdate")]
        public IActionResult DtoUpdate(CountryUpdateDto updateDto)
        {
            var result = _countryService.DtoUpdate(updateDto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _countryService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetById")]
        public IActionResult DtoGetById(int id)
        {
            var result = _countryService.DtoGetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _countryService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByName")]
        public IActionResult DtoGetAllByName(string name)
        {
            var result = _countryService.DtoGetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCountryCode")]
        public IActionResult GetAllByCountryCodes(string countryCode)
        {
            var result = _countryService.GetAllByCountryCode(countryCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByCountryCode")]
        public IActionResult DtoGetAllByCountryCodes(string countryCode)
        {
            var result = _countryService.GetAllByCountryCode(countryCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Country, bool>>? filter = null)
        {
            var result = _countryService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("DtoGetAllByFilter")]
        public IActionResult DtoGetAllByFilter(Expression<Func<Country, bool>>? filter = null)
        {
            var result = _countryService.DtoGetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _countryService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAllByIsDeleted")]
        public IActionResult DtoGetAllBySecret()
        {
            var result = _countryService.DtoGetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _countryService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("DtoGetAll")]
        public IActionResult DtoGetAll()
        {
            var result = _countryService.DtoGetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
