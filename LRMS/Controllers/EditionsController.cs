using Business.Abstract;
using Entities.Concrete.Infos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LRMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditionsController : ControllerBase
    {
        private readonly IEditionService _editionService;

        public EditionsController(IEditionService editionService)
        {
            _editionService = editionService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Edition edition)
        {
            var result = _editionService.Add(edition);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Guid id)
        {
            var result = _editionService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("ShadowDelete")]
        public IActionResult ShadowDelete(Guid id)
        {
            var result = _editionService.ShadowDelete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Edition edition)
        {
            var result = _editionService.Update(edition);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetById")]
        public IActionResult GetById(Guid id)
        {
            var result = _editionService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByNames")]
        public IActionResult GetByNames(string name)
        {
            var result = _editionService.GetByNames(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationId")]
        public IActionResult GetByCommunicationId(Guid id)
        {
            var result = _editionService.GetByCommunicationId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationName")]
        public IActionResult GetByCommunicationName(string name)
        {
            var result = _editionService.GetByCommunicationName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationPhone")]
        public IActionResult GetByCommunicationPhone(string phone)
        {
            var result = _editionService.GetByCommunicationPhone(phone);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationFaxNumber")]
        public IActionResult GetByCommunicationFaxNumber(string faxNumber)
        {
            var result = _editionService.GetByCommunicationFaxNumber(faxNumber);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationEmail")]
        public IActionResult GetByCommunicationEmail(string email)
        {
            var result = _editionService.GetByCommunicationEmail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationWebSite")]
        public IActionResult GetByCommunicationWebSite(string webSite)
        {
            var result = _editionService.GetByCommunicationWebSite(webSite);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAdderssId")]
        public IActionResult GetByAddressId(Guid id)
        {
            var result = _editionService.GetByAdderssId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressName")]
        public IActionResult GetByAddressName(string name)
        {
            var result = _editionService.GetByAddressName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByAddressLines")]
        public IActionResult GetByAddressLine(string line)
        {
            var result = _editionService.GetByAddressLines(line);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionNumbers")]
        public IActionResult GetByEditionNumbers(int number)
        {
            var result = _editionService.GetByEditionNumbers(number);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInCountryId")]
        public IActionResult GetByEditionCountryId(int id)
        {
            var result = _editionService.GetByEditionInCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInCountryName")]
        public IActionResult GetByEditionCountryName(string name)
        {
            var result = _editionService.GetByEditionInCountryName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInCountryCode")]
        public IActionResult GetByEditionCountryCode(string code)
        {
            var result = _editionService.GetByEditionInCountryCode(code);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInCityId")]
        public IActionResult GetByEditionCityId(int id)
        {
            var result = _editionService.GetByEditionInCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInCityName")]
        public IActionResult GetByEditionCityName(string name)
        {
            var result = _editionService.GetByEditionInCityName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInPostalCode")]
        public IActionResult GetByEditionPostalCode(string postalCode)
        {
            var result = _editionService.GetByEditionInPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByEditionInGeoLocation")]
        public IActionResult GetByEditionGeoLocation(string geoLocation)
        {
            var result = _editionService.GetByEditionInGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDateOfPublication")]
        public IActionResult GetByDateOfPublication(DateTime dateOfPublication)
        {
            var result = _editionService.GetByDateOfPublication(dateOfPublication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByDateOfPublicationMinMax")]
        public IActionResult GetByDateOfPublicationMinMax(DateTime min, DateTime max)
        {
            var result = _editionService.GetByDateOfPublicationMinMax(min, max);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetByFilterLists(Expression<Func<Edition, bool>>? filter = null)
        {
            var result = _editionService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllBySecrets")]
        public IActionResult GetAllBySecrets()
        {
            var result = _editionService.GetAllBySecrets();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            var result = _editionService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
