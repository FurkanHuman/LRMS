
using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Library entity)
        {
            var result = _libraryService.Add(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _libraryService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _libraryService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Library entity)
        {
            var result = _libraryService.Update(entity);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _libraryService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _libraryService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressId")]
        public IActionResult GetByAddressId(Guid id)
        {
            var result = _libraryService.GetByAddressId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByAddressName")]
        public IActionResult GetAllByAddressName(string name)
        {
            var result = _libraryService.GetAllByAddressName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByAddressLine")]
        public IActionResult GetByAddressLine(string line)
        {
            var result = _libraryService.GetAllByAddressLine(line);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationId")]
        public IActionResult GetByCommunicationId(Guid id)
        {
            var result = _libraryService.GetByCommunicationId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationEmail")]
        public IActionResult GetByCommunicationEmail(string email)
        {
            var result = _libraryService.GetByCommunicationEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCommunicationName")]
        public IActionResult GetAllByCommunicationName(string name)
        {
            var result = _libraryService.GetAllByCommunicationName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationFaxNumber")]
        public IActionResult GetByCommunicationFaxNumber(string faxNumber)
        {
            var result = _libraryService.GetByCommunicationFaxNumber(faxNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationPhone")]
        public IActionResult GetByCommunicationPhone(string phone)
        {
            var result = _libraryService.GetByCommunicationPhone(phone);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationWebSite")]
        public IActionResult GetByCommunicationWebSite(string webSite)
        {
            var result = _libraryService.GetByCommunicationWebSite(webSite);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryType")]
        public IActionResult GetAllByLibraryType(byte libraryType)
        {
            var result = _libraryService.GetAllByLibraryType(libraryType);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInCountryId")]
        public IActionResult GetAllByLibraryInCountryId(int id)
        {
            var result = _libraryService.GetAllByLibraryInCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInCountryName")]
        public IActionResult GetAllByLibraryInCountryName(string name)
        {
            var result = _libraryService.GetAllByLibraryInCountryName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInCountryCode")]
        public IActionResult GetAllByLibraryInCountryCode(string code)
        {
            var result = _libraryService.GetAllByLibraryInCountryCode(code);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInCityId")]
        public IActionResult GetAllByLibraryInCityId(int id)
        {
            var result = _libraryService.GetAllByLibraryInCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInCityName")]
        public IActionResult GetAllByLibraryInCityName(string name)
        {
            var result = _libraryService.GetAllByLibraryInCityName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInPostalCode")]
        public IActionResult GetAllByLibraryInPostalCode(string postalCode)
        {
            var result = _libraryService.GetAllByLibraryInPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByLibraryInGeoLocation")]
        public IActionResult GetAllByLibraryInGeoLocation(string geoLocation)
        {
            var result = _libraryService.GetAllByLibraryInGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Library, bool>>? filter = null)
        {
            var result = _libraryService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByLibraryType")]
        public IActionResult GetAllByLibraryType()
        {
            var result = _libraryService.GetAllEnumToDictionaryLibraryType();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _libraryService.GetAllByIsDeleted();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _libraryService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
