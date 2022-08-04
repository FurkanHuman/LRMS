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

        [HttpPost("GetAllByName")]
        public IActionResult GetAllByName(string name)
        {
            var result = _editionService.GetAllByName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetByCommunicationId")]
        public IActionResult GetByCommunicationId(Guid id)
        {
            var result = _editionService.GetByCommunicationId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByCommunicationName")]
        public IActionResult GetAllByCommunicationName(string name)
        {
            var result = _editionService.GetAllByCommunicationName(name);
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

        [HttpPost("GetAllByAddressName")]
        public IActionResult GetAllByAddressName(string name)
        {
            var result = _editionService.GetAllByAddressName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByAddressLine")]
        public IActionResult GetAllByAddressLine(string line)
        {
            var result = _editionService.GetAllByAddressLine(line);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionNumber")]
        public IActionResult GetAllByEditionNumbers(int number)
        {
            var result = _editionService.GetAllByEditionNumber(number);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInCountryId")]
        public IActionResult GetAllByEditionCountryId(int id)
        {
            var result = _editionService.GetAllByEditionInCountryId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInCountryName")]
        public IActionResult GetAllByEditionCountryName(string name)
        {
            var result = _editionService.GetAllByEditionInCountryName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInCountryCode")]
        public IActionResult GetAllByEditionCountryCode(string code)
        {
            var result = _editionService.GetAllByEditionInCountryCode(code);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInCityId")]
        public IActionResult GetAllByEditionCityId(int id)
        {
            var result = _editionService.GetAllByEditionInCityId(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInCityName")]
        public IActionResult GetAllByEditionCityName(string name)
        {
            var result = _editionService.GetAllByEditionInCityName(name);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInPostalCode")]
        public IActionResult GetAllByEditionPostalCode(string postalCode)
        {
            var result = _editionService.GetAllByEditionInPostalCode(postalCode);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByEditionInGeoLocation")]
        public IActionResult GetAllByEditionGeoLocation(string geoLocation)
        {
            var result = _editionService.GetAllByEditionInGeoLocation(geoLocation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDateOfPublication")]
        public IActionResult GetAllByDateOfPublication(DateTime dateOfPublication)
        {
            var result = _editionService.GetAllByDateOfPublication(dateOfPublication);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByDateOfPublicationMinMax")]
        public IActionResult GetAllByDateOfPublicationMinMax(DateTime min, DateTime max)
        {
            var result = _editionService.GetAllByDateOfPublicationMinMax(min, max);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByFilter")]
        public IActionResult GetAllByFilter(Expression<Func<Edition, bool>>? filter = null)
        {
            var result = _editionService.GetAllByFilter(filter);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("GetAllByIsDeleted")]
        public IActionResult GetAllBySecret()
        {
            var result = _editionService.GetAllByIsDeleted();
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
