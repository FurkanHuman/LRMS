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

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _libraryService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressId")]
        public IActionResult GetByAddressId(Guid id)
        {
            var result = _libraryService.GetByAddressId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressNames")]
        public IActionResult GetByAddressNames(string name)
        {
            var result = _libraryService.GetByAddressNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressLines")]
        public IActionResult GetByAddressLines(string line)
        {
            var result = _libraryService.GetByAddressLines(line);
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

        [HttpPost("GetByCommunicationNames")]
        public IActionResult GetByCommunicationNames(string name)
        {
            var result = _libraryService.GetByCommunicationNames(name);
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

        [HttpPost("GetByLibraryTypes")]
        public IActionResult GetByLibraryTypes(byte libraryType)
        {
            var result = _libraryService.GetByLibraryTypes(libraryType);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInCountryId")]
        public IActionResult GetByLibraryInCountryId(int id)
        {
            var result = _libraryService.GetByLibraryInCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInCountryNames")]
        public IActionResult GetByLibraryInCountryNames(string name)
        {
            var result = _libraryService.GetByLibraryInCountryNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInCountryCode")]
        public IActionResult GetByLibraryInCountryCode(string code)
        {
            var result = _libraryService.GetByLibraryInCountryCode(code);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInCityId")]
        public IActionResult GetByLibraryInCityId(int id)
        {
            var result = _libraryService.GetByLibraryInCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInCityNames")]
        public IActionResult GetByLibraryInCityNames(string name)
        {
            var result = _libraryService.GetByLibraryInCityNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInPostalCode")]
        public IActionResult GetByLibraryInPostalCode(string postalCode)
        {
            var result = _libraryService.GetByLibraryInPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByLibraryInGeoLocation")]
        public IActionResult GetByLibraryInGeoLocation(string geoLocation)
        {
            var result = _libraryService.GetByLibraryInGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByFilterLists")]
        public IActionResult GetByFilterLists(Expression<Func<Library, bool>>? filter = null)
        {
            var result = _libraryService.GetByFilterLists(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllByLibraryTypes")]
        public IActionResult GetAllByLibraryTypes()
        {
            var result = _libraryService.GetAllEnumToDictionaryLibraryTypes();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _libraryService.GetAllBySecrets();
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
